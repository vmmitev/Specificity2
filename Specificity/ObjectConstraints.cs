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
        public static void BeNull<T>(this IConstraint<T> self)
            where T : class
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.BeNull(null);
        }

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

        public static void BeEqualTo<TExpected, TActual>(this IConstraint<TActual> self, TExpected expected)
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.BeEqualTo(expected, null);
        }

        public static void BeEqualTo<TExpected, TActual>(this IConstraint<TActual> self, TExpected expected, string message, params object[] parameters)
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

        public static void BeSameAs<T>(this IConstraint<T> self, T expected)
            where T : class
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.BeSameAs(expected, null);
        }

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

        public static void BeLogicallyEqualTo<T>(this IConstraint<T> self, T expected)
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.BeLogicallyEqualTo(expected, null);
        }

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
        /// Verifies the object reference is <see langword="null"/>.
        /// </summary>
        /// <typeparam name="T">The specification value type.</typeparam>
        /// <param name="self">The specification value.</param>
        /// <param name="message">The message to use in failure exceptions.</param>
        /// <param name="parameters">The parameters used when formatting <paramref name="message"/>.</param>
        /// <returns>
        /// The <see cref="ConstrainedValue{T}"/> specification value.
        /// </returns>
        /// <exception cref="ConstraintFailedException">The assertion failed.</exception>
        public static ConstrainedValue<T> ShouldBeNull<T>(
            this ConstrainedValue<T> self,
            string message,
            params object[] parameters)
            where T : class
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.Should.BeNull(message, parameters);
            return self;
        }

        /// <summary>
        /// Verifies the object reference is <see langword="null"/>.
        /// </summary>
        /// <typeparam name="T">The specification value type.</typeparam>
        /// <param name="self">The specification value.</param>
        /// <returns>
        /// The <see cref="ConstrainedValue{T}"/> specification value.
        /// </returns>
        /// <exception cref="ConstraintFailedException">The assertion failed.</exception>
        public static ConstrainedValue<T> ShouldBeNull<T>(
            this ConstrainedValue<T> self)
            where T : class
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.Should.BeNull(null);
            return self;
        }

        /// <summary>
        /// Verifies the object reference is not <see langword="null"/>.
        /// </summary>
        /// <typeparam name="T">The specification value type.</typeparam>
        /// <param name="self">The specification value.</param>
        /// <param name="message">The message to use in failure exceptions.</param>
        /// <param name="parameters">The parameters used when formatting <paramref name="message"/>.</param>
        /// <returns>
        /// The <see cref="ConstrainedValue{T}"/> specification value.
        /// </returns>
        /// <exception cref="ConstraintFailedException">The assertion failed.</exception>
        public static ConstrainedValue<T> ShouldNotBeNull<T>(
            this ConstrainedValue<T> self,
            string message,
            params object[] parameters)
            where T : class
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.Should.Not.BeNull(message, parameters);
            return self;
        }

        /// <summary>
        /// Verifies the object reference is not <see langword="null"/>.
        /// </summary>
        /// <typeparam name="T">The specification value type.</typeparam>
        /// <param name="self">The specification value.</param>
        /// <returns>
        /// The <see cref="ConstrainedValue{T}"/> specification value.
        /// </returns>
        /// <exception cref="ConstraintFailedException">The assertion failed.</exception>
        public static ConstrainedValue<T> ShouldNotBeNull<T>(
            this ConstrainedValue<T> self)
            where T : class
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.Should.Not.BeNull(null);
            return self;
        }

        /// <summary>
        /// Verifies the specification value value is equal to an expected value.
        /// </summary>
        /// <typeparam name="TExpected">The type of the expected value.</typeparam>
        /// <typeparam name="TActual">The type of the actual value.</typeparam>
        /// <param name="self">The specification value.</param>
        /// <param name="expected">The expected.</param>
        /// <param name="message">The message to use in failure exceptions.</param>
        /// <param name="parameters">The parameters used when formatting <paramref name="message"/>.</param>
        /// <returns>
        /// The <see cref="ConstrainedValue{T}"/> specification value.
        /// </returns>
        /// <exception cref="ConstraintFailedException">The assertion failed.</exception>
        public static ConstrainedValue<TActual> ShouldBeEqualTo<TExpected, TActual>(
            this ConstrainedValue<TActual> self,
            TExpected expected,
            string message,
            params object[] parameters)
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.Should.BeEqualTo(expected, message, parameters);
            return self;
        }

        /// <summary>
        /// Verifies the specification value value is equal to an expected value.
        /// </summary>
        /// <typeparam name="TExpected">The type of the expected value.</typeparam>
        /// <typeparam name="TActual">The type of the actual value.</typeparam>
        /// <param name="self">The specification value.</param>
        /// <param name="expected">The expected.</param>
        /// <returns>
        /// The <see cref="ConstrainedValue{T}"/> specification value.
        /// </returns>
        /// <exception cref="ConstraintFailedException">The assertion failed.</exception>
        public static ConstrainedValue<TActual> ShouldBeEqualTo<TExpected, TActual>(
            this ConstrainedValue<TActual> self,
            TExpected expected)
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.Should.BeEqualTo(expected, null);
            return self;
        }

        /// <summary>
        /// Verifies the specification value value is not equal to an expected value.
        /// </summary>
        /// <typeparam name="TExpected">The type of the expected value.</typeparam>
        /// <typeparam name="TActual">The type of the actual value.</typeparam>
        /// <param name="self">The specification value.</param>
        /// <param name="expected">The expected value.</param>
        /// <param name="message">The message to use in failure exceptions.</param>
        /// <param name="parameters">The parameters used when formatting <paramref name="message"/>.</param>
        /// <returns>
        /// The <see cref="ConstrainedValue{T}"/> specification value.
        /// </returns>
        /// <exception cref="ConstraintFailedException">The assertion failed.</exception>
        public static ConstrainedValue<TActual> ShouldNotBeEqualTo<TExpected, TActual>(
            this ConstrainedValue<TActual> self,
            TExpected expected,
            string message,
            params object[] parameters)
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.Should.Not.BeEqualTo(expected, message, parameters);
            return self;
        }

        /// <summary>
        /// Verifies the specification value value is not equal to an expected value.
        /// </summary>
        /// <typeparam name="TExpected">The type of the expected value.</typeparam>
        /// <typeparam name="TActual">The type of the actual value.</typeparam>
        /// <param name="self">The specification value.</param>
        /// <param name="expected">The expected value.</param>
        /// <returns>
        /// The <see cref="ConstrainedValue{T}"/> specification value.
        /// </returns>
        /// <exception cref="ConstraintFailedException">The assertion failed.</exception>
        public static ConstrainedValue<TActual> ShouldNotBeEqualTo<TExpected, TActual>(
            this ConstrainedValue<TActual> self,
            TExpected expected)
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.Should.Not.BeEqualTo(expected, null);
            return self;
        }

        /// <summary>
        /// Verifies the specification value object and expected object refer to the same object.
        /// </summary>
        /// <typeparam name="T">The specification value type.</typeparam>
        /// <param name="self">The specification value.</param>
        /// <param name="expected">The expected value.</param>
        /// <param name="message">The message to use in failure exceptions.</param>
        /// <param name="parameters">The parameters used when formatting <paramref name="message"/>.</param>
        /// <returns>
        /// The <see cref="ConstrainedValue{T}"/> specification value.
        /// </returns>
        /// <exception cref="ConstraintFailedException">The assertion failed.</exception>
        public static ConstrainedValue<T> ShouldBeSameAs<T>(
            this ConstrainedValue<T> self,
            T expected,
            string message,
            params object[] parameters) where T : class
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.Should.BeSameAs(expected);
            return self;
        }

        /// <summary>
        /// Verifies the specification value object and expected object refer to the same object.
        /// </summary>
        /// <typeparam name="T">The specification value type.</typeparam>
        /// <param name="self">The specification value.</param>
        /// <param name="expected">The expected value.</param>
        /// <returns>
        /// The <see cref="ConstrainedValue{T}"/> specification value.
        /// </returns>
        /// <exception cref="ConstraintFailedException">The assertion failed.</exception>
        public static ConstrainedValue<T> ShouldBeSameAs<T>(
            this ConstrainedValue<T> self,
            T expected)
            where T : class
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.Should.BeSameAs(expected, null);
            return self;
        }

        /// <summary>
        /// Verifies the specification value object and expected object do not refer to the same object.
        /// </summary>
        /// <typeparam name="T">The specification value type.</typeparam>
        /// <param name="self">The specification value.</param>
        /// <param name="expected">The expected value.</param>
        /// <param name="message">The message to use in failure exceptions.</param>
        /// <param name="parameters">The parameters used when formatting <paramref name="message"/>.</param>
        /// <returns>
        /// The <see cref="ConstrainedValue{T}"/> specification value.
        /// </returns>
        /// <exception cref="ConstraintFailedException">The assertion failed.</exception>
        public static ConstrainedValue<T> ShouldNotBeSameAs<T>(
            this ConstrainedValue<T> self,
            T expected,
            string message,
            params object[] parameters)
            where T : class
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.Should.Not.BeSameAs(expected, message, parameters);
            return self;
        }

        /// <summary>
        /// Verifies the specification value object and expected object do not refer to the same object.
        /// </summary>
        /// <typeparam name="T">The specification value type.</typeparam>
        /// <param name="self">The specification value.</param>
        /// <param name="expected">The expected value.</param>
        /// <returns>
        /// The <see cref="ConstrainedValue{T}"/> specification value.
        /// </returns>
        /// <exception cref="ConstraintFailedException">The assertion failed.</exception>
        public static ConstrainedValue<T> ShouldNotBeSameAs<T>(
            this ConstrainedValue<T> self,
            T expected)
            where T : class
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.Should.Not.BeSameAs(expected, null);
            return self;
        }

        /// <summary>
        /// Verifies the specification value object should be an instance of the specified type.
        /// </summary>
        /// <typeparam name="T">The specification value type.</typeparam>
        /// <param name="self">The specification value.</param>
        /// <param name="expectedType">The expected type.</param>
        /// <param name="message">The message to use in failure exceptions.</param>
        /// <param name="parameters">The parameters used when formatting <paramref name="message"/>.</param>
        /// <returns>
        /// The <see cref="ConstrainedValue{T}"/> specification value.
        /// </returns>
        /// <exception cref="ConstraintFailedException">The assertion failed.</exception>
        public static ConstrainedValue<T> ShouldBeInstanceOfType<T>(
            this ConstrainedValue<T> self,
            Type expectedType,
            string message,
            params object[] parameters)
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            if (expectedType == null)
            {
                throw new ArgumentNullException("expectedType");
            }

            self.Should.BeInstanceOfType(expectedType, message, parameters);
            return self;
        }

        /// <summary>
        /// Verifies the specification value object should be an instance of the specified type.
        /// </summary>
        /// <typeparam name="T">The specification value type.</typeparam>
        /// <param name="self">The specification value.</param>
        /// <param name="expectedType">The expected type.</param>
        /// <returns>
        /// The <see cref="ConstrainedValue{T}"/> specification value.
        /// </returns>
        /// <exception cref="ConstraintFailedException">The assertion failed.</exception>
        public static ConstrainedValue<T> ShouldBeInstanceOfType<T>(
            this ConstrainedValue<T> self,
            Type expectedType)
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            if (expectedType == null)
            {
                throw new ArgumentNullException("expectedType");
            }

            self.Should.BeInstanceOfType(expectedType, null);
            return self;
        }

        /// <summary>
        /// Verifies the specification value object should not be an instance of the specified type.
        /// </summary>
        /// <typeparam name="T">The specification value type.</typeparam>
        /// <param name="self">The specification value.</param>
        /// <param name="wrongType">The expected type.</param>
        /// <param name="message">The message to use in failure exceptions.</param>
        /// <param name="parameters">The parameters used when formatting <paramref name="message"/>.</param>
        /// <returns>
        /// The <see cref="ConstrainedValue{T}"/> specification value.
        /// </returns>
        /// <exception cref="ConstraintFailedException">The assertion failed.</exception>
        public static ConstrainedValue<T> ShouldNotBeInstanceOfType<T>(
            this ConstrainedValue<T> self,
            Type wrongType,
            string message,
            params object[] parameters)
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            if (wrongType == null)
            {
                throw new ArgumentNullException("wrongType");
            }

            self.Should.Not.BeInstanceOfType(wrongType, message, parameters);
            return self;
        }

        /// <summary>
        /// Verifies the specification value object should not be an instance of the specified type.
        /// </summary>
        /// <typeparam name="T">The specification value type.</typeparam>
        /// <param name="self">The specification value.</param>
        /// <param name="wrongType">The expected type.</param>
        /// <returns>
        /// The <see cref="ConstrainedValue{T}"/> specification value.
        /// </returns>
        /// <exception cref="ConstraintFailedException">The assertion failed.</exception>
        public static ConstrainedValue<T> ShouldNotBeInstanceOfType<T>(
            this ConstrainedValue<T> self,
            Type wrongType)
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            if (wrongType == null)
            {
                throw new ArgumentNullException("wrongType");
            }

            self.Should.Not.BeInstanceOfType(wrongType, null);
            return self;
        }

        /// <summary>
        /// Verifies the specification value object should be logically equal to another object instance, i.e.
        /// they should be the same type and their public fields and properties should be logically equal.
        /// </summary>
        /// <typeparam name="T">The specification value type.</typeparam>
        /// <param name="self">The specification value.</param>
        /// <param name="expected">The expected type.</param>
        /// <param name="message">The message to use in failure exceptions.</param>
        /// <param name="parameters">The parameters used when formatting <paramref name="message"/>.</param>
        /// <returns>
        /// The <see cref="ConstrainedValue{T}"/> specification value.
        /// </returns>
        /// <exception cref="ConstraintFailedException">The assertion failed.</exception>
        public static ConstrainedValue<T> ShouldBeLogicallyEqualTo<T>(
            this ConstrainedValue<T> self,
            T expected,
            string message,
            params object[] parameters)
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.Should.BeLogicallyEqualTo(expected, message, parameters);
            return self;
        }

        /// <summary>
        /// Verifies the specification value object should be logically equal to another object instance, i.e.
        /// they should be the same type and their public fields and properties should be logically equal.
        /// </summary>
        /// <typeparam name="T">The specification value type.</typeparam>
        /// <param name="self">The specification value.</param>
        /// <param name="expected">The expected type.</param>
        /// <returns>
        /// The <see cref="ConstrainedValue{T}"/> specification value.
        /// </returns>
        /// <exception cref="ConstraintFailedException">The assertion failed.</exception>
        public static ConstrainedValue<T> ShouldBeLogicallyEqualTo<T>(
            this ConstrainedValue<T> self,
            T expected)
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.Should.BeLogicallyEqualTo(expected, null);
            return self;
        }

        /// <summary>
        /// Verifies the specification value object should not be logically equal to another object instance, i.e.
        /// they should be different types or their public fields and properties should not be logically equal.
        /// </summary>
        /// <typeparam name="T">The specification value type.</typeparam>
        /// <param name="self">The specification value.</param>
        /// <param name="expected">The expected type.</param>
        /// <param name="message">The message to use in failure exceptions.</param>
        /// <param name="parameters">The parameters used when formatting <paramref name="message"/>.</param>
        /// <returns>
        /// The <see cref="ConstrainedValue{T}"/> specification value.
        /// </returns>
        /// <exception cref="ConstraintFailedException">The assertion failed.</exception>
        public static ConstrainedValue<T> ShouldNotBeLogicallyEqualTo<T>(
            this ConstrainedValue<T> self,
            T expected,
            string message,
            params object[] parameters)
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.Should.Not.BeLogicallyEqualTo(expected, message, parameters);
            return self;
        }

        /// <summary>
        /// Verifies the specification value object should not be logically equal to another object instance, i.e.
        /// they should be different types or their public fields and properties should not be logically equal.
        /// </summary>
        /// <typeparam name="T">The specification value type.</typeparam>
        /// <param name="self">The specification value.</param>
        /// <param name="expected">The expected type.</param>
        /// <returns>
        /// The <see cref="ConstrainedValue{T}"/> specification value.
        /// </returns>
        /// <exception cref="ConstraintFailedException">The assertion failed.</exception>
        public static ConstrainedValue<T> ShouldNotBeLogicallyEqualTo<T>(
            this ConstrainedValue<T> self,
            T expected)
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.Should.Not.BeLogicallyEqualTo(expected, null);
            return self;
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
