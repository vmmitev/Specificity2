//-----------------------------------------------------------------------------
// <copyright file="StringConstraints.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Testing.Specificity
{
    using System;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Provides extension methods for String assertions.
    /// </summary>
    public static class StringConstraints
    {
        public static void BeEqualTo(this IConstraint<string> self, string expected, StringComparison comparisonType)
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.BeEqualTo(expected, comparisonType);
        }

        public static void BeEqualTo(this IConstraint<string> self, string expected, StringComparison comparisonType, string message, params object[] parameters)
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            if (string.Compare(expected, self.Value, comparisonType) != 0)
            {
                self.FailIfNotNegated(
                    self.FormatErrorMessage(
                        "BeEqualTo",
                        Messages.NotEqual(expected, self.Value),
                        message,
                        parameters));
            }
            else
            {
                self.FailIfNegated(
                    self.FormatErrorMessage(
                        "BeEqualTo",
                        Messages.Equal(expected, self.Value),
                        message,
                        parameters));
            }
        }

        public static void BeNullOrEmpty(this IConstraint<string> self, string message, params object[] parameters)
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            if (!string.IsNullOrEmpty(self.Value))
            {
                self.FailIfNotNegated(
                    self.FormatErrorMessage(
                        "BeNullOrEmpty",
                        null,
                        message,
                        parameters));
            }
            else
            {
                self.FailIfNegated(
                    self.FormatErrorMessage(
                        "BeNullOrEmpty",
                        null,
                        message,
                        parameters));
            }
        }

        public static void Contain(this IConstraint<string> self, string substring, StringComparison comparisonType)
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.Contain(substring, comparisonType);
        }

        public static void Contain(this IConstraint<string> self, string substring, StringComparison comparisonType, string message, params object[] parameters)
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            if (0 > self.Value.IndexOf(substring, comparisonType))
            {
                self.FailIfNotNegated(
                    self.FormatErrorMessage(
                        "Contain",
                        Messages.ContainsFail(self.Value, substring),
                        message,
                        parameters));
            }
            else
            {
                self.FailIfNegated(
                    self.FormatErrorMessage(
                        "Contain",
                        Messages.NotContainsFail(self.Value, substring),
                        message,
                        parameters));

            }
        }

        public static void Match(this IConstraint<string> self, Regex pattern)
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            if (pattern == null)
            {
                throw new ArgumentNullException("pattern");
            }

            self.Match(pattern, null);
        }

        public static void Match(this IConstraint<string> self, Regex pattern, string message, params object[] parameters)
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            if (pattern == null)
            {
                throw new ArgumentNullException("pattern");
            }

            if (!pattern.IsMatch(self.Value))
            {
                self.FailIfNotNegated(
                    self.FormatErrorMessage(
                        "Match",
                        Messages.IsMatchFail(self.Value, pattern),
                        message,
                        parameters));
            }
            else
            {
                self.FailIfNegated(
                    self.FormatErrorMessage(
                        "Match",
                        Messages.IsNotMatchFail(self.Value, pattern),
                        message,
                        parameters));
            }
        }

        public static void EndWith(this IConstraint<string> self, string substring, StringComparison comparisonType, string message, params object[] parameters)
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            if (!self.Value.EndsWith(substring, comparisonType))
            {
                self.FailIfNotNegated(
                    self.FormatErrorMessage(
                        "EndWith",
                        Messages.EndsWithFail(self.Value, substring),
                        message,
                        parameters));
            }
            else
            {
                self.FailIfNegated(
                    self.FormatErrorMessage(
                        "EndWith",
                        Messages.NotEndsWithFail(self.Value, substring),
                        message,
                        parameters));
            }
        }

        /// <summary>
        /// Verifies the specification value value is equal to an expected value.
        /// </summary>
        /// <param name="self">The specification value.</param>
        /// <param name="expected">The expected.</param>
        /// <param name="comparisonType">One of the <see cref="StringComparison"/> values.</param>
        /// <param name="message">The message to use in failure exceptions.</param>
        /// <param name="parameters">The parameters used when formatting <paramref name="message"/>.</param>
        /// <returns>
        /// The <see cref="ConstrainedValue{T}"/> specification value.
        /// </returns>
        /// <exception cref="ConstraintFailedException">The assertion failed.</exception>
        public static ConstrainedValue<string> ShouldBeEqualTo(this ConstrainedValue<string> self, string expected, StringComparison comparisonType, string message, params object[] parameters)
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.Should.BeEqualTo(expected, comparisonType, message, parameters);
            return self;
        }

        /// <summary>
        /// Verifies the specification value value is equal to an expected value.
        /// </summary>
        /// <param name="self">The specification value.</param>
        /// <param name="expected">The expected.</param>
        /// <param name="comparisonType">One of the <see cref="StringComparison"/> values.</param>
        /// <returns>
        /// The <see cref="ConstrainedValue{T}"/> specification value.
        /// </returns>
        /// <exception cref="ConstraintFailedException">The assertion failed.</exception>
        public static ConstrainedValue<string> ShouldBeEqualTo(this ConstrainedValue<string> self, string expected, StringComparison comparisonType)
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.Should.BeEqualTo(expected, comparisonType, null);
            return self;
        }

        /// <summary>
        /// Verifies the specification value value is not equal to an expected value.
        /// </summary>
        /// <param name="self">The specification value.</param>
        /// <param name="expected">The expected.</param>
        /// <param name="comparisonType">One of the <see cref="StringComparison"/> values.</param>
        /// <param name="message">The message to use in failure exceptions.</param>
        /// <param name="parameters">The parameters used when formatting <paramref name="message"/>.</param>
        /// <returns>
        /// The <see cref="ConstrainedValue{T}"/> specification value.
        /// </returns>
        /// <exception cref="ConstraintFailedException">The assertion failed.</exception>
        public static ConstrainedValue<string> ShouldNotBeEqualTo(this ConstrainedValue<string> self, string expected, StringComparison comparisonType, string message, params object[] parameters)
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.Should.Not.BeEqualTo(expected, comparisonType, message, parameters);
            return self;
        }

        /// <summary>
        /// Verifies the specification value value is not equal to an expected value.
        /// </summary>
        /// <param name="self">The specification value.</param>
        /// <param name="expected">The expected.</param>
        /// <param name="comparisonType">One of the <see cref="StringComparison"/> values.</param>
        /// <returns>
        /// The <see cref="ConstrainedValue{T}"/> specification value.
        /// </returns>
        /// <exception cref="ConstraintFailedException">The assertion failed.</exception>
        public static ConstrainedValue<string> ShouldNotBeEqualTo(this ConstrainedValue<string> self, string expected, StringComparison comparisonType)
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.Should.Not.BeEqualTo(expected, comparisonType, null);
            return self;
        }

        /// <summary>
        /// Verifies the specification value value is not a <see langword="null"/> reference or <see cref="String.Empty"/>.
        /// </summary>
        /// <param name="self">The specification value.</param>
        /// <param name="message">The message to use in failure exceptions.</param>
        /// <param name="parameters">The parameters used when formatting <paramref name="message"/>.</param>
        /// <returns>
        /// The <see cref="ConstrainedValue{T}"/> specification value.
        /// </returns>
        /// <exception cref="ConstraintFailedException">The assertion failed.</exception>
        public static ConstrainedValue<string> ShouldNotBeNullOrEmpty(this ConstrainedValue<string> self, string message, params object[] parameters)
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.Should.Not.BeNullOrEmpty(message, parameters);
            return self;
        }

        /// <summary>
        /// Verifies the specification value value is not a <see langword="null"/> reference or <see cref="String.Empty"/>.
        /// </summary>
        /// <param name="self">The specification value.</param>
        /// <returns>
        /// The <see cref="ConstrainedValue{T}"/> specification value.
        /// </returns>
        /// <exception cref="ConstraintFailedException">The assertion failed.</exception>
        public static ConstrainedValue<string> ShouldNotBeNullOrEmpty(this ConstrainedValue<string> self)
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.Should.Not.BeNullOrEmpty(null);
            return self;
        }

        /// <summary>
        /// Verifies the specification value value contains the specified substring.
        /// </summary>
        /// <param name="self">The specification value.</param>
        /// <param name="substring">The substring to search for.</param>
        /// <param name="comparisonType">One of the <see cref="StringComparison"/> values.</param>
        /// <param name="message">The message to use in failure exceptions.</param>
        /// <param name="parameters">The parameters used when formatting <paramref name="message"/>.</param>
        /// <returns>
        /// The <see cref="ConstrainedValue{T}"/> specification value.
        /// </returns>
        /// <exception cref="ConstraintFailedException">The assertion failed.</exception>
        public static ConstrainedValue<string> ShouldContain(this ConstrainedValue<string> self, string substring, StringComparison comparisonType, string message, params object[] parameters)
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.Should.Contain(substring, comparisonType, message, parameters);
            return self;
        }

        /// <summary>
        /// Verifies the specification value value contains the specified substring.
        /// </summary>
        /// <param name="self">The specification value.</param>
        /// <param name="substring">The substring to search for.</param>
        /// <param name="comparisonType">One of the <see cref="StringComparison"/> values.</param>
        /// <returns>
        /// The <see cref="ConstrainedValue{T}"/> specification value.
        /// </returns>
        /// <exception cref="ConstraintFailedException">The assertion failed.</exception>
        public static ConstrainedValue<string> ShouldContain(this ConstrainedValue<string> self, string substring, StringComparison comparisonType)
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.Should.Contain(substring, comparisonType, null);
            return self;
        }

        /// <summary>
        /// Verifies the specification value value does not contain the specified substring.
        /// </summary>
        /// <param name="self">The specification value.</param>
        /// <param name="substring">The substring to search for.</param>
        /// <param name="comparisonType">One of the <see cref="StringComparison"/> values.</param>
        /// <param name="message">The message to use in failure exceptions.</param>
        /// <param name="parameters">The parameters used when formatting <paramref name="message"/>.</param>
        /// <returns>
        /// The <see cref="ConstrainedValue{T}"/> specification value.
        /// </returns>
        /// <exception cref="ConstraintFailedException">The assertion failed.</exception>
        public static ConstrainedValue<string> ShouldNotContain(this ConstrainedValue<string> self, string substring, StringComparison comparisonType, string message, params object[] parameters)
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.Should.Not.Contain(substring, comparisonType, message, parameters);
            return self;
        }

        /// <summary>
        /// Verifies the specification value value does not contain the specified substring.
        /// </summary>
        /// <param name="self">The specification value.</param>
        /// <param name="substring">The substring to search for.</param>
        /// <param name="comparisonType">One of the <see cref="StringComparison"/> values.</param>
        /// <returns>
        /// The <see cref="ConstrainedValue{T}"/> specification value.
        /// </returns>
        /// <exception cref="ConstraintFailedException">The assertion failed.</exception>
        public static ConstrainedValue<string> ShouldNotContain(this ConstrainedValue<string> self, string substring, StringComparison comparisonType)
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.Should.Not.Contain(substring, comparisonType, null);
            return self;
        }

        /// <summary>
        /// Verifies the specification value value matches the specified regular expression pattern.
        /// </summary>
        /// <param name="self">The specification value.</param>
        /// <param name="pattern">The regular expression pattern to match against.</param>
        /// <param name="message">The message to use in failure exceptions.</param>
        /// <param name="parameters">The parameters used when formatting <paramref name="message"/>.</param>
        /// <returns>
        /// The <see cref="ConstrainedValue{T}"/> specification value.
        /// </returns>
        /// <exception cref="ConstraintFailedException">The assertion failed.</exception>
        public static ConstrainedValue<string> ShouldMatch(this ConstrainedValue<string> self, Regex pattern, string message, params object[] parameters)
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            if (pattern == null)
            {
                throw new ArgumentNullException("pattern");
            }

            self.Should.Match(pattern, message, parameters);
            return self;
        }

        /// <summary>
        /// Verifies the specification value value matches the specified regular expression pattern.
        /// </summary>
        /// <param name="self">The specification value.</param>
        /// <param name="pattern">The regular expression pattern to match agains.</param>
        /// <returns>
        /// The <see cref="ConstrainedValue{T}"/> specification value.
        /// </returns>
        /// <exception cref="ConstraintFailedException">The assertion failed.</exception>
        public static ConstrainedValue<string> ShouldMatch(this ConstrainedValue<string> self, Regex pattern)
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            if (pattern == null)
            {
                throw new ArgumentNullException("pattern");
            }

            self.Should.Match(pattern, null);
            return self;
        }

        /// <summary>
        /// Verifies the specification value value does not match the specified regular expression pattern.
        /// </summary>
        /// <param name="self">The specification value.</param>
        /// <param name="pattern">The regular expression pattern to match against.</param>
        /// <param name="message">The message to use in failure exceptions.</param>
        /// <param name="parameters">The parameters used when formatting <paramref name="message"/>.</param>
        /// <returns>
        /// The <see cref="ConstrainedValue{T}"/> specification value.
        /// </returns>
        /// <exception cref="ConstraintFailedException">The assertion failed.</exception>
        public static ConstrainedValue<string> ShouldNotMatch(this ConstrainedValue<string> self, Regex pattern, string message, params object[] parameters)
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            if (pattern == null)
            {
                throw new ArgumentNullException("pattern");
            }

            self.Should.Not.Match(pattern, message, parameters);
            return self;
        }

        /// <summary>
        /// Verifies the specification value value does not match the specified regular expression pattern.
        /// </summary>
        /// <param name="self">The specification value.</param>
        /// <param name="pattern">The regular expression pattern to match agains.</param>
        /// <returns>
        /// The <see cref="ConstrainedValue{T}"/> specification value.
        /// </returns>
        /// <exception cref="ConstraintFailedException">The assertion failed.</exception>
        public static ConstrainedValue<string> ShouldNotMatch(this ConstrainedValue<string> self, Regex pattern)
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            if (pattern == null)
            {
                throw new ArgumentNullException("pattern");
            }

            self.Should.Not.Match(pattern, null);
            return self;
        }

        /// <summary>
        /// Verifies the specification value value ends with the specified substring.
        /// </summary>
        /// <param name="self">The specification value.</param>
        /// <param name="substring">The substring to search for.</param>
        /// <param name="comparisonType">One of the <see cref="StringComparison"/> values.</param>
        /// <param name="message">The message to use in failure exceptions.</param>
        /// <param name="parameters">The parameters used when formatting <paramref name="message"/>.</param>
        /// <returns>
        /// The <see cref="ConstrainedValue{T}"/> specification value.
        /// </returns>
        /// <exception cref="ConstraintFailedException">The assertion failed.</exception>
        public static ConstrainedValue<string> ShouldEndWith(this ConstrainedValue<string> self, string substring, StringComparison comparisonType, string message, params object[] parameters)
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.Should.EndWith(substring, comparisonType, message, parameters);
            return self;
        }

        /// <summary>
        /// Verifies the specification value value ends with the specified substring.
        /// </summary>
        /// <param name="self">The specification value.</param>
        /// <param name="substring">The substring to search for.</param>
        /// <param name="comparisonType">One of the <see cref="StringComparison"/> values.</param>
        /// <returns>
        /// The <see cref="ConstrainedValue{T}"/> specification value.
        /// </returns>
        /// <exception cref="ConstraintFailedException">The assertion failed.</exception>
        public static ConstrainedValue<string> ShouldEndWith(this ConstrainedValue<string> self, string substring, StringComparison comparisonType)
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.Should.EndWith(substring, comparisonType, null);
            return self;
        }

        /// <summary>
        /// Verifies the specification value value does not end with the specified substring.
        /// </summary>
        /// <param name="self">The specification value.</param>
        /// <param name="substring">The substring to search for.</param>
        /// <param name="comparisonType">One of the <see cref="StringComparison"/> values.</param>
        /// <param name="message">The message to use in failure exceptions.</param>
        /// <param name="parameters">The parameters used when formatting <paramref name="message"/>.</param>
        /// <returns>
        /// The <see cref="ConstrainedValue{T}"/> specification value.
        /// </returns>
        /// <exception cref="ConstraintFailedException">The assertion failed.</exception>
        public static ConstrainedValue<string> ShouldNotEndWith(this ConstrainedValue<string> self, string substring, StringComparison comparisonType, string message, params object[] parameters)
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.Should.Not.EndWith(substring, comparisonType, message, parameters);
            return self;
        }

        /// <summary>
        /// Verifies the specification value value does not end with the specified substring.
        /// </summary>
        /// <param name="self">The specification value.</param>
        /// <param name="substring">The substring to search for.</param>
        /// <param name="comparisonType">One of the <see cref="StringComparison"/> values.</param>
        /// <returns>
        /// The <see cref="ConstrainedValue{T}"/> specification value.
        /// </returns>
        /// <exception cref="ConstraintFailedException">The assertion failed.</exception>
        public static ConstrainedValue<string> ShouldNotEndWith(this ConstrainedValue<string> self, string substring, StringComparison comparisonType)
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.Should.Not.EndWith(substring, comparisonType, null);
            return self;
        }

        /// <summary>
        /// Verifies the specification value value starts with the specified substring.
        /// </summary>
        /// <param name="self">The specification value.</param>
        /// <param name="substring">The substring to search for.</param>
        /// <param name="comparisonType">One of the <see cref="StringComparison"/> values.</param>
        /// <param name="message">The message to use in failure exceptions.</param>
        /// <param name="parameters">The parameters used when formatting <paramref name="message"/>.</param>
        /// <returns>
        /// The <see cref="ConstrainedValue{T}"/> specification value.
        /// </returns>
        /// <exception cref="ConstraintFailedException">The assertion failed.</exception>
        public static ConstrainedValue<string> ShouldStartWith(this ConstrainedValue<string> self, string substring, StringComparison comparisonType, string message, params object[] parameters)
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            if (!self.Value.StartsWith(substring, comparisonType))
            {
                Specify.Fail(
                    "ShouldStartWith",
                    Messages.DoesNotStartWith(self.Value, substring),
                    message,
                    parameters);
            }

            return self;
        }

        /// <summary>
        /// Verifies the specification value value starts with the specified substring.
        /// </summary>
        /// <param name="self">The specification value.</param>
        /// <param name="substring">The substring to search for.</param>
        /// <param name="comparisonType">One of the <see cref="StringComparison"/> values.</param>
        /// <returns>
        /// The <see cref="ConstrainedValue{T}"/> specification value.
        /// </returns>
        /// <exception cref="ConstraintFailedException">The assertion failed.</exception>
        public static ConstrainedValue<string> ShouldStartWith(this ConstrainedValue<string> self, string substring, StringComparison comparisonType)
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            return self.ShouldStartWith(substring, comparisonType, null);
        }

        /// <summary>
        /// Verifies the specification value value does not start with the specified substring.
        /// </summary>
        /// <param name="self">The specification value.</param>
        /// <param name="substring">The substring to search for.</param>
        /// <param name="comparisonType">One of the <see cref="StringComparison"/> values.</param>
        /// <param name="message">The message to use in failure exceptions.</param>
        /// <param name="parameters">The parameters used when formatting <paramref name="message"/>.</param>
        /// <returns>
        /// The <see cref="ConstrainedValue{T}"/> specification value.
        /// </returns>
        /// <exception cref="ConstraintFailedException">The assertion failed.</exception>
        public static ConstrainedValue<string> ShouldNotStartWith(this ConstrainedValue<string> self, string substring, StringComparison comparisonType, string message, params object[] parameters)
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            if (self.Value.StartsWith(substring, comparisonType))
            {
                Specify.Fail(
                    "ShouldNotStartWith",
                    Messages.StartsWith(self.Value, substring),
                    message,
                    parameters);
            }

            return self;
        }

        /// <summary>
        /// Verifies the specification value value does not start with the specified substring.
        /// </summary>
        /// <param name="self">The specification value.</param>
        /// <param name="substring">The substring to search for.</param>
        /// <param name="comparisonType">One of the <see cref="StringComparison"/> values.</param>
        /// <returns>
        /// The <see cref="ConstrainedValue{T}"/> specification value.
        /// </returns>
        /// <exception cref="ConstraintFailedException">The assertion failed.</exception>
        public static ConstrainedValue<string> ShouldNotStartWith(this ConstrainedValue<string> self, string substring, StringComparison comparisonType)
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            return self.ShouldNotStartWith(substring, comparisonType, null);
        }
    }
}
