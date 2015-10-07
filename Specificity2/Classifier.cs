//-----------------------------------------------------------------------------
// <copyright file="Classifier.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Testing.Specificity2
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Defines a type that can be used to classify values.
    /// </summary>
    /// <typeparam name="T">The value type to classify.</typeparam>
    public abstract class Classifier<T>
    {
        /// <summary>
        /// Created classifications.
        /// </summary>
        private readonly List<Classification<T>> classifications = new List<Classification<T>>();

        /// <summary>
        /// Gets the total number of values that have been classified.
        /// </summary>
        public int Count
        {
            get;
            private set;
        }

        /// <summary>
        /// Classifies a specified value.
        /// </summary>
        /// <param name="value">The value to classify.</param>
        public void Classify(T value)
        {
            this.Count++;
            foreach (var classification in this.classifications)
            {
                if (classification.Predicate(value))
                {
                    classification.Count++;
                }
            }
        }

        /// <summary>
        /// Creates a classification.
        /// </summary>
        /// <param name="predicate">The predicate to associate with the newly created
        /// <see cref="Classification{T}"/>.</param>
        /// <returns>A new <see cref="Classification{T}"/> instance.</returns>
        protected Classification<T> CreateClassification(Predicate<T> predicate)
        {
            if (this.Count > 0)
            {
                throw new InvalidOperationException();
            }

            var classification = new Classification<T>(this, predicate);
            this.classifications.Add(classification);
            return classification;
        }
    }
}