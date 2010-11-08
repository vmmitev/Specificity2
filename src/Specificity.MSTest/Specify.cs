//-----------------------------------------------------------------------------
// <copyright file="Specify.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Testing.Specificity
{
    using System;
    using System.Globalization;

    /// <summary>
    /// Static class used to declare fluent test constraints.
    /// </summary>
    public partial class Specify
    {
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
            ConstraintResult.Failure(Properties.Resources.SpecificationFailure);
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

            ConstraintResult.Failure(message);
        }

        /// <summary>
        /// Indicates that a specification can not be verified.
        /// </summary>
        /// <exception cref="Exception">Always thrown. The exact type of this exception is dependent on what
        /// testing framework is used.</exception>
        public static void Inconclusive()
        {
            ConstraintResult.Inconclusive(Properties.Resources.SpecificationInconclusive);
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

            ConstraintResult.Inconclusive(message);
        }
    }
}
