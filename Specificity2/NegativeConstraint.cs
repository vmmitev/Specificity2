//-----------------------------------------------------------------------------
// <copyright file="NegativeConstraint.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Testing.Specificity2
{
    using System.ComponentModel;

    /// <summary>
    /// Provides a negative constraint for use in fluent specifications.
    /// </summary>
    /// <typeparam name="T">The constrained value type.</typeparam>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public sealed class NegativeConstraint<T> : IConstraint<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NegativeConstraint&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        internal NegativeConstraint(T value)
        {
            this.Value = value;
        }

        /// <summary>
        /// Gets a value indicating whether this instance is negated.
        /// </summary>
        /// <value>
        /// <see langword="true"/> if this instance is negated; otherwise, <see langword="false"/>.
        /// </value>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool IsNegated
        {
            get { return true; }
        }

        /// <summary>
        /// Gets the constrained value.
        /// </summary>
        /// <value>The constrained value.</value>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public T Value
        {
            get;
            private set;
        }
    }
}