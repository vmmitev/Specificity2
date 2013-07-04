//-----------------------------------------------------------------------------
// <copyright file="When_calling_Should_Not_BeEqualTo.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Test.Specificity.ObjectConstrainsSpec
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Testing.Specificity;

    public static class When_calling_Should_Not_BeEqualTo
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
            [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1126:PrefixCallsCorrectly", Justification = "Reviewed.")]
            public override void Because()
            {
                Specify.That(reference).Should.Not.BeEqualTo(reference);
            }

            [TestMethod]
            public void Should_fail()
            {
                this.ShouldHaveFailed();
            }
        }

        [TestClass]
        public class with_equal_objects : TestScenario
        {
            public override void Because()
            {
                Specify.That(reference).Should.Not.BeEqualTo(reference.Clone());
            }

            [TestMethod]
            public void Should_fail()
            {
                this.ShouldHaveFailed();
            }
        }

        [TestClass]
        public class with_objects_that_are_not_equal : TestScenario
        {
            public override void Because()
            {
                Specify.That(reference).Should.Not.BeEqualTo(new TestObject("xyzzy"));
            }

            [TestMethod]
            public void Should_not_fail()
            {
                this.ShouldNotHaveFailed();
            }
        }

        [TestClass]
        public class with_equal_objects_and_given_message : TestScenario
        {
            public override void Because()
            {
                Specify.That(reference).Should.Not.BeEqualTo(reference.Clone(), "magic {0}", "xyzzy");
            }

            [TestMethod]
            public void Should_fail()
            {
                this.ShouldHaveFailed("magic xyzzy");
            }
        }
    }
}