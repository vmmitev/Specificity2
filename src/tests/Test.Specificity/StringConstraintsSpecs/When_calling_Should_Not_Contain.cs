﻿//-----------------------------------------------------------------------------
// <copyright file="When_calling_Should_Not_Contain.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Test.Specificity.StringConstraintsSpecs
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Testing.Specificity;

    public static class When_calling_Should_Not_Contain
    {
        [TestClass]
        public class with_substring : TestScenario
        {
            public override void Because()
            {
                Specify.That("foo bar").Should.Not.Contain("bar");
            }

            [TestMethod]
            public void Should_fail()
            {
                this.ShouldHaveFailed();
            }
        }

        [TestClass]
        public class with_string_not_contained_in_actual_string : TestScenario
        {
            public override void Because()
            {
                Specify.That("foo bar").Should.Not.Contain("baz");
            }

            [TestMethod]
            public void Should_not_fail()
            {
                this.ShouldNotHaveFailed();
            }
        }

        [TestClass]
        public class with_substring_differing_in_case_using_OrdinalIgnoreCase_comparison : TestScenario
        {
            public override void Because()
            {
                Specify.That("foo bar").Should.Not.Contain("BAR", StringComparison.OrdinalIgnoreCase);
            }

            [TestMethod]
            public void Should_fail()
            {
                this.ShouldHaveFailed();
            }
        }

        [TestClass]
        public class with_substring_and_given_message : TestScenario
        {
            public override void Because()
            {
                Specify.That("foo bar").Should.Not.Contain("bar", "magic {0}", "xyzzy");
            }

            [TestMethod]
            public void Should_fail_with_message()
            {
                this.ShouldHaveFailed("magic xyzzy");
            }
        }
    }
}