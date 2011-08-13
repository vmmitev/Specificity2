//-----------------------------------------------------------------------------
// <copyright file="When_calling_Should_Not_BeSameAs.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Test.Specificity.ObjectConstrainsSpec
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Testing.Specificity;

    public static class When_calling_Should_Not_BeSameAs
    {
        private static object reference = new object();

        [TestClass]
        public class with_same_reference : TestScenario
        {
            public override void Because()
            {
                Specify.That(reference).Should.Not.BeSameAs(reference);
            }

            [TestMethod]
            public void Should_fail()
            {
                this.ShouldHaveFailed();
            }
        }

        [TestClass]
        public class with_different_references : TestScenario
        {
            public override void Because()
            {
                Specify.That(reference).Should.Not.BeSameAs(new object());
            }

            [TestMethod]
            public void Should_not_fail()
            {
                this.ShouldNotHaveFailed();
            }
        }

        [TestClass]
        public class with_same_reference_and_given_message : TestScenario
        {
            public override void Because()
            {
                Specify.That(reference).Should.Not.BeSameAs(reference, "magic {0}", "xyzzy");
            }

            [TestMethod]
            public void Should_fail()
            {
                this.ShouldHaveFailed("magic xyzzy");
            }
        }
    }
}