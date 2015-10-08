// <copyright file="DefaultObjectFactoryRegistry.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>

namespace Testing.Specificity2.Objects
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Provides a registry for static object factories.
    /// </summary>
    internal class DefaultObjectFactoryRegistry : Dictionary<Type, Func<IObjectFactory, object>>, IObjectFactoryRegistry
    {
        /// <summary>
        /// Gets the registered customizations.
        /// </summary>
        public IEnumerable<ObjectFactoryCustomization> Customizations
        {
            get { return this.CustomizationsStack; }
        }

        /// <summary>
        /// The registered customizations as a stack.
        /// </summary>
        private Stack<ObjectFactoryCustomization> CustomizationsStack { get; } = new Stack<ObjectFactoryCustomization>();

        /// <summary>
        /// Adds a customization object to the registry.
        /// </summary>
        /// <param name="customization">The customization object.</param>
        public void Customize(ObjectFactoryCustomization customization)
        {
            this.CustomizationsStack.Push(customization);
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