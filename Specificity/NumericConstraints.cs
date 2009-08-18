//-----------------------------------------------------------------------------
// <copyright file="NumericConstraints.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Testing.Specificity
{
    using System;

    /// <summary>
    /// Provides extension methods for numeric assertions.
    /// </summary>
    public static class NumericConstraints
    {
        /// <summary>
        /// Verifies the specification value value is equal to an expected value.
        /// </summary>
        /// <param name="self">The specification value.</param>
        /// <param name="expected">The expected.</param>
        /// <param name="delta">The delta by which the comparison can vary.</param>
        /// <param name="message">The message to use in failure exceptions.</param>
        /// <param name="parameters">The parameters used when formatting <paramref name="message"/>.</param>
        /// <returns>
        /// The <see cref="ConstrainedValue{T}"/> specification value.
        /// </returns>
        /// <exception cref="ConstraintFailedException">The assertion failed.</exception>
        public static ConstrainedValue<double> ShouldBeEqualTo(this ConstrainedValue<double> self, double expected, double delta, string message, params object[] parameters)
        {
            if (Math.Abs((double)(expected - self.Value)) > delta)
            {
                Specify.Fail(
                    "ShouldBeEqualTo",
                    Messages.DifferenceMoreThanDelta(delta, expected, self.Value),
                    message,
                    parameters);
            }

            return self;
        }

        /// <summary>
        /// Verifies the specification value value is equal to an expected value.
        /// </summary>
        /// <param name="self">The specification value.</param>
        /// <param name="expected">The expected.</param>
        /// <param name="delta">The delta by which the comparison can vary.</param>
        /// <returns>
        /// The <see cref="ConstrainedValue{T}"/> specification value.
        /// </returns>
        /// <exception cref="ConstraintFailedException">The assertion failed.</exception>
        public static ConstrainedValue<double> ShouldBeEqualTo(this ConstrainedValue<double> self, double expected, double delta)
        {
            return self.ShouldBeEqualTo(expected, delta, null);
        }

        /// <summary>
        /// Verifies the specification value value is equal to an expected value.
        /// </summary>
        /// <param name="self">The specification value.</param>
        /// <param name="expected">The expected.</param>
        /// <param name="delta">The delta by which the comparison can vary.</param>
        /// <param name="message">The message to use in failure exceptions.</param>
        /// <param name="parameters">The parameters used when formatting <paramref name="message"/>.</param>
        /// <returns>
        /// The <see cref="ConstrainedValue{T}"/> specification value.
        /// </returns>
        /// <exception cref="ConstraintFailedException">The assertion failed.</exception>
        public static ConstrainedValue<float> ShouldBeEqualTo(this ConstrainedValue<float> self, float expected, float delta, string message, params object[] parameters)
        {
            if (Math.Abs((double)(expected - self.Value)) > delta)
            {
                Specify.Fail(
                    "ShouldBeEqualTo",
                    Messages.DifferenceMoreThanDelta(delta, expected, self.Value),
                    message,
                    parameters);
            }

            return self;
        }

        /// <summary>
        /// Verifies the specification value value is equal to an expected value.
        /// </summary>
        /// <param name="self">The specification value.</param>
        /// <param name="expected">The expected.</param>
        /// <param name="delta">The delta by which the comparison can vary.</param>
        /// <returns>
        /// The <see cref="ConstrainedValue{T}"/> specification value.
        /// </returns>
        /// <exception cref="ConstraintFailedException">The assertion failed.</exception>
        public static ConstrainedValue<float> ShouldBeEqualTo(this ConstrainedValue<float> self, float expected, float delta)
        {
            return self.ShouldBeEqualTo(expected, delta, null);
        }

        /// <summary>
        /// Verifies the specification value value is not equal to an expected value.
        /// </summary>
        /// <param name="self">The specification value.</param>
        /// <param name="expected">The expected.</param>
        /// <param name="delta">The delta by which the comparison can vary.</param>
        /// <param name="message">The message to use in failure exceptions.</param>
        /// <param name="parameters">The parameters used when formatting <paramref name="message"/>.</param>
        /// <returns>
        /// The <see cref="ConstrainedValue{T}"/> specification value.
        /// </returns>
        /// <exception cref="ConstraintFailedException">The assertion failed.</exception>
        public static ConstrainedValue<double> ShouldNotBeEqualTo(this ConstrainedValue<double> self, double expected, double delta, string message, params object[] parameters)
        {
            if (Math.Abs((double)(expected - self.Value)) <= delta)
            {
                Specify.Fail(
                    "ShouldNotBeEqualTo",
                    Messages.DifferenceLessThanDelta(delta, expected, self.Value),
                    message,
                    parameters);
            }

            return self;
        }

        /// <summary>
        /// Verifies the specification value value is not equal to an expected value.
        /// </summary>
        /// <param name="self">The specification value.</param>
        /// <param name="expected">The expected.</param>
        /// <param name="delta">The delta by which the comparison can vary.</param>
        /// <returns>
        /// The <see cref="ConstrainedValue{T}"/> specification value.
        /// </returns>
        /// <exception cref="ConstraintFailedException">The assertion failed.</exception>
        public static ConstrainedValue<double> ShouldNotBeEqualTo(this ConstrainedValue<double> self, double expected, double delta)
        {
            return self.ShouldNotBeEqualTo(expected, delta, null);
        }

        /// <summary>
        /// Verifies the specification value value is not equal to an expected value.
        /// </summary>
        /// <param name="self">The specification value.</param>
        /// <param name="expected">The expected.</param>
        /// <param name="delta">The delta by which the comparison can vary.</param>
        /// <param name="message">The message to use in failure exceptions.</param>
        /// <param name="parameters">The parameters used when formatting <paramref name="message"/>.</param>
        /// <returns>
        /// The <see cref="ConstrainedValue{T}"/> specification value.
        /// </returns>
        /// <exception cref="ConstraintFailedException">The assertion failed.</exception>
        public static ConstrainedValue<float> ShouldNotBeEqualTo(this ConstrainedValue<float> self, float expected, float delta, string message, params object[] parameters)
        {
            if (Math.Abs((double)(expected - self.Value)) <= delta)
            {
                Specify.Fail(
                    "ShouldNotBeEqualTo",
                    Messages.DifferenceLessThanDelta(delta, expected, self.Value),
                    message,
                    parameters);
            }

            return self;
        }

        /// <summary>
        /// Verifies the specification value value is not equal to an expected value.
        /// </summary>
        /// <param name="self">The specification value.</param>
        /// <param name="expected">The expected.</param>
        /// <param name="delta">The delta by which the comparison can vary.</param>
        /// <returns>
        /// The <see cref="ConstrainedValue{T}"/> specification value.
        /// </returns>
        /// <exception cref="ConstraintFailedException">The assertion failed.</exception>
        public static ConstrainedValue<float> ShouldNotBeEqualTo(this ConstrainedValue<float> self, float expected, float delta)
        {
            return self.ShouldNotBeEqualTo(expected, delta, null);
        }
    }
}
