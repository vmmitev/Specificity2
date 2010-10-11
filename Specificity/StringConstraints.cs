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

            if (string.Compare(expected, self.Value, comparisonType) != 0)
            {
                Specify.Fail(
                    "ShouldBeEqualTo",
                    Messages.NotEqual(expected, self.Value),
                    message,
                    parameters);
            }

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

            return self.ShouldBeEqualTo(expected, comparisonType, null);
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

            if (string.Compare(expected, self.Value, comparisonType) == 0)
            {
                Specify.Fail(
                    "ShouldNotBeEqualTo",
                    Messages.Equal(expected, self.Value), 
                    message,
                    parameters);
            }

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

            return self.ShouldNotBeEqualTo(expected, comparisonType, null);
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

            if (string.IsNullOrEmpty(self.Value))
            {
                Specify.Fail("ShouldNotBeNullOrEmpty", message, parameters);
            }

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

            return self.ShouldNotBeNullOrEmpty(null);
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

            if (0 > self.Value.IndexOf(substring, comparisonType))
            {
                Specify.Fail(
                    "ShouldContain",
                    Messages.ContainsFail(self.Value, substring),
                    message,
                    parameters);
            }

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

            return self.ShouldContain(substring, comparisonType, null);
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

            if (0 <= self.Value.IndexOf(substring, comparisonType))
            {
                Specify.Fail(
                    "ShouldNotContain",
                    Messages.NotContainsFail(self.Value, substring),
                    message,
                    parameters);
            }

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

            return self.ShouldNotContain(substring, comparisonType, null);
        }

        /// <summary>
        /// Verifies the specification value value matches the specified regular expression pattern.
        /// </summary>
        /// <param name="self">The specification value.</param>
        /// <param name="pattern">The regular expression pattern to match agains.</param>
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

            if (!pattern.IsMatch(self.Value))
            {
                Specify.Fail(
                    "ShouldMatch",
                    Messages.IsMatchFail(self.Value, pattern),
                    message,
                    parameters);
            }

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

            return self.ShouldMatch(pattern, null);
        }

        /// <summary>
        /// Verifies the specification value value does not match the specified regular expression pattern.
        /// </summary>
        /// <param name="self">The specification value.</param>
        /// <param name="pattern">The regular expression pattern to match agains.</param>
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

            if (pattern.IsMatch(self.Value))
            {
                Specify.Fail(
                    "ShouldNotMatch",
                    Messages.IsNotMatchFail(self.Value, pattern),
                    message,
                    parameters);
            }

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

            return self.ShouldNotMatch(pattern, null);
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

            if (!self.Value.EndsWith(substring, comparisonType))
            {
                Specify.Fail(
                    "ShouldEndWith",
                    Messages.EndsWithFail(self.Value, substring),
                    message,
                    parameters);
            }

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

            return self.ShouldEndWith(substring, comparisonType, null);
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

            if (self.Value.EndsWith(substring, comparisonType))
            {
                Specify.Fail(
                    "ShouldNotEndWith",
                    Messages.NotEndsWithFail(self.Value, substring),
                    message,
                    parameters);
            }

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

            return self.ShouldNotEndWith(substring, comparisonType, null);
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
