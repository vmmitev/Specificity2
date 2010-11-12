//-----------------------------------------------------------------------------
// <copyright file="When_calling_Should_HaveOnlyItemsOfType.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Test.Specificity.CollectionConstraintsSpecs
{
    using System.Collections;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Testing.Specificity;

    public static class When_calling_Should_HaveOnlyItemsOfType
    {
        public static IEnumerable AllStrings
        {
            get
            {
                yield return "foo";
                yield return "bar";
            }
        }

        public static IEnumerable Mixed
        {
            get
            {
                yield return "foo";
                yield return new object();
            }
        }

        [TestClass]
        public class with_collection_of_specified_type : Scenario
        {
            protected override void Because()
            {
                SpecifyThat(AllStrings).Should.HaveOnlyItemsOfType(typeof(string));
            }

            [TestMethod]
            public void Should_not_fail()
            {
                this.ShouldNotHaveFailed();
            }
        }

        [TestClass]
        public class with_collection_of_mixed_types : Scenario
        {
            protected override void Because()
            {
                SpecifyThat(Mixed).Should.HaveOnlyItemsOfType(typeof(string));
            }

            [TestMethod]
            public void Should_fail()
            {
                this.ShouldHaveFailed();
            }
        }

        [TestClass]
        public class with_collection_of_mixed_types_and_given_message : Scenario
        {
            protected override void Because()
            {
                SpecifyThat(Mixed).Should.HaveOnlyItemsOfType(typeof(string), "magic {0}", "xyzzy");
            }

            [TestMethod]
            public void Should_fail_with_message()
            {
                this.ShouldHaveFailed("magic xyzzy");
            }
        }
    }
}
