//-----------------------------------------------------------------------------
// <copyright file="When_calling_Should_HaveNullItems.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Test.Specificity.CollectionConstraintsSpecs
{
    using System.Collections;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Testing.Specificity;

    public static class When_calling_Should_HaveNullItems
    {
        public static IEnumerable WithNulls
        {
            get
            {
                yield return "foo";
                yield return null;
                yield return "bar";
            }
        }

        public static IEnumerable WithoutNulls
        {
            get
            {
                yield return "foo";
                yield return "bar";
            }
        }

        [TestClass]
        public class with_collection_containing_null_items : TestScenario
        {
            public override void Because()
            {
                Specify.That(WithNulls).Should.HaveNullItems();
            }

            [TestMethod]
            public void Should_not_fail()
            {
                this.ShouldNotHaveFailed();
            }
        }

        [TestClass]
        public class with_collection_that_does_not_contain_null_items : TestScenario
        {
            public override void Because()
            {
                Specify.That(WithoutNulls).Should.HaveNullItems();
            }

            [TestMethod]
            public void Should_fail()
            {
                this.ShouldHaveFailed();
            }
        }

        [TestClass]
        public class with_collection_that_does_not_contain_null_items_and_given_message : TestScenario
        {
            public override void Because()
            {
                Specify.That(WithoutNulls).Should.HaveNullItems("magic {0}", "xyzzy");
            }

            [TestMethod]
            public void Should_fail_with_message()
            {
                this.ShouldHaveFailed("magic xyzzy");
            }
        }
    }
}