//-----------------------------------------------------------------------------
// <copyright file="StringAssertionsTests.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Testing.SpecificityTests
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Text.RegularExpressions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Testing.Specificity;

    /// <summary>
    /// Provides tests for the <see cref="StringAssertions"/> extension methods.
    /// </summary>
    [TestClass]
    public class StringAssertionsTests
    {
        /// <summary>
        /// Verifies that <see cref="StringAssertions.ShouldBeEqualTo(ConstrainedValue{string}, string, StringComparison)"/> should not fail
        /// when given strings that differ only in case and using <see cref="StringComparison.OrdinalIgnoreCase"/>.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly",
            MessageId = "InCase",
            Justification = "This is two words, 'in case', not the single word 'incase'.")]
        [TestMethod]
        public void ShouldBeEqualTo_GivenStringsDifferingInCaseIgnoringCase_ShouldNotFail()
        {
            Specify.ThatAction(delegate
            {
                Specify.That("Foo").ShouldBeEqualTo("foo", StringComparison.OrdinalIgnoreCase);
            }).ShouldNotHaveThrown();
        }

        /// <summary>
        /// Verifies that <see cref="StringAssertions.ShouldBeEqualTo(ConstrainedValue{string}, string, StringComparison)"/> should fail
        /// when given strings that only differ in case and using <see cref="StringComparison.Ordinal"/>.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly",
            MessageId = "InCase",
            Justification = "This is two words, 'in case', not the single word 'incase'.")]
        [TestMethod]
        public void ShouldBeEqualTo_GivenStringsDifferingInCaseNotIgnoringCase_ShouldFail()
        {
            Specify.ThatAction(delegate
            {
                Specify.That("Foo").ShouldBeEqualTo("foo", StringComparison.Ordinal);
            }).ShouldHaveThrown(typeof(ConstraintFailedException));
        }

        /// <summary>
        /// Verifies that <see cref="StringAssertions.ShouldNotBeEqualTo(ConstrainedValue{string}, string, StringComparison)"/> should fail
        /// when given strings that only differ in case and using <see cref="StringComparison.OrdinalIgnoreCase"/>.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly",
            MessageId = "InCase",
            Justification = "This is two words, 'in case', not the single word 'incase'.")]
        [TestMethod]
        public void ShouldNotBeEqualTo_GivenStringsDifferingInCaseIgnoringCase_ShouldFail()
        {
            Specify.ThatAction(delegate
            {
                Specify.That("Foo").ShouldNotBeEqualTo("foo", StringComparison.OrdinalIgnoreCase);
            }).ShouldHaveThrown(typeof(ConstraintFailedException));
        }

        /// <summary>
        /// Verifies that <see cref="StringAssertions.ShouldNotBeEqualTo(ConstrainedValue{string}, string, StringComparison)"/> should not fail
        /// when given strings that only differ in case and using <see cref="StringComparison.Ordinal"/>.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly",
            MessageId = "InCase",
            Justification = "This is two words, 'in case', not the single word 'incase'.")]
        [TestMethod]
        public void ShouldNotBeEqualTo_GivenStringsDifferingInCaseNotIgnoringCase_ShouldNotFail()
        {
            Specify.ThatAction(delegate
            {
                Specify.That("Foo").ShouldNotBeEqualTo("foo", StringComparison.Ordinal);
            }).ShouldNotHaveThrown();
        }

        /// <summary>
        /// Verifies that <see cref="StringAssertions.ShouldNotBeNullOrEmpty(ConstrainedValue{string})"/> should not fail when given
        /// a non-empty string.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly",
            MessageId = "InCase",
            Justification = "This is two words, 'in case', not the single word 'incase'.")]
        [TestMethod]
        public void ShouldNotBeNullOrEmpty_GivenNonemptyString_ShouldNotFail()
        {
            Specify.ThatAction(
                delegate
                {
                    Specify.That("foo").ShouldNotBeNullOrEmpty();
                }).ShouldNotHaveThrown();
        }

        /// <summary>
        /// Verifies that <see cref="StringAssertions.ShouldNotBeNullOrEmpty(ConstrainedValue{string})"/> should fail when given
        /// an empty string.
        /// </summary>
        [TestMethod]
        public void ShouldNotBeNullOrEmpty_GivenEmptyString_ShouldFail()
        {
            Specify.ThatAction(
                delegate
                {
                    Specify.That(string.Empty).ShouldNotBeNullOrEmpty();
                }).ShouldHaveThrown(typeof(ConstraintFailedException));
        }

        /// <summary>
        /// Verifies that <see cref="StringAssertions.ShouldNotBeNullOrEmpty(ConstrainedValue{string})"/> should fail when given
        /// a <see langword="null"/> reference.
        /// </summary>
        [TestMethod]
        public void ShouldNotBeNullOrEmpty_GivenNull_ShouldFail()
        {
            Specify.ThatAction(
                delegate
                {
                    Specify.That((string)null).ShouldNotBeNullOrEmpty();
                }).ShouldHaveThrown(typeof(ConstraintFailedException));
        }

        /// <summary>
        /// Verifies that <see cref="StringAssertions.ShouldContain(ConstrainedValue{string}, string, StringComparison)"/> should not fail
        /// when given equal strings.
        /// </summary>
        [TestMethod]
        public void ShouldContain_GivenEqualStrings_ShouldNotFail()
        {
            Specify.ThatAction(delegate
            {
                Specify.That("foo").ShouldContain("foo", StringComparison.Ordinal);
            }).ShouldNotHaveThrown();
        }

        /// <summary>
        /// Verifies that <see cref="StringAssertions.ShouldContain(ConstrainedValue{string}, string, StringComparison)"/> should not fail
        /// when given a substring.
        /// </summary>
        [TestMethod]
        public void ShouldContain_GivenSubstring_ShouldNotFail()
        {
            Specify.ThatAction(delegate
            {
                Specify.That("foo").ShouldContain("fo", StringComparison.Ordinal);
            }).ShouldNotHaveThrown();
        }

        /// <summary>
        /// Verifies that <see cref="StringAssertions.ShouldContain(ConstrainedValue{string}, string, StringComparison)"/> should fail
        /// when given a string that's not a substring.
        /// </summary>
        [TestMethod]
        public void ShouldContain_GivenNonSubstring_ShouldFail()
        {
            Specify.ThatAction(delegate
            {
                Specify.That("foo").ShouldContain("bar", StringComparison.Ordinal);
            }).ShouldHaveThrown(typeof(ConstraintFailedException));
        }

        /// <summary>
        /// Verifies that <see cref="StringAssertions.ShouldNotContain(ConstrainedValue{string}, string, StringComparison)"/> should fail
        /// when given equal strings.
        /// </summary>
        [TestMethod]
        public void ShouldNotContain_GivenEqualStrings_ShouldFail()
        {
            Specify.ThatAction(delegate
            {
                Specify.That("foo").ShouldNotContain("foo", StringComparison.Ordinal);
            }).ShouldHaveThrown(typeof(ConstraintFailedException));
        }

        /// <summary>
        /// Verifies that <see cref="StringAssertions.ShouldNotContain(ConstrainedValue{string}, string, StringComparison)"/> should fail
        /// when given a substring.
        /// </summary>
        [TestMethod]
        public void ShouldNotContain_GivenSubstring_ShouldFail()
        {
            Specify.ThatAction(delegate
            {
                Specify.That("foo").ShouldNotContain("fo", StringComparison.Ordinal);
            }).ShouldHaveThrown(typeof(ConstraintFailedException));
        }

        /// <summary>
        /// Verifies that <see cref="StringAssertions.ShouldNotContain(ConstrainedValue{string}, string, StringComparison)"/> should
        /// not fail when given a string that's not a substring.
        /// </summary>
        [TestMethod]
        public void ShouldNotContain_GivenNonSubstring_ShouldNotFail()
        {
            Specify.ThatAction(delegate
            {
                Specify.That("foo").ShouldNotContain("bar", StringComparison.Ordinal);
            }).ShouldNotHaveThrown();
        }

        /// <summary>
        /// Verifies that <see cref="StringAssertions.ShouldMatch(ConstrainedValue{string}, Regex)"/> should not fail when given
        /// a pattern that matches.
        /// </summary>
        [TestMethod]
        public void ShouldMatch_GivenMatchingPattern_ShouldNotFail()
        {
            Specify.ThatAction(delegate
            {
                Specify.That("foo").ShouldMatch(new Regex("f.*"));
            }).ShouldNotHaveThrown();
        }

        /// <summary>
        /// Verifies that <see cref="StringAssertions.ShouldMatch(ConstrainedValue{string}, Regex)"/> should fail when given
        /// a pattern that does not match.
        /// </summary>
        [TestMethod]
        public void ShouldMatch_GivenNonMatchingPattern_ShouldFail()
        {
            Specify.ThatAction(delegate
            {
                Specify.That("foo").ShouldMatch(new Regex("b.*"));
            }).ShouldHaveThrown(typeof(ConstraintFailedException));
        }

        /// <summary>
        /// Verifies that <see cref="StringAssertions.ShouldNotMatch(ConstrainedValue{string}, Regex)"/> should fail when given
        /// a pattern that matches.
        /// </summary>
        [TestMethod]
        public void ShouldNotMatch_GivenMatchingPattern_ShouldFail()
        {
            Specify.ThatAction(delegate
            {
                Specify.That("foo").ShouldNotMatch(new Regex("f.*"));
            }).ShouldHaveThrown(typeof(ConstraintFailedException));
        }

        /// <summary>
        /// Verifies that <see cref="StringAssertions.ShouldNotMatch(ConstrainedValue{string}, Regex)"/> should not fail when given
        /// a pattern that does not match.
        /// </summary>
        [TestMethod]
        public void ShouldNotMatch_GivenNonMatchingPattern_ShouldNotFail()
        {
            Specify.ThatAction(delegate
            {
                Specify.That("foo").ShouldNotMatch(new Regex("b.*"));
            }).ShouldNotHaveThrown();
        }

        /// <summary>
        /// Verifies that <see cref="StringAssertions.ShouldEndWith(ConstrainedValue{string}, string, StringComparison)"/> should not
        /// fail when given a string that matches the end.
        /// </summary>
        [TestMethod]
        public void ShouldEndWith_GivenSubstringAtEnd_ShouldNotFail()
        {
            Specify.ThatAction(delegate
            {
                Specify.That("foo").ShouldEndWith("oo", StringComparison.Ordinal);
            }).ShouldNotHaveThrown();
        }

        /// <summary>
        /// Verifies that <see cref="StringAssertions.ShouldEndWith(ConstrainedValue{string}, string, StringComparison)"/> should
        /// fail when given a string that does not match the end.
        /// </summary>
        [TestMethod]
        public void ShouldEndWith_GivenSubstringNotAtEnd_ShouldFail()
        {
            Specify.ThatAction(delegate
            {
                Specify.That("foo").ShouldEndWith("bar", StringComparison.Ordinal);
            }).ShouldHaveThrown(typeof(ConstraintFailedException));
        }

        /// <summary>
        /// Verifies that <see cref="StringAssertions.ShouldNotEndWith(ConstrainedValue{string}, string, StringComparison)"/> should
        /// fail when given a string that matches the end.
        /// </summary>
        [TestMethod]
        public void ShouldNotEndWith_GivenSubstringAtEnd_ShouldFail()
        {
            Specify.ThatAction(delegate
            {
                Specify.That("foo").ShouldNotEndWith("oo", StringComparison.Ordinal);
            }).ShouldHaveThrown(typeof(ConstraintFailedException));
        }

        /// <summary>
        /// Verifies that <see cref="StringAssertions.ShouldNotEndWith(ConstrainedValue{string}, string, StringComparison)"/> should
        /// not fail when given a string that does not match the end.
        /// </summary>
        [TestMethod]
        public void ShouldNotEndWith_GivenSubstringNotAtEnd_ShouldNotFail()
        {
            Specify.ThatAction(delegate
            {
                Specify.That("foo").ShouldNotEndWith("bar", StringComparison.Ordinal);
            }).ShouldNotHaveThrown();
        }

        /// <summary>
        /// Verifies that <see cref="StringAssertions.ShouldStartWith(ConstrainedValue{string}, string, StringComparison)"/> should
        /// not fail when given a string that matches the start.
        /// </summary>
        [TestMethod]
        public void ShouldStartWith_GivenSubstringAtStart_ShouldNotFail()
        {
            Specify.ThatAction(delegate
            {
                Specify.That("foo").ShouldStartWith("fo", StringComparison.Ordinal);
            }).ShouldNotHaveThrown();
        }

        /// <summary>
        /// Verifies that <see cref="StringAssertions.ShouldStartWith(ConstrainedValue{string}, string, StringComparison)"/> should
        /// fail when given a string that does not match the start.
        /// </summary>
        [TestMethod]
        public void ShouldStartWith_GivenSubstringNotAtStart_ShouldFail()
        {
            Specify.ThatAction(delegate
            {
                Specify.That("foo").ShouldStartWith("bar", StringComparison.Ordinal);
            }).ShouldHaveThrown(typeof(ConstraintFailedException));
        }

        /// <summary>
        /// Verifies that <see cref="StringAssertions.ShouldNotStartWith(ConstrainedValue{string}, string, StringComparison)"/> should
        /// fail when given a string that matches the start.
        /// </summary>
        [TestMethod]
        public void ShouldNotStartWith_GivenSubstringAtStart_ShouldFail()
        {
            Specify.ThatAction(delegate
            {
                Specify.That("foo").ShouldNotStartWith("fo", StringComparison.Ordinal);
            }).ShouldHaveThrown(typeof(ConstraintFailedException));
        }

        /// <summary>
        /// Verifies that <see cref="StringAssertions.ShouldNotStartWith(ConstrainedValue{string}, string, StringComparison)"/> should
        /// not fail when given a string that does not match the start.
        /// </summary>
        [TestMethod]
        public void ShouldNotStartWith_GivenSubstringNotAtStart_ShouldNotFail()
        {
            Specify.ThatAction(delegate
            {
                Specify.That("foo").ShouldNotStartWith("bar", StringComparison.Ordinal);
            }).ShouldNotHaveThrown();
        }
    }
}
