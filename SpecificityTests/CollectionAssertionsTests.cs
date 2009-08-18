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

    /// <summary>
    /// Provides tests for the <see cref="CollectionAssertions"/> extension methods.
    /// </summary>
    [TestClass]
    public class CollectionAssertionsTests
    {
        /// <summary>
        /// Verifies that <see cref="CollectionAssertions.ShouldBeEmpty{T}(ConstrainedValue{T})"/> should not fail when given an
        /// empty collection.
        /// </summary>
        [TestMethod]
        public void ShouldBeEmpty_GivenEmptyCollection_ShouldNotFail()
        {
            Specify.ThatAction(delegate
            {
                Specify.That(new int[] { }).ShouldBeEmpty();
            }).ShouldNotHaveThrown();
        }

        /// <summary>
        /// Verifies that <see cref="CollectionAssertions.ShouldBeEmpty{T}(ConstrainedValue{T})"/> should fail when given a
        /// non-empty collection.
        /// </summary>
        [TestMethod]
        public void ShouldBeEmpty_GivenNonemptyCollection_ShouldFail()
        {
            Specify.ThatAction(delegate
            {
                Specify.That(new int[] { 1 }).ShouldBeEmpty();
            }).ShouldHaveThrown(typeof(ConstraintFailedException));
        }

        /// <summary>
        /// Verifies that <see cref="CollectionAssertions.ShouldNotBeEmpty{T}(ConstrainedValue{T})"/> should fail when given an
        /// empty collection.
        /// </summary>
        [TestMethod]
        public void ShouldNotBeEmpty_GivenEmptyCollection_ShouldFail()
        {
            Specify.ThatAction(delegate
            {
                Specify.That(new int[] { }).ShouldNotBeEmpty();
            }).ShouldHaveThrown(typeof(ConstraintFailedException));
        }

        /// <summary>
        /// Verifies that <see cref="CollectionAssertions.ShouldNotBeEmpty{T}(ConstrainedValue{T})"/> should not fail when given
        /// a non-empty collection.
        /// </summary>
        [TestMethod]
        public void ShouldNotBeEmpty_GivenNonemptyCollection_ShouldNotFail()
        {
            Specify.ThatAction(delegate
            {
                Specify.That(new int[] { 1 }).ShouldNotBeEmpty();
            }).ShouldNotHaveThrown();
        }

        /// <summary>
        /// Verifies that <see cref="CollectionAssertions.ShouldOnlyHaveItemsOfType{T}(ConstrainedValue{T}, System.Type)"/> should
        /// not fail when given a collection containing only elements of the specified type.
        /// </summary>
        [TestMethod]
        public void ShouldOnlyHaveItemsOfType_GivenAllElementsOfSpecifiedType_ShouldNotFail()
        {
            Specify.ThatAction(delegate
            {
                Specify.That(new object[] { 1, 2, 5 }).ShouldOnlyHaveItemsOfType(typeof(int));
            }).ShouldNotHaveThrown();
        }

        /// <summary>
        /// Verifies that <see cref="CollectionAssertions.ShouldOnlyHaveItemsOfType{T}(ConstrainedValue{T}, System.Type)"/> should
        /// fail when given a collection not containing only elements of the specified type.
        /// </summary>
        [TestMethod]
        public void ShouldOnlyHaveItemsOfType_GivenElementsOfDifferentType_ShouldFail()
        {
            Specify.ThatAction(delegate
            {
                Specify.That(new object[] { 1, 2, 5.0 }).ShouldOnlyHaveItemsOfType(typeof(int));
            }).ShouldHaveThrown(typeof(ConstraintFailedException));
        }

        /// <summary>
        /// Verifies that <see cref="CollectionAssertions.ShouldNotHaveNullItems{T}(ConstrainedValue{T})"/> should not fail when
        /// collection does not contain <see langword="null"/> elements.
        /// </summary>
        [TestMethod]
        public void ShouldNotHaveNullItems_GivenNonNullItems_ShouldNotFail()
        {
            Specify.ThatAction(delegate
            {
                Specify.That(new string[] { "foo", "bar" }).ShouldNotHaveNullItems();
            }).ShouldNotHaveThrown();
        }

        /// <summary>
        /// Verifies that <see cref="CollectionAssertions.ShouldNotHaveNullItems{T}(ConstrainedValue{T})"/> should fail when
        /// collection contains <see langword="null"/> elements.
        /// </summary>
        [TestMethod]
        public void ShouldNotHaveNullItems_GivenNullItems_ShouldFail()
        {
            Specify.ThatAction(delegate
            {
                Specify.That(new string[] { "foo", "bar", null }).ShouldNotHaveNullItems();
            }).ShouldHaveThrown(typeof(ConstraintFailedException));
        }

        /// <summary>
        /// Verifies that <see cref="CollectionAssertions.ShouldHaveUniqueItems{T}(ConstrainedValue{T})"/> should not fail
        /// when given collection with unique items.
        /// </summary>
        [TestMethod]
        public void ShouldHaveUniqueItems_GivenUniqueItems_ShouldNotFail()
        {
            Specify.ThatAction(delegate
            {
                Specify.That(new string[] { "foo", "bar", "baz" }).ShouldHaveUniqueItems();
            }).ShouldNotHaveThrown();
        }

        /// <summary>
        /// Verifies that <see cref="CollectionAssertions.ShouldHaveUniqueItems{T}(ConstrainedValue{T})"/> should fail
        /// when not given collection with unique items.
        /// </summary>
        [TestMethod]
        public void ShouldHaveUniqueItems_GivenNonUniqueItems_ShouldFail()
        {
            Specify.ThatAction(delegate
            {
                Specify.That(new string[] { "foo", "bar", "baz", "foo" }).ShouldHaveUniqueItems();
            }).ShouldHaveThrown(typeof(ConstraintFailedException));
        }

        /// <summary>
        /// Verifies that <see cref="CollectionAssertions.ShouldBeEqualTo{T}(ConstrainedValue{T}, ICollection, IComparer)"/> should not fail
        /// when given collections that are logically equal.
        /// </summary>
        [TestMethod]
        public void ShouldBeEqualTo_GivenEqualCollections_ShouldNotFail()
        {
            Specify.ThatAction(delegate
            {
                Specify.That(new int[] { 1, 2, 5 }).ShouldBeEqualTo(new int[] { 1, 2, 5 }, Comparer<int>.Default);
            }).ShouldNotHaveThrown();
        }

        /// <summary>
        /// Verifies that <see cref="CollectionAssertions.ShouldBeEqualTo{T}(ConstrainedValue{T}, ICollection, IComparer)"/> should fail
        /// when given collections that are not logically equal.
        /// </summary>
        [TestMethod]
        public void ShouldBeEqualTo_GivenNonEqualCollections_ShouldFail()
        {
            Specify.ThatAction(delegate
            {
                Specify.That(new int[] { 1, 2, 5 }).ShouldBeEqualTo(new int[] { 1, 2, 8 }, Comparer<int>.Default);
            }).ShouldHaveThrown(typeof(ConstraintFailedException));
        }

        /// <summary>
        /// Verifies that <see cref="CollectionAssertions.ShouldNotBeEqualTo{T}(ConstrainedValue{T}, ICollection, IComparer)"/> should fail
        /// when given collections that are logically equal.
        /// </summary>
        [TestMethod]
        public void ShouldNotBeEqualTo_GivenEqualCollections_ShouldFail()
        {
            Specify.ThatAction(delegate
            {
                Specify.That(new int[] { 1, 2, 5 }).ShouldNotBeEqualTo(new int[] { 1, 2, 5 }, Comparer<int>.Default);
            }).ShouldHaveThrown(typeof(ConstraintFailedException));
        }

        /// <summary>
        /// Verifies that <see cref="CollectionAssertions.ShouldNotBeEqualTo{T}(ConstrainedValue{T}, ICollection, IComparer)"/> should not fail
        /// when given collections that are not logically equal.
        /// </summary>
        [TestMethod]
        public void ShouldNotBeEqualTo_GivenNonEqualCollections_ShouldNotFail()
        {
            Specify.ThatAction(delegate
            {
                Specify.That(new int[] { 1, 2, 5 }).ShouldNotBeEqualTo(new int[] { 1, 2, 8 }, Comparer<int>.Default);
            }).ShouldNotHaveThrown();
        }

        /// <summary>
        /// Verifies that <see cref="CollectionAssertions.ShouldBeEquivalentTo{T}(ConstrainedValue{T}, ICollection)"/> should not fail
        /// when given the same collection.
        /// </summary>
        [TestMethod]
        public void ShouldBeEquivalentTo_GivenSameCollection_ShouldNotFail()
        {
            Specify.ThatAction(delegate
            {
                ArrayList list = new ArrayList();
                Specify.That(list).ShouldBeEquivalentTo(list);
            }).ShouldNotHaveThrown();
        }

        /// <summary>
        /// Verifies that <see cref="CollectionAssertions.ShouldBeEquivalentTo{T}(ConstrainedValue{T}, ICollection)"/> should not fail
        /// when given collections that are logically equal.
        /// </summary>
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

        /// <summary>
        /// Verifies that <see cref="CollectionAssertions.ShouldBeEquivalentTo{T}(ConstrainedValue{T}, ICollection)"/> should not fail
        /// when given collections that are logically equivalent.
        /// </summary>
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

        /// <summary>
        /// Verifies that <see cref="CollectionAssertions.ShouldBeEquivalentTo{T}(ConstrainedValue{T}, ICollection)"/> should fail
        /// when given collections that differ in length.
        /// </summary>
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

        /// <summary>
        /// Verifies that <see cref="CollectionAssertions.ShouldBeEquivalentTo{T}(ConstrainedValue{T}, ICollection)"/> should fail
        /// when given collections with different items.
        /// </summary>
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

        /// <summary>
        /// Verifies that <see cref="CollectionAssertions.ShouldNotBeEquivalentTo{T}(ConstrainedValue{T}, ICollection)"/> should fail
        /// when given the same collection.
        /// </summary>
        [TestMethod]
        public void ShouldNotBeEquivalentTo_GivenSameCollection_ShouldFail()
        {
            Specify.ThatAction(delegate
            {
                ArrayList list = new ArrayList();
                Specify.That(list).ShouldNotBeEquivalentTo(list);
            }).ShouldHaveThrown(typeof(ConstraintFailedException));
        }

        /// <summary>
        /// Verifies that <see cref="CollectionAssertions.ShouldNotBeEquivalentTo{T}(ConstrainedValue{T}, ICollection)"/> should fail
        /// when given collections that are logically equal.
        /// </summary>
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

        /// <summary>
        /// Verifies that <see cref="CollectionAssertions.ShouldNotBeEquivalentTo{T}(ConstrainedValue{T}, ICollection)"/> should fail
        /// when given collections that are logically equivalent.
        /// </summary>
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

        /// <summary>
        /// Verifies that <see cref="CollectionAssertions.ShouldNotBeEquivalentTo{T}(ConstrainedValue{T}, ICollection)"/> should fail
        /// when given collections that differ in length.
        /// </summary>
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

        /// <summary>
        /// Verifies that <see cref="CollectionAssertions.ShouldNotBeEquivalentTo{T}(ConstrainedValue{T}, ICollection)"/> should fail
        /// when given collections with different items.
        /// </summary>
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

        /// <summary>
        /// Verifies that <see cref="CollectionAssertions.ShouldContain{T}(ConstrainedValue{T}, object)"/> should not fail
        /// when given an item in the collection.
        /// </summary>
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

        /// <summary>
        /// Verifies that <see cref="CollectionAssertions.ShouldContain{T}(ConstrainedValue{T}, object)"/> should fail
        /// when given an item not in the collection.
        /// </summary>
        [TestMethod]
        public void ShouldContain_GivenItemNotInCollection_ShouldFail()
        {
            Specify.ThatAction(delegate
            {
                Specify.That(new ArrayList()).ShouldContain("foo");
            }).ShouldHaveThrown(typeof(ConstraintFailedException));
        }

        /// <summary>
        /// Verifies that <see cref="CollectionAssertions.ShouldNotContain{T}(ConstrainedValue{T}, object)"/> should fail
        /// when given an item in the collection.
        /// </summary>
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

        /// <summary>
        /// Verifies that <see cref="CollectionAssertions.ShouldNotContain{T}(ConstrainedValue{T}, object)"/> should not fail
        /// when given an item not in the collection.
        /// </summary>
        [TestMethod]
        public void ShouldNotContain_GivenItemNotInCollection_ShouldNotFail()
        {
            Specify.ThatAction(delegate
            {
                Specify.That(new ArrayList()).ShouldNotContain("foo");
            }).ShouldNotHaveThrown();
        }

        /// <summary>
        /// Verifies that <see cref="CollectionAssertions.ShouldBeSubsetOf{T}(ConstrainedValue{T}, ICollection)"/> should not fail
        /// given empty collections.
        /// </summary>
        [TestMethod]
        public void ShouldBeSubsetOf_GivenEmptyCollectionAndEmptySuperset_ShouldNotFail()
        {
            Specify.ThatAction(delegate
            {
                Specify.That(new ArrayList()).ShouldBeSubsetOf(new ArrayList());
            }).ShouldNotHaveThrown();
        }

        /// <summary>
        /// Verifies that <see cref="CollectionAssertions.ShouldBeSubsetOf{T}(ConstrainedValue{T}, ICollection)"/> should not fail
        /// given empty collections.
        /// </summary>
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

        /// <summary>
        /// Verifies that <see cref="CollectionAssertions.ShouldBeSubsetOf{T}(ConstrainedValue{T}, ICollection)"/> should not fail
        /// given collections that are logically equal.
        /// </summary>
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

        /// <summary>
        /// Verifies that <see cref="CollectionAssertions.ShouldBeSubsetOf{T}(ConstrainedValue{T}, ICollection)"/> should not fail
        /// given collections that are logically equivalent.
        /// </summary>
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

        /// <summary>
        /// Verifies that <see cref="CollectionAssertions.ShouldBeSubsetOf{T}(ConstrainedValue{T}, ICollection)"/> should fail
        /// given collections with items not in the superset.
        /// </summary>
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

        /// <summary>
        /// Verifies that <see cref="CollectionAssertions.ShouldNotBeSubsetOf{T}(ConstrainedValue{T}, ICollection)"/> should fail
        /// given collections that are empty.
        /// </summary>
        [TestMethod]
        public void ShouldNotBeSubsetOf_GivenEmptyCollectionAndEmptySuperset_ShouldFail()
        {
            Specify.ThatAction(delegate
            {
                Specify.That(new ArrayList()).ShouldNotBeSubsetOf(new ArrayList());
            }).ShouldHaveThrown(typeof(ConstraintFailedException));
        }

        /// <summary>
        /// Verifies that <see cref="CollectionAssertions.ShouldNotBeSubsetOf{T}(ConstrainedValue{T}, ICollection)"/> should fail
        /// given empty collection and non-empty superset.
        /// </summary>
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

        /// <summary>
        /// Verifies that <see cref="CollectionAssertions.ShouldNotBeSubsetOf{T}(ConstrainedValue{T}, ICollection)"/> should fail
        /// given collections that are logically equal.
        /// </summary>
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

        /// <summary>
        /// Verifies that <see cref="CollectionAssertions.ShouldNotBeSubsetOf{T}(ConstrainedValue{T}, ICollection)"/> should fail
        /// given collections that are logically equivalent.
        /// </summary>
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

        /// <summary>
        /// Verifies that <see cref="CollectionAssertions.ShouldNotBeSubsetOf{T}(ConstrainedValue{T}, ICollection)"/> should not fail
        /// given collection with items not in the superset.
        /// </summary>
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
