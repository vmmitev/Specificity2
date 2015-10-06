//-----------------------------------------------------------------------------
// <copyright file="Distribution.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Testing.Specificity2
{
    using System;

    /// <summary>
    /// Defines a distribution mechanism for random number generation.
    /// </summary>
    public abstract class Distribution
    {
        /// <summary>
        /// Mean used when calculating gaussian values.
        /// </summary>
        private const double MEAN = 0.0;

        /// <summary>
        /// Sigma used when calculating gaussian values.
        /// </summary>
        private const int SIGMA = 3;

        /// <summary>
        /// Standard deviation used when calculating gaussian values.
        /// </summary>
        private const double STDDEV = 1.0;

        /// <summary>
        /// The inverted normal distribution random number generator.
        /// </summary>
        private static readonly Distribution InvertedNormalInstance = new InvertedNormalDistribution();

        /// <summary>
        /// The negative normal distribution random number generator.
        /// </summary>
        private static readonly Distribution NegativeNormalInstance = new NegativeNormalDistribution();

        /// <summary>
        /// The positive normal distribution random number generator.
        /// </summary>
        private static readonly Distribution PositiveNormalInstance = new PositiveNormalDistribution();

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
        /// inverted normal pseudo-random numbers.
        /// </summary>
        public static Distribution InvertedNormal
        {
            get { return Distribution.InvertedNormalInstance; }
        }

        /// <summary>
        /// Gets a <see cref="Distribution"/> object that can be used to generate
        /// negative normal pseudo-random numbers.
        /// </summary>
        public static Distribution NegativeNormal
        {
            get { return Distribution.NegativeNormalInstance; }
        }

        /// <summary>
        /// Gets a <see cref="Distribution"/> object that can be used to generate
        /// positive normal pseudo-random numbers.
        /// </summary>
        public static Distribution PositiveNormal
        {
            get { return Distribution.PositiveNormalInstance; }
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
        /// Gets the next gaussian value.
        /// </summary>
        /// <param name="random">The pseudo-random number generator to use.</param>
        /// <param name="sigma">The sigma to use.</param>
        /// <returns>A gaussian value.</returns>
        protected double NextGaussian(Random random, int sigma = SIGMA)
        {
            double u1 = random.NextDouble();
            double u2 = random.NextDouble();
            double stdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2);
            double gausian = MEAN + (STDDEV * stdNormal);
            return (gausian % sigma) / sigma;
        }

        /// <summary>
        /// A <see cref="Distribution"/> used to create inverted normal pseudo-random numbers.
        /// </summary>
        private sealed class InvertedNormalDistribution : Distribution
        {
            /// <summary>
            /// Gets the next pseudo-radom double value.
            /// </summary>
            /// <param name="random">The pseudo-random number generator to use.</param>
            /// <returns>A uniform pseudo-random number.</returns>
            public override double NextDouble(Random random)
            {
                double next = this.NextGaussian(random, SIGMA * 2);
                return (next < 0) ? 1 + next : next;
            }
        }

        /// <summary>
        /// A <see cref="Distribution"/> used to create negative normal pseudo-random numbers.
        /// </summary>
        private sealed class NegativeNormalDistribution : Distribution
        {
            /// <summary>
            /// Gets the next pseudo-radom double value.
            /// </summary>
            /// <param name="random">The pseudo-random number generator to use.</param>
            /// <returns>A uniform pseudo-random number.</returns>
            public override double NextDouble(Random random)
            {
                return Math.Abs(-1 + Math.Abs(this.NextGaussian(random)));
            }
        }

        /// <summary>
        /// A <see cref="Distribution"/> used to create positive normal pseudo-random numbers.
        /// </summary>
        private sealed class PositiveNormalDistribution : Distribution
        {
            /// <summary>
            /// Gets the next pseudo-radom double value.
            /// </summary>
            /// <param name="random">The pseudo-random number generator to use.</param>
            /// <returns>A uniform pseudo-random number.</returns>
            public override double NextDouble(Random random)
            {
                return Math.Abs(this.NextGaussian(random));
            }
        }

        /// <summary>
        /// A <see cref="Distribution"/> used to create uniform pseudo-random numbers.
        /// </summary>
        private sealed class UniformDistribution : Distribution
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