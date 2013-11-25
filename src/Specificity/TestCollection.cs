//-----------------------------------------------------------------------------
// <copyright file="TestCollection.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Testing.Specificity
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Represents a collection of tests.
    /// </summary>
    public sealed class TestCollection : List<Action>
    {
        /// <summary>
        /// The message to use if the tests fail.
        /// </summary>
        private string message;

        /// <summary>
        /// Initializes a new instance of the <see cref="TestCollection"/> class.
        /// </summary>
        /// <param name="message">The message to use if any of the tests fail.</param>
        /// <param name="arguments">The arguments used to format the message.</param>
        public TestCollection(string message, params object[] arguments)
        {
            this.message = string.Format(message, arguments);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TestCollection"/> class.
        /// </summary>
        public TestCollection()
            : this("Multiple tests failed.")
        {
        }

        /// <summary>
        /// Adds a collection of tests as a sub-test.
        /// </summary>
        /// <param name="subTests">The tests to add.</param>
        public void Add(TestCollection subTests)
        {
            this.Add(() => subTests.RunTests());
        }

        /// <summary>
        /// Runs the tests.
        /// </summary>
        public void RunTests()
        {
            List<Exception> exceptions = new List<Exception>();
            foreach (var test in this)
            {
                try
                {
                    test();
                }
                catch (Exception e)
                {
                    exceptions.Add(e);
                }
            }

            if (exceptions.Any())
            {
                Specify.Failure(exceptions, this.message);
            }
        }
    }
}