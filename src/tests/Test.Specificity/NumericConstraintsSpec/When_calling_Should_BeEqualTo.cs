//-----------------------------------------------------------------------------
// <copyright file="When_calling_Should_BeEqualTo.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Test.Specificity.NumericConstraintsSpec
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Testing.Specificity;

    public static class When_calling_Should_BeEqualTo
    {
        [TestClass]
        public class with_double_within_postive_delta : TestScenario
        {
            public override void Because()
            {
                Specify.That(10.0d).Should.BeEqualTo(10.2d, 0.5d);
            }

            [TestMethod]
            public void Should_not_fail()
            {
                this.ShouldNotHaveFailed();
            }
        }

        [TestClass]
        public class with_double_within_negative_delta : TestScenario
        {
            public override void Because()
            {
                Specify.That(10.0d).Should.BeEqualTo(9.8d, 0.5d);
            }

            [TestMethod]
            public void Should_not_fail()
            {
                this.ShouldNotHaveFailed();
            }
        }

        [TestClass]
        public class with_double_not_within_delta : TestScenario
        {
            public override void Because()
            {
                Specify.That(10.0d).Should.BeEqualTo(9.4d, 0.5d);
            }

            [TestMethod]
            public void Should_fail()
            {
                this.ShouldHaveFailed();
            }
        }

        [TestClass]
        public class with_double_not_within_delta_and_given_message : TestScenario
        {
            public override void Because()
            {
                Specify.That(10.0d).Should.BeEqualTo(9.4d, 0.5d, "magic {0}", "xyzzy");
            }

            [TestMethod]
            public void Should_fail()
            {
                this.ShouldHaveFailed("magic xyzzy");
            }
        }

        [TestClass]
        public class with_float_within_postive_delta : TestScenario
        {
            public override void Because()
            {
                Specify.That(10.0f).Should.BeEqualTo(10.2f, 0.5f);
            }

            [TestMethod]
            public void Should_not_fail()
            {
                this.ShouldNotHaveFailed();
            }
        }

        [TestClass]
        public class with_float_within_negative_delta : TestScenario
        {
            public override void Because()
            {
                Specify.That(10.0f).Should.BeEqualTo(9.8f, 0.5f);
            }

            [TestMethod]
            public void Should_not_fail()
            {
                this.ShouldNotHaveFailed();
            }
        }

        [TestClass]
        public class with_float_not_within_delta : TestScenario
        {
            public override void Because()
            {
                Specify.That(10.0f).Should.BeEqualTo(9.4f, 0.5f);
            }

            [TestMethod]
            public void Should_fail()
            {
                this.ShouldHaveFailed();
            }
        }

        [TestClass]
        public class with_float_not_within_delta_and_given_message : TestScenario
        {
            public override void Because()
            {
                Specify.That(10.0f).Should.BeEqualTo(9.4f, 0.5f, "magic {0}", "xyzzy");
            }

            [TestMethod]
            public void Should_fail()
            {
                this.ShouldHaveFailed("magic xyzzy");
            }
        }
    }
}