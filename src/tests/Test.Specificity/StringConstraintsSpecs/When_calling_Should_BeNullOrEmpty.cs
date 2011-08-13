//-----------------------------------------------------------------------------
// <copyright file="When_calling_Should_BeNullOrEmpty.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Test.Specificity.StringConstraintsSpecs
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Testing.Specificity;

    public static class When_calling_Should_BeNullOrEmpty
    {
        [TestClass]
        public class with_null : TestScenario
        {
            public override void Because()
            {
                Specify.That<string>(null).Should.BeNullOrEmpty();
            }

            [TestMethod]
            public void Should_not_fail()
            {
                this.ShouldNotHaveFailed();
            }
        }

        [TestClass]
        public class with_empty : TestScenario
        {
            public override void Because()
            {
                Specify.That(string.Empty).Should.BeNullOrEmpty();
            }

            [TestMethod]
            public void Should_not_fail()
            {
                this.ShouldNotHaveFailed();
            }
        }

        [TestClass]
        public class with_non_empty_string : TestScenario
        {
            public override void Because()
            {
                Specify.That("xyzzy").Should.BeNullOrEmpty();
            }

            [TestMethod]
            public void Should_fail()
            {
                this.ShouldHaveFailed();
            }
        }

        [TestClass]
        public class with_non_empty_string_and_given_message : TestScenario
        {
            public override void Because()
            {
                Specify.That("xyzzy").Should.BeNullOrEmpty("magic {0}", "xyzzy");
            }

            [TestMethod]
            public void Should_fail_with_message()
            {
                this.ShouldHaveFailed("magic xyzzy");
            }
        }
    }
}