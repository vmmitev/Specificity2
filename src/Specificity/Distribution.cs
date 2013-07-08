//-----------------------------------------------------------------------------
// <copyright file="Distribution.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Testing.Specificity
{
    using System;

    /// <summary>
    /// Defines a distribution mechanism for random number generation.
    /// </summary>
    public abstract class Distribution
    {
        /// <summary>
        /// The uniform distribution random number generator.
        /// </summary>
        private static readonly Distribution UniformInstance = new UniformDistribution();

        /// <summary>
        /// Initializes a new instance of the <see cref="Distribution"/> class.
        /// </summary>
        internal Distribution()
        {
        }

        /// <summary>
        /// Gets a <see cref="Distribution"/> object that can be used to generate
        /// uniform pseudo-random numbers.
        /// </summary>
        public static Distribution Uniform
        {
            get { return Distribution.UniformInstance; }
        }

        /// <summary>
        /// Gets the next pseudo-radom double value.
        /// </summary>
        /// <param name="random">The pseudo-random number generator to use.</param>
        /// <returns>A uniform pseudo-random number.</returns>
        public abstract double NextDouble(Random random);

        /// <summary>
        /// A <see cref="Distribution"/> used to create uniform pseudo-random numbers.
        /// </summary>
        private class UniformDistribution : Distribution
        {
            /// <summary>
            /// Gets the next pseudo-radom double value.
            /// </summary>
            /// <param name="random">The pseudo-random number generator to use.</param>
            /// <returns>A uniform pseudo-random number.</returns>
            public override double NextDouble(Random random)
            {
                return random.NextDouble();
            }
        }
    }
}
