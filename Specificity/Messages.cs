//-----------------------------------------------------------------------------
// <copyright file="Messages.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Testing.Specificity
{
    using System;
    using System.Globalization;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Provides localized messages obtained from the resource file.
    /// </summary>
    internal static class Messages
    {
        /// <summary>
        /// Gets a textual representation of a null value.
        /// </summary>
        /// <value>The textual representation of a null value.</value>
        public static string NullValue
        {
            get { return Properties.Resources.NullValue; }
        }

        /// <summary>
        /// Gets a message string indicating both references are for the same collection.
        /// </summary>
        /// <value>A message string indicating that both references are for the same collection.</value>
        public static string BothSameCollection
        {
            get { return Properties.Resources.BothSameCollection; }
        }

        /// <summary>
        /// Gets a message string indicating both collections are empty.
        /// </summary>
        /// <value>A message string indicating that both collections are empty.</value>
        public static string BothCollectionsEmpty
        {
            get { return Properties.Resources.BothCollectionsEmpty; }
        }

        /// <summary>
        /// Gets a message string indicating both collections have the same elements.
        /// </summary>
        /// <value>A message string indicating both collections have the same elements.</value>
        public static string BothSameElements
        {
            get { return Properties.Resources.BothSameElements; }
        }

        /// <summary>
        /// Gets a message indicating collections contain the same elements.
        /// </summary>
        /// <value>A message string indicating the collections contain the same elements.</value>
        public static string ContainsSameElements
        {
            get { return Properties.Resources.ContainsSameElements; }
        }

        /// <summary>
        /// Gets a message indicating constraint was given value types.
        /// </summary>
        /// <value>A message string indicating the constraint was given value types.</value>
        public static string GivenValueTypes
        {
            get { return Properties.Resources.GivenValueTypes; }
        }

        /// <summary>
        /// An unexpected exception type was thrown.
        /// </summary>
        /// <param name="expectedType">The expected type.</param>
        /// <param name="actualType">The actual type.</param>
        /// <returns>A message string indicating that an unexpected exception type was thrown.</returns>
        public static string UnexpectedExceptionType(Type expectedType, Type actualType)
        {
            return Format(
                Properties.Resources.UnexpectedException,
                expectedType,
                actualType);
        }

        /// <summary>
        /// No exception was thrown.
        /// </summary>
        /// <param name="actualType">The actual type.</param>
        /// <returns>A message string indicating that no exception was thrown.</returns>
        public static string NoExceptionThrown(Type actualType)
        {
            return Format(
                Properties.Resources.NoExceptionThrown,
                actualType);
        }

        /// <summary>
        /// Unexpected exception was thrown.
        /// </summary>
        /// <param name="exceptionType">Type of the exception.</param>
        /// <returns>A message string indicating that an unexpected exception was thrown.</returns>
        public static string UnexpectedException(Type exceptionType)
        {
            return Format(
                Properties.Resources.UnexpectedException,
                exceptionType);
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
            return Format(
                Properties.Resources.ElementTypesAtIndexDoNotMatch,
                index,
                expectedType,
                actualType);
        }

        /// <summary>
        /// Element types at specified index do not match.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="expectedType">The expected type.</param>
        /// <returns>A message string indicating that element types at the specified index do not match.</returns>
        public static string ElementTypesAtIndexDoNotMatch2(int index, Type expectedType)
        {
            return Format(
                Properties.Resources.ElementTypesAtIndexDoNotMatch2,
                index,
                expectedType);
        }

        /// <summary>
        /// A duplicate element was found.
        /// </summary>
        /// <param name="duplicateItem">The duplicate item.</param>
        /// <returns>A message string indicating that a duplicate element was found.</returns>
        public static string DuplicateElement(object duplicateItem)
        {
            return Format(
                Properties.Resources.DuplicateElement,
                duplicateItem);
        }

        /// <summary>
        /// Element numbers do not match.
        /// </summary>
        /// <param name="expectedCount">The expected count.</param>
        /// <param name="actualCount">The actual count.</param>
        /// <returns>A message string indicating that the element numbers do not match.</returns>
        public static string ElementNumbersDoNotMatch(int expectedCount, int actualCount)
        {
            return Format(
                Properties.Resources.ElementNumbersDoNotMatch,
                expectedCount,
                actualCount);
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
            return Format(
                Properties.Resources.MismatchedElements,
                expectedCount,
                mismatchedObject,
                actualCount);
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
            return Format(
                Properties.Resources.DifferenceMoreThanDelta,
                delta,
                expected,
                actual);
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
            return Format(
                Properties.Resources.DifferenceLessThanDelta,
                delta,
                expected,
                actual);
        }

        /// <summary>
        /// Objects are not equal.
        /// </summary>
        /// <param name="expected">The expected value.</param>
        /// <param name="actual">The actual value.</param>
        /// <returns>A message string indicating the objects are not equal.</returns>
        public static string NotEqual(object expected, object actual)
        {
            return Format(
                Properties.Resources.NotEqual,
                expected,
                actual);
        }

        /// <summary>
        /// Objects are equal.
        /// </summary>
        /// <param name="expected">The expected value.</param>
        /// <param name="actual">The actual value.</param>
        /// <returns>A message string indicating the objects are equal.</returns>
        public static string Equal(object expected, object actual)
        {
            return Format(
                Properties.Resources.Equal,
                expected,
                actual);
        }

        /// <summary>
        /// Types were not equal.
        /// </summary>
        /// <param name="expectedType">The expected type.</param>
        /// <param name="actualType">The actual type.</param>
        /// <returns>A message string indicating the types were not equal.</returns>
        public static string NotEqualTypes(Type expectedType, Type actualType)
        {
            return Format(
                Properties.Resources.NotEqualTypes,
                expectedType,
                actualType);
        }

        /// <summary>
        /// Types were equal.
        /// </summary>
        /// <param name="wrongType">Type of the wrong.</param>
        /// <param name="actualType">The actual type.</param>
        /// <returns>A message string indicating the types were equal.</returns>
        public static string EqualTypes(Type wrongType, Type actualType)
        {
            return Format(
                Properties.Resources.EqualTypes,
                wrongType,
                actualType);
        }

        /// <summary>
        /// The string does not contain the substring.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="substring">The substring.</param>
        /// <returns>A message string indicating the string does not contain the substring.</returns>
        public static string ContainsFail(string value, string substring)
        {
            return Format(
                Properties.Resources.ContainsFail,
                value,
                substring);
        }

        /// <summary>
        /// The string contains the substring.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="substring">The substring.</param>
        /// <returns>A message string indicating the string contains the substring.</returns>
        public static string NotContainsFail(string value, string substring)
        {
            return Format(
                Properties.Resources.NotContainsFail,
                value,
                substring);
        }

        /// <summary>
        /// The string does not match the pattern.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="pattern">The pattern.</param>
        /// <returns>A message string indicating the string does not match the pattern.</returns>
        public static string IsMatchFail(string value, Regex pattern)
        {
            return Format(
                Properties.Resources.IsMatchFail,
                value,
                pattern);
        }

        /// <summary>
        /// The string matches the pattern.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="pattern">The pattern.</param>
        /// <returns>A message string indicating the string matches the pattern.</returns>
        public static string IsNotMatchFail(string value, Regex pattern)
        {
            return Format(
                Properties.Resources.IsNotMatchFail,
                value,
                pattern);
        }

        /// <summary>
        /// The string does not end with the substring.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="substring">The substring.</param>
        /// <returns>A message string indicating the string does not end with the substring.</returns>
        public static string EndsWithFail(string value, string substring)
        {
            return Format(
                Properties.Resources.EndsWithFail,
                value,
                substring);
        }

        /// <summary>
        /// The string ends with the substring.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="substring">The substring.</param>
        /// <returns>A message string indicating the string ends with the substring.</returns>
        public static string NotEndsWithFail(string value, string substring)
        {
            return Format(
                Properties.Resources.NotEndsWithFail,
                value,
                substring);
        }

        /// <summary>
        /// The string does not start with the substring.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="substring">The substring.</param>
        /// <returns>A message string indicating the string does not start with the substring.</returns>
        public static string DoesNotStartWith(string value, string substring)
        {
            return Format(
                Properties.Resources.DoesNotStartWith,
                value,
                substring);
        }

        /// <summary>
        /// The string starts with the substring.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="substring">The substring.</param>
        /// <returns>A message string indicating the string starts with the substring.</returns>
        public static string StartsWith(string value, string substring)
        {
            return Format(
                Properties.Resources.StartsWith,
                value,
                substring);
        }

        /// <summary>
        /// Formats the specified template.
        /// </summary>
        /// <param name="template">The template.</param>
        /// <param name="paramters">The paramters.</param>
        /// <returns>The formatted string.</returns>
        private static string Format(string template, params object[] paramters)
        {
            return string.Format(CultureInfo.CurrentCulture, template, paramters);
        }
    }
}
