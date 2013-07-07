//-----------------------------------------------------------------------------
// <copyright file="IConstraint.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Testing.Specificity
{
    using System.ComponentModel;

    /// <summary>
    /// Defines a constraint.
    /// </summary>
    /// <typeparam name="T">The constrained value type.</typeparam>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IConstraint<T>
    {
        /// <summary>
        /// Gets a value indicating whether this instance is negated.
        /// </summary>
        /// <value>
        /// <see langword="true"/> if this instance is negated; otherwise, <see langword="false"/>.
        /// </value>
        bool IsNegated { get; }

        /// <summary>
        /// Gets the constrained value.
        /// </summary>
        /// <value>The constrained value.</value>
        T Value { get; }
    }
}
