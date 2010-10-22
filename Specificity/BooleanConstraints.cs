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
        /// Verifies whether or not the constrained Boolean value is <see langword="true"/>.
        /// </summary>
        /// <param name="self">The constrained Boolean value.</param>
        public static void BeTrue(this IConstraint<bool> self)
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.BeTrue(null);
        }

        /// <summary>
        /// Verifies whether or not the constrained Boolean value is <see langword="true"/>.
        /// </summary>
        /// <param name="self">The constrained Boolean value.</param>
        /// <param name="message">The message to display in case of failure.</param>
        /// <param name="parameters">The parameters used to format the <paramref name="message"/>.</param>
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
        /// Verifies whether or not the constrained Boolean value is <see langword="false"/>.
        /// </summary>
        /// <param name="self">The constrained Boolean value.</param>
        public static void BeFalse(this IConstraint<bool> self)
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.BeFalse(null);
        }

        /// <summary>
        /// Verifies whether or not the constrained Boolean value is <see langword="false"/>.
        /// </summary>
        /// <param name="self">The constrained Boolean value.</param>
        /// <param name="message">The message to display in case of failure.</param>
        /// <param name="parameters">The parameters used to format the <paramref name="message"/>.</param>
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
        /// <remarks>This method will be obsolete in the future and is intentionally hidden from IntelliSense.</remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ConstrainedValue<bool> ShouldBeTrue(
            this ConstrainedValue<bool> self,
            string message,
            params object[] parameters)
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.Should.BeTrue(message, parameters);
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
        /// <remarks>This method will be obsolete in the future and is intentionally hidden from IntelliSense.</remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ConstrainedValue<bool> ShouldBeTrue(this ConstrainedValue<bool> self)
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.Should.BeTrue(null);
            return self;
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
        /// <remarks>This method will be obsolete in the future and is intentionally hidden from IntelliSense.</remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ConstrainedValue<bool> ShouldBeFalse(
            this ConstrainedValue<bool> self,
            string message,
            params object[] parameters)
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.Should.BeFalse(message, parameters);
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
        /// <remarks>This method will be obsolete in the future and is intentionally hidden from IntelliSense.</remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ConstrainedValue<bool> ShouldBeFalse(this ConstrainedValue<bool> self)
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.Should.BeFalse(null);
            return self;
        }
    }
}
