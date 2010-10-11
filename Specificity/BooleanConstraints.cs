//-----------------------------------------------------------------------------
// <copyright file="BooleanConstraints.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

using System;
namespace Testing.Specificity
{
    /// <summary>
    /// Provides extension methods for Boolean assertions.
    /// </summary>
    public static class BooleanConstraints
    {
        /// <summary>
        /// Verifies the specification value value is <see langword="true"/>.
        /// </summary>
        /// <param name="self">The specification value.</param>
        /// <param name="message">The message to use in failure exceptions.</param>
        /// <param name="parameters">The parameters used when formatting <paramref name="message"/>.</param>
        /// <returns>
        /// The <see cref="ConstrainedValue{T}"/> specification value.
        /// </returns>
        /// <exception cref="ConstraintFailedException">The assertion failed.</exception>
        public static ConstrainedValue<bool> ShouldBeTrue(
            this ConstrainedValue<bool> self,
            string message,
            params object[] parameters)
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            if (!self.Value)
            {
                Specify.Fail("ShouldBeTrue", message, parameters);
            }

            return self;
        }

        /// <summary>
        /// Verifies the specification value value is <see langword="true"/>.
        /// </summary>
        /// <param name="self">The specification value.</param>
        /// <returns>
        /// The <see cref="ConstrainedValue{T}"/> specification value.
        /// </returns>
        /// <exception cref="ConstraintFailedException">The assertion failed.</exception>
        public static ConstrainedValue<bool> ShouldBeTrue(this ConstrainedValue<bool> self)
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            return self.ShouldBeTrue(null);
        }

        /// <summary>
        /// Verifies the specification value value is <see langword="false"/>.
        /// </summary>
        /// <param name="self">The specification value.</param>
        /// <param name="message">The message to use in failure exceptions.</param>
        /// <param name="parameters">The parameters used when formatting <paramref name="message"/>.</param>
        /// <returns>
        /// The <see cref="ConstrainedValue{T}"/> specification value.
        /// </returns>
        /// <exception cref="ConstraintFailedException">The assertion failed.</exception>
        public static ConstrainedValue<bool> ShouldBeFalse(
            this ConstrainedValue<bool> self,
            string message,
            params object[] parameters)
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            if (self.Value)
            {
                Specify.Fail("ShouldBeFalse", message, parameters);
            }

            return self;
        }

        /// <summary>
        /// Verifies the specification value value is <see langword="false"/>.
        /// </summary>
        /// <param name="self">The specification value.</param>
        /// <returns>
        /// The <see cref="ConstrainedValue{T}"/> specification value.
        /// </returns>
        /// <exception cref="ConstraintFailedException">The assertion failed.</exception>
        public static ConstrainedValue<bool> ShouldBeFalse(this ConstrainedValue<bool> self)
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            return self.ShouldBeFalse(null);
        }
    }
}
