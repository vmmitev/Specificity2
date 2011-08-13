//-----------------------------------------------------------------------------
// <copyright file="ConstraintResultType.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Testing.Specificity
{
    using System.ComponentModel;

    /// <summary>
    /// The constraint result type.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum ConstraintResultType
    {
        /// <summary>
        /// The constraint failed.
        /// </summary>
        Failure,

        /// <summary>
        /// The constraint was inconclusive.
        /// </summary>
        Inconclusive
    }
}
