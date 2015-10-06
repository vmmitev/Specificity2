//-----------------------------------------------------------------------------
// <copyright file="ContractVerifier.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Testing.Specificity2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Base class for objects that can verify type contracts.
    /// </summary>
    public abstract class ContractVerifier
    {
        /// <summary>
        /// Verifies the type contract.
        /// </summary>
        public void Verify()
        {
            var exceptions = this.GetTests()
                .Select(t => this.RunTest(t))
                .Where(t => t != null).ToArray();
            if (exceptions.Length > 0)
            {
                Specify.Failure(exceptions, string.Format("{0} failed verification.", this.GetType()));
            }
        }

        /// <summary>
        /// Gets the test methods used to verify the contract.
        /// </summary>
        /// <returns>A collection of test methods.</returns>
        protected abstract IEnumerable<Action> GetTests();

        /// <summary>
        /// Runs the test, observing exceptions thrown from the test.
        /// </summary>
        /// <param name="test">The test method.</param>
        /// <returns>The exception thrown by the test, if any.</returns>
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