//-----------------------------------------------------------------------------
// <copyright file="CollectionAssertionsTests.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Testing.SpecificityTests
{
    using System.Collections;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Testing.Specificity;
    using System.Linq;

    [TestClass]
    public class CollectionAssertionsTests
    {
        [TestMethod]
        public void ShouldBeEmpty_GivenEmptyCollection_ShouldNotFail()
        {
            Verify.That(() => Specify.That(Enumerable.Empty<int>()).Should.BeEmpty()).ShouldNotFail();
        }

        [TestMethod]
        public void ShouldBeEmtpy_GivenNonEmptyCollection_ShouldFail()
        {
            Verify.That(() => Specify.That(Enumerable.Repeat<int>(1, 1)).Should.BeEmpty()).ShouldFail();
        }

        [TestMethod]
        public void ShouldNotBeEmpty_GivenEmptyCollection_ShouldFail()
        {
            Verify.That(() => Specify.That(Enumerable.Empty<int>()).Should.Not.BeEmpty()).ShouldFail();
        }

        [TestMethod]
        public void ShouldNotBeEmpty_GivenNonEmptyCollection_ShouldNotFail()
        {
            Verify.That(() => Specify.That(Enumerable.Repeat(1, 1)).Should.Not.BeEmpty()).ShouldNotFail();
        }

        [TestMethod]
        public void ShouldHaveOnlyItemsOfType_GivenAllElementsOfSpecifiedType_ShouldNotFail()
        {
            Verify.That(() => Specify.That(Enumerable.Repeat<object>(1, 4)).Should.HaveOnlyItemsOfType(typeof(int))).ShouldNotFail();
        }

        [TestMethod]
        public void ShouldHaveOnlyItemsOfType_GivenElementsOfDifferentType_ShouldFail()
        {
            Verify.That(() => Specify.That(new object[] { 1, 2, 5.0 }).Should.HaveOnlyItemsOfType(typeof(int))).ShouldFail();
        }

        [TestMethod]
        public void ShouldNotHaveOnlyItemsOfType_GivenAllElementsOfSpecifiedType_ShouldFail()
        {
            Verify.That(() => Specify.That(Enumerable.Repeat<object>(1, 4)).Should.Not.HaveOnlyItemsOfType(typeof(int))).ShouldFail();
        }

        [TestMethod]
        public void ShouldNotHaveOnlyItemsOfType_GivenElementsOfDifferentType_ShouldNotFail()
        {
            Verify.That(() => Specify.That(new object[] { 1, 2, 5.0 }).Should.Not.HaveOnlyItemsOfType(typeof(int))).ShouldNotFail();
        }

        [TestMethod]
        public void LegacyShouldBeEmpty_GivenEmptyCollection_ShouldNotFail()
        {
            Verify.That(() => Specify.That(new int[] { }).ShouldBeEmpty()).ShouldNotFail();
        }

        [TestMethod]
        public void LegacyShouldBeEmpty_GivenNonEmptyCollection_ShouldFail()
        {
            Verify.That(() => Specify.That(new int[] { 1 }).ShouldBeEmpty()).ShouldFail();
        }

        [TestMethod]
        public void LegacyShouldNotBeEmpty_GivenEmptyCollection_ShouldFail()
        {
            Verify.That(() => Specify.That(new int[] { }).ShouldNotBeEmpty()).ShouldFail();
        }

        [TestMethod]
        public void LegacyShouldNotBeEmpty_GivenNonEmptyCollection_ShouldNotFail()
        {
            Verify.That(() => Specify.That(new int[] { 1 }).ShouldNotBeEmpty()).ShouldNotFail();
        }

        [TestMethod]
        public void LegacyShouldOnlyHaveItemsOfType_GivenAllElementsOfSpecifiedType_ShouldNotFail()
        {
            Verify.That(() => Specify.That(new object[] { 1, 2, 5 }).ShouldOnlyHaveItemsOfType(typeof(int))).ShouldNotFail();
        }

        [TestMethod]
        public void LegacyShouldOnlyHaveItemsOfType_GivenElementsOfDifferentType_ShouldFail()
        {
            Verify.That(() => Specify.That(new object[] { 1, 2, 5.0 }).ShouldOnlyHaveItemsOfType(typeof(int))).ShouldFail();
        }

        [TestMethod]
        public void ShouldNotHaveNullItems_GivenNonNullItems_ShouldNotFail()
        {
            Specify.ThatAction(delegate
            {
                Specify.That(new string[] { "foo", "bar" }).ShouldNotHaveNullItems();
            }).ShouldNotHaveThrown();
        }

        [TestMethod]
        public void ShouldNotHaveNullItems_GivenNullItems_ShouldFail()
        {
            Specify.ThatAction(delegate
            {
                Specify.That(new string[] { "foo", "bar", null }).ShouldNotHaveNullItems();
            }).ShouldHaveThrown(typeof(ConstraintFailedException));
        }

        [TestMethod]
        public void ShouldHaveUniqueItems_GivenUniqueItems_ShouldNotFail()
        {
            Specify.ThatAction(delegate
            {
                Specify.That(new string[] { "foo", "bar", "baz" }).ShouldHaveUniqueItems();
            }).ShouldNotHaveThrown();
        }

        [TestMethod]
        public void ShouldHaveUniqueItems_GivenNonUniqueItems_ShouldFail()
        {
            Specify.ThatAction(delegate
            {
                Specify.That(new string[] { "foo", "bar", "baz", "foo" }).ShouldHaveUniqueItems();
            }).ShouldHaveThrown(typeof(ConstraintFailedException));
        }

        [TestMethod]
        public void ShouldBeEqualTo_GivenEqualCollections_ShouldNotFail()
        {
            Specify.ThatAction(delegate
            {
                Specify.That(new int[] { 1, 2, 5 }).ShouldBeEqualTo(new int[] { 1, 2, 5 }, Comparer<int>.Default);
            }).ShouldNotHaveThrown();
        }

        [TestMethod]
        public void ShouldBeEqualTo_GivenNonEqualCollections_ShouldFail()
        {
            Specify.ThatAction(delegate
            {
                Specify.That(new int[] { 1, 2, 5 }).ShouldBeEqualTo(new int[] { 1, 2, 8 }, Comparer<int>.Default);
            }).ShouldHaveThrown(typeof(ConstraintFailedException));
        }

        [TestMethod]
        public void ShouldNotBeEqualTo_GivenEqualCollections_ShouldFail()
        {
            Specify.ThatAction(delegate
            {
                Specify.That(new int[] { 1, 2, 5 }).ShouldNotBeEqualTo(new int[] { 1, 2, 5 }, Comparer<int>.Default);
            }).ShouldHaveThrown(typeof(ConstraintFailedException));
        }

        [TestMethod]
        public void ShouldNotBeEqualTo_GivenNonEqualCollections_ShouldNotFail()
        {
            Specify.ThatAction(delegate
            {
                Specify.That(new int[] { 1, 2, 5 }).ShouldNotBeEqualTo(new int[] { 1, 2, 8 }, Comparer<int>.Default);
            }).ShouldNotHaveThrown();
        }

        [TestMethod]
        public void ShouldBeEquivalentTo_GivenSameCollection_ShouldNotFail()
        {
            Specify.ThatAction(delegate
            {
                ArrayList list = new ArrayList();
                Specify.That(list).ShouldBeEquivalentTo(list);
            }).ShouldNotHaveThrown();
        }

        [TestMethod]
        public void ShouldBeEquivalentTo_GivenEqualCollections_ShouldNotFail()
        {
            Specify.ThatAction(delegate
            {
                ArrayList list1 = new ArrayList();
                list1.Add("foo");
                ArrayList list2 = new ArrayList();
                list2.Add("foo");
                Specify.That(list1).ShouldBeEquivalentTo(list2);
            }).ShouldNotHaveThrown();
        }

        [TestMethod]
        public void ShouldBeEquivalentTo_GivenEquivalentCollections_ShouldNotFail()
        {
            Specify.ThatAction(delegate
            {
                ArrayList list1 = new ArrayList();
                list1.Add("foo");
                list1.Add("bar");
                ArrayList list2 = new ArrayList();
                list2.Add("bar");
                list2.Add("foo");
                Specify.That(list1).ShouldBeEquivalentTo(list2);
            }).ShouldNotHaveThrown();
        }

        [TestMethod]
        public void ShouldBeEquivalentTo_GivenCollectionsOfDifferentLength_ShouldFail()
        {
            Specify.ThatAction(delegate
            {
                ArrayList list1 = new ArrayList();
                list1.Add("foo");
                list1.Add("bar");
                ArrayList list2 = new ArrayList();
                list2.Add("foo");
                Specify.That(list1).ShouldBeEquivalentTo(list2);
            }).ShouldHaveThrown(typeof(ConstraintFailedException));
        }

        [TestMethod]
        public void ShouldBeEquivalentTo_GivenCollectionsWithDifferentItems_ShouldFail()
        {
            Specify.ThatAction(delegate
            {
                ArrayList list1 = new ArrayList();
                list1.Add("foo");
                ArrayList list2 = new ArrayList();
                list2.Add("bar");
                Specify.That(list1).ShouldBeEquivalentTo(list2);
            }).ShouldHaveThrown(typeof(ConstraintFailedException));
        }

        [TestMethod]
        public void ShouldNotBeEquivalentTo_GivenSameCollection_ShouldFail()
        {
            Specify.ThatAction(delegate
            {
                ArrayList list = new ArrayList();
                Specify.That(list).ShouldNotBeEquivalentTo(list);
            }).ShouldHaveThrown(typeof(ConstraintFailedException));
        }

        [TestMethod]
        public void ShouldNotBeEquivalentTo_GivenEqualCollections_ShouldFail()
        {
            Specify.ThatAction(delegate
            {
                ArrayList list1 = new ArrayList();
                list1.Add("foo");
                ArrayList list2 = new ArrayList();
                list2.Add("foo");
                Specify.That(list1).ShouldNotBeEquivalentTo(list2);
            }).ShouldHaveThrown(typeof(ConstraintFailedException));
        }

        [TestMethod]
        public void ShouldNotBeEquivalentTo_GivenEquivalentCollections_ShouldFail()
        {
            Specify.ThatAction(delegate
            {
                ArrayList list1 = new ArrayList();
                list1.Add("foo");
                list1.Add("bar");
                ArrayList list2 = new ArrayList();
                list2.Add("bar");
                list2.Add("foo");
                Specify.That(list1).ShouldNotBeEquivalentTo(list2);
            }).ShouldHaveThrown(typeof(ConstraintFailedException));
        }

        [TestMethod]
        public void ShouldNotBeEquivalentTo_GivenCollectionsOfDifferentLength_ShouldNotFail()
        {
            Specify.ThatAction(delegate
            {
                ArrayList list1 = new ArrayList();
                list1.Add("foo");
                list1.Add("bar");
                ArrayList list2 = new ArrayList();
                list2.Add("foo");
                Specify.That(list1).ShouldNotBeEquivalentTo(list2);
            }).ShouldNotHaveThrown();
        }

        [TestMethod]
        public void ShouldNotBeEquivalentTo_GivenCollectionsWithDifferentItems_ShouldNotFail()
        {
            Specify.ThatAction(delegate
            {
                ArrayList list1 = new ArrayList();
                list1.Add("foo");
                ArrayList list2 = new ArrayList();
                list2.Add("bar");
                Specify.That(list1).ShouldNotBeEquivalentTo(list2);
            }).ShouldNotHaveThrown();
        }

        [TestMethod]
        public void ShouldContain_GivenItemInCollection_ShouldNotFail()
        {
            Specify.ThatAction(delegate
            {
                ArrayList list = new ArrayList();
                list.Add("foo");
                Specify.That(list).ShouldContain("foo");
            }).ShouldNotHaveThrown();
        }

        [TestMethod]
        public void ShouldContain_GivenItemNotInCollection_ShouldFail()
        {
            Specify.ThatAction(delegate
            {
                Specify.That(new ArrayList()).ShouldContain("foo");
            }).ShouldHaveThrown(typeof(ConstraintFailedException));
        }

        [TestMethod]
        public void ShouldNotContain_GivenItemInCollection_ShouldFail()
        {
            Specify.ThatAction(delegate
            {
                ArrayList list = new ArrayList();
                list.Add("foo");
                Specify.That(list).ShouldNotContain("foo");
            }).ShouldHaveThrown(typeof(ConstraintFailedException));
        }

        [TestMethod]
        public void ShouldNotContain_GivenItemNotInCollection_ShouldNotFail()
        {
            Specify.ThatAction(delegate
            {
                Specify.That(new ArrayList()).ShouldNotContain("foo");
            }).ShouldNotHaveThrown();
        }

        [TestMethod]
        public void ShouldBeSubsetOf_GivenEmptyCollectionAndEmptySuperset_ShouldNotFail()
        {
            Specify.ThatAction(delegate
            {
                Specify.That(new ArrayList()).ShouldBeSubsetOf(new ArrayList());
            }).ShouldNotHaveThrown();
        }

        [TestMethod]
        public void ShouldBeSubsetOf_GiveEmptyCollectionAndNonemptySuperset_ShouldNotFail()
        {
            Specify.ThatAction(delegate
            {
                ArrayList superset = new ArrayList();
                superset.Add("foo");
                Specify.That(new ArrayList()).ShouldBeSubsetOf(superset);
            }).ShouldNotHaveThrown();
        }

        [TestMethod]
        public void ShouldBeSubsetOf_GivenEqualCollections_ShouldNotFail()
        {
            Specify.ThatAction(delegate
            {
                ArrayList list = new ArrayList();
                list.Add("foo");
                ArrayList superset = new ArrayList();
                superset.Add("foo");
                Specify.That(list).ShouldBeSubsetOf(superset);
            }).ShouldNotHaveThrown();
        }

        [TestMethod]
        public void ShouldBeSubsetOf_GivenEquivalentCollections_ShouldNotFail()
        {
            Specify.ThatAction(delegate
            {
                ArrayList list = new ArrayList();
                list.Add("foo");
                list.Add("bar");
                ArrayList superset = new ArrayList();
                superset.Add("bar");
                superset.Add("foo");
                Specify.That(list).ShouldBeSubsetOf(superset);
            }).ShouldNotHaveThrown();
        }

        [TestMethod]
        public void ShouldBeSubsetOf_GivenCollectionWithItemsNotInSuperset_ShouldFail()
        {
            Specify.ThatAction(delegate
            {
                ArrayList list = new ArrayList();
                list.Add("foo");
                Specify.That(list).ShouldBeSubsetOf(new ArrayList());
            }).ShouldHaveThrown(typeof(ConstraintFailedException));
        }

        [TestMethod]
        public void ShouldNotBeSubsetOf_GivenEmptyCollectionAndEmptySuperset_ShouldFail()
        {
            Specify.ThatAction(delegate
            {
                Specify.That(new ArrayList()).ShouldNotBeSubsetOf(new ArrayList());
            }).ShouldHaveThrown(typeof(ConstraintFailedException));
        }

        [TestMethod]
        public void ShouldNotBeSubsetOf_GiveEmptyCollectionAndNonemptySuperset_ShouldFail()
        {
            Specify.ThatAction(delegate
            {
                ArrayList superset = new ArrayList();
                superset.Add("foo");
                Specify.That(new ArrayList()).ShouldNotBeSubsetOf(superset);
            }).ShouldHaveThrown(typeof(ConstraintFailedException));
        }

        [TestMethod]
        public void ShouldNotBeSubsetOf_GivenEqualCollections_ShouldFail()
        {
            Specify.ThatAction(delegate
            {
                ArrayList list = new ArrayList();
                list.Add("foo");
                ArrayList superset = new ArrayList();
                superset.Add("foo");
                Specify.That(list).ShouldNotBeSubsetOf(superset);
            }).ShouldHaveThrown(typeof(ConstraintFailedException));
        }

        [TestMethod]
        public void ShouldNotBeSubsetOf_GivenEquivalentCollections_ShouldFail()
        {
            Specify.ThatAction(delegate
            {
                ArrayList list = new ArrayList();
                list.Add("foo");
                list.Add("bar");
                ArrayList superset = new ArrayList();
                superset.Add("bar");
                superset.Add("foo");
                Specify.That(list).ShouldNotBeSubsetOf(superset);
            }).ShouldHaveThrown(typeof(ConstraintFailedException));
        }

        [TestMethod]
        public void ShouldNotBeSubsetOf_GivenCollectionWithItemsNotInSuperset_ShouldNotFail()
        {
            Specify.ThatAction(delegate
            {
                ArrayList list = new ArrayList();
                list.Add("foo");
                Specify.That(list).ShouldNotBeSubsetOf(new ArrayList());
            }).ShouldNotHaveThrown();
        }
    }
}
