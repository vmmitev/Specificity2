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
        /// Verifies the constrained <see cref="string"/> is equal to the specified value using the specified
        /// <see cref="StringComparison"/>.
        /// </summary>
        /// <param name="self">The constrained value.</param>
        /// <param name="expected">The expected value.</param>
        /// <param name="comparisonType">The <see cref="StringComparison"/> to use to compare the values.</param>
        /// <exception cref="ConstraintFailedException">The constraint failed. The exact type of exception thrown will
        /// depend on the unit test framework, if any, in use.</exception>
        public static void BeEqualTo(this IConstraint<string> self, string expected, StringComparison comparisonType)
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.BeEqualTo(expected, comparisonType);
        }

        /// <summary>
        /// Verifies the constrained <see cref="string"/> is equal to the specified value using the specified
        /// <see cref="StringComparison"/>.
        /// </summary>
        /// <param name="self">The constrained value.</param>
        /// <param name="expected">The expected value.</param>
        /// <param name="comparisonType">The <see cref="StringComparison"/> to use to compare the values.</param>
        /// <param name="message">The message to display in case of failure.</param>
        /// <param name="parameters">The parameters used to format the <paramref name="message"/>.</param>
        /// <exception cref="ConstraintFailedException">The constraint failed. The exact type of exception thrown will
        /// depend on the unit test framework, if any, in use.</exception>
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

        /// <summary>
        /// Verifies the constrained <see cref="String"/> is <see langword="null"/> or <see cref="String.Empty"/>.
        /// </summary>
        /// <param name="self">The constrained value.</param>
        /// <exception cref="ConstraintFailedException">The constraint failed. The exact type of exception thrown will
        /// depend on the unit test framework, if any, in use.</exception>
        public static void BeNullOrEmpty(this IConstraint<string> self)
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }
        }

        /// <summary>
        /// Verifies the constrained <see cref="String"/> is <see langword="null"/> or <see cref="String.Empty"/>.
        /// </summary>
        /// <param name="self">The constrained value.</param>
        /// <param name="message">The message to display in case of failure.</param>
        /// <param name="parameters">The parameters used to format the <paramref name="message"/>.</param>
        /// <exception cref="ConstraintFailedException">The constraint failed. The exact type of exception thrown will
        /// depend on the unit test framework, if any, in use.</exception>
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

        /// <summary>
        /// Verifies the constrained <see cref="String"/> contains the specified substring.
        /// </summary>
        /// <param name="self">The constrained value.</param>
        /// <param name="substring">The substring to verify is contained by the constrained value.</param>
        /// <param name="comparisonType">The <see cref="StringComparison"/> to use to compare the values.</param>
        /// <exception cref="ConstraintFailedException">The constraint failed. The exact type of exception thrown will
        /// depend on the unit test framework, if any, in use.</exception>
        public static void Contain(this IConstraint<string> self, string substring, StringComparison comparisonType)
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.Contain(substring, comparisonType);
        }

        /// <summary>
        /// Verifies the constrained <see cref="String"/> contains the specified substring.
        /// </summary>
        /// <param name="self">The constrained value.</param>
        /// <param name="substring">The substring to verify is contained by the constrained value.</param>
        /// <param name="comparisonType">The <see cref="StringComparison"/> to use to compare the values.</param>
        /// <param name="message">The message to display in case of failure.</param>
        /// <param name="parameters">The parameters used to format the <paramref name="message"/>.</param>
        /// <exception cref="ConstraintFailedException">The constraint failed. The exact type of exception thrown will
        /// depend on the unit test framework, if any, in use.</exception>
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

        /// <summary>
        /// Verifies the constrained <see cref="String"/> matches the specified regular expression pattern.
        /// </summary>
        /// <param name="self">The constrained value.</param>
        /// <param name="pattern">The regular expression pattern to match.</param>
        /// <exception cref="ConstraintFailedException">The constraint failed. The exact type of exception thrown will
        /// depend on the unit test framework, if any, in use.</exception>
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

        /// <summary>
        /// Verifies the constrained <see cref="String"/> matches the specified regular expression pattern.
        /// </summary>
        /// <param name="self">The constrained value.</param>
        /// <param name="pattern">The regular expression pattern to match.</param>
        /// <param name="message">The message to display in case of failure.</param>
        /// <param name="parameters">The parameters used to format the <paramref name="message"/>.</param>
        /// <exception cref="ConstraintFailedException">The constraint failed. The exact type of exception thrown will
        /// depend on the unit test framework, if any, in use.</exception>
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

        /// <summary>
        /// Verifies the constrained <see cref="String"/> ends with the specified substring.
        /// </summary>
        /// <param name="self">The constrained value.</param>
        /// <param name="substring">The substring to search for at the end of the constrained value.</param>
        /// <param name="comparisonType">The <see cref="StringComparison"/> to use to compare the values.</param>
        /// <exception cref="ConstraintFailedException">The constraint failed. The exact type of exception thrown will
        /// depend on the unit test framework, if any, in use.</exception>
        public static void EndWith(this IConstraint<string> self, string substring, StringComparison comparisonType)
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.EndWith(substring, comparisonType, null);
        }

        /// <summary>
        /// Verifies the constrained <see cref="String"/> ends with the specified substring.
        /// </summary>
        /// <param name="self">The constrained value.</param>
        /// <param name="substring">The substring to search for at the end of the constrained value.</param>
        /// <param name="comparisonType">The <see cref="StringComparison"/> to use to compare the values.</param>
        /// <param name="message">The message to display in case of failure.</param>
        /// <param name="parameters">The parameters used to format the <paramref name="message"/>.</param>
        /// <exception cref="ConstraintFailedException">The constraint failed. The exact type of exception thrown will
        /// depend on the unit test framework, if any, in use.</exception>
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
        /// Verifies the constrained <see cref="String"/> starts with the specified substring.
        /// </summary>
        /// <param name="self">The constrained value.</param>
        /// <param name="substring">The substring to search for at the start of the constrained value.</param>
        /// <param name="comparisonType">The <see cref="StringComparison"/> to use to compare the values.</param>
        /// <exception cref="ConstraintFailedException">The constraint failed. The exact type of exception thrown will
        /// depend on the unit test framework, if any, in use.</exception>
        public static void StartWith(this IConstraint<string> self, string substring, StringComparison comparisonType)
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.StartWith(substring, comparisonType, null);
        }

        /// <summary>
        /// Verifies the constrained <see cref="String"/> starts with the specified substring.
        /// </summary>
        /// <param name="self">The constrained value.</param>
        /// <param name="substring">The substring to search for at the start of the constrained value.</param>
        /// <param name="comparisonType">The <see cref="StringComparison"/> to use to compare the values.</param>
        /// <param name="message">The message to display in case of failure.</param>
        /// <param name="parameters">The parameters used to format the <paramref name="message"/>.</param>
        /// <exception cref="ConstraintFailedException">The constraint failed. The exact type of exception thrown will
        /// depend on the unit test framework, if any, in use.</exception>
        public static void StartWith(this IConstraint<string> self, string substring, StringComparison comparisonType, string message, params object[] parameters)
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            if (!self.Value.StartsWith(substring, comparisonType))
            {
                self.FailIfNotNegated(
                    self.FormatErrorMessage(
                        "StartWith",
                        Messages.DoesNotStartWith(self.Value, substring),
                        message,
                        parameters));
            }
            else
            {
                self.FailIfNegated(
                    self.FormatErrorMessage(
                        "EndWith",
                        Messages.StartsWith(self.Value, substring),
                        message,
                        parameters));
            }
        }
    }
}
