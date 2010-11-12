﻿//-----------------------------------------------------------------------------
// <copyright file="When_calling_Should_BeSubsetOf.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Test.Specificity.CollectionConstraintsSpecs
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Testing.Specificity;

    public static class When_calling_Should_BeSubsetOf
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
        public class with_superset : Scenario
        {
            protected override void Because()
            {
                SpecifyThat(Collection).Should.BeSubsetOf(Collection.Concat(new string[] { "xyzzy" }));
            }

            [TestMethod]
            public void Should_not_fail()
            {
                this.ShouldNotHaveFailed();
            }
        }

        [TestClass]
        public class with_subset : Scenario
        {
            protected override void Because()
            {
                SpecifyThat(Collection).Should.BeSubsetOf(Collection.Skip(1));
            }

            [TestMethod]
            public void Should_fail()
            {
                this.ShouldHaveFailed();
            }
        }

        [TestClass]
        public class with_subset_and_given_message : Scenario
        {
            protected override void Because()
            {
                SpecifyThat(Collection).Should.BeSubsetOf(Collection.Skip(1), "magic {0}", "xyzzy");
            }

            [TestMethod]
            public void Should_fail_with_message()
            {
                this.ShouldHaveFailed("magic xyzzy");
            }
        }

        [TestClass]
        public class with_superset_in_different_order : Scenario
        {
            protected override void Because()
            {
                SpecifyThat(Collection).Should.BeSubsetOf(Collection.Concat(new string[] { "xyzzy" }).Reverse());
            }

            [TestMethod]
            public void Should_not_fail()
            {
                this.ShouldNotHaveFailed();
            }
        }
    }
}
