//-----------------------------------------------------------------------------
// <copyright file="DefaultObjectFactoryRegistry.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Testing.Specificity
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Provides a registry for static object factories.
    /// </summary>
    internal class DefaultObjectFactoryRegistry : Dictionary<Type, Func<IObjectFactory, object>>, IObjectFactoryRegistry
    {
        /// <summary>
        /// The registered customizations;
        /// </summary>
        private readonly Stack<ObjectFactoryCustomization> customizations = new Stack<ObjectFactoryCustomization>();

        /// <summary>
        /// Gets the registered customizations.
        /// </summary>
        public IEnumerable<ObjectFactoryCustomization> Customizations
        {
            get { return this.customizations; }
        }

        /// <summary>
        /// Adds a customization object to the registry.
        /// </summary>
        /// <param name="customization">The customization object.</param>
        public void Customize(ObjectFactoryCustomization customization)
        {
            this.customizations.Push(customization);
        }

        /// <summary>
        /// Registers a factory method that can be used to create instances of the specified type.
        /// </summary>
        /// <param name="type">The type of object created by the factory.</param>
        /// <param name="factoryMethod">The factory method.</param>
        public void Register(Type type, Func<IObjectFactory, object> factoryMethod)
        {
            this[type] = factoryMethod;
        }
    }
}