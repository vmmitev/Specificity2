//-----------------------------------------------------------------------------
// <copyright file="ConstraintExtensions.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Testing.Specificity
{
    using System.ComponentModel;
    using System.Globalization;
    using System;

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
        public static void Fail<T>(this IConstraint<T> self, string message, params object[] args)
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

        internal static void Fail<T>(this IConstraint<T> self, string constraint, string reason, string message, object[] messageParameters)
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            if (!self.IsNegated)
            {
                Specify.Failure(GetErrorMessage(constraint, reason, message, messageParameters));
            }
        }

        internal static void FailIfNegated<T>(this IConstraint<T> self, string constraint, string reason, string message, object[] messageParameters)
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            if (self.IsNegated)
            {
                Specify.Failure(GetErrorMessage(constraint, reason, message, messageParameters));
            }
        }

        private static string GetErrorMessage(string constraint, string reason, string message, object[] messageParameters)
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

            return message;
        }
    }
}
