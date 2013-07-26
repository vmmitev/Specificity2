//-----------------------------------------------------------------------------
// <copyright file="IObjectFactory.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

using System;
namespace Testing.Specificity
{
    /// <summary>
    /// Defines an interface that can be used to create pseudo-random values.
    /// </summary>
    public interface IObjectFactory
    {
        /// <summary>
        /// Generate a pseudo-random <see cref="System.Double"/> value.
        /// </summary>
        /// <param name="minimum">The minimum value to generate.</param>
        /// <param name="maximum">The maximum value to generate.</param>
        /// <param name="distribution">The distribution to use.</param>
        /// <returns>A pseudo-random <see cref="System.Double"/> value.</returns>
        double AnyDouble(double minimum = double.MinValue, double maximum = double.MaxValue, Distribution distribution = null);

        /// <summary>
        /// Generate a pseudo-random object of the specified type.
        /// </summary>
        /// <typeparam name="T">The type of object to generate.</typeparam>
        /// <returns>A pseudo-random instance of the specified type.</returns>
        object Any(Type type);
    }
}