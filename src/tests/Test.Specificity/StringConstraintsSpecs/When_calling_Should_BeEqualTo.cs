//-----------------------------------------------------------------------------
// <copyright file="When_calling_Should_BeEqualTo.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Test.Specificity.StringConstraintsSpecs
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Testing.Specificity;

    public static class When_calling_Should_BeEqualTo
    {
        [TestClass]
        public class with_equal_strings_using_Ordinal_comparison : TestScenario
        {
            public override void Because()
            {
                Specify.That("xyzzy").Should.BeEqualTo("xyzzy", StringComparison.Ordinal);
            }

            [TestMethod]
            public void Should_not_fail()
            {
                this.ShouldNotHaveFailed();
            }
        }

        [TestClass]
        public class with_strings_that_differ_in_case_using_Ordinal_comparision : TestScenario
        {
            public override void Because()
            {
                Specify.That("xyzzy").Should.BeEqualTo("XYZZY", StringComparison.Ordinal);
            }

            [TestMethod]
            public void Should_fail()
            {
                this.ShouldHaveFailed();
            }
        }

        [TestClass]
        public class with_string_that_differ_using_Ordinal_comparison : TestScenario
        {
            public override void Because()
            {
                Specify.That("xyzzy").Should.BeEqualTo("magic", StringComparison.Ordinal);
            }

            [TestMethod]
            public void Should_fail()
            {
                this.ShouldHaveFailed();
            }
        }

        [TestClass]
        public class with_equal_strings_using_OrdinalIgnoreCase_comparison : TestScenario
        {
            public override void Because()
            {
                Specify.That("xyzzy").Should.BeEqualTo("xyzzy", StringComparison.OrdinalIgnoreCase);
            }

            [TestMethod]
            public void Should_not_fail()
            {
                this.ShouldNotHaveFailed();
            }
        }

        [TestClass]
        public class with_strings_that_differ_in_case_using_OrdinalIgnoreCase_comparison : TestScenario
        {
            public override void Because()
            {
                Specify.That("xyzzy").Should.BeEqualTo("XYZZY", StringComparison.OrdinalIgnoreCase);
            }

            [TestMethod]
            public void Should_not_fail()
            {
                this.ShouldNotHaveFailed();
            }
        }

        [TestClass]
        public class with_strings_that_differ_using_OrdinalIgnoreCase_comparison : TestScenario
        {
            public override void Because()
            {
                Specify.That("xyzzy").Should.BeEqualTo("magic", StringComparison.OrdinalIgnoreCase);
            }

            [TestMethod]
            public void Should_fail()
            {
                this.ShouldHaveFailed();
            }
        }

        [TestClass]
        public class with_strings_that_differ_and_given_message : TestScenario
        {
            public override void Because()
            {
                Specify.That("xyzzy").Should.BeEqualTo("magic", StringComparison.Ordinal, "magic {0}", "xyzzy");
            }

            [TestMethod]
            public void Should_fail_with_message()
            {
                this.ShouldHaveFailed("magic xyzzy");
            }
        }
    }
}