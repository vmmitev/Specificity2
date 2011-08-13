//-----------------------------------------------------------------------------
// <copyright file="When_calling_Should_BeEquivalentTo.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Test.Specificity.CollectionConstraintsSpecs
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Testing.Specificity;

    public static class When_calling_Should_BeEquivalentTo
    {
        public static IEnumerable<string> Collection
        {
            get
            {
                yield return "foo";
                yield return "bar";
                yield return "baz";
            }
        }

        [TestClass]
        public class with_same_reference : TestScenario
        {
            private IList<string> reference;

            public override void EstablishContext()
            {
                base.EstablishContext();
                this.reference = Collection.ToList();
            }

            public override void Because()
            {
                Specify.That(this.reference).Should.BeEquivalentTo(this.reference);
            }

            [TestMethod]
            public void Should_not_fail()
            {
                this.ShouldNotHaveFailed();
            }
        }

        [TestClass]
        public class with_different_references_of_equal_items : TestScenario
        {
            public override void Because()
            {
                Specify.That(Collection.ToList()).Should.BeEquivalentTo(Collection.ToList());
            }

            [TestMethod]
            public void Should_not_fail()
            {
                this.ShouldNotHaveFailed();
            }
        }

        [TestClass]
        public class with_collections_of_different_sizes : TestScenario
        {
            public override void Because()
            {
                Specify.That(Collection).Should.BeEquivalentTo(Collection.Skip(1));
            }

            [TestMethod]
            public void Should_fail()
            {
                this.ShouldHaveFailed();
            }
        }

        [TestClass]
        public class with_collections_with_same_items_in_different_order : TestScenario
        {
            public override void Because()
            {
                Specify.That(Collection).Should.BeEquivalentTo(Collection.Reverse());
            }

            [TestMethod]
            public void Should_fail()
            {
                this.ShouldHaveFailed();
            }
        }

        [TestClass]
        public class with_collections_that_are_not_equal_and_given_message : TestScenario
        {
            public override void Because()
            {
                Specify.That(Collection).Should.BeEquivalentTo(Collection.Skip(1), "magic {0}", "xyzzy");
            }

            [TestMethod]
            public void Should_fail_with_message()
            {
                this.ShouldHaveFailed("magic xyzzy");
            }
        }

        [TestClass]
        public class with_collections_with_same_items_in_different_order_and_ItemSort_Any_specified : TestScenario
        {
            public override void Because()
            {
                Specify.That(Collection).Should.BeEquivalentTo(Collection.Reverse(), ItemOrder.Any);
            }

            [TestMethod]
            public void Should_not_fail()
            {
                this.ShouldNotHaveFailed();
            }
        }
    }
}