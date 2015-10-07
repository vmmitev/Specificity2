//-----------------------------------------------------------------------------
// <copyright file="ContractVerifier.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Testing.Specificity2
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    /// <summary>
    /// Base class for objects that can verify type contracts.
    /// </summary>
    public abstract class ContractVerifier
    {
        /// <summary>
        /// Gets the test methods used to verify the contract.
        /// </summary>
        /// <value>A collection of test methods.</value>
        protected abstract IEnumerable<Action> Tests { get; }

        /// <summary>
        /// Verifies the type contract.
        /// </summary>
        public void Verify()
        {
            var exceptions = this.Tests
                .Select(test => this.RunTest(test))
                .Where(test => test != null)
                .ToArray();

            if (exceptions.Length > 0)
            {
                Specify.Failure(exceptions, string.Format("{0} failed verification.", this.GetType()));
            }
        }

        /// <summary>
        /// Runs the test, observing exceptions thrown from the test.
        /// </summary>
        /// <param name="test">The test method.</param>
        /// <returns>The exception thrown by the test, if any.</returns>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "The point is to report exception failures.")]
        private Exception RunTest(Action test)
        {
            try
            {
                test();
            }
            catch (Exception e)
            {
                return e;
            }

            return null;
        }
    }
}