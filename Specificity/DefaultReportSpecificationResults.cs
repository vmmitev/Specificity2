//-----------------------------------------------------------------------------
// <copyright file="DefaultReportSpecificationResults.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Testing.Specificity
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Default <see cref="IReportSpecificationResults"/> implementation used when no testing framework
    /// specific assembly has been referenced.
    /// </summary>
    public class DefaultReportSpecificationResults : IReportSpecificationResults
    {
        /// <summary>
        /// Fails the specification without checking any constraints.
        /// </summary>
        /// <param name="message">The message to display.</param>
        /// <exception cref="Exception">Always thrown. The exact type of this exception is dependent on what
        /// testing framework is used.</exception>
        public void Failure(string message)
        {
            throw new ConstraintFailedException(message);
        }

        /// <summary>
        /// Indicates that a specification can not be verified.
        /// </summary>
        /// <param name="message">The message to display.</param>
        /// <exception cref="Exception">Always thrown. The exact type of this exception is dependent on what
        /// testing framework is used.</exception>
        public void Inconclusive(string message)
        {
            throw new ConstraintInconclusiveException(message);
        }
    }
}
