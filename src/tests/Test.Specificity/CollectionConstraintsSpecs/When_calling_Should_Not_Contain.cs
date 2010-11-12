﻿//-----------------------------------------------------------------------------
// <copyright file="When_calling_Should_Not_Contain.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Test.Specificity.CollectionConstraintsSpecs
{
    using System.Collections;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Testing.Specificity;

    public static class When_calling_Should_Not_Contain
    {
        public static IEnumerable Collection
        {
            get
            {
                yield return "foo";
                yield return "bar";
                yield return "baz";
            }
        }

        [TestClass]
        public class with_item_in_collection : Scenario
        {
            protected override void Because()
            {
                SpecifyThat(Collection).Should.Not.Contain("bar");
            }

            [TestMethod]
            public void Should_fail()
            {
                this.ShouldHaveFailed();
            }
        }

        [TestClass]
        public class with_item_not_in_collection : Scenario
        {
            protected override void Because()
            {
                SpecifyThat(Collection).Should.Not.Contain("xyzzy");
            }

            [TestMethod]
            public void Should_not_fail()
            {
                this.ShouldNotHaveFailed();
            }
        }

        [TestClass]
        public class with_item_in_collection_and_given_message : Scenario
        {
            protected override void Because()
            {
                SpecifyThat(Collection).Should.Not.Contain("bar", "magic {0}", "xyzzy");
            }

            [TestMethod]
            public void Should_fail_with_message()
            {
                this.ShouldHaveFailed("magic xyzzy");
            }
        }
    }
}
