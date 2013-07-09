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
        /// Verifies the <see cref="double"/> is equal to the specified value within a specified tolerance.
        /// </summary>
        /// <param name="self">The constrained double.</param>
        /// <param name="expected">The expected value.</param>
        /// <param name="delta">The specified tolerance.</param>
        /// <param name="message">The message to display in case of failure.</param>
        /// <param name="parameters">The parameters used to format the <paramref name="message"/>.</param>
        /// <exception cref="Exception">The constraint failed. The exact type of exception thrown will
        /// depend on the unit test framework, if any, in use.</exception>
        public static void BeEqualTo(this IConstraint<double> self, double expected, double delta, string message = null, params object[] parameters)
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

        /// <summary>
        /// Verifies the <see cref="float"/> is equal to the specified value within a specified tolerance.
        /// </summary>
        /// <param name="self">The constrained float.</param>
        /// <param name="expected">The expected value.</param>
        /// <param name="delta">The specified tolerance.</param>
        /// <param name="message">The message to display in case of failure.</param>
        /// <param name="parameters">The parameters used to format the <paramref name="message"/>.</param>
        /// <exception cref="Exception">The constraint failed. The exact type of exception thrown will
        /// depend on the unit test framework, if any, in use.</exception>
        public static void BeEqualTo(this IConstraint<float> self, float expected, float delta, string message = null, params object[] parameters)
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
    }
}