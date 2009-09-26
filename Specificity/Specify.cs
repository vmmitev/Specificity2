//-----------------------------------------------------------------------------
// <copyright file="Specify.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Testing.Specificity
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Threading;

    /// <summary>
    /// Static class used to start specifying assertions on a value.
    /// </summary>
    public static class Specify
    {
        /// <summary>
        /// The synchronization root object.
        /// </summary>
        private static object syncRoot = new object();

        /// <summary>
        /// The specification result reporting service.
        /// </summary>
        private static volatile IReportSpecificationResults reporter;

        /// <summary>
        /// Gets the specification result reporting service.
        /// </summary>
        /// <value>The specification result reporting service.</value>
        private static IReportSpecificationResults SpecificationResultReporter
        {
            get
            {
                if (reporter == null)
                {
                    lock (syncRoot)
                    {
                        if (reporter == null)
                        {
                            var defaultServiceType = typeof(DefaultReportSpecificationResults);
                            var serviceType = (from a in AppDomain.CurrentDomain.GetAssemblies()
                                               from t in a.GetTypes()
                                               where typeof(IReportSpecificationResults).IsAssignableFrom(t) &&
                                                     t != defaultServiceType &&
                                                     t != typeof(IReportSpecificationResults)
                                               select t).FirstOrDefault() ?? defaultServiceType;
                            reporter = (IReportSpecificationResults)Activator.CreateInstance(serviceType);
                        }
                    }
                }

                return reporter;
            }
        }

        /// <summary>
        /// Sets the service to be used when reporting specification results.
        /// </summary>
        /// <param name="service">The reporting service.</param>
        public static void SetReportingService(IReportSpecificationResults service)
        {
            lock (syncRoot)
            {
                reporter = service;
            }
        }

        /// <summary>
        /// Starts an assertion chain in a fluent API.
        /// </summary>
        /// <typeparam name="T">The value type.</typeparam>
        /// <param name="value">The value to make assertions on.</param>
        /// <returns>
        /// An <see cref="ConstrainedValue{T}"/> instance which wraps the <paramref name="value"/>.
        /// </returns>
        public static ConstrainedValue<T> That<T>(T value)
        {
            return new ConstrainedValue<T>(value);
        }

        /// <summary>
        /// Starts an assertion chain on an <see cref="Action"/> in a fluent API.
        /// </summary>
        /// <param name="action">The action to make assertions on.</param>
        /// <returns>
        /// An <see cref="ConstrainedValue{T}"/> instance which wraps the <paramref name="action"/>.
        /// </returns>
        public static ConstrainedValue<Action> ThatAction(Action action)
        {
            return new ConstrainedValue<Action>(action);
        }

        /// <summary>
        /// Fails the specification without checking any constraints.
        /// </summary>
        /// <exception cref="Exception">Always thrown. The exact type of this exception is dependent on what
        /// testing framework is used.</exception>
        public static void Failure()
        {
            Failure(Properties.Resources.SpecificationFailure);
        }

        /// <summary>
        /// Fails the specification without checking any constraints.
        /// </summary>
        /// <param name="message">The message to display.</param>
        /// <param name="parameters">The parameters used to format the message.</param>
        /// <exception cref="Exception">Always thrown. The exact type of this exception is dependent on what
        /// testing framework is used.</exception>
        public static void Failure(string message, params object[] parameters)
        {
            if (parameters != null && parameters.Length > 0)
            {
                message = string.Format(CultureInfo.CurrentCulture, message, parameters);
            }

            SpecificationResultReporter.Failure(message);
        }

        /// <summary>
        /// Indicates that a specification can not be verified.
        /// </summary>
        /// <exception cref="Exception">Always thrown. The exact type of this exception is dependent on what
        /// testing framework is used.</exception>
        public static void Inconclusive()
        {
            Inconclusive(Properties.Resources.SpecificationInconclusive);
        }

        /// <summary>
        /// Indicates that a specification can not be verified.
        /// </summary>
        /// <param name="message">The message to display.</param>
        /// <param name="parameters">The parameters used to format the message.</param>
        /// <exception cref="Exception">Always thrown. The exact type of this exception is dependent on what
        /// testing framework is used.</exception>
        public static void Inconclusive(string message, params object[] parameters)
        {
            if (parameters != null && parameters.Length > 0)
            {
                message = string.Format(CultureInfo.CurrentCulture, message, parameters);
            }

            SpecificationResultReporter.Inconclusive(message);
        }

        /// <summary>
        /// Throws a <see cref="ConstraintFailedException"/>.
        /// </summary>
        /// <param name="constraint">The constraint that failed.</param>
        /// <param name="message">The user message explaining why the constraint failed.</param>
        /// <param name="messageParameters">The message parameters.</param>
        internal static void Fail(string constraint, string message, object[] messageParameters)
        {
            Fail(constraint, null, message, messageParameters);
        }

        /// <summary>
        /// Throws a <see cref="ConstraintFailedException"/>.
        /// </summary>
        /// <param name="constraint">The constraint that failed.</param>
        /// <param name="reason">The reason the constraint failed.</param>
        /// <param name="message">The user message explaining why the constraint failed.</param>
        /// <param name="messageParameters">The message parameters.</param>
        internal static void Fail(string constraint, string reason, string message, object[] messageParameters)
        {
            if (!string.IsNullOrEmpty(message))
            {
                if (messageParameters != null && messageParameters.Length != 0)
                {
                    message = string.Format(CultureInfo.CurrentCulture, message, messageParameters);
                }
            }

            if (!string.IsNullOrEmpty(reason))
            {
                message = reason + " " + message;
            }

            message = string.Format(
                CultureInfo.CurrentCulture,
                Properties.Resources.ConstraintFailed,
                constraint,
                message);
            Failure(message);
        }
    }
}
