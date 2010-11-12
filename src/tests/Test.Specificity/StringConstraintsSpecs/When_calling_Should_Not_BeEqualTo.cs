//-----------------------------------------------------------------------------
// <copyright file="When_calling_Should_Not_BeEqualTo.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Test.Specificity.StringConstraintsSpecs
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Testing.Specificity;

    public static class When_calling_Should_Not_BeEqualTo
    {
        [TestClass]
        public class with_equal_strings_using_Ordinal_comparison : Scenario
        {
            protected override void Because()
            {
                SpecifyThat("xyzzy").Should.Not.BeEqualTo("xyzzy", StringComparison.Ordinal);
            }

            [TestMethod]
            public void Should_fail()
            {
                this.ShouldHaveFailed();
            }
        }

        [TestClass]
        public class with_strings_that_differ_in_case_using_Ordinal_comparision : Scenario
        {
            protected override void Because()
            {
                SpecifyThat("xyzzy").Should.Not.BeEqualTo("XYZZY", StringComparison.Ordinal);
            }

            [TestMethod]
            public void Should_not_fail()
            {
                this.ShouldNotHaveFailed();
            }
        }

        [TestClass]
        public class with_string_that_differ_using_Ordinal_comparison : Scenario
        {
            protected override void Because()
            {
                SpecifyThat("xyzzy").Should.Not.BeEqualTo("magic", StringComparison.Ordinal);
            }

            [TestMethod]
            public void Should_not_fail()
            {
                this.ShouldNotHaveFailed();
            }
        }

        [TestClass]
        public class with_equal_strings_using_OrdinalIgnoreCase_comparison : Scenario
        {
            protected override void Because()
            {
                SpecifyThat("xyzzy").Should.Not.BeEqualTo("xyzzy", StringComparison.OrdinalIgnoreCase);
            }

            [TestMethod]
            public void Should_fail()
            {
                this.ShouldHaveFailed();
            }
        }

        [TestClass]
        public class with_strings_that_differ_in_case_using_OrdinalIgnoreCase_comparison : Scenario
        {
            protected override void Because()
            {
                SpecifyThat("xyzzy").Should.Not.BeEqualTo("XYZZY", StringComparison.OrdinalIgnoreCase);
            }

            [TestMethod]
            public void Should_fail()
            {
                this.ShouldHaveFailed();
            }
        }

        [TestClass]
        public class with_strings_that_differ_using_OrdinalIgnoreCase_comparison : Scenario
        {
            protected override void Because()
            {
                SpecifyThat("xyzzy").Should.Not.BeEqualTo("magic", StringComparison.OrdinalIgnoreCase);
            }

            [TestMethod]
            public void Should_not_fail()
            {
                this.ShouldNotHaveFailed();
            }
        }

        [TestClass]
        public class with_equal_strings_and_given_message : Scenario
        {
            protected override void Because()
            {
                SpecifyThat("xyzzy").Should.Not.BeEqualTo("xyzzy", StringComparison.Ordinal, "magic {0}", "xyzzy");
            }

            [TestMethod]
            public void Should_fail_with_message()
            {
                this.ShouldHaveFailed("magic xyzzy");
            }
        }
    }
}
