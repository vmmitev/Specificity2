//-----------------------------------------------------------------------------
// <copyright file="StringConstraintsTests.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Testing.Specificity2.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class StringConstraintsTests
    {
        [TestMethod]
        public void BeEqualToGivenOrdinalIgnoreCaseAndUppercaseStringShouldNotFail()
        {
            Specify.That("Test Message").Should.BeEqualTo("TEST MESSAGE", StringComparison.OrdinalIgnoreCase);
        }

        [TestMethod]
        public void BeEqualToNegatedGivenOrdinalIgnoreCaseAndUppercaseStringShouldFail()
        {
            try
            {
                Specify.That("Test Message").Should.Not.BeEqualTo("TEST MESSAGE", StringComparison.OrdinalIgnoreCase);
            }
            catch (AssertFailedException)
            {
                return;
            }

            Specify.Failure("Specification did not fail.");
        }

        [TestMethod]
        public void BeNullOrEmptyGivenEmptyShouldNotFail()
        {
            Specify.That(string.Empty).Should.BeNullOrEmpty();
        }

        [TestMethod]
        public void BeNullOrEmptyGivenNonemptyStringShouldFail()
        {
            try
            {
                Specify.That("foo").Should.BeNullOrEmpty();
            }
            catch (AssertFailedException)
            {
                return;
            }

            Specify.Failure("Specification did not fail.");
        }

        [TestMethod]
        public void BeNullOrEmptyGivenNullShouldNotFail()
        {
            Specify.That((string)null).Should.BeNullOrEmpty();
        }

        [TestMethod]
        public void BeNullOrEmptyNegatedGivenEmptyShouldFail()
        {
            try
            {
                Specify.That(string.Empty).Should.Not.BeNullOrEmpty();
            }
            catch (AssertFailedException)
            {
                return;
            }

            Specify.Failure("Specification did not fail.");
        }

        [TestMethod]
        public void BeNullOrEmptyNegatedGivenNonemptyStringShouldNotFail()
        {
            Specify.That("foo").Should.Not.BeNullOrEmpty();
        }

        [TestMethod]
        public void BeNullOrEmptyNegatedGivenNullShouldFail()
        {
            try
            {
                Specify.That((string)null).Should.Not.BeNullOrEmpty();
            }
            catch (AssertFailedException)
            {
                return;
            }

            Specify.Failure("Specification did not fail.");
        }

        [TestMethod]
        public void BeNullOrWhiteSpaceGivenEmptyShouldNotFail()
        {
            Specify.That(string.Empty).Should.BeNullOrWhiteSpace();
        }

        [TestMethod]
        public void BeNullOrWhiteSpaceGivenNonemptyStringShouldFail()
        {
            try
            {
                Specify.That("foo").Should.BeNullOrWhiteSpace();
            }
            catch (AssertFailedException)
            {
                return;
            }

            Specify.Failure("Specification did not fail.");
        }

        [TestMethod]
        public void BeNullOrWhiteSpaceGivenNullShouldNotFail()
        {
            Specify.That((string)null).Should.BeNullOrWhiteSpace();
        }

        [TestMethod]
        public void BeNullOrWhiteSpaceGivenWhiteSpaceShouldNotFail()
        {
            Specify.That(" ").Should.BeNullOrWhiteSpace();
        }

        [TestMethod]
        public void BeNullOrWhiteSpaceNegatedGivenEmptyShouldFail()
        {
            try
            {
                Specify.That(string.Empty).Should.Not.BeNullOrWhiteSpace();
            }
            catch (AssertFailedException)
            {
                return;
            }

            Specify.Failure("Specification did not fail.");
        }

        [TestMethod]
        public void BeNullOrWhiteSpaceNegatedGivenNonemptyStringShouldNotFail()
        {
            Specify.That("foo").Should.Not.BeNullOrWhiteSpace();
        }

        [TestMethod]
        public void BeNullOrWhiteSpaceNegatedGivenNullShouldFail()
        {
            try
            {
                Specify.That((string)null).Should.Not.BeNullOrWhiteSpace();
            }
            catch (AssertFailedException)
            {
                return;
            }

            Specify.Failure("Specification did not fail.");
        }

        [TestMethod]
        public void BeNullOrWhiteSpaceNegatedGivenWhiteSpaceShouldFail()
        {
            try
            {
                Specify.That(" ").Should.Not.BeNullOrWhiteSpace();
            }
            catch (AssertFailedException)
            {
                return;
            }

            Specify.Failure("Specification did not fail.");
        }

        [TestMethod]
        public void ContainSubstringGivenNonSubstringShouldFail()
        {
            try
            {
                Specify.That("Test Message").Should.Contain("Not a Message");
            }
            catch (AssertFailedException)
            {
                return;
            }

            Specify.Failure("Specification did not fail.");
        }

        [TestMethod]
        public void ContainSubstringGivenOrdinalIgnoreCaseAndUppercaseSubstringShouldNotFail()
        {
            Specify.That("Test Message").Should.Contain("TEST", StringComparison.OrdinalIgnoreCase);
        }

        [TestMethod]
        public void ContainSubstringGivenSubstringShouldNotFail()
        {
            Specify.That("Test Message").Should.Contain("Test", StringComparison.Ordinal);
        }

        [TestMethod]
        public void ContainSubstringNegatedGivenNonSubstringShouldNotFail()
        {
            Specify.That("Test Message").Should.Not.Contain("Not a Message", StringComparison.Ordinal);
        }

        [TestMethod]
        public void ContainSubstringNegatedGivenOrdinalIgnoreCaseAndUppercaseSubstringShouldFail()
        {
            try
            {
                Specify.That("Test Message").Should.Not.Contain("TEST", StringComparison.OrdinalIgnoreCase);
            }
            catch (AssertFailedException)
            {
                return;
            }

            Specify.Failure("Specification did not fail.");
        }

        [TestMethod]
        public void ContainSubstringNegatedGivenSubstringShouldFail()
        {
            try
            {
                Specify.That("Test Message").Should.Not.Contain("Test Message", StringComparison.Ordinal);
            }
            catch (AssertFailedException)
            {
                return;
            }

            Specify.Failure("Specification did not fail.");
        }

        [TestMethod]
        public void EndWithGivenStringAtEndShouldNotFail()
        {
            Specify.That("Test Message").Should.EndWith("Message", StringComparison.Ordinal);
        }

        [TestMethod]
        public void EndWithGivenStringNotAtEndShouldFail()
        {
            try
            {
                Specify.That("Test Message").Should.EndWith("Test", StringComparison.Ordinal);
            }
            catch (AssertFailedException)
            {
                return;
            }

            Specify.Failure("Specification did not fail.");
        }

        [TestMethod]
        public void EndWithNegatedGivenStringAtEndShouldFail()
        {
            try
            {
                Specify.That("Test Message").Should.Not.EndWith("Message", StringComparison.Ordinal);
            }
            catch (AssertFailedException)
            {
                return;
            }

            Specify.Failure("Specification did not fail.");
        }

        [TestMethod]
        public void EndWithNegatedGivenStringNotAtEndShouldNotFail()
        {
            Specify.That("xyzzzy").Should.Not.EndWith("42");
        }

        [TestMethod]
        public void MatchGivenMatchingPatternShouldNotFail()
        {
            Specify.That("aaa").Should.Match("a+");
        }

        [TestMethod]
        public void MatchGivenNonmatchingPatternShouldFail()
        {
            try
            {
                Specify.That("aaa").Should.Match("b+");
            }
            catch (AssertFailedException)
            {
                return;
            }

            Specify.Failure("Specification did not fail.");
        }

        [TestMethod]
        public void MatchNegatedGivenMatchingPatternShouldFail()
        {
            try
            {
                Specify.That("aaa").Should.Not.Match("a+");
            }
            catch (AssertFailedException)
            {
                return;
            }

            Specify.Failure("Specification did not fail.");
        }

        [TestMethod]
        public void MatchNegatedGivenNonmatchingPatternShouldNotFail()
        {
            Specify.That("aaa").Should.Not.Match("b+");
        }

        [TestMethod]
        public void StartWithGivenStringAtStartShouldNotFail()
        {
            Specify.That("Test Message").Should.StartWith("Test", StringComparison.Ordinal);
        }

        [TestMethod]
        public void StartWithGivenStringNotAtStartShouldFail()
        {
            try
            {
                Specify.That("Test Message").Should.StartWith("Not a Message", StringComparison.Ordinal);
            }
            catch (AssertFailedException)
            {
                return;
            }

            Specify.Failure("Specification did not fail.");
        }

        [TestMethod]
        public void StartWithNegatedGivenStringAtStartShouldFail()
        {
            try
            {
                Specify.That("Test Message").Should.Not.StartWith("Test", StringComparison.Ordinal);
            }
            catch (AssertFailedException)
            {
                return;
            }

            Specify.Failure("Specification did not fail.");
        }

        [TestMethod]
        public void StartWithNegatedGivenStringNotAtStartShouldNotFail()
        {
            Specify.That("Test Message").Should.Not.StartWith("Not a Message", StringComparison.Ordinal);
        }
    }
}