// <copyright file="ActionConstraints.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>

namespace Testing.Specificity2
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Provides extension methods for specifications on <see cref="Action"/> delegates.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class ActionConstraints
    {
        /// <summary>
        /// Verifies the constrained <see cref="Action"/> throws an exception of the specified type.
        /// </summary>
        /// <param name="self">The constrained action.</param>
        /// <param name="message">The message to display in case of failure.</param>
        /// <param name="parameters">The parameters used to format the <paramref name="message"/>.</param>
        /// <exception cref="Exception">The constraint failed. The exact type of exception thrown will
        /// depend on the unit test framework, if any, in use.</exception>
        public static void HaveThrown(this IConstraint<Action> self, string message = null, params object[] parameters)
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.HaveThrown(typeof(Exception), message, parameters);
        }

        /// <summary>
        /// Verifies the constrained <see cref="Action"/> throws an exception of the specified type.
        /// </summary>
        /// <param name="self">The constrained action.</param>
        /// <param name="exceptionType">Type of the exception that should be thrown.</param>
        /// <param name="message">The message to display in case of failure.</param>
        /// <param name="parameters">The parameters used to format the <paramref name="message"/>.</param>
        /// <exception cref="Exception">The constraint failed. The exact type of exception thrown will
        /// depend on the unit test framework, if any, in use.</exception>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "The point is to report exception failures.")]
        public static void HaveThrown(this IConstraint<Action> self, Type exceptionType, string message = null, params object[] parameters)
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            exceptionType = exceptionType ?? typeof(Exception);
            Action action = self.Value;
            try
            {
                action();
            }
            catch (Exception e)
            {
                Type actualType = e.GetType();
                Type expectedType = exceptionType;
                if (!expectedType.IsAssignableFrom(actualType))
                {
                    self.FailIfNotNegated(
                        self.FormatErrorMessage(
                            "HaveThrown",
                            Messages.UnexpectedExceptionType(expectedType, actualType),
                            message,
                            parameters));
                }
                else
                {
                    self.FailIfNegated(
                        self.FormatErrorMessage(
                            "HaveThrown",
                            Messages.UnexpectedException(actualType),
                            message,
                            parameters));
                }

                return;
            }

            self.FailIfNotNegated(
                self.FormatErrorMessage(
                    "HaveThrown",
                    Messages.NoExceptionThrown(exceptionType),
                    message,
                    parameters));
        }
    }
}