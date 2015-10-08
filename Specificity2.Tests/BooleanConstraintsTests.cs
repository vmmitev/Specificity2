// <copyright file="BooleanConstraintsTests.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>

namespace Testing.Specificity2.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class BooleanConstraintsTests
    {
        [TestMethod]
        public void BeTrueForFalseGivenMessageAndArgShouldFail()
        {
            string message = "{0}";
            string arg = "Test Message";
            try
            {
                Specify.That(false).Should.BeTrue(message, arg);
            }
            catch (AssertFailedException e)
            {
                StringAssert.EndsWith(e.Message, arg);
                return;
            }

            Specify.Failure("Specification did not fail.");
        }

        [TestMethod]
        public void BeTrueForFalseGivenMessageShouldFail()
        {
            string message = "Test Message";
            try
            {
                Specify.That(false).Should.BeTrue(message);
            }
            catch (AssertFailedException e)
            {
                StringAssert.EndsWith(e.Message, message);
                return;
            }

            Specify.Failure("Specification did not fail.");
        }

        [TestMethod]
        public void BeTrueForFalseShouldFail()
        {
            try
            {
                Specify.That(false).Should.BeTrue();
            }
            catch (AssertFailedException)
            {
                return;
            }

            Specify.Failure("Specification did not fail.");
        }

        [TestMethod]
        public void BeTrueForTrueGivenMessageAndArgShouldNotFail()
        {
            string message = "{0}";
            string arg = "Test Message";
            Specify.That(true).Should.BeTrue(message, arg);
        }

        [TestMethod]
        public void BeTrueForTrueGivenMessageShouldNotFail()
        {
            string message = "Test Message";
            Specify.That(true).Should.BeTrue(message);
        }

        [TestMethod]
        public void BeTrueForTrueShouldNotFail()
        {
            Specify.That(true).Should.BeTrue();
        }

        [TestMethod]
        public void BeTrueNegatedForFalseGivenMessageAndArgShouldNotFail()
        {
            string message = "{0}";
            string arg = "Test Message";
            Specify.That(true).Should.BeTrue(message, arg);
        }

        [TestMethod]
        public void BeTrueNegatedForFalseGivenMessageShouldNotFail()
        {
            string message = "Test Message";
            Specify.That(false).Should.Not.BeTrue(message);
        }

        [TestMethod]
        public void BeTrueNegatedForFalseShouldNotFail()
        {
            Specify.That(false).Should.Not.BeTrue();
        }

        [TestMethod]
        public void BeTrueNegatedForShouldFail()
        {
            try
            {
                Specify.That(true).Should.Not.BeTrue();
            }
            catch (AssertFailedException)
            {
                return;
            }

            Specify.Failure("Specification did not fail.");
        }

        [TestMethod]
        public void BeTrueNegatedForTrueGivenMessageAndArgShouldFail()
        {
            string message = "{0}";
            string arg = "Test Message";
            try
            {
                Specify.That(true).Should.Not.BeTrue(message, arg);
            }
            catch (AssertFailedException e)
            {
                StringAssert.EndsWith(e.Message, arg);
                return;
            }

            Specify.Failure("Specification did not fail.");
        }

        [TestMethod]
        public void BeTrueNegatedForTrueGivenMessageShouldFail()
        {
            string message = "Test Message";
            try
            {
                Specify.That(true).Should.Not.BeTrue(message);
            }
            catch (AssertFailedException e)
            {
                StringAssert.EndsWith(e.Message, message);
                return;
            }

            Specify.Failure("Specification did not fail.");
        }
    }
}