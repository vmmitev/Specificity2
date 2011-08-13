//-----------------------------------------------------------------------------
// <copyright file="When_calling_Should_Not_StartWith.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Test.Specificity.StringConstraintsSpecs
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Testing.Specificity;

    public static class When_calling_Should_Not_StartWith
    {
        [TestClass]
        public class with_substring_found_at_start : TestScenario
        {
            public override void Because()
            {
                Specify.That("foo bar").Should.Not.StartWith("foo");
            }

            [TestMethod]
            public void Should_fail()
            {
                this.ShouldHaveFailed();
            }
        }

        [TestClass]
        public class with_string_not_found_at_start : TestScenario
        {
            public override void Because()
            {
                Specify.That("foo bar").Should.Not.StartWith("baz");
            }

            [TestMethod]
            public void Should_not_fail()
            {
                this.ShouldNotHaveFailed();
            }
        }

        [TestClass]
        public class with_substring_found_at_start_and_given_message : TestScenario
        {
            public override void Because()
            {
                Specify.That("foo bar").Should.Not.StartWith("foo", "magic {0}", "xyzzy");
            }

            [TestMethod]
            public void Should_fail_with_message()
            {
                this.ShouldHaveFailed("magic xyzzy");
            }
        }
    }
}