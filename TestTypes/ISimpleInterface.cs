//-----------------------------------------------------------------------------
// <copyright file="ISimpleInterface.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace TestTypes
{
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