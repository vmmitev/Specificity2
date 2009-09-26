//-----------------------------------------------------------------------------
// <copyright file="IReportSpecificationResults.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Testing.Specificity
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// Internal interface used to define a type that can report specification results in a
    /// "native" manner.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IReportSpecificationResults
    {
        /// <summary>
        /// Fails the specification without checking any constraints.
        /// </summary>
        /// <param name="message">The message to display.</param>
        /// <exception cref="Exception">Always thrown. The exact type of this exception is dependent on what
        /// testing framework is used.</exception>
        void Failure(string message);
        
        /// <summary>
        /// Indicates that a specification can not be verified.
        /// </summary>
        /// <param name="message">The message to display.</param>
        /// <exception cref="Exception">Always thrown. The exact type of this exception is dependent on what
        /// testing framework is used.</exception>
        void Inconclusive(string message);
    }
}
