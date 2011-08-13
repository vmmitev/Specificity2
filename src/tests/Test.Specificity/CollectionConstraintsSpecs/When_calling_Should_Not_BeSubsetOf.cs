//-----------------------------------------------------------------------------
// <copyright file="When_calling_Should_Not_BeSubsetOf.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Test.Specificity.CollectionConstraintsSpecs
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Testing.Specificity;

    public static class When_calling_Should_Not_BeSubsetOf
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
        public class with_superset : TestScenario
        {
            public override void Because()
            {
                Specify.That(Collection).Should.Not.BeSubsetOf(Collection.Concat(new string[] { "xyzzy" }));
            }

            [TestMethod]
            public void Should_fail()
            {
                this.ShouldHaveFailed();
            }
        }

        [TestClass]
        public class with_subset : TestScenario
        {
            public override void Because()
            {
                Specify.That(Collection).Should.Not.BeSubsetOf(Collection.Skip(1));
            }

            [TestMethod]
            public void Should_not_fail()
            {
                this.ShouldNotHaveFailed();
            }
        }

        [TestClass]
        public class with_superset_and_given_message : TestScenario
        {
            public override void Because()
            {
                Specify.That(Collection).Should.Not.BeSubsetOf(Collection.Concat(new string[] { "xyzzy" }), "magic {0}", "xyzzy");
            }

            [TestMethod]
            public void Should_fail_with_message()
            {
                this.ShouldHaveFailed("magic xyzzy");
            }
        }

        [TestClass]
        public class with_subset_in_different_order : TestScenario
        {
            public override void Because()
            {
                Specify.That(Collection).Should.Not.BeSubsetOf(Collection.Skip(1).Reverse());
            }

            [TestMethod]
            public void Should_not_fail()
            {
                this.ShouldNotHaveFailed();
            }
        }
    }
}