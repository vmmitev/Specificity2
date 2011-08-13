//-----------------------------------------------------------------------------
// <copyright file="ObjectConstraints.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Testing.Specificity
{
    using System;
    using System.Collections;
    using System.Reflection;

    /// <summary>
    /// Provides extension methods for object assertions.
    /// </summary>
    public static class ObjectConstraints
    {
        /// <summary>
        /// Verifies the constrained reference is <see langword="null"/>.
        /// </summary>
        /// <typeparam name="T">The type of the constrained reference.</typeparam>
        /// <param name="self">The constrained value.</param>
        /// <exception cref="ConstraintFailedException">The constraint failed. The exact type of exception thrown will
        /// depend on the unit test framework, if any, in use.</exception>
        public static void BeNull<T>(this IConstraint<T> self)
            where T : class
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.BeNull(null);
        }

        /// <summary>
        /// Verifies the constrained reference is <see langword="null"/>.
        /// </summary>
        /// <typeparam name="T">The type of the constrained reference.</typeparam>
        /// <param name="self">The constrained value.</param>
        /// <param name="message">The message to display in case of failure.</param>
        /// <param name="parameters">The parameters used to format the <paramref name="message"/>.</param>
        /// <exception cref="ConstraintFailedException">The constraint failed. The exact type of exception thrown will
        /// depend on the unit test framework, if any, in use.</exception>
        public static void BeNull<T>(this IConstraint<T> self, string message, params object[] parameters)
            where T : class
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            if (self.Value != null)
            {
                self.FailIfNotNegated(
                    self.FormatErrorMessage(
                    "BeNull",
                    null,
                    message,
                    parameters));
            }
            else
            {
                self.FailIfNegated(
                    self.FormatErrorMessage(
                    "BeNull",
                    null,
                    message,
                    parameters));
            }
        }

        /// <summary>
        /// Verifies the constrained value is equal to the specified value.
        /// </summary>
        /// <typeparam name="TExpected">The type of the constrained value.</typeparam>
        /// <typeparam name="TActual">The type of the actual value.</typeparam>
        /// <param name="self">The constrained value.</param>
        /// <param name="expected">The expected value.</param>
        /// <exception cref="ConstraintFailedException">The constraint failed. The exact type of exception thrown will
        /// depend on the unit test framework, if any, in use.</exception>
        public static void BeEqualTo<TExpected, TActual>(this IConstraint<TExpected> self, TActual expected)
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.BeEqualTo(expected, null);
        }

        /// <summary>
        /// Verifies the constrained value is equal to the specified value.
        /// </summary>
        /// <typeparam name="TExpected">The type of the constrained value.</typeparam>
        /// <typeparam name="TActual">The type of the actual value.</typeparam>
        /// <param name="self">The constrained value.</param>
        /// <param name="expected">The expected value.</param>
        /// <param name="message">The message to display in case of failure.</param>
        /// <param name="parameters">The parameters used to format the <paramref name="message"/>.</param>
        /// <exception cref="ConstraintFailedException">The constraint failed. The exact type of exception thrown will
        /// depend on the unit test framework, if any, in use.</exception>
        public static void BeEqualTo<TExpected, TActual>(this IConstraint<TExpected> self, TActual expected, string message, params object[] parameters)
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            if (!object.Equals(expected, self.Value))
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
        /// Verifies the constrained reference references the same instance as the specified reference.
        /// </summary>
        /// <typeparam name="T">Type of the constrained reference.</typeparam>
        /// <param name="self">The constrained reference.</param>
        /// <param name="expected">The expected reference.</param>
        /// <exception cref="ConstraintFailedException">The constraint failed. The exact type of exception thrown will
        /// depend on the unit test framework, if any, in use.</exception>
        public static void BeSameAs<T>(this IConstraint<T> self, T expected)
            where T : class
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.BeSameAs(expected, null);
        }

        /// <summary>
        /// Verifies the constrained reference references the same instance as the specified reference.
        /// </summary>
        /// <typeparam name="T">Type of the constrained reference.</typeparam>
        /// <param name="self">The constrained reference.</param>
        /// <param name="expected">The expected reference.</param>
        /// <param name="message">The message to display in case of failure.</param>
        /// <param name="parameters">The parameters used to format the <paramref name="message"/>.</param>
        /// <exception cref="ConstraintFailedException">The constraint failed. The exact type of exception thrown will
        /// depend on the unit test framework, if any, in use.</exception>
        public static void BeSameAs<T>(this IConstraint<T> self, T expected, string message, params object[] parameters)
            where T : class
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            if (!object.ReferenceEquals(expected, self.Value))
            {
                self.FailIfNotNegated(
                    self.FormatErrorMessage(
                    "BeSameAs",
                    null,
                    message,
                    parameters));
            }
            else
            {
                self.FailIfNegated(
                    self.FormatErrorMessage(
                    "BeSameAs",
                    null,
                    message,
                    parameters));
            }
        }

        /// <summary>
        /// Verifies the constrained value is of the specified type.
        /// </summary>
        /// <typeparam name="T">The type of the constrained value.</typeparam>
        /// <param name="self">The constrained value.</param>
        /// <param name="expectedType">The expected type.</param>
        /// <exception cref="ConstraintFailedException">The constraint failed. The exact type of exception thrown will
        /// depend on the unit test framework, if any, in use.</exception>
        public static void BeInstanceOfType<T>(this IConstraint<T> self, Type expectedType)
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            if (expectedType == null)
            {
                throw new ArgumentNullException("expectedType");
            }

            self.BeInstanceOfType(expectedType, null);
        }

        /// <summary>
        /// Verifies the constrained value is of the specified type.
        /// </summary>
        /// <typeparam name="T">The type of the constrained value.</typeparam>
        /// <param name="self">The constrained value.</param>
        /// <param name="expectedType">The expected type.</param>
        /// <param name="message">The message to display in case of failure.</param>
        /// <param name="parameters">The parameters used to format the <paramref name="message"/>.</param>
        /// <exception cref="ConstraintFailedException">The constraint failed. The exact type of exception thrown will
        /// depend on the unit test framework, if any, in use.</exception>
        public static void BeInstanceOfType<T>(this IConstraint<T> self, Type expectedType, string message, params object[] parameters)
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            if (expectedType == null)
            {
                throw new ArgumentNullException("expectedType");
            }

            if (!expectedType.IsInstanceOfType(self.Value))
            {
                self.FailIfNotNegated(
                    self.FormatErrorMessage(
                    "BeInstanceOfType",
                    Messages.NotEqualTypes(expectedType, self.Value.GetType()),
                    message,
                    parameters));
            }
            else
            {
                self.FailIfNegated(
                    self.FormatErrorMessage(
                    "BeInstanceOfType",
                    Messages.EqualTypes(expectedType, self.Value.GetType()),
                    message,
                    parameters));
            }
        }

        /// <summary>
        /// Verifies the constrained value is logically equal (all public fields and properties are logically equal)
        /// to the specified value.
        /// </summary>
        /// <typeparam name="T">The type of constrained value.</typeparam>
        /// <param name="self">The constrained value.</param>
        /// <param name="expected">The expected value.</param>
        /// <exception cref="ConstraintFailedException">The constraint failed. The exact type of exception thrown will
        /// depend on the unit test framework, if any, in use.</exception>
        public static void BeLogicallyEqualTo<T>(this IConstraint<T> self, T expected)
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.BeLogicallyEqualTo(expected, null);
        }

        /// <summary>
        /// Verifies the constrained value is logically equal (all public fields and properties are logically equal)
        /// to the specified value.
        /// </summary>
        /// <typeparam name="T">The type of constrained value.</typeparam>
        /// <param name="self">The constrained value.</param>
        /// <param name="expected">The expected value.</param>
        /// <param name="message">The message to display in case of failure.</param>
        /// <param name="parameters">The parameters used to format the <paramref name="message"/>.</param>
        /// <exception cref="ConstraintFailedException">The constraint failed. The exact type of exception thrown will
        /// depend on the unit test framework, if any, in use.</exception>
        public static void BeLogicallyEqualTo<T>(this IConstraint<T> self, T expected, string message, params object[] parameters)
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            if (!IsLogicallyEqual(self.Value, expected))
            {
                self.FailIfNotNegated(
                    self.FormatErrorMessage(
                    "BeLogicallyEqualTo",
                    Messages.NotEqual(expected, self.Value),
                    message,
                    parameters));
            }
            else
            {
                self.FailIfNegated(
                    self.FormatErrorMessage(
                    "BeLogicallyEqualTo",
                    Messages.Equal(expected, self.Value),
                    message,
                    parameters));
            }
        }

        /// <summary>
        /// Determines whether two objects are logically equal.
        /// </summary>
        /// <param name="left">The left instance.</param>
        /// <param name="right">The right instance.</param>
        /// <returns>
        /// <see langword="true"/> if the objects are logically equal; otherwise, <see langword="false"/>.
        /// </returns>
        private static bool IsLogicallyEqual(object left, object right)
        {
            if (object.ReferenceEquals(left, right))
            {
                return true;
            }

            if (left == null || right == null)
            {
                return false;
            }

            Type type = left.GetType();
            if (type != right.GetType())
            {
                return false;
            }

            Type equatableType = typeof(IEquatable<>).MakeGenericType(type);
            if (equatableType.IsAssignableFrom(type))
            {
                MethodInfo equals = equatableType.GetMethod("Equals");
                return (bool)equals.Invoke(left, new object[] { right });
            }

            Type comparableType = typeof(IComparable<>).MakeGenericType(type);
            if (comparableType.IsAssignableFrom(type))
            {
                MethodInfo compare = comparableType.GetMethod("Compare");
                return (int)compare.Invoke(left, new object[] { right }) == 0;
            }

            IComparable comparable = left as IComparable;
            if (comparable != null)
            {
                return comparable.CompareTo(right) == 0;
            }

            ICollection collection = left as ICollection;
            if (collection != null)
            {
                return AreCollectionsLogicallyEqual(collection, right as ICollection);
            }

            return CompareProperties(left, right) && CompareFields(left, right);
        }

        /// <summary>
        /// Determines if two collections are logically equal.
        /// </summary>
        /// <param name="left">The left instance.</param>
        /// <param name="right">The right instance.</param>
        /// <returns>
        /// <see langword="true"/> if the collections are logically equal; otherwise, <see langword="false"/>.
        /// </returns>
        private static bool AreCollectionsLogicallyEqual(ICollection left, ICollection right)
        {
            if (left.Count != right.Count)
            {
                return false;
            }

            IEnumerator leftEnumerator = left.GetEnumerator();
            IEnumerator rightEnumerator = right.GetEnumerator();
            for (int i = 0; leftEnumerator.MoveNext() && rightEnumerator.MoveNext(); ++i)
            {
                object leftValue = leftEnumerator.Current;
                object rightValue = rightEnumerator.Current;
                if (leftValue == null || rightValue == null)
                {
                    if (leftValue == rightValue)
                    {
                        continue;
                    }

                    return false;
                }

                Type type = leftValue.GetType();
                if (rightValue.GetType() != type)
                {
                    return false;
                }

                if (!IsLogicallyEqual(leftValue, rightValue))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Compares the properties.
        /// </summary>
        /// <typeparam name="T">Type of objects to compare.</typeparam>
        /// <param name="left">The left instance.</param>
        /// <param name="right">The right instance.</param>
        /// <returns>
        /// <see langword="true"/> if all properties are logically equal; otherwise <see langword="false"/>.
        /// </returns>
        private static bool CompareProperties<T>(T left, T right)
        {
            PropertyInfo[] props = left.GetType().GetProperties();
            if (props == null || props.Length == 0)
            {
                return true;
            }

            foreach (PropertyInfo prop in props)
            {
                object leftValue = prop.GetValue(left, null);
                object rightValue = prop.GetValue(right, null);
                if ((leftValue == null || rightValue == null) && leftValue != rightValue)
                {
                    return false;
                }

                if (!IsLogicallyEqual(leftValue, rightValue))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Compares the fields.
        /// </summary>
        /// <typeparam name="T">Type of objects to compare.</typeparam>
        /// <param name="left">The left instance.</param>
        /// <param name="right">The right instance.</param>
        /// <returns>
        /// <see langword="true"/> if all fields are logically equal; otherwise <see langword="false"/>.
        /// </returns>
        private static bool CompareFields<T>(T left, T right)
        {
            FieldInfo[] fields = left.GetType().GetFields();
            if (fields == null || fields.Length == 0)
            {
                return true;
            }

            foreach (FieldInfo field in fields)
            {
                object leftValue = field.GetValue(left);
                object rightValue = field.GetValue(right);
                if ((leftValue == null || rightValue == null) && leftValue != rightValue)
                {
                    return false;
                }

                if (!IsLogicallyEqual(leftValue, rightValue))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
