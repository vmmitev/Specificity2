//-----------------------------------------------------------------------------
// <copyright file="ISimpleInterface.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace TestTypes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Simple interface for testing auto-fakes.
    /// </summary>
    public interface ISimpleInterface
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        string Name { get; set; }
    }
}
