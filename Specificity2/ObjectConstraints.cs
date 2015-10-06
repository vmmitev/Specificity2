//-----------------------------------------------------------------------------
// <copyright file="ObjectConstraints.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Testing.Specificity2
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Reflection;

    /// <summary>
    /// Provides extension methods for specifications on any type.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class ObjectConstraints
    {
        /// <summary>
        /// Verifies the constrained value is equal to the specified value.
        /// </summary>
        /// <typeparam name="T">The type of the constrained value.</typeparam>
        /// <param name="self">The constrained value.</param>
        /// <param name="expected">The value to compare to. </param>
        /// <param name="message">The message to display in case of failure.</param>
        /// <param name="parameters">The parameters used to format the <paramref name="message"/>.</param>
        /// <exception cref="Exception">The constraint failed. The exact type of exception thrown will
        /// depend on the unit test framework, if any, in use.</exception>
        public static void BeEqualTo<T>(this IConstraint<T> self, T expected, string message = null, params object[] parameters)
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.BeEqualTo(expected, ConstraintComparer<T>.Default, message, parameters);
        }

        /// <summary>
        /// Verifies the constrained value is equal to the specified value using the specified
        /// equality comparer.
        /// </summary>
        /// <typeparam name="T">The type of the constrained value.</typeparam>
        /// <param name="self">The constrained value.</param>
        /// <param name="expected">The value to compare to.</param>
        /// <param name="comparer">The equality comparer to use for making comparisons.</param>
        /// <param name="message">The message to display in case of failure.</param>
        /// <param name="parameters">The parameters used to format the <paramref name="message"/>.</param>
        /// <exception cref="Exception">The constraint failed. The exact type of exception thrown will
        /// depend on the unit test framework, if any, in use.</exception>
        public static void BeEqualTo<T>(this IConstraint<T> self, T expected, IEqualityComparer<T> comparer, string message = null, params object[] parameters)
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            if (comparer == null)
            {
                throw new ArgumentNullException("comparer");
            }

            if (comparer.Equals(self.Value, expected))
            {
                self.FailIfNegated(
                    self.FormatErrorMessage(
                    "BeEqualTo",
                    Messages.NotEqual(expected, self.Value),
                    message,
                    parameters));
            }
            else
            {
                self.FailIfNotNegated(
                    self.FormatErrorMessage(
                    "BeEqualTo",
                    Messages.NotEqual(expected, self.Value),
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
        /// <param name="message">The message to display in case of failure.</param>
        /// <param name="parameters">The parameters used to format the <paramref name="message"/>.</param>
        /// <exception cref="Exception">The constraint failed. The exact type of exception thrown will
        /// depend on the unit test framework, if any, in use.</exception>
        public static void BeInstanceOfType<T>(this IConstraint<T> self, Type expectedType, string message = null, params object[] parameters)
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            if (expectedType == null)
            {
                throw new ArgumentNullException("expectedType");
            }

            if (expectedType.IsInstanceOfType(self.Value))
            {
                self.FailIfNegated(
                    self.FormatErrorMessage(
                    "BeInstanceOfType",
                    Messages.EqualTypes(expectedType, self.Value.GetType()),
                    message,
                    parameters));
            }
            else
            {
                self.FailIfNotNegated(
                    self.FormatErrorMessage(
                    "BeInstanceOfType",
                    Messages.NotEqualTypes(expectedType, self.Value.GetType()),
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
        /// <param name="message">The message to display in case of failure.</param>
        /// <param name="parameters">The parameters used to format the <paramref name="message"/>.</param>
        /// <exception cref="Exception">The constraint failed. The exact type of exception thrown will
        /// depend on the unit test framework, if any, in use.</exception>
        public static void BeLogicallyEqualTo<T>(this IConstraint<T> self, T expected, string message = null, params object[] parameters)
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
        /// Verifies the constrained reference is <see langword="null"/>.
        /// </summary>
        /// <typeparam name="T">The type of the constrained reference.</typeparam>
        /// <param name="self">The constrained value.</param>
        /// <param name="message">The message to display in case of failure.</param>
        /// <param name="parameters">The parameters used to format the <paramref name="message"/>.</param>
        /// <exception cref="Exception">The constraint failed. The exact type of exception thrown will
        /// depend on the unit test framework, if any, in use.</exception>
        public static void BeNull<T>(this IConstraint<T> self, string message = null, params object[] parameters)
            where T : class
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            if (self.Value == null)
            {
                self.FailIfNegated(
                    self.FormatErrorMessage(
                    "BeNull",
                    null,
                    message,
                    parameters));
            }
            else
            {
                self.FailIfNotNegated(
                   self.FormatErrorMessage(
                   "BeNull",
                   null,
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
        /// <param name="message">The message to display in case of failure.</param>
        /// <param name="parameters">The parameters used to format the <paramref name="message"/>.</param>
        /// <exception cref="Exception">The constraint failed. The exact type of exception thrown will
        /// depend on the unit test framework, if any, in use.</exception>
        public static void BeSameAs<T>(this IConstraint<T> self, T expected, string message = null, params object[] parameters)
            where T : class
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            if (object.ReferenceEquals(self.Value, expected))
            {
                self.FailIfNegated(
                    self.FormatErrorMessage(
                    "BeSameAs",
                    null,
                    message,
                    parameters));
            }
            else
            {
                self.FailIfNotNegated(
                    self.FormatErrorMessage(
                    "BeSameAs",
                    null,
                    message,
                    parameters));
            }
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
        /// Provides an <see cref="IEqualityComparer"/> to compare the specified constraint type.
        /// </summary>
        /// <typeparam name="T">The constraint type.</typeparam>
        private static class ConstraintComparer<T>
        {
            /// <summary>
            /// The cached comparer.
            /// </summary>
            private static readonly IEqualityComparer<T> Comparer;

            /// <summary>
            /// Initializes static members of the <see cref="ConstraintComparer{T}"/> class.
            /// </summary>
            static ConstraintComparer()
            {
                var type = typeof(T);
                if (typeof(IEnumerable).IsAssignableFrom(type))
                {
                    var enumerableType = type.GetInterfaces()
                        .FirstOrDefault(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEnumerable<>));
                    if (enumerableType != null)
                    {
                        var comparerType = typeof(EnumerableComparer<,>)
                            .MakeGenericType(typeof(T), enumerableType.GetGenericArguments().First());
                        var defaultProperty = comparerType.GetProperty("Default", BindingFlags.Public | BindingFlags.Static);
                        ConstraintComparer<T>.Comparer = (IEqualityComparer<T>)defaultProperty.GetValue(null);
                    }
                    else
                    {
                        var comparerType = typeof(EnumerableComparer<>)
                            .MakeGenericType(typeof(T));
                        var defaultProperty = comparerType.GetProperty("Default", BindingFlags.Public | BindingFlags.Static);
                        ConstraintComparer<T>.Comparer = (IEqualityComparer<T>)defaultProperty.GetValue(null);
                    }
                }
                else
                {
                    ConstraintComparer<T>.Comparer = EqualityComparer<T>.Default;
                }
            }

            /// <summary>
            /// Gets the default comparer for the constraint type.
            /// </summary>
            public static IEqualityComparer<T> Default
            {
                get { return ConstraintComparer<T>.Comparer; }
            }
        }

        /// <summary>
        /// Defines an equality comparer for <see cref="IEnumerable"/> types.
        /// </summary>
        /// <typeparam name="T">The enumerable type.</typeparam>
        private class EnumerableComparer<T> : IEqualityComparer<T>
            where T : IEnumerable
        {
            /// <summary>
            /// The cached comparer.
            /// </summary>
            private static readonly IEqualityComparer<T> Comparer = new EnumerableComparer<T>();

            /// <summary>
            /// Gets the default comparer for the enumerable type.
            /// </summary>
            public static IEqualityComparer<T> Default
            {
                get { return EnumerableComparer<T>.Comparer; }
            }

            /// <summary>
            /// Determines whether the specified objects are equal.
            /// </summary>
            /// <param name="x">The first object of type T to compare.</param>
            /// <param name="y">The second object of type T to compare.</param>
            /// <returns><see langword="true"/> if the specified objects are equal; otherwise, <see langword="false"/>.</returns>
            public bool Equals(T x, T y)
            {
                if (object.ReferenceEquals(x, y))
                {
                    return true;
                }

                var xc = x as ICollection;
                if (xc != null)
                {
                    var yc = y as ICollection;
                    if (xc.Count != yc.Count)
                    {
                        return false;
                    }
                }

                return x.Cast<object>().SequenceEqual(y.Cast<object>());
            }

            /// <summary>
            /// Returns a hash code for the specified object.
            /// </summary>
            /// <param name="obj">The <see cref="Object"/> for which a hash code is to be returned.</param>
            /// <returns>A hash code for the specified object.</returns>
            public int GetHashCode(T obj)
            {
                return obj.Cast<object>().Aggregate(0, this.CalculateHash);
            }

            /// <summary>
            /// Calculates a hash value.
            /// </summary>
            /// <param name="currentHash">The current hash value.</param>
            /// <param name="item">The next item.</param>
            /// <returns>A has value.</returns>
            private int CalculateHash(int currentHash, object item)
            {
                unchecked
                {
                    return (currentHash * 397) ^ item.GetHashCode();
                }
            }
        }

        /// <summary>
        /// Defines an equality comparer for <see cref="IEnumerable{T}"/> types.
        /// </summary>
        /// <typeparam name="TEnumerable">The enumerable type.</typeparam>
        /// <typeparam name="TItem">The type of the items in the enumerable.</typeparam>
        private class EnumerableComparer<TEnumerable, TItem> : IEqualityComparer<TEnumerable>
            where TEnumerable : IEnumerable<TItem>
        {
            /// <summary>
            /// The cached comparer.
            /// </summary>
            private static readonly IEqualityComparer<TEnumerable> Comparer = new EnumerableComparer<TEnumerable, TItem>();

            /// <summary>
            /// Gets the default comparer for the enumerable type.
            /// </summary>
            public static IEqualityComparer<TEnumerable> Default
            {
                get { return EnumerableComparer<TEnumerable, TItem>.Comparer; }
            }

            /// <summary>
            /// Determines whether the specified objects are equal.
            /// </summary>
            /// <param name="x">The first object of type T to compare.</param>
            /// <param name="y">The second object of type T to compare.</param>
            /// <returns><see langword="true"/> if the specified objects are equal; otherwise, <see langword="false"/>.</returns>
            public bool Equals(TEnumerable x, TEnumerable y)
            {
                if (object.ReferenceEquals(x, y))
                {
                    return true;
                }

                var xc = x as ICollection<TItem>;
                if (xc != null)
                {
                    var yc = y as ICollection<TItem>;
                    if (xc.Count != yc.Count)
                    {
                        return false;
                    }
                }

                return x.SequenceEqual(y);
            }

            /// <summary>
            /// Returns a hash code for the specified object.
            /// </summary>
            /// <param name="obj">The <see cref="Object"/> for which a hash code is to be returned.</param>
            /// <returns>A hash code for the specified object.</returns>
            public int GetHashCode(TEnumerable obj)
            {
                return obj.Aggregate(0, this.CalculateHash);
            }

            /// <summary>
            /// Calculates a hash value.
            /// </summary>
            /// <param name="currentHash">The current hash value.</param>
            /// <param name="item">The next item.</param>
            /// <returns>A has value.</returns>
            private int CalculateHash(int currentHash, TItem item)
            {
                unchecked
                {
                    return (currentHash * 397) ^ item.GetHashCode();
                }
            }
        }
    }
}