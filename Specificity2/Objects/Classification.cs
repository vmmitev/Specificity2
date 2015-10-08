// <copyright file="Classification.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>

namespace Testing.Specificity2.Objects
{
    using System;

    /// <summary>
    /// Defines a single classification.
    /// </summary>
    /// <typeparam name="T">The value type to classify.</typeparam>
    public sealed class Classification<T>
    {
        /// <summary>
        /// The owner.
        /// </summary>
        private readonly Classifier<T> owner;

        /// <summary>
        /// The predicate associated with this classification.
        /// </summary>
        private readonly Predicate<T> predicate;

        /// <summary>
        /// Initializes a new instance of the <see cref="Classification{T}"/> class.
        /// </summary>
        /// <param name="owner">The owner.</param>
        /// <param name="predicate">The predicate to associate with this classification.</param>
        internal Classification(Classifier<T> owner, Predicate<T> predicate)
        {
            this.owner = owner;
            this.predicate = predicate;
        }

        /// <summary>
        /// Gets the count of the number of values that matched the predicate associated
        /// with this classification.
        /// </summary>
        public int Count
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets the percentage of times a value was matched by the predicate associated
        /// with this classification.
        /// </summary>
        public double Percent
        {
            get { return (double)this.Count / this.owner.Count; }
        }

        /// <summary>
        /// Gets the predicate associated with this classification.
        /// </summary>
        internal Predicate<T> Predicate
        {
            get { return this.predicate; }
        }
    }
}