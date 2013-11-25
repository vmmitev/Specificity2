//-----------------------------------------------------------------------------
// <copyright file="EquivalenceClassCollection.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Testing.Specificity
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Provide a collection of equivalence classes.
    /// </summary>
    /// <typeparam name="T">The root type.</typeparam>
    public sealed class EquivalenceClassCollection<T> : IEnumerable<IEnumerable<T>>
    {
        /// <summary>
        /// The equivalence classes.
        /// </summary>
        private readonly List<IEnumerable<T>> classes = new List<IEnumerable<T>>();

        /// <summary>
        /// Adds an equivalence class.
        /// </summary>
        /// <param name="firstEquatable">The first equatable.</param>
        /// <param name="secondEquatable">The second equatable.</param>
        /// <param name="otherEquatables">The rest of the equatables.</param>
        public void Add(T firstEquatable, T secondEquatable, params T[] otherEquatables)
        {
            this.classes.Add(Enumerable.Repeat(firstEquatable, 1).Concat(Enumerable.Repeat(secondEquatable, 1).Concat(otherEquatables).ToList()));
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection of equivalence classes.
        /// </summary>
        /// <returns>An <see cref="IEnumerator{T}"/> that can iterate through the equivalence classes.</returns>
        public IEnumerator<IEnumerable<T>> GetEnumerator()
        {
            return this.classes.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection of equivalence classes.
        /// </summary>
        /// <returns>An <see cref="IEnumerator{T}"/> that can iterate through the equivalence classes.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}