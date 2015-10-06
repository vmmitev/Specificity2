//-----------------------------------------------------------------------------
// <copyright file="CollectionConstraintsTests.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Testing.Specificity2.Tests
{
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CollectionConstraintsTests
    {
        [TestMethod]
        public void BeEmptyGivenEmptyCollectionShouldNotFail()
        {
            Specify.That(Enumerable.Empty<object>()).Should.BeEmpty();
        }

        [TestMethod]
        public void BeEmptyNegatedGivenEmptyCollectionShouldFail()
        {
            try
            {
                Specify.That(Enumerable.Empty<object>()).Should.Not.BeEmpty();
            }
            catch (AssertFailedException)
            {
                return;
            }

            Specify.Failure("Specification did not fail.");
        }

        [TestMethod]
        public void BeEmptyNegatedGivenNonemptyCollectionShouldNotFail()
        {
            Specify.That(new[] { "foo" }).Should.Not.BeEmpty();
        }

        [TestMethod]
        public void BeEmptyGivenNonemptyCollectionShouldFail()
        {
            try
            {
                Specify.That(new[] { "foo" }).Should.BeEmpty();
            }
            catch (AssertFailedException)
            {
                return;
            }

            Specify.Failure("Specification did not fail.");
        }

        [TestMethod]
        public void BeEquivalentToGivenEquivalentCollectionsShouldNotFail()
        {
            Specify.That(new[] { 1, 2, 3, 4 }).Should.BeEquivalentTo(new[] { 4, 3, 2, 1 });
        }

        [TestMethod]
        public void BeEquivalentToGivenDifferentCollectionsShouldFail()
        {
            try
            {
                Specify.That(new[] { 1, 2, 3, 4 }).Should.BeEquivalentTo(new[] { 1, 2 });
            }
            catch (AssertFailedException)
            {
                return;
            }

            Specify.Failure("Specification did not fail.");
        }

        [TestMethod]
        public void BeEquivalentToNegatedGivenEquivalentCollectionsShouldFail()
        {
            try
            {
                Specify.That(new[] { 1, 2, 3, 4 }).Should.Not.BeEquivalentTo(new[] { 4, 3, 2, 1 });
            }
            catch (AssertFailedException)
            {
                return;
            }

            Specify.Failure("Specification did not fail.");
        }

        [TestMethod]
        public void BeEquivalentToNegatedGivenDifferentCollectionsShouldNotFail()
        {
            Specify.That(new[] { 1, 2, 3, 4 }).Should.Not.BeEquivalentTo(new[] { 1, 2 });
        }

        [TestMethod]
        public void BeSubsetOfGivenSubsetShouldFail()
        {
            try
            {
                Specify.That(new[] { 1, 2, 3 }).Should.BeSubsetOf(new[] { 1, 2 });
            }
            catch (AssertFailedException)
            {
                return;
            }

            Specify.Failure("Specification did not fail.");
        }

        [TestMethod]
        public void BeSubsetOfGivenSupersetShouldNotFail()
        {
            Specify.That(new[] { 1, 2 }).Should.BeSubsetOf(new[] { 1, 2, 3, 4 });
        }

        [TestMethod]
        public void BeSubsetOfNegatedGivenSubsetShouldNotFail()
        {
            Specify.That(new[] { 1, 2, 3 }).Should.Not.BeSubsetOf(new[] { 1, 2 });
        }

        [TestMethod]
        public void BeSubsetOfNegatedGivenSupersetShouldFail()
        {
            try
            {
                Specify.That(new[] { 1, 2 }).Should.Not.BeSubsetOf(new[] { 1, 2, 3, 4 });
            }
            catch (AssertFailedException)
            {
                return;
            }

            Specify.Failure("Specification did not fail.");
        }

        [TestMethod]
        public void ContainGivenElementInCollectionShouldNotFail()
        {
            Specify.That(new[] { 1, 2, 3, 4 }).Should.Contain(3);
        }

        [TestMethod]
        public void ContainGivenElementNotInCollectionShouldFail()
        {
            try
            {
                Specify.That(new[] { 1, 2, 3, 4 }).Should.Contain(5);
            }
            catch (AssertFailedException)
            {
                return;
            }

            Specify.Failure("Specification did not fail.");
        }

        [TestMethod]
        public void ContainNegatedGivenElementInCollectionShouldFail()
        {
            try
            {
                Specify.That(new[] { 1, 2, 3, 4 }).Should.Not.Contain(3);
            }
            catch (AssertFailedException)
            {
                return;
            }

            Specify.Failure("Specification did not fail.");
        }

        [TestMethod]
        public void ContainNegatedGivenItemNotInCollectionShouldNotFail()
        {
            Specify.That(new[] { 1, 2, 3, 4 }).Should.Not.Contain(5);
        }

        [TestMethod]
        public void HaveNullItemsGivenCollectionWithNullItemsShouldNotFail()
        {
            Specify.That(new[] { "foo", null }).Should.HaveNullItems();
        }

        [TestMethod]
        public void HaveNullItemsGivenCollectionWithoutNullItemsShouldFail()
        {
            try
            {
                Specify.That(new[] { "foo", "bar" }).Should.HaveNullItems();
            }
            catch (AssertFailedException)
            {
                return;
            }

            Specify.Failure("Specification did not fail.");
        }

        [TestMethod]
        public void HaveNullItemsNegatedGiveCollectionWithoutNullItemsShouldNotFail()
        {
            Specify.That(new[] { "foo", "bar" }).Should.Not.HaveNullItems();
        }

        [TestMethod]
        public void HaveNullItemsNegatedGivenCollectionWithNullItemsShouldFail()
        {
            try
            {
                Specify.That(new[] { "foo", null }).Should.Not.HaveNullItems();
            }
            catch (AssertFailedException)
            {
                return;
            }

            Specify.Failure("Specification did not fail.");
        }

        [TestMethod]
        public void HaveOnlyItemsOfTypeGivenCollectionOfDifferentTypesShouldFail()
        {
            try
            {
                Specify.That(new object[] { 1, 2, 3, "foo" }).Should.HaveOnlyItemsOfType(typeof(int));
            }
            catch (AssertFailedException)
            {
                return;
            }

            Specify.Failure("Specification did not fail.");
        }

        [TestMethod]
        public void HaveOnlyItemsOfTypeGivenCollectionOfSpecifiedTypeShouldNotFail()
        {
            Specify.That(new[] { 1, 2, 3, 4 }).Should.HaveOnlyItemsOfType(typeof(int));
        }

        [TestMethod]
        public void HaveOnlyItemsOfTypeNegatedGivenCollectionOfDifferentTypesShouldNotFail()
        {
            Specify.That(new object[] { 1, 2, 3, "foo" }).Should.Not.HaveOnlyItemsOfType(typeof(int));
        }

        [TestMethod]
        public void HaveOnlyItemsOfTypeNegatedGivenCollectionOfSpecifiedTypeShouldFail()
        {
            try
            {
                Specify.That(new[] { 1, 2, 3, 4 }).Should.Not.HaveOnlyItemsOfType(typeof(int));
            }
            catch (AssertFailedException)
            {
                return;
            }

            Specify.Failure("Specification did not fail.");
        }

        [TestMethod]
        public void HaveUniqueItemsGivenCollectionWithDuplicateItemsShouldFail()
        {
            try
            {
                Specify.That(new[] { 1, 2, 2, 4 }).Should.HaveUniqueItems();
            }
            catch (AssertFailedException)
            {
                return;
            }

            Specify.Failure("Specification did not fail.");
        }

        [TestMethod]
        public void HaveUniqueItemsGivenCollectionWithUniqueItemsShouldNotFail()
        {
            Specify.That(new[] { 1, 2, 3, 4 }).Should.HaveUniqueItems();
        }

        [TestMethod]
        public void HaveUniqueItemsNegatedGivenCollectionWithDuplicateItemsShouldNotFail()
        {
            Specify.That(new[] { 1, 2, 2, 4 }).Should.Not.HaveUniqueItems();
        }

        [TestMethod]
        public void HaveUniqueItemsNegatedGivenCollectionWithUniqueItemsShouldFail()
        {
            try
            {
                Specify.That(new[] { 1, 2, 3, 4 }).Should.Not.HaveUniqueItems();
            }
            catch (AssertFailedException)
            {
                return;
            }

            Specify.Failure("Specification did not fail.");
        }
    }
}