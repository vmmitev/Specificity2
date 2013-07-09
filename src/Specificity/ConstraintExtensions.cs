//-----------------------------------------------------------------------------
// <copyright file="ConstraintExtensions.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Testing.Specificity
{
    using System;
    using System.ComponentModel;
    using System.Globalization;

    /// <summary>
    /// Provides extension methods for <see cref="IConstraint{T}"/>.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class ConstraintExtensions
    {
        /// <summary>
        /// Fails the specified constraint if it's not negated.
        /// </summary>
        /// <typeparam name="T">The constraint value type.</typeparam>
        /// <param name="self">The constraint.</param>
        /// <param name="message">The message.</param>
        /// <param name="args">The arguments.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void FailIfNotNegated<T>(this IConstraint<T> self, string message, params object[] args)
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            if (!self.IsNegated)
            {
                Specify.Failure(string.Format(CultureInfo.CurrentCulture, message, args));
            }
        }

        /// <summary>
        /// Fails the specified constraint if it's negated.
        /// </summary>
        /// <typeparam name="T">The constraint value type.</typeparam>
        /// <param name="self">The constraint.</param>
        /// <param name="message">The message.</param>
        /// <param name="args">The arguments.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void FailIfNegated<T>(this IConstraint<T> self, string message, params object[] args)
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            if (self.IsNegated)
            {
                Specify.Failure(string.Format(CultureInfo.CurrentCulture, message, args));
            }
        }

        /// <summary>
        /// Formats the error message.
        /// </summary>
        /// <typeparam name="T">The constraint value type.</typeparam>
        /// <param name="self">The constraint.</param>
        /// <param name="constraint">The name of the constraint.</param>
        /// <param name="reason">The reason for the failure.</param>
        /// <param name="message">The user message.</param>
        /// <param name="messageParameters">The parameters used to format the user message.</param>
        /// <returns>The formatted error message.</returns>
        internal static string FormatErrorMessage<T>(this IConstraint<T> self, string constraint, string reason, string message, object[] messageParameters)
        {
            // Format the user message.
            if (!string.IsNullOrEmpty(message))
            {
                if (messageParameters != null && messageParameters.Length != 0)
                {
                    message = string.Format(CultureInfo.CurrentCulture, message, messageParameters);
                }
            }

            // Add the reason to the beginning.
            if (!string.IsNullOrEmpty(reason))
            {
                message = reason + " " + message;
            }

            constraint = (self.IsNegated ? "Should.Not." : "Should.") + constraint;

            return string.Format(CultureInfo.CurrentCulture, "{0} {1}", Messages.ConstraintFailed(constraint), message);
        }
    }
}