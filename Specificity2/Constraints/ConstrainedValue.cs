// <copyright file="ConstrainedValue.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>

namespace Testing.Specificity2
{
    using System.ComponentModel;
    using System.Diagnostics;

    /// <summary>
    /// Defines a wrapper for values used to distinguish values being specified with assertions in order to play
    /// nicely with IntelliSense. Unless implementing an assertion, this is an implementation detail that may be
    /// ignored.
    /// </summary>
    /// <typeparam name="T">The type of the wrapped value.</typeparam>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public sealed class ConstrainedValue<T>
    {
        /// <summary>
        /// The wrapped value.
        /// </summary>
        private readonly T value;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConstrainedValue{T}"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        [DebuggerStepThrough]
        public ConstrainedValue(T value)
        {
            this.value = value;
        }

        /// <summary>
        /// Gets the positive constraint.
        /// </summary>
        /// <value>The positive constraint.</value>
        public Constraint<T> Should
        {
            get { return new Constraint<T>(this.value); }
        }

        /// <summary>
        /// Gets the wrapped value.
        /// </summary>
        /// <value>The wrapped value.</value>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public T Value
        {
            get { return this.value; }
        }

        /// <summary>
        /// Determines whether the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <param name="obj">The <see cref="T:System.Object"/> to compare with the current <see cref="T:System.Object"/>.</param>
        /// <returns>
        /// <see langword="true"/> if the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>; otherwise, <see langword="false"/>.
        /// </returns>
        /// <exception cref="T:System.NullReferenceException">
        /// The <paramref name="obj"/> parameter is null.
        /// </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        /// <summary>
        /// Serves as a hash function for a particular type.
        /// </summary>
        /// <returns>
        /// A hash code for the current <see cref="T:System.Object"/>.
        /// </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString()
        {
            return base.ToString();
        }
    }
}