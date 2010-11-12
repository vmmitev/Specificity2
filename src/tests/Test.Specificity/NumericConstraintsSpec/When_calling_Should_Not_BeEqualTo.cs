//-----------------------------------------------------------------------------
// <copyright file="When_calling_Should_Not_BeEqualTo.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Test.Specificity.NumericConstraintsSpec
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Testing.Specificity;

    public static class When_calling_Should_Not_BeEqualTo
    {
        [TestClass]
        public class with_double_within_postive_delta : Scenario
        {
            protected override void Because()
            {
                SpecifyThat(10.0d).Should.Not.BeEqualTo(10.2d, 0.5d);
            }

            [TestMethod]
            public void Should_fail()
            {
                this.ShouldHaveFailed();
            }
        }

        [TestClass]
        public class with_double_within_negative_delta : Scenario
        {
            protected override void Because()
            {
                SpecifyThat(10.0d).Should.Not.BeEqualTo(9.8d, 0.5d);
            }

            [TestMethod]
            public void Should_fail()
            {
                this.ShouldHaveFailed();
            }
        }

        [TestClass]
        public class with_double_not_within_delta : Scenario
        {
            protected override void Because()
            {
                SpecifyThat(10.0d).Should.Not.BeEqualTo(9.4d, 0.5d);
            }

            [TestMethod]
            public void Should_not_fail()
            {
                this.ShouldNotHaveFailed();
            }
        }

        [TestClass]
        public class with_double_within_delta_and_given_message : Scenario
        {
            protected override void Because()
            {
                SpecifyThat(10.0d).Should.Not.BeEqualTo(9.8d, 0.5d, "magic {0}", "xyzzy");
            }

            [TestMethod]
            public void Should_fail()
            {
                this.ShouldHaveFailed("magic xyzzy");
            }
        }

        [TestClass]
        public class with_float_within_postive_delta : Scenario
        {
            protected override void Because()
            {
                SpecifyThat(10.0f).Should.Not.BeEqualTo(10.2f, 0.5f);
            }

            [TestMethod]
            public void Should_fail()
            {
                this.ShouldHaveFailed();
            }
        }

        [TestClass]
        public class with_float_within_negative_delta : Scenario
        {
            protected override void Because()
            {
                SpecifyThat(10.0f).Should.Not.BeEqualTo(9.8f, 0.5f);
            }

            [TestMethod]
            public void Should_fail()
            {
                this.ShouldHaveFailed();
            }
        }

        [TestClass]
        public class with_float_not_within_delta : Scenario
        {
            protected override void Because()
            {
                SpecifyThat(10.0f).Should.Not.BeEqualTo(9.4f, 0.5f);
            }

            [TestMethod]
            public void Should_not_fail()
            {
                this.ShouldNotHaveFailed();
            }
        }

        [TestClass]
        public class with_float_within_delta_and_given_message : Scenario
        {
            protected override void Because()
            {
                SpecifyThat(10.0f).Should.Not.BeEqualTo(9.8f, 0.5f, "magic {0}", "xyzzy");
            }

            [TestMethod]
            public void Should_fail()
            {
                this.ShouldHaveFailed("magic xyzzy");
            }
        }
    }
}
