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
        /// <param name="message">The message to display in case of failure.</param>
        /// <param name="args">The arguments used to format the <paramref name="message"/>.</param>
        /// <exception cref="Exception">The constraint failed. The exact type of exception thrown will
        /// depend on the unit test framework, if any, in use.</exception>
        public static void BeTrue(this IConstraint<bool> self, string message = null, params object[] args)
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }
            
            if (!self.Value)
            {
                self.FailIfNotNegated(self.FormatErrorMessage("BeTrue", null, message, args));
            }
            else
            {
                self.FailIfNegated(self.FormatErrorMessage("BeTrue", null, message, args));
            }
        }
    }
}
