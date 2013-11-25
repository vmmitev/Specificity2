//-----------------------------------------------------------------------------
// <copyright file="NumericConstraintsTests.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Testing.Specificity.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class NumericConstraintsTests
    {
        [TestMethod]
        public void BeEqualToGivenDoubleOutsideToleranceShouldFail()
        {
            try
            {
                Specify.That(0.5d).Should.BeEqualTo(1.0d, 0.2d);
            }
            catch (AssertFailedException)
            {
                return;
            }

            Specify.Failure("Specification did not fail.");
        }

        [TestMethod]
        public void BeEqualToGivenDoubleWithinToleranceShouldNotFail()
        {
            Specify.That(0.5d).Should.BeEqualTo(0.6d, 0.2d);
        }

        [TestMethod]
        public void BeEqualToGivenFloatOutsideToleranceShouldFail()
        {
            try
            {
                Specify.That(0.5f).Should.BeEqualTo(1.0f, 0.2f);
            }
            catch (AssertFailedException)
            {
                return;
            }

            Specify.Failure("Specification did not fail.");
        }

        [TestMethod]
        public void BeEqualToGivenFloatWithinToleranceShouldNotFail()
        {
            Specify.That(0.5f).Should.BeEqualTo(0.6f, 0.2f);
        }

        [TestMethod]
        public void BeEqualToNegatedGivenDoubleOutsideToleranceShouldNotFail()
        {
            Specify.That(0.5d).Should.Not.BeEqualTo(1.0d, 0.2d);
        }

        [TestMethod]
        public void BeEqualToNegatedGivenDoubleWithinToleranceShouldFail()
        {
            try
            {
                Specify.That(0.5d).Should.Not.BeEqualTo(0.6d, 0.2d);
            }
            catch (AssertFailedException)
            {
                return;
            }

            Specify.Failure("Specification did not fail.");
        }

        [TestMethod]
        public void BeEqualToNegatedGivenFloatOutsideToleranceShouldNotFail()
        {
            Specify.That(0.5f).Should.Not.BeEqualTo(1.0f, 0.2f);
        }

        [TestMethod]
        public void BeEqualToNegatedGivenFloatWithinToleranceShouldFail()
        {
            try
            {
                Specify.That(0.5f).Should.Not.BeEqualTo(0.6f, 0.2f);
            }
            catch (AssertFailedException)
            {
                return;
            }

            Specify.Failure("Specification did not fail.");
        }
    }
}