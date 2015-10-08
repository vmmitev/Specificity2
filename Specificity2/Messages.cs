// <copyright file="Messages.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>

namespace Testing.Specificity2
{
    using System;
    using System.Globalization;
    using System.Text.RegularExpressions;
    using Properties;

    /// <summary>
    /// Provides localized messages obtained from the resource file.
    /// </summary>
    internal static partial class Messages
    {
        /// <summary>
        /// Gets a message string indicating the constraint failed.
        /// </summary>
        /// <param name="constraint">The constraint.</param>
        /// <returns>A message string indicating the constraint failed.</returns>
        public static string ConstraintFailed(string constraint)
        {
            return Format(Resources.ConstraintFailed, constraint);
        }

        /// <summary>
        /// The string does not contain the substring.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="substring">The substring.</param>
        /// <returns>A message string indicating the string does not contain the substring.</returns>
        public static string ContainsFail(string value, string substring)
        {
            return Format(Resources.ContainsFail, value, substring);
        }

        /// <summary>
        /// Values differ by less than the provided delta.
        /// </summary>
        /// <typeparam name="T">The type of the values compared.</typeparam>
        /// <param name="delta">The delta.</param>
        /// <param name="expected">The expected value.</param>
        /// <param name="actual">The actual value.</param>
        /// <returns>A message string indicating the values differ by less than the provided delta.</returns>
        public static string DifferenceLessThanDelta<T>(T delta, T expected, T actual)
        {
            return Format(Resources.DifferenceLessThanDelta, delta, expected, actual);
        }

        /// <summary>
        /// Values differ by more than the provided delta.
        /// </summary>
        /// <typeparam name="T">The type of the values compared.</typeparam>
        /// <param name="delta">The delta.</param>
        /// <param name="expected">The expected value.</param>
        /// <param name="actual">The actual value.</param>
        /// <returns>A message string indicating the values differ by more than the provided delta.</returns>
        public static string DifferenceMoreThanDelta<T>(T delta, T expected, T actual)
        {
            return Format(Resources.DifferenceMoreThanDelta, delta, expected, actual);
        }

        /// <summary>
        /// The string does not start with the substring.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="substring">The substring.</param>
        /// <returns>A message string indicating the string does not start with the substring.</returns>
        public static string DoesNotStartWith(string value, string substring)
        {
            return Format(Resources.DoesNotStartWith, value, substring);
        }

        /// <summary>
        /// A duplicate element was found.
        /// </summary>
        /// <param name="duplicateItem">The duplicate item.</param>
        /// <returns>A message string indicating that a duplicate element was found.</returns>
        public static string DuplicateElement(object duplicateItem)
        {
            return Format(Resources.DuplicateElement, duplicateItem);
        }

        /// <summary>
        /// Element numbers do not match.
        /// </summary>
        /// <param name="expectedCount">The expected count.</param>
        /// <param name="actualCount">The actual count.</param>
        /// <returns>A message string indicating that the element numbers do not match.</returns>
        public static string ElementNumbersDoNotMatch(int expectedCount, int actualCount)
        {
            return Format(Resources.ElementNumbersDoNotMatch, expectedCount, actualCount);
        }

        /// <summary>
        /// Element types at specified index do not match.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="expectedType">The expected type.</param>
        /// <param name="actualType">The actual type.</param>
        /// <returns>A message string indicating that element types at the specified index do not match.</returns>
        public static string ElementTypesAtIndexDoNotMatch(int index, Type expectedType, Type actualType)
        {
            return Format(Resources.ElementTypesAtIndexDoNotMatch, index, expectedType, actualType);
        }

        /// <summary>
        /// Element types at specified index do not match.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="expectedType">The expected type.</param>
        /// <returns>A message string indicating that element types at the specified index do not match.</returns>
        public static string ElementTypesAtIndexDoNotMatch2(int index, Type expectedType)
        {
            return Format(Resources.ElementTypesAtIndexDoNotMatch2, index, expectedType);
        }

        /// <summary>
        /// The string does not end with the substring.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="substring">The substring.</param>
        /// <returns>A message string indicating the string does not end with the substring.</returns>
        public static string EndsWithFail(string value, string substring)
        {
            return Format(Resources.EndsWithFail, value, substring);
        }

        /// <summary>
        /// Objects are equal.
        /// </summary>
        /// <param name="expected">The expected value.</param>
        /// <param name="actual">The actual value.</param>
        /// <returns>A message string indicating the objects are equal.</returns>
        public static string Equal(object expected, object actual)
        {
            return Format(Resources.Equal, expected, actual);
        }

        /// <summary>
        /// Types were equal.
        /// </summary>
        /// <param name="wrongType">Type of the wrong.</param>
        /// <param name="actualType">The actual type.</param>
        /// <returns>A message string indicating the types were equal.</returns>
        public static string EqualTypes(Type wrongType, Type actualType)
        {
            return Format(Resources.EqualTypes, wrongType, actualType);
        }

        /// <summary>
        /// The string does not match the pattern.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="pattern">The pattern.</param>
        /// <returns>A message string indicating the string does not match the pattern.</returns>
        public static string IsMatchFail(string value, Regex pattern)
        {
            return Format(Resources.IsMatchFail, value, pattern);
        }

        /// <summary>
        /// The string matches the pattern.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="pattern">The pattern.</param>
        /// <returns>A message string indicating the string matches the pattern.</returns>
        public static string IsNotMatchFail(string value, Regex pattern)
        {
            return Format(Resources.IsNotMatchFail, value, pattern);
        }

        /// <summary>
        /// Mismatched elements found.
        /// </summary>
        /// <param name="expectedCount">The expected count.</param>
        /// <param name="mismatchedObject">The mismatched object.</param>
        /// <param name="actualCount">The actual count.</param>
        /// <returns>A message string indicating that mismatched elements were found.</returns>
        public static string MismatchedElements(int expectedCount, object mismatchedObject, int actualCount)
        {
            return Format(Resources.MismatchedElements, expectedCount, mismatchedObject, actualCount);
        }

        /// <summary>
        /// No exception was thrown.
        /// </summary>
        /// <param name="actualType">The actual type.</param>
        /// <returns>A message string indicating that no exception was thrown.</returns>
        public static string NoExceptionThrown(Type actualType)
        {
            return Format(Resources.NoExceptionThrown, actualType);
        }

        /// <summary>
        /// The string contains the substring.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="substring">The substring.</param>
        /// <returns>A message string indicating the string contains the substring.</returns>
        public static string NotContainsFail(string value, string substring)
        {
            return Format(Resources.NotContainsFail, value, substring);
        }

        /// <summary>
        /// The string ends with the substring.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="substring">The substring.</param>
        /// <returns>A message string indicating the string ends with the substring.</returns>
        public static string NotEndsWithFail(string value, string substring)
        {
            return Format(Resources.NotEndsWithFail, value, substring);
        }

        /// <summary>
        /// Objects are not equal.
        /// </summary>
        /// <param name="expected">The expected value.</param>
        /// <param name="actual">The actual value.</param>
        /// <returns>A message string indicating the objects are not equal.</returns>
        public static string NotEqual(object expected, object actual)
        {
            return Format(Resources.NotEqual, expected, actual);
        }

        /// <summary>
        /// Types were not equal.
        /// </summary>
        /// <param name="expectedType">The expected type.</param>
        /// <param name="actualType">The actual type.</param>
        /// <returns>A message string indicating the types were not equal.</returns>
        public static string NotEqualTypes(Type expectedType, Type actualType)
        {
            return Format(Resources.NotEqualTypes, expectedType, actualType);
        }

        /// <summary>
        /// The string starts with the substring.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="substring">The substring.</param>
        /// <returns>A message string indicating the string starts with the substring.</returns>
        public static string StartsWith(string value, string substring)
        {
            return Format(Resources.StartsWith, value, substring);
        }

        /// <summary>
        /// Unexpected exception was thrown.
        /// </summary>
        /// <param name="exceptionType">Type of the exception.</param>
        /// <returns>A message string indicating that an unexpected exception was thrown.</returns>
        public static string UnexpectedException(Type exceptionType)
        {
            return Format(Resources.UnexpectedException, exceptionType);
        }

        /// <summary>
        /// An unexpected exception type was thrown.
        /// </summary>
        /// <param name="expectedType">The expected type.</param>
        /// <param name="actualType">The actual type.</param>
        /// <returns>A message string indicating that an unexpected exception type was thrown.</returns>
        public static string UnexpectedExceptionType(Type expectedType, Type actualType)
        {
            return Format(Resources.UnexpectedExceptionType, expectedType, actualType);
        }

        private static string Format(string message, params object[] parameters)
        {
            return string.Format(CultureInfo.CurrentCulture, message, parameters);
        }
    }
}