//-----------------------------------------------------------------------------
// <copyright file="When_calling_Should_Not_BeTrue.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Test.Specificity.BooleanConstraintsSpecs
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Testing.Specificity;

    public static class When_calling_Should_Not_BeTrue
    {
        [TestClass]
        public class with_true : Scenario
        {
            protected override void Because()
            {
                SpecifyThat(true).Should.Not.BeTrue();
            }

            [TestMethod]
            public void Should_fail()
            {
                this.ShouldHaveFailed();
            }
        }

        [TestClass]
        public class with_false : Scenario
        {
            protected override void Because()
            {
                SpecifyThat(false).Should.Not.BeTrue();
            }

            [TestMethod]
            public void Should_not_fail()
            {
                this.ShouldNotHaveFailed();
            }
        }

        [TestClass]
        public class with_true_and_given_message : Scenario
        {
            protected override void Because()
            {
                SpecifyThat(true).Should.Not.BeTrue("magic {0}", "xyzzy");
            }

            [TestMethod]
            public void Should_fail_with_message()
            {
                this.ShouldHaveFailed("magic xyzzy");
            }
        }
    }
}
