//-----------------------------------------------------------------------------
// <copyright file="When_calling_Should_BeEmpty.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Test.Specificity.CollectionConstraintsSpecs
{
    using System.Collections;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Testing.Specificity;

    public static class When_calling_Should_BeEmpty
    {
        public static IEnumerable EmptyEnumerable
        {
            get
            {
                yield break;
            }
        }

        public static IEnumerable NonEmptyEnumerable
        {
            get
            {
                yield return "foo";
                yield return "bar";
            }
        }

        [TestClass]
        public class with_empty_enumerable : Scenario
        {
            protected override void Because()
            {
                SpecifyThat(EmptyEnumerable).Should.BeEmpty();
            }

            [TestMethod]
            public void Should_not_fail()
            {
                this.ShouldNotHaveFailed();
            }
        }

        [TestClass]
        public class with_non_empty_enumerable : Scenario
        {
            protected override void Because()
            {
                SpecifyThat(NonEmptyEnumerable).Should.BeEmpty();
            }

            [TestMethod]
            public void Should_fail()
            {
                this.ShouldHaveFailed();
            }
        }

        [TestClass]
        public class with_non_empty_enumerable_and_given_message : Scenario
        {
            protected override void Because()
            {
                SpecifyThat(NonEmptyEnumerable).Should.BeEmpty("magic {0}", "xyzzy");
            }

            [TestMethod]
            public void Should_fail_with_message()
            {
                this.ShouldHaveFailed("magic xyzzy");
            }
        }
    }
}
