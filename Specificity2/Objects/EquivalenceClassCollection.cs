﻿// <copyright file="EquivalenceClassCollection.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>

namespace Testing.Specificity2.Objects
{
    using System;
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
        private List<IEnumerable<T>> Classes { get; } = new List<IEnumerable<T>>();

        /// <summary>
        /// Adds an equivalence class with element created by using the specified factory, which should return a new
        /// equivalent instance each time it is called.
        /// </summary>
        /// <param name="factory">The factory function used to create equivalent instances.</param>
        public void Add(Func<T> factory)
        {
            this.Classes.Add(Enumerable.Range(0, 3).Select(_ => factory()));
        }

        /// <summary>
        /// Adds an equivalence class.
        /// </summary>
        /// <param name="firstEquatable">The first equatable.</param>
        /// <param name="secondEquatable">The second equatable.</param>
        /// <param name="otherEquatableItems">The rest of the equatables.</param>
        public void Add(T firstEquatable, T secondEquatable, params T[] otherEquatableItems)
        {
            this.Classes.Add(
                Enumerable.Repeat(firstEquatable, 1)
                    .Concat(Enumerable.Repeat(secondEquatable, 1)
                    .Concat(otherEquatableItems)));
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection of equivalence classes.
        /// </summary>
        /// <returns>An <see cref="IEnumerator{T}"/> that can iterate through the equivalence classes.</returns>
        public IEnumerator<IEnumerable<T>> GetEnumerator()
        {
            return this.Classes.GetEnumerator();
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