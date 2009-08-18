//-----------------------------------------------------------------------------
// <copyright file="ScenarioConstraints.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Testing.Specificity
{
    using System;

    /// <summary>
    /// Provides extension methods for assertions on <see cref="ScenarioBase"/> types.
    /// </summary>
    public static class ScenarioConstraints
    {
        /// <summary>
        /// Verifies the <see cref="ScenarioBase"/> throws an exception.
        /// </summary>
        /// <typeparam name="T">The constraind value type.</typeparam>
        /// <param name="self">The specification value.</param>
        /// <param name="message">The message to use in failure exceptions.</param>
        /// <param name="parameters">The parameters used when formatting <paramref name="message"/>.</param>
        /// <returns>
        /// The <see cref="ConstrainedValue{ScenarioBase}"/> specification value.
        /// </returns>
        /// <exception cref="ConstraintFailedException">The assertion failed.</exception>
        public static ConstrainedValue<T> ShouldThrow<T>(this ConstrainedValue<T> self, string message, params object[] parameters) where T : ScenarioBase
        {
            return ShouldThrow(self, typeof(Exception), message, parameters);
        }

        /// <summary>
        /// Verifies the <see cref="ScenarioBase"/> throws an exception.
        /// </summary>
        /// <typeparam name="T">The constraind value type.</typeparam>
        /// <param name="self">The specification value.</param>
        /// <returns>
        /// The <see cref="ConstrainedValue{ScenarioBase}"/> specification value.
        /// </returns>
        /// <exception cref="ConstraintFailedException">The assertion failed.</exception>
        public static ConstrainedValue<T> ShouldThrow<T>(this ConstrainedValue<T> self) where T : ScenarioBase
        {
            return ShouldThrow(self, typeof(Exception), null);
        }

        /// <summary>
        /// Verifies the <see cref="ScenarioBase"/> throws an exception of the specified type.
        /// </summary>
        /// <typeparam name="T">The constraind value type.</typeparam>
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
            ScenarioBase scenario = self.Value;
            if (scenario.Exception == null)
            {
                Specify.Fail(
                    "ShouldThrow",
                    Messages.NoExceptionThrown(exceptionType),
                    message,
                    parameters);
            }

            Type actualType = scenario.Exception.GetType();
            Type expectedType = exceptionType;
            if (!expectedType.IsAssignableFrom(actualType))
            {
                Specify.Fail(
                    "ShouldThrow",
                    Messages.UnexpectedExceptionType(expectedType, actualType),
                    message,
                    parameters);
            }

            return self;
        }

        /// <summary>
        /// Verifies the <see cref="ScenarioBase"/> throws an exception of the specified type.
        /// </summary>
        /// <typeparam name="T">The constraind value type.</typeparam>
        /// <param name="self">The specification value.</param>
        /// <param name="exceptionType">Type of the exception.</param>
        /// <returns>
        /// The <see cref="ConstrainedValue{ScenarioBase}"/> specification value.
        /// </returns>
        /// <exception cref="ConstraintFailedException">The assertion failed.</exception>
        public static ConstrainedValue<T> ShouldThrow<T>(this ConstrainedValue<T> self, Type exceptionType) where T : ScenarioBase
        {
            return self.ShouldThrow(exceptionType, null);
        }

        /// <summary>
        /// Verifies the <see cref="ScenarioBase"/> doesn't throw any exceptions.
        /// </summary>
        /// <typeparam name="T">The constraind value type.</typeparam>
        /// <param name="self">The specification value.</param>
        /// <param name="message">The message to use in failure exceptions.</param>
        /// <param name="parameters">The parameters used when formatting <paramref name="message"/>.</param>
        /// <returns>
        /// The <see cref="ConstrainedValue{ScenarioBase}"/> specification value.
        /// </returns>
        /// <exception cref="ConstraintFailedException">The assertion failed.</exception>
        public static ConstrainedValue<T> ShouldNotThrow<T>(this ConstrainedValue<T> self, string message, params object[] parameters) where T : ScenarioBase
        {
            ScenarioBase scenario = self.Value;
            if (scenario.Exception != null)
            {
                Specify.Fail(
                    "ShouldNotThrow",
                    Messages.UnexpectedException(scenario.Exception.GetType()),
                    message,
                    parameters);
            }

            return self;
        }

        /// <summary>
        /// Verifies the <see cref="ScenarioBase"/> doesn't throw any exceptions.
        /// </summary>
        /// <typeparam name="T">The constraind value type.</typeparam>
        /// <param name="self">The specification value.</param>
        /// <returns>
        /// The <see cref="ConstrainedValue{ScenarioBase}"/> specification value.
        /// </returns>
        /// <exception cref="ConstraintFailedException">The assertion failed.</exception>
        public static ConstrainedValue<T> ShouldNotThrow<T>(this ConstrainedValue<T> self) where T : ScenarioBase
        {
            return self.ShouldNotThrow(null);
        }
    }
}
