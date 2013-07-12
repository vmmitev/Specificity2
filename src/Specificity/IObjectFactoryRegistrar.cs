//-----------------------------------------------------------------------------
// <copyright file="IObjectFactoryRegistrar.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Testing.Specificity
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

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
