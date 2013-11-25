//-----------------------------------------------------------------------------
// <copyright file="ObjectConstraintsTests.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Testing.Specificity.Tests
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ObjectConstraintsTests
    {
        [TestMethod]
        public void BeEqualToGivenDifferentCollectionsShouldFail()
        {
            var first = new[] { 1, 2, 3, 4 };
            var second = new[] { 4, 3, 2, 1 };
            try
            {
                Specify.That(first).Should.BeEqualTo(second);
            }
            catch (AssertFailedException)
            {
                return;
            }

            Specify.Failure("Specification did not fail.");
        }

        [TestMethod]
        public void BeEqualToGivenDifferentInstancesShouldFail()
        {
            try
            {
                Specify.That(new object()).Should.BeEqualTo(new object());
            }
            catch (AssertFailedException)
            {
                return;
            }

            Specify.Failure("Specification did not fail.");
        }

        [TestMethod]
        public void BeEqualToGivenEqualCollectionsShouldNotFail()
        {
            var first = new[] { 1, 2, 4, 9 };
            var second = first.ToArray();
            Specify.That(first).Should.BeEqualTo(second);
        }

        [TestMethod]
        public void BeEqualToGivenEqualValuesShouldNotFail()
        {
            Specify.That(42).Should.BeEqualTo(42);
        }

        [TestMethod]
        public void BeEqualToGivenSameInstanceShouldNotFail()
        {
            object instance = new object();
            Specify.That(instance).Should.BeEqualTo(instance);
        }

        [TestMethod]
        public void BeEqualToNegatedGivenDifferentCollectionsShouldNotFail()
        {
            var first = new[] { 1, 2, 3, 4 };
            var second = new[] { 4, 3, 2, 1 };
            Specify.That(first).Should.Not.BeEqualTo(second);
        }

        [TestMethod]
        public void BeEqualToNegatedGivenDifferentInstancesShouldNotFail()
        {
            Specify.That(new object()).Should.Not.BeEqualTo(new object());
        }

        [TestMethod]
        public void BeEqualToNegatedGivenEqualCollectionsShouldFail()
        {
            var first = new[] { 1, 2, 4, 9 };
            var second = first.ToArray();
            try
            {
                Specify.That(first).Should.Not.BeEqualTo(second);
            }
            catch (AssertFailedException)
            {
                return;
            }

            Specify.Failure("Specification did not fail.");
        }

        [TestMethod]
        public void BeEqualToNegatedGivenEqualValuesShouldFail()
        {
            try
            {
                Specify.That(42).Should.Not.BeEqualTo(42);
            }
            catch (AssertFailedException)
            {
                return;
            }

            Specify.Failure("Specification did not fail.");
        }

        [TestMethod]
        public void BeEqualToNegatedGivenSameInstanceShouldNotFail()
        {
            object instance = new object();
            try
            {
                Specify.That(instance).Should.Not.BeEqualTo(instance);
            }
            catch (AssertFailedException)
            {
                return;
            }

            Specify.Failure("Specification did not fail.");
        }

        [TestMethod]
        public void BeInstanceOfTypeGivenInstanceOfDifferentTypeShouldFail()
        {
            try
            {
                Specify.That(new object()).Should.BeInstanceOfType(typeof(Exception));
            }
            catch (AssertFailedException)
            {
                return;
            }

            Specify.Failure("Specification did not fail.");
        }

        [TestMethod]
        public void BeInstanceOfTypeGivenInstanceOfTypeShouldNotFail()
        {
            Specify.That(new object()).Should.BeInstanceOfType(typeof(object));
        }

        [TestMethod]
        public void BeInstanceOfTypeNegatedGivenInstanceOfDifferentTypeShouldNotFail()
        {
            Specify.That(new object()).Should.Not.BeInstanceOfType(typeof(Exception));
        }

        [TestMethod]
        public void BeInstanceOfTypeNegatedGivenInstanceOfTypeShouldFail()
        {
            try
            {
                Specify.That(new object()).Should.Not.BeInstanceOfType(typeof(object));
            }
            catch (AssertFailedException)
            {
                return;
            }

            Specify.Failure("Specification did not fail.");
        }

        [TestMethod]
        public void BeLogicallyEqualToGivenLogicallyEqualCollectionsShouldNotFail()
        {
            var one = new[] { new Data { Text = "foo", Number = 2 } };
            var two = new[] { new Data { Text = "foo", Number = 2 } };
            Specify.That(one).Should.BeLogicallyEqualTo(two);
        }

        [TestMethod]
        public void BeLogicallyEqualToGivenLogicallyEqualObjectsShouldNotFail()
        {
            var one = new Data { Text = "foo", Number = 2 };
            var two = new Data { Text = "foo", Number = 2 };
            Specify.That(one).Should.BeLogicallyEqualTo(two);
        }

        [TestMethod]
        public void BeLogicallyEqualToGivenUnequalCollectionsShouldFail()
        {
            var one = new[] { new Data { Text = "foo", Number = 2 } };
            var two = new[] { new Data { Text = "foo", Number = 3 } };
            try
            {
                Specify.That(one).Should.BeLogicallyEqualTo(two);
            }
            catch (AssertFailedException)
            {
                return;
            }

            Specify.That("Specification did not fail.");
        }

        [TestMethod]
        public void BeLogicallyEqualToGivenUnequalObjectsShouldFail()
        {
            var one = new Data { Text = "foo", Number = 2 };
            var two = new Data { Text = "foo", Number = 3 };
            try
            {
                Specify.That(one).Should.BeLogicallyEqualTo(two);
            }
            catch (AssertFailedException)
            {
                return;
            }

            Specify.That("Specification did not fail.");
        }

        [TestMethod]
        public void BeLogicallyEqualToNegatedGivenLogicallyEqualCollectionsShouldFail()
        {
            var one = new[] { new Data { Text = "foo", Number = 2 } };
            var two = new[] { new Data { Text = "foo", Number = 2 } };
            try
            {
                Specify.That(one).Should.Not.BeLogicallyEqualTo(two);
            }
            catch (AssertFailedException)
            {
                return;
            }

            Specify.That("Specification did not fail.");
        }

        [TestMethod]
        public void BeLogicallyEqualToNegatedGivenLogicallyEqualObjectsShouldFail()
        {
            var one = new Data { Text = "foo", Number = 2 };
            var two = new Data { Text = "foo", Number = 2 };
            try
            {
                Specify.That(one).Should.Not.BeLogicallyEqualTo(two);
            }
            catch (AssertFailedException)
            {
                return;
            }

            Specify.That("Specification did not fail.");
        }

        [TestMethod]
        public void BeLogicallyEqualToNegatedGivenUnequalCollectionsShouldNotFail()
        {
            var one = new[] { new Data { Text = "foo", Number = 2 } };
            var two = new[] { new Data { Text = "foo", Number = 3 } };
            Specify.That(one).Should.Not.BeLogicallyEqualTo(two);
        }

        [TestMethod]
        public void BeLogicallyEqualToNegatedGivenUnequalObjectsShouldNotFail()
        {
            var one = new Data { Text = "foo", Number = 2 };
            var two = new Data { Text = "foo", Number = 3 };
            Specify.That(one).Should.Not.BeLogicallyEqualTo(two);
        }

        [TestMethod]
        public void BeNullGivenInstanceShouldFail()
        {
            try
            {
                Specify.That(new object()).Should.BeNull();
            }
            catch (AssertFailedException)
            {
                return;
            }

            Specify.Failure("Specification did not fail.");
        }

        [TestMethod]
        public void BeNullGivenNullShouldNotFail()
        {
            Specify.That((object)null).Should.BeNull();
        }

        [TestMethod]
        public void BeNullNegatedGivenInstanceShouldNotFail()
        {
            Specify.That(new object()).Should.Not.BeNull();
        }

        [TestMethod]
        public void BeNullNegatedGivenNullShouldFail()
        {
            try
            {
                Specify.That((object)null).Should.Not.BeNull();
            }
            catch (AssertFailedException)
            {
                return;
            }

            Specify.Failure("Specification did not fail.");
        }

        [TestMethod]
        public void BeSameAsGivenDifferentInstancesShouldFail()
        {
            try
            {
                Specify.That(new object()).Should.BeSameAs(new object());
            }
            catch (AssertFailedException)
            {
                return;
            }

            Specify.Failure("Specification did not fail.");
        }

        [TestMethod]
        public void BeSameAsGivenSameInstanceShouldNotFail()
        {
            var instance = new object();
            Specify.That(instance).Should.BeSameAs(instance);
        }

        [TestMethod]
        public void BeSameAsNegatedGivenDifferentInstancesShouldNotFail()
        {
            Specify.That(new object()).Should.Not.BeSameAs(new object());
        }

        [TestMethod]
        public void BeSameAsNegatedGivenSameInstanceShouldFail()
        {
            var instance = new object();
            try
            {
                Specify.That(instance).Should.Not.BeSameAs(instance);
            }
            catch (AssertFailedException)
            {
                return;
            }

            Specify.Failure("Specification did not fail.");
        }

        private class Data
        {
            [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Reviewed.")]
            public int Number;

            public string Text { get; set; }
        }
    }
}