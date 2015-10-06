//-----------------------------------------------------------------------------
// <copyright file="IObjectFactoryRegistrar.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Testing.Specificity2
{
    /// <summary>
    /// Defines an interface for object that can register factory methods with an
    /// <see cref="IObjectFactoryRegistry"/>.
    /// </summary>
    public interface IObjectFactoryRegistrar
    {
        /// <summary>
        /// Registers factory methods with the specified registry.
        /// </summary>
        /// <param name="registry">The registry to register factory methods on.</param>
        void Register(IObjectFactoryRegistry registry);
    }
}