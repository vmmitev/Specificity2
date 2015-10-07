//-----------------------------------------------------------------------------
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

            var stubTypes = AppDomain.CurrentDomain
                .GetAssemblies()
                .SelectMany(assembly => assembly.GetTypes())
                .Where(type => !type.IsInterface &&
                               !type.IsAbstract &&
                               typeof(IStub).IsAssignableFrom(type));

            KnownStubs = stubTypes.ToDictionary(stubType => GetStubbedType(stubType));
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
            if (factory == null)
            {
                throw new ArgumentNullException("factory");
            }

            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

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
            var referencedAssemblies = AppDomain.CurrentDomain
                .GetAssemblies()
                .SelectMany(assembly => assembly.GetReferencedAssemblies());

            foreach (var name in referencedAssemblies)
            {
                if (name.Name.EndsWith(".Fakes"))
                {
                    Assembly.Load(name);
                }
            }
        }

        /// <summary>
        /// Returns the stubbed type from the stub type.
        /// </summary>
        /// <param name="stubType">The stub type.</param>
        /// <returns>The stubbed type.</returns>
        private static Type GetStubbedType(Type stubType)
        {
            return stubType.GetInterfaces()
                .Where(stubInterface => IsStubInterfaceType(stubInterface))
                .Select(stubInterface => stubInterface.GetGenericArguments().Single())
                .Single();
        }

        /// <summary>
        /// Returns whether the interface type matches <see cref="IStub{T}"/>.
        /// </summary>
        /// <param name="interfaceType">The interface type to check.</param>
        /// <returns>true if the type matches <see cref="IStub{T}"/>; otherwise, false</returns>
        private static bool IsStubInterfaceType(Type interfaceType)
        {
            return interfaceType.IsGenericType
                && interfaceType.GetGenericTypeDefinition() == typeof(IStub<>);
        }
    }
}