//-----------------------------------------------------------------------------
// <copyright file="ConstrainedValue.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Testing.Specificity
{
    /// <summary>
    /// Defines a wrapper for values used to distinguish values being specified with assertions in order to play
    /// nicely with intellisense. Unless implementing an assertion, this is an implementation detail that may be
    /// ignored.
    /// </summary>
    /// <typeparam name="T">The type of the wrapped value.</typeparam>
    public class ConstrainedValue<T>
    {
        /// <summary>
        /// The wrapped value.
        /// </summary>
        private readonly T value;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConstrainedValue{T}"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        internal ConstrainedValue(T value)
        {
            this.value = value;
        }

        /// <summary>
        /// Gets the wrapped value.
        /// </summary>
        /// <value>The wrapped value.</value>
        public T Value
        {
            get { return this.value; }
        }
    }
}
