//-----------------------------------------------------------------------------
// <copyright file="When_calling_Should_Not_HaveUniqueItems.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Test.Specificity.CollectionConstraintsSpecs
{
    using System.Collections;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Testing.Specificity;

    public static class When_calling_Should_Not_HaveUniqueItems
    {
        public static IEnumerable Unique
        {
            get
            {
                yield return "foo";
                yield return "bar";
                yield return "baz";
            }
        }

        public static IEnumerable NonUnique
        {
            get
            {
                yield return "foo";
                yield return "bar";
                yield return "foo";
            }
        }

        public static IEnumerable MultipleNulls
        {
            get
            {
                yield return null;
                yield return null;
            }
        }

        [TestClass]
        public class with_collection_of_unique_items : TestScenario
        {
            public override void Because()
            {
                Specify.That(Unique).Should.Not.HaveUniqueItems();
            }

            [TestMethod]
            public void Should_fail()
            {
                this.ShouldHaveFailed();
            }
        }

        [TestClass]
        public class with_collection_containing_duplicate_items : TestScenario
        {
            public override void Because()
            {
                Specify.That(NonUnique).Should.Not.HaveUniqueItems();
            }

            [TestMethod]
            public void Should_not_fail()
            {
                this.ShouldNotHaveFailed();
            }
        }

        [TestClass]
        public class with_collection_of_unique_items_and_given_message : TestScenario
        {
            public override void Because()
            {
                Specify.That(Unique).Should.Not.HaveUniqueItems("magic {0}", "xyzzy");
            }

            [TestMethod]
            public void Should_fail_with_message()
            {
                this.ShouldHaveFailed("magic xyzzy");
            }
        }

        [TestClass]
        public class with_collection_containing_multiple_null_references : TestScenario
        {
            public override void Because()
            {
                Specify.That(MultipleNulls).Should.Not.HaveUniqueItems();
            }

            [TestMethod]
            public void Should_not_fail()
            {
                this.ShouldNotHaveFailed();
            }
        }
    }
}