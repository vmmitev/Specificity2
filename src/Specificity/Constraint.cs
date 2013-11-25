//-----------------------------------------------------------------------------
// <copyright file="Constraint.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Testing.Specificity
{
    using System.ComponentModel;

    /// <summary>
    /// Provides a positive constraint for use in fluent specifications.
    /// </summary>
    /// <typeparam name="T">The constrained value type.</typeparam>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public sealed class Constraint<T> : IConstraint<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Constraint&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        internal Constraint(T value)
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
            get { return false; }
        }

        /// <summary>
        /// Gets a negative constraint for this instance.
        /// </summary>
        /// <value>The negative constraint for this instance.</value>
        public NegativeConstraint<T> Not
        {
            get { return new NegativeConstraint<T>(this.Value); }
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