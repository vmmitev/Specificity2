//-----------------------------------------------------------------------------
// <copyright file="When_calling_Should_Not_Match.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Test.Specificity.StringConstraintsSpecs
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Testing.Specificity;

    public static class When_calling_Should_Not_Match
    {
        [TestClass]
        public class with_pattern_that_matches : Scenario
        {
            protected override void Because()
            {
                SpecifyThat("xyzzy").Should.Not.Match("xy.*");
            }

            [TestMethod]
            public void Should_fail()
            {
                this.ShouldHaveFailed();
            }
        }

        [TestClass]
        public class with_pattern_that_does_not_match : Scenario
        {
            protected override void Because()
            {
                SpecifyThat("xyzzy").Should.Not.Match("a+");
            }

            [TestMethod]
            public void Should_not_fail()
            {
                this.ShouldNotHaveFailed();
            }
        }

        [TestClass]
        public class with_pattern_that_matches_and_given_message : Scenario
        {
            protected override void Because()
            {
                SpecifyThat("xyzzy").Should.Not.Match("xy.*", "magic {0}", "xyzzy");
            }

            [TestMethod]
            public void Should_fail_with_message()
            {
                this.ShouldHaveFailed("magic xyzzy");
            }
        }
    }
}
