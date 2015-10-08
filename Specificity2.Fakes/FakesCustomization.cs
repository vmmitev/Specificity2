// <copyright file="FakesCustomization.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>

namespace Testing.Specificity2.Objects
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
        private static IDictionary<Type, Type> KnownStubs { get; } = GetKnownStubs();

        /// <inheritdoc/>
        public override bool TryGetAny<T>(IObjectFactory factory, CustomizationContext context, out T result)
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
            if (KnownStubs.TryGetValue(typeof(T), out stubType))
            {
                result = (T)factory.Any(stubType);

                return true;
            }

            return context.TryNextCustomization(factory, out result);
        }

        /// <summary>
        /// Returns a dictionary of discoverable stub types.
        /// </summary>
        /// <returns>The dictionary mapping between stubbed type and the actual stub type.</returns>
        private static Dictionary<Type, Type> GetKnownStubs()
        {
            EnsureFakesAssembliesAreLoaded();

            return GetStubTypes().ToDictionary(stubType => GetStubbedType(stubType));
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
                if (name.Name.EndsWith(".Fakes", StringComparison.Ordinal))
                {
                    Assembly.Load(name);
                }
            }
        }

        /// <summary>
        /// Returns an enumeration of discoverable stub types.
        /// </summary>
        /// <returns>The enumeration of discovered stub types.</returns>
        private static IEnumerable<Type> GetStubTypes()
        {
            return AppDomain.CurrentDomain
                            .GetAssemblies()
                            .SelectMany(assembly => assembly.GetTypes())
                            .Where(type => !type.IsInterface &&
                                           !type.IsAbstract &&
                                           typeof(IStub).IsAssignableFrom(type));
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
        /// <returns><see langword="true"/> if the type matches <see cref="IStub{T}"/>; otherwise, <see langword="false"/>.</returns>
        private static bool IsStubInterfaceType(Type interfaceType)
        {
            return interfaceType.IsGenericType
                && interfaceType.GetGenericTypeDefinition() == typeof(IStub<>);
        }
    }
}