//-----------------------------------------------------------------------------
// <copyright file="ItemOrder.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Testing.Specificity
{
    /// <summary>
    /// Specifies the order requirements for a collection specification.
    /// </summary>
    public enum ItemOrder
    {
        /// <summary>
        /// The items can be in any order.
        /// </summary>
        Any,

        /// <summary>
        /// The items must be in the same order.
        /// </summary>
        Same
    }
}
