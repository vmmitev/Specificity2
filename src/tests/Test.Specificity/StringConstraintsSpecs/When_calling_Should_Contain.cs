//-----------------------------------------------------------------------------
// <copyright file="When_calling_Should_Contain.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Test.Specificity.StringConstraintsSpecs
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Testing.Specificity;

    public static class When_calling_Should_Contain
    {
        [TestClass]
        public class with_substring : Scenario
        {
            protected override void Because()
            {
                SpecifyThat("foo bar").Should.Contain("bar");
            }

            [TestMethod]
            public void Should_not_fail()
            {
                this.ShouldNotHaveFailed();
            }
        }

        [TestClass]
        public class with_string_not_contained_in_actual_string : Scenario
        {
            protected override void Because()
            {
                SpecifyThat("foo bar").Should.Contain("baz");
            }

            [TestMethod]
            public void Should_fail()
            {
                this.ShouldHaveFailed();
            }
        }

        [TestClass]
        public class with_substring_differing_in_case_using_OrdinalIgnoreCase_comparison : Scenario
        {
            protected override void Because()
            {
                SpecifyThat("foo bar").Should.Contain("BAR", StringComparison.OrdinalIgnoreCase);
            }

            [TestMethod]
            public void Should_not_fail()
            {
                this.ShouldNotHaveFailed();
            }
        }

        [TestClass]
        public class with_string_not_contained_in_actual_string_and_given_message : Scenario
        {
            protected override void Because()
            {
                SpecifyThat("foo bar").Should.Contain("baz", "magic {0}", "xyzzy");
            }

            [TestMethod]
            public void Should_fail_with_message()
            {
                this.ShouldHaveFailed("magic xyzzy");
            }
        }
    }
}
