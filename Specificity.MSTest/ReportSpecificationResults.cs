//-----------------------------------------------------------------------------
// <copyright file="ReportSpecificationResults.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Testing.Specificity
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// <see cref="IReportSpecificationResults"/> implementation used with MSTest.
    /// </summary>
    public sealed class ReportSpecificationResults : IReportSpecificationResults
    {
        /// <summary>
        /// Fails the specification without checking any constraints.
        /// </summary>
        /// <param name="message">The message to display.</param>
        /// <exception cref="System.Exception">Always thrown. The exact type of this exception is dependent on what
        /// testing framework is used.</exception>
        public void Failure(string message)
        {
            Assert.Fail(message);
        }

        /// <summary>
        /// Indicates that a specification can not be verified.
        /// </summary>
        /// <param name="message">The message to display.</param>
        /// <exception cref="System.Exception">Always thrown. The exact type of this exception is dependent on what
        /// testing framework is used.</exception>
        public void Inconclusive(string message)
        {
            Assert.Inconclusive(message);
        }
    }
}
