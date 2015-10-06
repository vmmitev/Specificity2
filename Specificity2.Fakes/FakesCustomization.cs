﻿//-----------------------------------------------------------------------------
// <copyright file="FakesCustomization.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Testing.Specificity2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Microsoft.QualityTools.Testing.Fakes.Stubs;

    /// <summary>
    /// Customizes an <see cref="ObjectFactory"/> to produce "auto-fakes" when asking for a type
    /// that has been stubbed by the Microsoft Fakes library.
    /// </summary>
    public sealed class FakesCustomization : ObjectFactoryCustomization
    {
        /// <summary>
        /// The known stub types.
        /// </summary>
        private static readonly Dictionary<Type, Type> KnownStubs;

        /// <summary>
        /// Initializes static members of the <see cref="FakesCustomization"/> class.
        /// </summary>
        static FakesCustomization()
        {
            EnsureFakesAssembliesAreLoaded();
            var stubs = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(t => !t.IsInterface && !t.IsAbstract && typeof(IStub).IsAssignableFrom(t));
            KnownStubs = stubs.ToDictionary(t => GetStubbedType(t));
        }

        /// <summary>
        /// Try to obtain an instance of the specified type.
        /// </summary>
        /// <param name="type">The type of object to obtain.</param>
        /// <param name="factory">The factory associated with this customization.</param>
        /// <param name="context">The context in which the object is being obtained.</param>
        /// <param name="result">The object instance to return to the caller.</param>
        /// <returns><see langword="true"/> if an instance of the specified type was obtained; otherwise <see langword="false"/></returns>
        public override bool TryGetAny(Type type, IObjectFactory factory, CustomizationContext context, out object result)
        {
            Type stubType;
            if (KnownStubs.TryGetValue(type, out stubType))
            {
                result = factory.Any(stubType);
                return true;
            }

            return context.CallNextCustomization(type, factory, out result);
        }

        /// <summary>
        /// Ensure Fakes assemblies are loaded.
        /// </summary>
        private static void EnsureFakesAssembliesAreLoaded()
        {
            var referencedAssemblies = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.GetReferencedAssemblies());
            foreach (var name in referencedAssemblies)
            {
                if (name.Name.EndsWith(".Fakes"))
                {
                    Assembly.Load(name);
                }
            }
        }

        /// <summary>
        /// The the stubbed type from the stub type.
        /// </summary>
        /// <param name="stubType">The stub type.</param>
        /// <returns>The stubbed type.</returns>
        private static Type GetStubbedType(Type stubType)
        {
            return (from t in stubType.GetInterfaces()
                    where t.IsGenericType
                    let d = t.GetGenericTypeDefinition()
                    where d == typeof(IStub<>)
                    select t.GetGenericArguments().First())
                   .First();
        }
    }
}