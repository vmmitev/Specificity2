// <copyright file="FakesExtensions.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>

namespace Testing.Specificity2.Objects
{
    using System;
    using System.ComponentModel;
    using System.Linq;
    using Microsoft.QualityTools.Testing.Fakes.Stubs;

    /// <summary>
    /// Provides extension methods for <see cref="IObjectFactoryRegistry"/> instances used to freeze
    /// stubs.
    /// </summary>
    [CLSCompliant(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class FakesExtensions
    {
        /// <summary>
        /// Freezes the specified stub as the result for any further calls to obtain an object of the specified type.
        /// </summary>
        /// <typeparam name="T">The stubbed type.</typeparam>
        /// <param name="registry">The registry.</param>
        /// <param name="stub">The stub instance to freeze.</param>
        public static void FreezeStub<T>(this IObjectFactoryRegistry registry, IStub<T> stub)
            where T : class
        {
            registry.Freeze(typeof(T), stub);
        }

        /// <summary>
        /// Creates and freezes a new instance of the specified stub.
        /// </summary>
        /// <typeparam name="TStub">The stub type to freeze.</typeparam>
        /// <param name="registry">The registry.</param>
        /// <returns>The frozen stub instance.</returns>
        public static TStub FreezeStub<TStub>(this IObjectFactoryRegistry registry)
            where TStub : class, IStub
        {
            var itf = typeof(TStub).GetInterfaces()
                .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IStub<>))
                .First();
            var type = itf.GetGenericArguments().First();
            var stub = Activator.CreateInstance<TStub>();
            registry.Freeze(type, stub);
            return stub;
        }
    }
}