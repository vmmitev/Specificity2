﻿//-----------------------------------------------------------------------------
// <copyright file="IObjectFactoryRegistry.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Testing.Specificity
{
    using System;

    /// <summary>
    /// Defines an interface that can be used to register object factory methods.
    /// </summary>
    public interface IObjectFactoryRegistry
    {
        /// <summary>
        /// Registers a factory method that can be used to create instances of the specified type.
        /// </summary>
        /// <param name="type">The type of object created by the factory.</param>
        /// <param name="factory">The factory method.</param>
        void Register(Type type, Func<IObjectFactory, object> factory);
    }
}