//-----------------------------------------------------------------------------
// <copyright file="BooleanConstraints.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Testing.Specificity
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// Provides extension methods for Boolean assertions.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class BooleanConstraints
    {
        /// <summary>
        /// Verifies the constrained <see cref="Boolean"/> value is <see langword="true"/>.
        /// </summary>
        /// <param name="self">The constrained <see cref="Boolean"/> value.</param>
        /// <exception cref="ConstraintFailedException">The constraint failed. The exact type of exception thrown will
        /// depend on the unit test framework, if any, in use.</exception>
        public static void BeTrue(this IConstraint<bool> self)
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.BeTrue(null);
        }

        /// <summary>
        /// Verifies the constrained <see cref="Boolean"/> value is <see langword="true"/>.
        /// </summary>
        /// <param name="self">The constrained <see cref="Boolean"/> value.</param>
        /// <param name="message">The message to display in case of failure.</param>
        /// <param name="parameters">The parameters used to format the <paramref name="message"/>.</param>
        /// <exception cref="ConstraintFailedException">The constraint failed. The exact type of exception thrown will
        /// depend on the unit test framework, if any, in use.</exception>
        public static void BeTrue(this IConstraint<bool> self, string message, params object[] parameters)
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            if (!self.Value)
            {
                self.FailIfNotNegated(self.FormatErrorMessage("BeTrue", null, message, parameters));
            }
            else
            {
                self.FailIfNegated(self.FormatErrorMessage("BeTrue", null, message, parameters));
            }
        }

        /// <summary>
        /// Verifies the constrained <see cref="Boolean"/> value is <see langword="false"/>.
        /// </summary>
        /// <param name="self">The constrained <see cref="Boolean"/> value.</param>
        /// <exception cref="ConstraintFailedException">The constraint failed. The exact type of exception thrown will
        /// depend on the unit test framework, if any, in use.</exception>
        public static void BeFalse(this IConstraint<bool> self)
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.BeFalse(null);
        }

        /// <summary>
        /// Verifies the constrained <see cref="Boolean"/> value is <see langword="false"/>.
        /// </summary>
        /// <param name="self">The constrained <see cref="Boolean"/> value.</param>
        /// <param name="message">The message to display in case of failure.</param>
        /// <param name="parameters">The parameters used to format the <paramref name="message"/>.</param>
        /// <exception cref="ConstraintFailedException">The constraint failed. The exact type of exception thrown will
        /// depend on the unit test framework, if any, in use.</exception>
        public static void BeFalse(this IConstraint<bool> self, string message, params object[] parameters)
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            if (self.Value)
            {
                self.FailIfNotNegated(self.FormatErrorMessage("BeFalse", null, message, parameters));
            }
            else
            {
                self.FailIfNegated(self.FormatErrorMessage("BeFalse", null, message, parameters));
            }
        }
    }
}
