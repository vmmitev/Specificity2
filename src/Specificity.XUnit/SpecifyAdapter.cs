//-----------------------------------------------------------------------------
// <copyright file="SpecifyAdapter.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Testing.Specificity
{
    using System;
    using System.Collections.Generic;
    using Xunit;
    using Xunit.Sdk;

    /// <summary>
    /// Provides a Specify adapter for the MSTest framework.
    /// </summary>
    internal sealed class SpecifyAdapter : ISpecifyAdapter
    {
        /// <summary>
        /// Raise the unit test framework specific exception.
        /// </summary>
        /// <param name="message">The failure message.</param>
        public void Fail(string message)
        {
            throw new AssertException(message);
        }

        /// <summary>
        /// Raise the unit test framework specific "aggregate exception".
        /// </summary>
        /// <param name="innerExceptions">The inner exceptions.</param>
        /// <param name="message">The failure message.</param>
        public void Fail(IEnumerable<Exception> innerExceptions, string message)
        {
            throw new AggregateAssertException(message, innerExceptions);
        }

        /// <summary>
        /// Raise the unit test framework specific "inconclusive test exception".
        /// </summary>
        /// <param name="message">The message to display in the test results.</param>
        public void Inconclusive(string message)
        {
            throw new AssertException("Inconclusive. " + message);
        }
    }
}
