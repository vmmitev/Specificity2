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
        public static void BeEqualTo(this IConstraint<double> self, double expected, double delta)
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.BeEqualTo(expected, delta, null);
        }

        public static void BeEqualTo(this IConstraint<double> self, double expected, double delta, string message, params object[] parameters)
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            if (Math.Abs((double)(expected - self.Value)) > delta)
            {
                self.FailIfNotNegated(
                    self.FormatErrorMessage(
                    "BeEqualTo",
                    Messages.DifferenceMoreThanDelta(delta, expected, self.Value),
                    message,
                    parameters));
            }
            else
            {
                self.FailIfNegated(
                    self.FormatErrorMessage(
                    "BeEqualTo",
                    Messages.DifferenceLessThanDelta(delta, expected, self.Value),
                    message,
                    parameters));
            }
        }

        public static void BeEqualTo(this IConstraint<float> self, float expected, float delta)
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.BeEqualTo(expected, delta, null);
        }

        public static void BeEqualTo(this IConstraint<float> self, float expected, float delta, string message, params object[] parameters)
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            if (Math.Abs((float)(expected - self.Value)) > delta)
            {
                self.FailIfNotNegated(
                    self.FormatErrorMessage(
                    "BeEqualTo",
                    Messages.DifferenceMoreThanDelta(delta, expected, self.Value),
                    message,
                    parameters));
            }
            else
            {
                self.FailIfNegated(
                    self.FormatErrorMessage(
                    "BeEqualTo",
                    Messages.DifferenceLessThanDelta(delta, expected, self.Value),
                    message,
                    parameters));
            }
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
        public static ConstrainedValue<double> ShouldBeEqualTo(this ConstrainedValue<double> self, double expected, double delta, string message, params object[] parameters)
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.Should.BeEqualTo(expected, delta, message, parameters);
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
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.Should.BeEqualTo(expected, delta, null);
            return self;
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
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.Should.BeEqualTo(expected, delta, message, parameters);
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
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.Should.BeEqualTo(expected, delta, null);
            return self;
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
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.Should.Not.BeEqualTo(expected, delta, message, parameters);
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
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.Should.Not.BeEqualTo(expected, delta, null);
            return self;
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
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.Should.Not.BeEqualTo(expected, delta, message, parameters);
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
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.Should.Not.BeEqualTo(expected, delta, null);
            return self;
        }
    }
}
