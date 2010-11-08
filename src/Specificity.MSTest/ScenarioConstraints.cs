//-----------------------------------------------------------------------------
// <copyright file="ScenarioConstraints.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Testing.Specificity
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Provides extension methods for assertions on <see cref="Scenario"/> types.
    /// </summary>
    public static class ScenarioConstraints
    {
        /// <summary>
        /// Tests whether or not the <see cref="Scenario"/> threw an exception.
        /// </summary>
        /// <typeparam name="T">The type of the constrained scenario.</typeparam>
        /// <param name="self">The constrained scenario.</param>
        public static void HaveThrown<T>(this IConstraint<T> self)
            where T : Scenario
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.HaveThrown(typeof(Exception), null);
        }

        /// <summary>
        /// Tests whether or not the <see cref="Scenario"/> threw an exception.
        /// </summary>
        /// <typeparam name="T">The type of the constrained scenario.</typeparam>
        /// <param name="self">The constrained scenario.</param>
        /// <param name="message">The message to display in case of failure.</param>
        /// <param name="parameters">The parameters used to format the <paramref name="message"/>.</param>
        public static void HaveThrown<T>(this IConstraint<T> self, string message, params object[] parameters)
            where T : Scenario
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.HaveThrown(typeof(Exception), message, parameters);
        }

        /// <summary>
        /// Verifies the constrained <see cref="Scenario"/> threw an exception of the specified type.
        /// </summary>
        /// <typeparam name="T">The type of the constrained <see cref="Scenario"/>.</typeparam>
        /// <param name="self">The constrained action.</param>
        /// <param name="exceptionType">Type of the exception that should have been thrown.</param>
        /// <exception cref="ConstraintFailedException">The constraint failed. The exact type of exception thrown will
        /// depend on the unit test framework, if any, in use.</exception>
        public static void HaveThrown<T>(this IConstraint<T> self, Type exceptionType)
            where T : Scenario
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            if (exceptionType == null)
            {
                throw new ArgumentNullException("exceptionType");
            }

            self.HaveThrown(exceptionType, null);
        }

        /// <summary>
        /// Verifies the constrained <see cref="Scenario"/> threw an exception of the specified type.
        /// </summary>
        /// <typeparam name="T">The type of the constrained <see cref="Scenario"/>.</typeparam>
        /// <param name="self">The constrained <see cref="Scenario"/>.</param>
        /// <param name="exceptionType">Type of the exception that should have been thrown.</param>
        /// <param name="message">The message to display in case of failure.</param>
        /// <param name="parameters">The parameters used to format the <paramref name="message"/>.</param>
        /// <exception cref="ConstraintFailedException">The constraint failed. The exact type of exception thrown will
        /// depend on the unit test framework, if any, in use.</exception>
        [SuppressMessage("Microsoft.Design",
            "CA1031:DoNotCatchGeneralExceptionTypes",
            Justification = "The point is to report exception failures.")]
        public static void HaveThrown<T>(this IConstraint<T> self, Type exceptionType, string message, params object[] parameters)
            where T : Scenario
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            if (exceptionType == null)
            {
                throw new ArgumentNullException("exceptionType");
            }

            if (self.Value.Exception != null)
            {
                Type actualType = self.Value.Exception.GetType();
                Type expectedType = exceptionType;
                if (!expectedType.IsAssignableFrom(actualType))
                {
                    self.FailIfNotNegated("HaveThrown");
                    return;
                }
                else
                {
                    self.FailIfNegated("HaveThrown");
                    return;
                }
            }
            else
            {
                self.FailIfNotNegated("HaveThrown");
            }
        }
    }
}
