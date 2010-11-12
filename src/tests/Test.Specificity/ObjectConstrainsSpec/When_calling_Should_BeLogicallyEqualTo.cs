//-----------------------------------------------------------------------------
// <copyright file="When_calling_Should_BeLogicallyEqualTo.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Test.Specificity.ObjectConstrainsSpec
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Testing.Specificity;

    public static class When_calling_Should_BeLogicallyEqualTo
    {
        public class TestObject
        {
            public TestObject(string data)
            {
                this.Data = data;
            }

            public string Data { get; private set; }
        }

        [TestClass]
        public class with_objects_that_are_logically_equal : Scenario
        {
            protected override void Because()
            {
                SpecifyThat(new TestObject("xyzzy")).Should.BeLogicallyEqualTo(new TestObject("xyzzy"));
            }

            [TestMethod]
            public void Should_not_fail()
            {
                this.ShouldNotHaveFailed();
            }
        }

        [TestClass]
        public class with_objects_that_are_not_logically_equal : Scenario
        {
            protected override void Because()
            {
                SpecifyThat(new TestObject("magic")).Should.BeLogicallyEqualTo(new TestObject("xyzzy"));
            }

            [TestMethod]
            public void Should_fail()
            {
                this.ShouldHaveFailed();
            }
        }

        [TestClass]
        public class with_objects_that_are_not_logically_equal_and_given_message : Scenario
        {
            protected override void Because()
            {
                SpecifyThat(new TestObject("magic")).Should.BeLogicallyEqualTo(new TestObject("xyzzy"), "magic {0}", "xyzzy");
            }

            [TestMethod]
            public void Should_fail()
            {
                this.ShouldHaveFailed("magic xyzzy");
            }
        }
    }
}
