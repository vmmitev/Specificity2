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
        private readonly List<Classification> classifications = new List<Classification>();

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
        /// <see cref="Classification"/>.</param>
        /// <returns>A new <see cref="Classification"/> instance.</returns>
        protected Classification CreateClassification(Predicate<T> predicate)
        {
            if (this.Count > 0)
            {
                throw new InvalidOperationException();
            }

            var classification = new Classification(this, predicate);
            this.classifications.Add(classification);
            return classification;
        }

        /// <summary>
        /// Defines a single classification.
        /// </summary>
        public sealed class Classification
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
            /// Initializes a new instance of the <see cref="Classification"/> class.
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
}