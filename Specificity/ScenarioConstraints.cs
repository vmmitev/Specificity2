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
    /// Provides extension methods for assertions on <see cref="ScenarioBase"/> types.
    /// </summary>
    public static class ScenarioConstraints
    {
        /// <summary>
        /// Tests whether or not the <see cref="Action"/> threw an exception.
        /// </summary>
        /// <param name="self">The action constraint.</param>
        public static void HaveThrown<T>(this IConstraint<T> self)
            where T : ScenarioBase
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.HaveThrown(typeof(Exception), null);
        }

        /// <summary>
        /// Tests whether or not the <see cref="Action"/> threw an exception.
        /// </summary>
        /// <param name="self">The action constraint.</param>
        /// <param name="message">The message to display in case of failure.</param>
        /// <param name="parameters">The parameters used to format the <paramref name="message"/>.</param>
        public static void HaveThrown<T>(this IConstraint<T> self, string message, params object[] parameters)
            where T : ScenarioBase
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.HaveThrown(typeof(Exception), message, parameters);
        }

        /// <summary>
        /// Tests whether or not the <see cref="Action"/> threw an exception of the specified type.
        /// </summary>
        /// <param name="self">The action constraint.</param>
        /// <param name="exceptionType">Type of the exception to test for.</param>
        public static void HaveThrown<T>(this IConstraint<T> self, Type exceptionType)
            where T : ScenarioBase
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
        /// Tests whether or not the <see cref="Action"/> threw an exception of the specified type.
        /// </summary>
        /// <param name="self">The action constraint.</param>
        /// <param name="exceptionType">Type of the exception to test for.</param>
        /// <param name="message">The message to display in case of failure.</param>
        /// <param name="parameters">The parameters used to format the <paramref name="message"/>.</param>
        [SuppressMessage("Microsoft.Design",
            "CA1031:DoNotCatchGeneralExceptionTypes",
            Justification = "The point is to report exception failures.")]
        public static void HaveThrown<T>(this IConstraint<T> self, Type exceptionType, string message, params object[] parameters)
            where T : ScenarioBase
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
                    self.FailIfNotNegated(
                        self.FormatErrorMessage(
                            "HaveThrown",
                            Messages.UnexpectedExceptionType(expectedType, actualType),
                            message,
                            parameters));
                    return;
                }
                else
                {
                    self.FailIfNegated(
                        self.FormatErrorMessage(
                            "HaveThrown",
                            Messages.UnexpectedException(actualType),
                            message,
                            parameters));
                    return;
                }
            }
            else
            {
                self.FailIfNotNegated(
                    self.FormatErrorMessage(
                        "HaveThrown",
                        Messages.NoExceptionThrown(exceptionType),
                        message,
                        parameters));
            }
        }

        /// <summary>
        /// Verifies the <see cref="ScenarioBase"/> throws an exception.
        /// </summary>
        /// <typeparam name="T">The constrained value type.</typeparam>
        /// <param name="self">The specification value.</param>
        /// <param name="message">The message to use in failure exceptions.</param>
        /// <param name="parameters">The parameters used when formatting <paramref name="message"/>.</param>
        /// <returns>
        /// The <see cref="ConstrainedValue{ScenarioBase}"/> specification value.
        /// </returns>
        /// <exception cref="ConstraintFailedException">The assertion failed.</exception>
        public static ConstrainedValue<T> ShouldThrow<T>(this ConstrainedValue<T> self, string message, params object[] parameters) where T : ScenarioBase
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.Should.HaveThrown(typeof(Exception), message, parameters);
            return self;
        }

        /// <summary>
        /// Verifies the <see cref="ScenarioBase"/> throws an exception.
        /// </summary>
        /// <typeparam name="T">The constrained value type.</typeparam>
        /// <param name="self">The specification value.</param>
        /// <returns>
        /// The <see cref="ConstrainedValue{ScenarioBase}"/> specification value.
        /// </returns>
        /// <exception cref="ConstraintFailedException">The assertion failed.</exception>
        public static ConstrainedValue<T> ShouldThrow<T>(this ConstrainedValue<T> self) where T : ScenarioBase
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.Should.HaveThrown(typeof(Exception), null);
            return self;
        }

        /// <summary>
        /// Verifies the <see cref="ScenarioBase"/> throws an exception of the specified type.
        /// </summary>
        /// <typeparam name="T">The constrained value type.</typeparam>
        /// <param name="self">The specification value.</param>
        /// <param name="exceptionType">Type of the exception.</param>
        /// <param name="message">The message to use in failure exceptions.</param>
        /// <param name="parameters">The parameters used when formatting <paramref name="message"/>.</param>
        /// <returns>
        /// The <see cref="ConstrainedValue{ScenarioBase}"/> specification value.
        /// </returns>
        /// <exception cref="ConstraintFailedException">The assertion failed.</exception>
        public static ConstrainedValue<T> ShouldThrow<T>(this ConstrainedValue<T> self, Type exceptionType, string message, params object[] parameters) where T : ScenarioBase
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            if (exceptionType == null)
            {
                throw new ArgumentNullException("exceptionType");
            }

            self.Should.HaveThrown(exceptionType, message, parameters);
            return self;
        }

        /// <summary>
        /// Verifies the <see cref="ScenarioBase"/> throws an exception of the specified type.
        /// </summary>
        /// <typeparam name="T">The constrained value type.</typeparam>
        /// <param name="self">The specification value.</param>
        /// <param name="exceptionType">Type of the exception.</param>
        /// <returns>
        /// The <see cref="ConstrainedValue{ScenarioBase}"/> specification value.
        /// </returns>
        /// <exception cref="ConstraintFailedException">The assertion failed.</exception>
        public static ConstrainedValue<T> ShouldThrow<T>(this ConstrainedValue<T> self, Type exceptionType) where T : ScenarioBase
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.Should.HaveThrown(exceptionType, null);
            return self;
        }

        /// <summary>
        /// Verifies the <see cref="ScenarioBase"/> doesn't throw any exceptions.
        /// </summary>
        /// <typeparam name="T">The constrained value type.</typeparam>
        /// <param name="self">The specification value.</param>
        /// <param name="message">The message to use in failure exceptions.</param>
        /// <param name="parameters">The parameters used when formatting <paramref name="message"/>.</param>
        /// <returns>
        /// The <see cref="ConstrainedValue{ScenarioBase}"/> specification value.
        /// </returns>
        /// <exception cref="ConstraintFailedException">The assertion failed.</exception>
        public static ConstrainedValue<T> ShouldNotThrow<T>(this ConstrainedValue<T> self, string message, params object[] parameters) where T : ScenarioBase
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.Should.Not.HaveThrown(typeof(Exception), message, parameters);
            return self;
        }

        /// <summary>
        /// Verifies the <see cref="ScenarioBase"/> doesn't throw any exceptions.
        /// </summary>
        /// <typeparam name="T">The constrained value type.</typeparam>
        /// <param name="self">The specification value.</param>
        /// <returns>
        /// The <see cref="ConstrainedValue{ScenarioBase}"/> specification value.
        /// </returns>
        /// <exception cref="ConstraintFailedException">The assertion failed.</exception>
        public static ConstrainedValue<T> ShouldNotThrow<T>(this ConstrainedValue<T> self) where T : ScenarioBase
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.Should.Not.HaveThrown(typeof(Exception), null);
            return self;
        }
    }
}
