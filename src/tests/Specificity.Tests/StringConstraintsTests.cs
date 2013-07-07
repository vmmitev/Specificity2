//-----------------------------------------------------------------------------
// <copyright file="StringConstraintsTests.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Testing.Specificity.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class StringConstraintsTests
    {
        [TestMethod]
        public void BeEqualToGivenOrdinalIgnoreCaseAndUppercaseStringShouldNotFail()
        {
            Specify.That("xyzzy").Should.BeEqualTo("XYZZY", StringComparison.OrdinalIgnoreCase);
        }

        [TestMethod]
        public void BeEqualToNegatedGivenOrdinalIgnoreCaseAndUppercaseStringShouldFail()
        {
            try
            {
                Specify.That("xyzzy").Should.Not.BeEqualTo("XYZZY", StringComparison.OrdinalIgnoreCase);
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
        public void BeNullOrEmptyGivenEmptyShouldNotFail()
        {
            Specify.That(string.Empty).Should.BeNullOrEmpty();
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
        public void BeNullOrEmptyGivenNonEmptyStringShouldFail()
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
        public void BeNullOrEmptyNegatedGivenNonEmptyStringShouldNotFail()
        {
            Specify.That("foo").Should.Not.BeNullOrEmpty();
        }

        [TestMethod]
        public void BeNullOrWhiteSpaceGivenNullShouldNotFail()
        {
            Specify.That((string)null).Should.BeNullOrWhiteSpace();
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
        public void BeNullOrWhiteSpaceGivenEmptyShouldNotFail()
        {
            Specify.That(string.Empty).Should.BeNullOrWhiteSpace();
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
        public void BeNullOrWhiteSpaceGivenWhiteSpaceShouldNotfail()
        {
            Specify.That(" ").Should.BeNullOrWhiteSpace();
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
        public void BeNullOrWhiteSpaceGivenNonEmptyStringShouldFail()
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
        public void BeNullOrWhiteSpaceNegatedGivenNonEmptyStringShouldNotFail()
        {
            Specify.That("foo").Should.Not.BeNullOrWhiteSpace();
        }

        [TestMethod]
        public void ContainSubstringGivenSubstringShouldNotFail()
        {
            Specify.That("xyzzy").Should.Contain("zz");
        }

        [TestMethod]
        public void ContainSubstringNegatedGivenSubstringShouldFail()
        {
            try
            {
                Specify.That("xyzzy").Should.Not.Contain("zz");
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
                Specify.That("xyzzy").Should.Contain("zzz");
            }
            catch (AssertFailedException)
            {
                return;
            }

            Specify.Failure("Specification did not fail.");
        }

        [TestMethod]
        public void ContainSubstringNegatedGivenNonSubstringShouldNotFail()
        {
            Specify.That("xyzzy").Should.Not.Contain("zzz");
        }

        [TestMethod]
        public void ContainSubstringGivenOrdinalIgnoreCaseAndUppercaseSubstringShouldNotFail()
        {
            Specify.That("xyzzy").Should.Contain("ZZ", StringComparison.OrdinalIgnoreCase);
        }

        [TestMethod]
        public void ContainSubstringNegatedGivenOrdinalIgnoreCaseAndUppercaseSubstringShouldFail()
        {
            try
            {
                Specify.That("xyzzy").Should.Not.Contain("ZZ", StringComparison.OrdinalIgnoreCase);
            }
            catch (AssertFailedException)
            {
                return;
            }

            Specify.Failure("Specification did not fail.");
        }

        [TestMethod]
        public void MatchGivenMatchingPatternShouldNotFail()
        {
            Specify.That("aaa").Should.Match("a+");
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
        public void MatchGivenNonMatchingPatternShouldFail()
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
        public void MatchNegatedGivenNonMatchingPatternShouldNotFail()
        {
            Specify.That("aaa").Should.Not.Match("b+");
        }

        [TestMethod]
        public void EndWithGivenStringAtEndShouldNotFail()
        {
            Specify.That("xyzzy").Should.EndWith("zy");
        }

        [TestMethod]
        public void EndWithNegatedGivenStringAtEndShouldFail()
        {
            try
            {
                Specify.That("xyzzy").Should.Not.EndWith("zy");
            }
            catch (AssertFailedException)
            {
                return;
            }

            Specify.Failure("Specification did not fail.");
        }

        [TestMethod]
        public void EndWithGivenStringNotAtEndShouldFail()
        {
            try
            {
                Specify.That("zyzzy").Should.EndWith("42");
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
        public void StartWithGivenStringAtStartShouldNotFail()
        {
            Specify.That("xyzzy").Should.StartWith("xy");
        }

        [TestMethod]
        public void StartWithNegatedGivenStringAtStartShouldFail()
        {
            try
            {
                Specify.That("xyzzy").Should.Not.StartWith("xy");
            }
            catch (AssertFailedException)
            {
                return;
            }

            Specify.Failure("Specification did not fail.");
        }

        [TestMethod]
        public void StartWithGivenStringNotAtStartShouldFail()
        {
            try
            {
                Specify.That("xyzzy").Should.StartWith("42");
            }
            catch (AssertFailedException)
            {
                return;
            }

            Specify.Failure("Specification did not fail.");
        }

        [TestMethod]
        public void StartWithNegatedGivenSttringNotAtStartShouldNotFail()
        {
            Specify.That("xyzzy").Should.Not.StartWith("42");
        }
    }
}
