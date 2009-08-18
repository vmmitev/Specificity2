using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Testing.Specificity
{
    internal static class Messages
    {
        public static string UnexpectedExceptionType(Type expectedType, Type actualType)
        {
            return Format(
                Properties.Resources.UnexpectedException,
                expectedType,
                actualType);
        }

        public static string NoExceptionThrown(Type actualType)
        {
            return Format(
                Properties.Resources.NoExceptionThrown,
                actualType);
        }

        public static string UnexpectedException(Type exceptionType)
        {
            return Format(
                Properties.Resources.UnexpectedException,
                exceptionType);
        }

        public static string ElementTypesAtIndexDoNotMatch(int index, Type expectedType, Type actualType)
        {
            return Format(
                Properties.Resources.ElementTypesAtIndexDoNotMatch,
                index,
                expectedType,
                actualType);
        }

        public static string ElementTypesAtIndexDoNotMatch2(int index, Type expectedType)
        {
            return Format(
                Properties.Resources.ElementTypesAtIndexDoNotMatch2,
                index,
                expectedType);
        }

        public static string DuplicateElement(object duplicateItem)
        {
            return Format(
                Properties.Resources.DuplicateElement,
                duplicateItem);
        }

        public static string NullValue
        {
            get { return Properties.Resources.NullValue; }
        }

        public static string ElementNumbersDoNotMatch(int expectedCount, int actualCount)
        {
            return Format(
                Properties.Resources.ElementNumbersDoNotMatch,
                expectedCount,
                actualCount);
        }

        //public static string ElementAtIndexDoNotMatch(int index, object expected, object actual)
        //{
        //    return Format(
        //        Properties.Resources.ElementsAtIndexDoNotMatch,
        //        index,
        //        expected,
        //        actual);
        //}

        public static string MismatchedElements(int expectedCount, object mismatchedObject, int actualCount)
        {
            return Format(
                Properties.Resources.MismatchedElements,
                expectedCount,
                mismatchedObject,
                actualCount);
        }

        public static string BothSameCollection
        {
            get { return Properties.Resources.BothSameCollection; }
        }

        public static string BothCollectionsEmpty
        {
            get { return Properties.Resources.BothCollectionsEmpty; }
        }

        public static string BothSameElements
        {
            get { return Properties.Resources.BothSameElements; }
        }

        public static string DifferenceMoreThanDelta<T>(T delta, T expected, T actual)
        {
            return Format(
                Properties.Resources.DifferenceMoreThanDelta,
                delta,
                expected,
                actual);
        }

        public static string DifferenceLessThanDelta<T>(T delta, T expected, T actual)
        {
            return Format(
                Properties.Resources.DifferenceLessThanDelta,
                delta,
                expected,
                actual);
        }

        public static string ContainsSameElements
        {
            get { return Properties.Resources.ContainsSameElements; }
        }

        public static string NotEqual(object expected, object actual)
        {
            return Format(
                Properties.Resources.NotEqual,
                expected,
                actual);
        }

        public static string Equal(object expected, object actual)
        {
            return Format(
                Properties.Resources.Equal,
                expected,
                actual);
        }

        public static string GivenValueTypes
        {
            get { return Properties.Resources.GivenValueTypes; }
        }

        public static string NotEqualTypes(Type expectedType, Type actualType)
        {
            return Format(
                Properties.Resources.NotEqualTypes,
                expectedType,
                actualType);
        }

        public static string EqualTypes(Type wrongType, Type actualType)
        {
            return Format(
                Properties.Resources.EqualTypes,
                wrongType,
                actualType);
        }

        public static string ContainsFail(string value, string substring)
        {
            return Format(
                Properties.Resources.ContainsFail,
                value,
                substring);
        }

        public static string NotContainsFail(string value, string substring)
        {
            return Format(
                Properties.Resources.NotContainsFail,
                value,
                substring);
        }

        public static string IsMatchFail(string value, Regex pattern)
        {
            return Format(
                Properties.Resources.IsMatchFail,
                value,
                pattern);
        }

        public static string IsNotMatchFail(string value, Regex pattern)
        {
            return Format(
                Properties.Resources.IsNotMatchFail,
                value,
                pattern);
        }

        public static string EndsWithFail(string value, string substring)
        {
            return Format(
                Properties.Resources.EndsWithFail,
                value,
                substring);
        }

        public static string NotEndsWithFail(string value, string substring)
        {
            return Format(
                Properties.Resources.NotEndsWithFail,
                value,
                substring);
        }

        public static string DoesNotStartWith(string value, string substring)
        {
            return Format(
                Properties.Resources.DoesNotStartWith,
                value,
                substring);
        }

        public static string StartsWith(string value, string substring)
        {
            return Format(
                Properties.Resources.StartsWith,
                value,
                substring);
        }

        private static string Format(string template, params object[] paramters)
        {
            return string.Format(CultureInfo.CurrentCulture, template, paramters);
        }
    }
}
