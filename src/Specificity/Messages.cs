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
    using Testing.Specificity.Properties;

    /// <summary>
    /// Provides localized messages obtained from the resource file.
    /// </summary>
    internal static partial class Messages
    {
        /// <summary>
        /// Gets a message string indicating both references are for the same collection.
        /// </summary>
        /// <value>A message string indicating that both references are for the same collection.</value>
        public static string BothSameCollection
        {
            get { return GetMessage("BothSameCollection"); }
        }

        /// <summary>
        /// Gets a message indicating collections contain the same elements.
        /// </summary>
        /// <value>A message string indicating the collections contain the same elements.</value>
        public static string ContainsSameElements
        {
            get { return GetMessage("ContainsSameElements"); }
        }

        /// <summary>
        /// Gets a message indicating the elements at a specified index don't match.
        /// </summary>
        /// <value>A message string indicating the elements at index do not match.</value>
        public static string ElementsAtIndexDoNotMatch
        {
            get { return GetMessage("ElementsAtIndexDoNotMatch"); }
        }

        /// <summary>
        /// Gets a textual representation of a null value.
        /// </summary>
        /// <value>The textual representation of a null value.</value>
        public static string NullValue
        {
            get { return GetMessage("NullValue"); }
        }

        /// <summary>
        /// Gets a message string indicating the constraint failed.
        /// </summary>
        /// <param name="constraint">The constraint.</param>
        /// <returns>A message string indicating the constraint failed.</returns>
        public static string ConstraintFailed(string constraint)
        {
            return Format("ConstraintFailed", constraint);
        }

        /// <summary>
        /// The string does not contain the substring.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="substring">The substring.</param>
        /// <returns>A message string indicating the string does not contain the substring.</returns>
        public static string ContainsFail(string value, string substring)
        {
            return Format("ContainsFail", value, substring);
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
            return Format("DifferenceLessThanDelta", delta, expected, actual);
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
            return Format("DifferenceMoreThanDelta", delta, expected, actual);
        }

        /// <summary>
        /// The string does not start with the substring.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="substring">The substring.</param>
        /// <returns>A message string indicating the string does not start with the substring.</returns>
        public static string DoesNotStartWith(string value, string substring)
        {
            return Format("DoesNotStartWith", value, substring);
        }

        /// <summary>
        /// A duplicate element was found.
        /// </summary>
        /// <param name="duplicateItem">The duplicate item.</param>
        /// <returns>A message string indicating that a duplicate element was found.</returns>
        public static string DuplicateElement(object duplicateItem)
        {
            return Format("DuplicateElement", duplicateItem);
        }

        /// <summary>
        /// Element numbers do not match.
        /// </summary>
        /// <param name="expectedCount">The expected count.</param>
        /// <param name="actualCount">The actual count.</param>
        /// <returns>A message string indicating that the element numbers do not match.</returns>
        public static string ElementNumbersDoNotMatch(int expectedCount, int actualCount)
        {
            return Format("ElementNumbersDoNotMatch", expectedCount, actualCount);
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
            return Format("ElementTypesAtIndexDoNotMatch", index, expectedType, actualType);
        }

        /// <summary>
        /// Element types at specified index do not match.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="expectedType">The expected type.</param>
        /// <returns>A message string indicating that element types at the specified index do not match.</returns>
        public static string ElementTypesAtIndexDoNotMatch2(int index, Type expectedType)
        {
            return Format("ElementTypesAtIndexDoNotMatch2", index, expectedType);
        }

        /// <summary>
        /// The string does not end with the substring.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="substring">The substring.</param>
        /// <returns>A message string indicating the string does not end with the substring.</returns>
        public static string EndsWithFail(string value, string substring)
        {
            return Format("EndsWithFail", value, substring);
        }

        /// <summary>
        /// Objects are equal.
        /// </summary>
        /// <param name="expected">The expected value.</param>
        /// <param name="actual">The actual value.</param>
        /// <returns>A message string indicating the objects are equal.</returns>
        public static string Equal(object expected, object actual)
        {
            return Format("Equal", expected, actual);
        }

        /// <summary>
        /// Types were equal.
        /// </summary>
        /// <param name="wrongType">Type of the wrong.</param>
        /// <param name="actualType">The actual type.</param>
        /// <returns>A message string indicating the types were equal.</returns>
        public static string EqualTypes(Type wrongType, Type actualType)
        {
            return Format("EqualTypes", wrongType, actualType);
        }

        /// <summary>
        /// The string does not match the pattern.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="pattern">The pattern.</param>
        /// <returns>A message string indicating the string does not match the pattern.</returns>
        public static string IsMatchFail(string value, Regex pattern)
        {
            return Format("IsMatchFail", value, pattern);
        }

        /// <summary>
        /// The string matches the pattern.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="pattern">The pattern.</param>
        /// <returns>A message string indicating the string matches the pattern.</returns>
        public static string IsNotMatchFail(string value, Regex pattern)
        {
            return Format("IsNotMatchFail", value, pattern);
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
            return Format("MismatchedElements", expectedCount, mismatchedObject, actualCount);
        }

        /// <summary>
        /// No exception was thrown.
        /// </summary>
        /// <param name="actualType">The actual type.</param>
        /// <returns>A message string indicating that no exception was thrown.</returns>
        public static string NoExceptionThrown(Type actualType)
        {
            return Format("NoExceptionThrown", actualType);
        }

        /// <summary>
        /// The string contains the substring.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="substring">The substring.</param>
        /// <returns>A message string indicating the string contains the substring.</returns>
        public static string NotContainsFail(string value, string substring)
        {
            return Format("NotContainsFail", value, substring);
        }

        /// <summary>
        /// The string ends with the substring.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="substring">The substring.</param>
        /// <returns>A message string indicating the string ends with the substring.</returns>
        public static string NotEndsWithFail(string value, string substring)
        {
            return Format("NotEndsWithFail", value, substring);
        }

        /// <summary>
        /// Objects are not equal.
        /// </summary>
        /// <param name="expected">The expected value.</param>
        /// <param name="actual">The actual value.</param>
        /// <returns>A message string indicating the objects are not equal.</returns>
        public static string NotEqual(object expected, object actual)
        {
            return Format("NotEqual", expected, actual);
        }

        /// <summary>
        /// Types were not equal.
        /// </summary>
        /// <param name="expectedType">The expected type.</param>
        /// <param name="actualType">The actual type.</param>
        /// <returns>A message string indicating the types were not equal.</returns>
        public static string NotEqualTypes(Type expectedType, Type actualType)
        {
            return Format("NotEqualTypes", expectedType, actualType);
        }

        /// <summary>
        /// The string starts with the substring.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="substring">The substring.</param>
        /// <returns>A message string indicating the string starts with the substring.</returns>
        public static string StartsWith(string value, string substring)
        {
            return Format("StartsWith", value, substring);
        }

        /// <summary>
        /// Unexpected exception was thrown.
        /// </summary>
        /// <param name="exceptionType">Type of the exception.</param>
        /// <returns>A message string indicating that an unexpected exception was thrown.</returns>
        public static string UnexpectedException(Type exceptionType)
        {
            return Format("UnexpectedException", exceptionType);
        }

        /// <summary>
        /// An unexpected exception type was thrown.
        /// </summary>
        /// <param name="expectedType">The expected type.</param>
        /// <param name="actualType">The actual type.</param>
        /// <returns>A message string indicating that an unexpected exception type was thrown.</returns>
        public static string UnexpectedExceptionType(Type expectedType, Type actualType)
        {
            return Format("UnexpectedException", expectedType, actualType);
        }

        /// <summary>
        /// Formats the specified string from the string resources.
        /// </summary>
        /// <param name="name">The name of the string resource.</param>
        /// <param name="parameters">The parameters to use to format the string.</param>
        /// <returns>The formatted string.</returns>
        private static string Format(string name, params object[] parameters)
        {
            string format = GetMessage(name);
            return string.Format(CultureInfo.CurrentCulture, format, parameters);
        }

        /// <summary>
        /// Gets the message text from the resources.
        /// </summary>
        /// <param name="name">The name of the string resource.</param>
        /// <returns>The message text.</returns>
        private static string GetMessage(string name)
        {
            return Resources.ResourceManager.GetString(name);
        }
    }
}