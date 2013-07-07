//-----------------------------------------------------------------------------
// <copyright file="ISpecifyAdapter.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Testing.Specificity
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Platform adapter for Specify class.
    /// </summary>
    internal interface ISpecifyAdapter
    {
        /// <summary>
        /// Raise the unit test framework specific exception.
        /// </summary>
        /// <param name="message">The failure message.</param>
        void Fail(string message);

        /// <summary>
        /// Raise the unit test framework specific "aggregate exception".
        /// </summary>
        /// <param name="innerExceptions">The inner exceptions.</param>
        /// <param name="message">The failure message.</param>
        void Fail(IEnumerable<Exception> innerExceptions, string message);

        /// <summary>
        /// Raise the unit test framework specific "inconclusive test exception".
        /// </summary>
        /// <param name="message">The message to display in the test results.</param>
        void Inconclusive(string message);
    }
}
