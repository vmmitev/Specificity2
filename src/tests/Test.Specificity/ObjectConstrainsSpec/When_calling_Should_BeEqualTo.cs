//-----------------------------------------------------------------------------
// <copyright file="When_calling_Should_BeEqualTo.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Test.Specificity.ObjectConstrainsSpec
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Testing.Specificity;

    public static class When_calling_Should_BeEqualTo
    {
        private static TestObject reference = new TestObject("magic");

        public sealed class TestObject : IEquatable<TestObject>, ICloneable
        {
            private readonly string data;

            public TestObject(string data)
            {
                this.data = data;
            }

            public bool Equals(TestObject other)
            {
                return this.data.Equals(other.data);
            }

            public override bool Equals(object obj)
            {
                TestObject other = obj as TestObject;
                if (other == null)
                {
                    return false;
                }

                return this.Equals(other);
            }

            public override int GetHashCode()
            {
                return this.data.GetHashCode();
            }

            public object Clone()
            {
                return new TestObject(this.data);
            }
        }

        [TestClass]
        public class with_same_reference : TestScenario
        {
            public override void Because()
            {
                Specify.That(reference).Should.BeEqualTo(reference);
            }

            [TestMethod]
            public void Should_not_fail()
            {
                this.ShouldNotHaveFailed();
            }
        }

        [TestClass]
        public class with_equal_objects : TestScenario
        {
            public override void Because()
            {
                Specify.That(reference).Should.BeEqualTo(reference.Clone());
            }

            [TestMethod]
            public void Should_not_fail()
            {
                this.ShouldNotHaveFailed();
            }
        }

        [TestClass]
        public class with_objects_that_are_not_equal : TestScenario
        {
            public override void Because()
            {
                Specify.That(reference).Should.BeEqualTo(new TestObject("xyzzy"));
            }

            [TestMethod]
            public void Should_fail()
            {
                this.ShouldHaveFailed();
            }
        }

        [TestClass]
        public class with_objects_that_are_not_equal_ang_given_message : TestScenario
        {
            public override void Because()
            {
                Specify.That(reference).Should.BeEqualTo(new TestObject("xyzzy"), "magic {0}", "xyzzy");
            }

            [TestMethod]
            public void Should_fail()
            {
                this.ShouldHaveFailed("magic xyzzy");
            }
        }
    }
}
