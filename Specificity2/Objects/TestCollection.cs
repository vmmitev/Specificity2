﻿// <copyright file="TestCollection.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>

namespace Testing.Specificity2.Objects
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using Properties;

    /// <summary>
    /// Represents a collection of tests.
    /// </summary>
    internal sealed class TestCollection : List<Action>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TestCollection"/> class.
        /// </summary>
        public TestCollection()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TestCollection" /> class.
        /// </summary>
        /// <param name="tests">The tests.</param>
        public TestCollection(IEnumerable<Action> tests)
            : base(tests)
        {
        }

        /// <summary>
        /// Adds a collection of tests as a sub-test.
        /// </summary>
        /// <param name="tests">The tests to add.</param>
        public void Add(IEnumerable<Action> tests)
        {
            var subTests = tests as TestCollection ?? new TestCollection(tests);

            this.Add(() => subTests.RunTests());
        }

        /// <summary>
        /// Runs the tests.
        /// </summary>
        public void RunTests()
        {
            this.RunTests(Resources.MultipleTestsFailed);
        }

        /// <summary>
        /// Runs the tests with specific failure message and arguments.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="arguments">The arguments.</param>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "The point is to report exception failures.")]
        public void RunTests(string message, params object[] arguments)
        {
            var exceptions = new List<Exception>();
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
                Specify.Failure(exceptions, message, arguments);
            }
        }
    }
}