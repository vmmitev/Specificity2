//-----------------------------------------------------------------------------
// <copyright file="Specify.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Testing.Specificity
{
    using System;
    using System.Globalization;
    using System.Text;
    using Testing.Specificity.Properties;

    /// <summary>
    /// Static class used to start specifying assertions on a value.
    /// </summary>
    public static class Specify
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

        internal static string Format(string format, params object[] parameters)
        {
            for (int i = 0; i < parameters.Length; ++i)
            {
                if (parameters[i] == null)
                {
                    parameters[i] = Messages.NullValue;
                }
            }

            return string.Format(CultureInfo.CurrentUICulture, format, parameters);
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
                    message = Format(message, messageParameters);
                }
            }

            if (!string.IsNullOrEmpty(reason))
            {
                message = reason + " " + message;
            }

            throw new ConstraintFailedException(constraint, message);
        }
    }
}
