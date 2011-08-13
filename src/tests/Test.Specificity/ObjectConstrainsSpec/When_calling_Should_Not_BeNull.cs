//-----------------------------------------------------------------------------
// <copyright file="When_calling_Should_Not_BeNull.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Test.Specificity.ObjectConstrainsSpec
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Testing.Specificity;

    public static class When_calling_Should_Not_BeNull
    {
        [TestClass]
        public class with_null : TestScenario
        {
            public override void Because()
            {
                Specify.That<object>(null).Should.Not.BeNull();
            }

            [TestMethod]
            public void Should_fail()
            {
                this.ShouldHaveFailed();
            }
        }

        [TestClass]
        public class with_reference : TestScenario
        {
            public override void Because()
            {
                Specify.That(new object()).Should.Not.BeNull();
            }

            [TestMethod]
            public void Should_not_fail()
            {
                this.ShouldNotHaveFailed();
            }
        }

        [TestClass]
        public class with_null_and_given_message : TestScenario
        {
            public override void Because()
            {
                Specify.That<object>(null).Should.Not.BeNull("magic {0}", "xyzzy");
            }

            [TestMethod]
            public void Should_fail_with_message()
            {
                this.ShouldHaveFailed("magic xyzzy");
            }
        }
    }
}