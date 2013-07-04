//-----------------------------------------------------------------------------
// <copyright file="When_calling_Should_Not_BeEquivalentTo.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Test.Specificity.CollectionConstraintsSpecs
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Testing.Specificity;

    public static class When_calling_Should_Not_BeEquivalentTo
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
            private IList reference;

            public override void EstablishContext()
            {
                base.EstablishContext();
                this.reference = Collection.ToList();
            }

            public override void Because()
            {
                Specify.That<ICollection>(this.reference).Should.Not.BeEquivalentTo(this.reference);
            }

            [TestMethod]
            public void Should_fail()
            {
                this.ShouldHaveFailed();
            }
        }

        [TestClass]
        public class with_different_references_of_equal_items : TestScenario
        {
            public override void Because()
            {
                Specify.That(Collection.ToList()).Should.Not.BeEquivalentTo(Collection.ToList());
            }

            [TestMethod]
            public void Should_fail()
            {
                this.ShouldHaveFailed();
            }
        }

        [TestClass]
        public class with_collections_of_different_sizes : TestScenario
        {
            public override void Because()
            {
                Specify.That(Collection).Should.Not.BeEquivalentTo(Collection.Skip(1));
            }

            [TestMethod]
            public void Should_not_fail()
            {
                this.ShouldNotHaveFailed();
            }
        }

        [TestClass]
        public class with_collections_with_same_items_in_different_order : TestScenario
        {
            public override void Because()
            {
                Specify.That(Collection).Should.Not.BeEquivalentTo(Collection.Reverse());
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
            [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1126:PrefixCallsCorrectly", Justification = "Reviewed.")]
            public override void Because()
            {
                Specify.That(Collection).Should.Not.BeEquivalentTo(Collection, "magic {0}", "xyzzy");
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
                Specify.That(Collection).Should.Not.BeEquivalentTo(Collection.Reverse(), ItemOrder.Any);
            }

            [TestMethod]
            public void Should_fail()
            {
                this.ShouldHaveFailed();
            }
        }
    }
}