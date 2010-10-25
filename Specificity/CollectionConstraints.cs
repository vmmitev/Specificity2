//-----------------------------------------------------------------------------
// <copyright file="CollectionConstraints.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Testing.Specificity
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Globalization;
    using System.ComponentModel;
    using System.Linq;

    /// <summary>
    /// Provides extension methods for ICollection assertions.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class CollectionConstraints
    {
        /// <summary>
        /// Verifies whether the collection is empty or not.
        /// </summary>
        /// <typeparam name="T">The collection type.</typeparam>
        /// <param name="self">The constrained collection.</param>
        public static void BeEmpty<T>(this IConstraint<T> self)
            where T : IEnumerable
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.BeEmpty(null);
        }

        /// <summary>
        /// Verifies whether the collection is empty or not.
        /// </summary>
        /// <typeparam name="T">The collection type.</typeparam>
        /// <param name="self">The constrained collection.</param>
        /// <param name="message">The message to display in case of failure.</param>
        /// <param name="parameters">The parameters used to format the <paramref name="message"/>.</param>
        public static void BeEmpty<T>(this IConstraint<T> self, string message, params object[] parameters)
            where T : IEnumerable
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            bool empty = false;
            ICollection collection = self.Value as ICollection;
            if (collection != null)
            {
                empty = collection.Count == 0;
            }
            else
            {
                var enumerator = self.Value.GetEnumerator();
                empty = !enumerator.MoveNext();
            }

            if (!empty)
            {
                self.FailIfNotNegated(self.FormatErrorMessage("BeEmpty", null, message, parameters));
            }
            else
            {
                self.FailIfNegated(self.FormatErrorMessage("BeEmpty", null, message, parameters));
            }
        }

        /// <summary>
        /// Verifies whether the collection has only items of the specified type or not.
        /// </summary>
        /// <typeparam name="T">The collection type.</typeparam>
        /// <param name="self">The constrained collection.</param>
        /// <param name="expectedType">The type expected for all items.</param>
        public static void HaveOnlyItemsOfType<T>(this IConstraint<T> self, Type expectedType)
            where T : IEnumerable
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            if (expectedType == null)
            {
                throw new ArgumentNullException("expectedType");
            }

            self.HaveOnlyItemsOfType(expectedType, null);
        }

        /// <summary>
        /// Verifies whether the collection has only items of the specified type or not.
        /// </summary>
        /// <typeparam name="T">The collection type.</typeparam>
        /// <param name="self">The constrained collection.</param>
        /// <param name="expectedType">The type expected for all items.</param>
        /// <param name="message">The message to display in case of failure.</param>
        /// <param name="parameters">The parameters used to format the <paramref name="message"/>.</param>
        public static void HaveOnlyItemsOfType<T>(this IConstraint<T> self, Type expectedType, string message, params object[] parameters)
            where T : IEnumerable
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            if (expectedType == null)
            {
                throw new ArgumentNullException("expectedType");
            }

            int num = 0;
            foreach (object item in self.Value)
            {
                if (!expectedType.IsInstanceOfType(item))
                {
                    string reason;
                    if (item != null)
                    {
                        reason = Messages.ElementTypesAtIndexDoNotMatch(
                            num,
                            expectedType,
                            item.GetType());
                    }
                    else
                    {
                        reason = Messages.ElementTypesAtIndexDoNotMatch2(
                            num,
                            expectedType);
                    }

                    self.FailIfNotNegated(self.FormatErrorMessage("HaveOnlyItemsOfType", reason, message, parameters));
                    return;
                }

                ++num;
            }

            self.FailIfNegated(self.FormatErrorMessage("HaveOnlyItemsOfType", null, message, parameters));
        }

        public static void HaveNullItems<T>(this IConstraint<T> self)
            where T : IEnumerable
        {
            self.HaveNullItems(null);
        }

        public static void HaveNullItems<T>(this IConstraint<T> self, string message, params object[] parameters)
            where T : IEnumerable
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            foreach (var item in self.Value)
            {
                if (item == null)
                {
                    self.FailIfNegated(self.FormatErrorMessage("HaveNullItems", null, message, parameters));
                    return;
                }
            }

            self.FailIfNotNegated(self.FormatErrorMessage("HaveNullItems", null, message, parameters));
        }

        public static void HaveUniqueItems<T>(this IConstraint<T> self)
            where T : IEnumerable
        {
            self.HaveUniqueItems(null);
        }

        public static void HaveUniqueItems<T>(this IConstraint<T> self, string message, params object[] parameters)
            where T : IEnumerable
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            bool flag = false;
            Hashtable hashtable = new Hashtable();
            int index = 0;
            foreach (object item in self.Value)
            {
                if (item == null)
                {
                    if (!flag)
                    {
                        flag = true;
                    }
                    else
                    {
                        self.FailIfNotNegated(
                            self.FormatErrorMessage(
                                "HaveUniqueItems",
                                Messages.DuplicateElement(Messages.NullValue),
                                message,
                                parameters));
                    }
                }
                else if (hashtable.Contains(item))
                {
                    self.FailIfNotNegated(
                        self.FormatErrorMessage(
                            "HaveUniqueItems",
                            Messages.DuplicateElement(item),
                            message,
                            parameters));
                }
                else
                {
                    hashtable.Add(item, true);
                }

                ++index;
            }

            self.FailIfNegated(
                self.FormatErrorMessage(
                    "HaveUniqueItems",
                    null,
                    message,
                    parameters));
        }

        public static void BeEqualTo<T>(this IConstraint<T> self, IEnumerable expected)
            where T : IEnumerable
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.BeEqualTo(expected, Comparer.Default, null);
        }

        public static void BeEqualTo<T>(this IConstraint<T> self, IEnumerable expected, string message, params object[] parameters)
            where T : IEnumerable
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.BeEqualTo(expected, Comparer.Default, message, parameters);
        }

        public static void BeEqualTo<T>(this IConstraint<T> self, IEnumerable expected, IComparer comparer)
            where T : IEnumerable
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.BeEqualTo(expected, comparer, null);
        }

        public static void BeEqualTo<T>(this IConstraint<T> self, IEnumerable expected, IComparer comparer, string message, params object[] parameters)
            where T : IEnumerable
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            string reason;
            if (!AreCollectionsEqual(expected, self.Value, comparer, out reason))
            {
                self.FailIfNotNegated(
                    self.FormatErrorMessage(
                        "BeEqualTo",
                        reason,
                        message,
                        parameters));
            }
            else
            {
                self.FailIfNegated(
                    self.FormatErrorMessage(
                        "BeEqualTo",
                        reason,
                        message,
                        parameters));
            }
        }

        public static void BeEquivalentTo<T>(this IConstraint<T> self, IEnumerable expected, IComparer comparer, string message, params object[] parameters)
            where T : IEnumerable
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            if ((expected == null) != (self.Value == null))
            {
                self.FailIfNotNegated(
                    self.FormatErrorMessage(
                        "BeEquivalentTo",
                        null,
                        message,
                        parameters));
            }
            else if (expected == null && self.Value == null)
            {
                self.FailIfNegated(
                    self.FormatErrorMessage(
                        "BeEquivalentTo",
                        null,
                        message,
                        parameters));
            }

            bool areReferencesEqual = object.ReferenceEquals(expected, self.Value);
            if (areReferencesEqual)
            {
                self.FailIfNegated(
                    self.FormatErrorMessage(
                        "BeEquivalentTo",
                        null,
                        message,
                        parameters));
            }

            if (!areReferencesEqual && expected != null)
            {
                int actualCount;
                int expectedCount;
                object mismatchedObject;
                var expectedCollection = expected as ICollection ?? expected.Cast<object>().ToList();
                var actualCollection = self.Value as ICollection ?? self.Value.Cast<object>().ToList();
                if (expectedCollection.Count != actualCollection.Count)
                {
                    self.FailIfNotNegated(
                        self.FormatErrorMessage(
                            "BeEquivalentTo",
                            Messages.ElementNumbersDoNotMatch(expectedCollection.Count, actualCollection.Count),
                            message,
                            parameters));
                }

                if ((expectedCollection.Count != 0) &&
                    FindMismatchedElement(
                        expectedCollection,
                        actualCollection,
                        out expectedCount,
                        out actualCount,
                        out mismatchedObject))
                {
                    self.FailIfNotNegated(
                        self.FormatErrorMessage(
                            "BeEquivalentTo",
                            Messages.MismatchedElements(expectedCount, mismatchedObject, actualCount),
                            message,
                            parameters));
                    return;
                }
            }

            self.FailIfNegated(
                self.FormatErrorMessage(
                    "BeEquivalentTo",
                    null,
                    message,
                    parameters));
        }

        public static void Contain<T>(this IConstraint<T> self, object element)
            where T : IEnumerable
        {
            self.Contain(element, null);
        }

        public static void Contain<T>(this IConstraint<T> self, object element, string message, params object[] parameters)
            where T : IEnumerable
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            foreach (object item in self.Value)
            {
                if (object.Equals(item, element))
                {
                    self.FailIfNegated(
                        self.FormatErrorMessage(
                            "Contain",
                            null,
                            message,
                            parameters));
                    return;
                }
            }

            self.FailIfNotNegated(
                self.FormatErrorMessage(
                    "Contain",
                    null,
                    message,
                    parameters));
        }

        public static void BeSubsetOf<T>(this IConstraint<T> self, IEnumerable superset)
            where T : IEnumerable
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.BeSubsetOf(superset, null);
        }

        public static void BeSubsetOf<T>(
            this IConstraint<T> self,
            IEnumerable superset,
            string message,
            params object[] parameters)
            where T : IEnumerable
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            if (!IsSubsetOf(self.Value, superset))
            {
                self.FailIfNotNegated(
                    self.FormatErrorMessage(
                        "BeSubsetOf",
                        null,
                        message,
                        parameters));
            }
            else
            {
                self.FailIfNegated(
                    self.FormatErrorMessage(
                        "BeSubsetOf",
                        null,
                        message,
                        parameters));
            }
        }

        /// <summary>
        /// Verifies that the collection is empty.
        /// </summary>
        /// <typeparam name="T">The collection type.</typeparam>
        /// <param name="self">The specification value.</param>
        /// <param name="message">The message to use in failure exceptions.</param>
        /// <param name="parameters">The parameters used when formatting <paramref name="message"/>.</param>
        /// <returns>
        /// The <see cref="ConstrainedValue{T}"/> specification value.
        /// </returns>
        /// <exception cref="ConstraintFailedException">The assertion failed.</exception>
        /// <remarks>This method will be obsolete in the future and is intentionally hidden from IntelliSense.</remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ConstrainedValue<T> ShouldBeEmpty<T>(
            this ConstrainedValue<T> self,
            string message,
            params object[] parameters)
            where T : ICollection
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.Should.BeEmpty(message, parameters);
            return self;
        }

        /// <summary>
        /// Verifies that the collection is empty.
        /// </summary>
        /// <typeparam name="T">The collection type.</typeparam>
        /// <param name="self">The specification value.</param>
        /// <returns>
        /// The <see cref="ConstrainedValue{T}"/> specification value.
        /// </returns>
        /// <exception cref="ConstraintFailedException">The assertion failed.</exception>
        /// <remarks>This method will be obsolete in the future and is intentionally hidden from IntelliSense.</remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ConstrainedValue<T> ShouldBeEmpty<T>(this ConstrainedValue<T> self)
            where T : ICollection
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.Should.BeEmpty(null);
            return self;
        }

        /// <summary>
        /// Verifies that the collection is not empty.
        /// </summary>
        /// <typeparam name="T">The collection type.</typeparam>
        /// <param name="self">The specification value.</param>
        /// <param name="message">The message to use in failure exceptions.</param>
        /// <param name="parameters">The parameters used when formatting <paramref name="message"/>.</param>
        /// <returns>
        /// The <see cref="ConstrainedValue{T}"/> specification value.
        /// </returns>
        /// <exception cref="ConstraintFailedException">The assertion failed.</exception>
        /// <remarks>This method will be obsolete in the future and is intentionally hidden from IntelliSense.</remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ConstrainedValue<T> ShouldNotBeEmpty<T>(
            this ConstrainedValue<T> self,
            string message,
            params object[] parameters)
            where T : ICollection
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.Should.Not.BeEmpty(message, parameters);
            return self;
        }

        /// <summary>
        /// Verifies that the collection is not empty.
        /// </summary>
        /// <typeparam name="T">The collection type.</typeparam>
        /// <param name="self">The specification value.</param>
        /// <returns>
        /// The <see cref="ConstrainedValue{T}"/> specification value.
        /// </returns>
        /// <exception cref="ConstraintFailedException">The assertion failed.</exception>
        /// <remarks>This method will be obsolete in the future and is intentionally hidden from IntelliSense.</remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ConstrainedValue<T> ShouldNotBeEmpty<T>(this ConstrainedValue<T> self)
            where T : ICollection
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.Should.Not.BeEmpty(null);
            return self;
        }

        /// <summary>
        /// Verifies that the collection only has items of the specified type.
        /// </summary>
        /// <typeparam name="T">The collection type.</typeparam>
        /// <param name="self">The specification value.</param>
        /// <param name="expectedType">The expected type.</param>
        /// <param name="message">The message to use in failure exceptions.</param>
        /// <param name="parameters">The parameters used when formatting <paramref name="message"/>.</param>
        /// <returns>
        /// The <see cref="ConstrainedValue{T}"/> specification value.
        /// </returns>
        /// <exception cref="ConstraintFailedException">The assertion failed.</exception>
        /// <remarks>This method will be obsolete in the future and is intentionally hidden from IntelliSense.</remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ConstrainedValue<T> ShouldOnlyHaveItemsOfType<T>(
            this ConstrainedValue<T> self,
            Type expectedType,
            string message,
            params object[] parameters)
            where T : ICollection
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            if (expectedType == null)
            {
                throw new ArgumentNullException("expectedType");
            }

            self.Should.HaveOnlyItemsOfType(expectedType, message, parameters);
            return self;
        }

        /// <summary>
        /// Verifies that the collection only has items of the specified type.
        /// </summary>
        /// <typeparam name="T">The collection type.</typeparam>
        /// <param name="self">The specification value.</param>
        /// <param name="expectedType">The expected type.</param>
        /// <returns>
        /// The <see cref="ConstrainedValue{T}"/> specification value.
        /// </returns>
        /// <exception cref="ConstraintFailedException">The assertion failed.</exception>
        /// <remarks>This method will be obsolete in the future and is intentionally hidden from IntelliSense.</remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ConstrainedValue<T> ShouldOnlyHaveItemsOfType<T>(
            this ConstrainedValue<T> self,
            Type expectedType)
            where T : ICollection
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            if (expectedType == null)
            {
                throw new ArgumentNullException("expectedType");
            }

            self.Should.HaveOnlyItemsOfType(expectedType, null);
            return self;
        }

        /// <summary>
        /// Verifies that the collection does not contain any <see langword="null"/> values.
        /// </summary>
        /// <typeparam name="T">The collection type.</typeparam>
        /// <param name="self">The specification value.</param>
        /// <param name="message">The message to use in failure exceptions.</param>
        /// <param name="parameters">The parameters used when formatting <paramref name="message"/>.</param>
        /// <returns>
        /// The <see cref="ConstrainedValue{T}"/> specification value.
        /// </returns>
        /// <exception cref="ConstraintFailedException">The assertion failed.</exception>
        /// <remarks>This method will be obsolete in the future and is intentionally hidden from IntelliSense.</remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ConstrainedValue<T> ShouldNotHaveNullItems<T>(
            this ConstrainedValue<T> self,
            string message,
            params object[] parameters)
            where T : ICollection
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.Should.Not.HaveNullItems(message, parameters);
            return self;
        }

        /// <summary>
        /// Verifies that the collection does not contain any <see langword="null"/> values.
        /// </summary>
        /// <typeparam name="T">The collection type.</typeparam>
        /// <param name="self">The specification value.</param>
        /// <returns>
        /// The <see cref="ConstrainedValue{T}"/> specification value.
        /// </returns>
        /// <exception cref="ConstraintFailedException">The assertion failed.</exception>
        /// <remarks>This method will be obsolete in the future and is intentionally hidden from IntelliSense.</remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ConstrainedValue<T> ShouldNotHaveNullItems<T>(this ConstrainedValue<T> self)
            where T : ICollection
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.Should.Not.HaveNullItems(null);
            return self;
        }

        /// <summary>
        /// Verifies that the collection does not contain any duplicate values.
        /// </summary>
        /// <typeparam name="T">The collection type.</typeparam>
        /// <param name="self">The specification value.</param>
        /// <param name="message">The message to use in failure exceptions.</param>
        /// <param name="parameters">The parameters used when formatting <paramref name="message"/>.</param>
        /// <returns>
        /// The <see cref="ConstrainedValue{T}"/> specification value.
        /// </returns>
        /// <exception cref="ConstraintFailedException">The assertion failed.</exception>
        /// <remarks>This method will be obsolete in the future and is intentionally hidden from IntelliSense.</remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ConstrainedValue<T> ShouldHaveUniqueItems<T>(
            this ConstrainedValue<T> self,
            string message,
            params object[] parameters)
            where T : ICollection
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.Should.HaveUniqueItems(message, parameters);
            return self;
        }

        /// <summary>
        /// Verifies that the collection does not contain any duplicate values.
        /// </summary>
        /// <typeparam name="T">The collection type.</typeparam>
        /// <param name="self">The specification value.</param>
        /// <returns>
        /// The <see cref="ConstrainedValue{T}"/> specification value.
        /// </returns>
        /// <exception cref="ConstraintFailedException">The assertion failed.</exception>
        /// <remarks>This method will be obsolete in the future and is intentionally hidden from IntelliSense.</remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ConstrainedValue<T> ShouldHaveUniqueItems<T>(this ConstrainedValue<T> self)
            where T : ICollection
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.Should.HaveUniqueItems(null);
            return self;
        }

        /// <summary>
        /// Verifies the collections are logically equal.
        /// </summary>
        /// <typeparam name="T">The collection type.</typeparam>
        /// <param name="self">The specification value.</param>
        /// <param name="expected">The expected.</param>
        /// <param name="comparer">The <see cref="IComparer"/> to use for comparing elements.</param>
        /// <param name="message">The message to use in failure exceptions.</param>
        /// <param name="parameters">The parameters used when formatting <paramref name="message"/>.</param>
        /// <returns>
        /// The <see cref="ConstrainedValue{T}"/> specification value.
        /// </returns>
        /// <exception cref="ConstraintFailedException">The assertion failed.</exception>
        /// <remarks>This method will be obsolete in the future and is intentionally hidden from IntelliSense.</remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ConstrainedValue<T> ShouldBeEqualTo<T>(
            this ConstrainedValue<T> self,
            ICollection expected,
            IComparer comparer,
            string message,
            params object[] parameters)
            where T : ICollection
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.Should.BeEqualTo(expected, comparer, message, parameters);
            return self;
        }

        /// <summary>
        /// Verifies the collections are logically equal.
        /// </summary>
        /// <typeparam name="T">The collection type.</typeparam>
        /// <param name="self">The specification value.</param>
        /// <param name="expected">The expected.</param>
        /// <param name="comparer">The <see cref="IComparer"/> to use for comparing elements.</param>
        /// <returns>
        /// The <see cref="ConstrainedValue{T}"/> specification value.
        /// </returns>
        /// <exception cref="ConstraintFailedException">The assertion failed.</exception>
        /// <remarks>This method will be obsolete in the future and is intentionally hidden from IntelliSense.</remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ConstrainedValue<T> ShouldBeEqualTo<T>(
            this ConstrainedValue<T> self,
            ICollection expected,
            IComparer comparer)
            where T : ICollection
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.Should.BeEqualTo(expected, comparer, null);
            return self;
        }

        /// <summary>
        /// Verifies the collections are not logically equal.
        /// </summary>
        /// <typeparam name="T">The collection type.</typeparam>
        /// <param name="self">The specification value.</param>
        /// <param name="expected">The expected.</param>
        /// <param name="comparer">The <see cref="IComparer"/> to use for comparing elements.</param>
        /// <param name="message">The message to use in failure exceptions.</param>
        /// <param name="parameters">The parameters used when formatting <paramref name="message"/>.</param>
        /// <returns>
        /// The <see cref="ConstrainedValue{T}"/> specification value.
        /// </returns>
        /// <exception cref="ConstraintFailedException">The assertion failed.</exception>
        /// <remarks>This method will be obsolete in the future and is intentionally hidden from IntelliSense.</remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ConstrainedValue<T> ShouldNotBeEqualTo<T>(
            this ConstrainedValue<T> self,
            ICollection expected,
            IComparer comparer,
            string message,
            params object[] parameters)
            where T : ICollection
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            string reason;
            if (AreCollectionsEqual(expected, self.Value, comparer, out reason))
            {
                Specify.Fail(
                    "ShouldNotBeEqualTo",
                    reason,
                    message,
                    parameters);
            }

            return self;
        }

        /// <summary>
        /// Verifies the collections are not logically equal.
        /// </summary>
        /// <typeparam name="T">The collection type.</typeparam>
        /// <param name="self">The specification value.</param>
        /// <param name="expected">The expected.</param>
        /// <param name="comparer">The <see cref="IComparer"/> to use for comparing elements.</param>
        /// <returns>
        /// The <see cref="ConstrainedValue{T}"/> specification value.
        /// </returns>
        /// <exception cref="ConstraintFailedException">The assertion failed.</exception>
        /// <remarks>This method will be obsolete in the future and is intentionally hidden from IntelliSense.</remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ConstrainedValue<T> ShouldNotBeEqualTo<T>(
            this ConstrainedValue<T> self,
            ICollection expected,
            IComparer comparer)
            where T : ICollection
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            return self.ShouldNotBeEqualTo(expected, comparer, null);
        }

        /// <summary>
        /// Verifies the collections are logically equivalent (same elements, but not necessarily in the same order).
        /// </summary>
        /// <typeparam name="T">The collection type.</typeparam>
        /// <param name="self">The specification value.</param>
        /// <param name="expected">The expected.</param>
        /// <param name="message">The message to use in failure exceptions.</param>
        /// <param name="parameters">The parameters used when formatting <paramref name="message"/>.</param>
        /// <returns>
        /// The <see cref="ConstrainedValue{T}"/> specification value.
        /// </returns>
        /// <exception cref="ConstraintFailedException">The assertion failed.</exception>
        /// <remarks>This method will be obsolete in the future and is intentionally hidden from IntelliSense.</remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ConstrainedValue<T> ShouldBeEquivalentTo<T>(
            this ConstrainedValue<T> self,
            ICollection expected,
            string message,
            params object[] parameters)
            where T : ICollection
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.Should.BeEquivalentTo(expected, Comparer.Default, message, parameters);
            return self;
        }

        /// <summary>
        /// Verifies the collections are logically equivalent (same elements, but not necessarily in the same order).
        /// </summary>
        /// <typeparam name="T">The collection type.</typeparam>
        /// <param name="self">The specification value.</param>
        /// <param name="expected">The expected.</param>
        /// <returns>
        /// The <see cref="ConstrainedValue{T}"/> specification value.
        /// </returns>
        /// <exception cref="ConstraintFailedException">The assertion failed.</exception>
        /// <remarks>This method will be obsolete in the future and is intentionally hidden from IntelliSense.</remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ConstrainedValue<T> ShouldBeEquivalentTo<T>(
            this ConstrainedValue<T> self,
            ICollection expected)
            where T : ICollection
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.Should.BeEquivalentTo(expected, Comparer.Default, null);
            return self;
        }

        /// <summary>
        /// Verifies the collections are not logically equivalent (same elements, but not necessarily in the same order).
        /// </summary>
        /// <typeparam name="T">The collection type.</typeparam>
        /// <param name="self">The specification value.</param>
        /// <param name="expected">The expected.</param>
        /// <param name="message">The message to use in failure exceptions.</param>
        /// <param name="parameters">The parameters used when formatting <paramref name="message"/>.</param>
        /// <returns>
        /// The <see cref="ConstrainedValue{T}"/> specification value.
        /// </returns>
        /// <exception cref="ConstraintFailedException">The assertion failed.</exception>
        /// <remarks>This method will be obsolete in the future and is intentionally hidden from IntelliSense.</remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ConstrainedValue<T> ShouldNotBeEquivalentTo<T>(
            this ConstrainedValue<T> self,
            ICollection expected,
            string message,
            params object[] parameters)
            where T : ICollection
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.Should.Not.BeEquivalentTo(expected, Comparer.Default, message, parameters);
            return self;
        }

        /// <summary>
        /// Verifies the collections are not logically equivalent (same elements, but not necessarily in the same order).
        /// </summary>
        /// <typeparam name="T">The collection type.</typeparam>
        /// <param name="self">The specification value.</param>
        /// <param name="expected">The expected.</param>
        /// <returns>
        /// The <see cref="ConstrainedValue{T}"/> specification value.
        /// </returns>
        /// <exception cref="ConstraintFailedException">The assertion failed.</exception>
        /// <remarks>This method will be obsolete in the future and is intentionally hidden from IntelliSense.</remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ConstrainedValue<T> ShouldNotBeEquivalentTo<T>(
            this ConstrainedValue<T> self,
            ICollection expected)
            where T : ICollection
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.Should.Not.BeEquivalentTo(expected, Comparer.Default, null);
            return self;
        }

        /// <summary>
        /// Verifies the collection contains the specified element.
        /// </summary>
        /// <typeparam name="T">The collection type.</typeparam>
        /// <param name="self">The specification value.</param>
        /// <param name="element">The element.</param>
        /// <param name="message">The message to use in failure exceptions.</param>
        /// <param name="parameters">The parameters used when formatting <paramref name="message"/>.</param>
        /// <returns>
        /// The <see cref="ConstrainedValue{T}"/> specification value.
        /// </returns>
        /// <exception cref="ConstraintFailedException">The assertion failed.</exception>
        /// <remarks>This method will be obsolete in the future and is intentionally hidden from IntelliSense.</remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ConstrainedValue<T> ShouldContain<T>(
            this ConstrainedValue<T> self,
            object element,
            string message,
            params object[] parameters)
            where T : ICollection
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.Should.Contain(element, message, parameters);
            return self;
        }

        /// <summary>
        /// Verifies the collection contains the specified element.
        /// </summary>
        /// <typeparam name="T">The collection type.</typeparam>
        /// <param name="self">The specification value.</param>
        /// <param name="element">The element.</param>
        /// <returns>
        /// The <see cref="ConstrainedValue{T}"/> specification value.
        /// </returns>
        /// <exception cref="ConstraintFailedException">The assertion failed.</exception>
        /// <remarks>This method will be obsolete in the future and is intentionally hidden from IntelliSense.</remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ConstrainedValue<T> ShouldContain<T>(
            this ConstrainedValue<T> self,
            object element)
            where T : ICollection
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.Should.Contain(element, null);
            return self;
        }

        /// <summary>
        /// Verifies the collection does not contain the specified element.
        /// </summary>
        /// <typeparam name="T">The collection type.</typeparam>
        /// <param name="self">The specification value.</param>
        /// <param name="element">The element.</param>
        /// <param name="message">The message to use in failure exceptions.</param>
        /// <param name="parameters">The parameters used when formatting <paramref name="message"/>.</param>
        /// <returns>
        /// The <see cref="ConstrainedValue{T}"/> specification value.
        /// </returns>
        /// <exception cref="ConstraintFailedException">The assertion failed.</exception>
        /// <remarks>This method will be obsolete in the future and is intentionally hidden from IntelliSense.</remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ConstrainedValue<T> ShouldNotContain<T>(
            this ConstrainedValue<T> self,
            object element,
            string message,
            params object[] parameters)
            where T : ICollection
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.Should.Not.Contain(element, message, parameters);
            return self;
        }

        /// <summary>
        /// Verifies the collection does not contain the specified element.
        /// </summary>
        /// <typeparam name="T">The collection type.</typeparam>
        /// <param name="self">The specification value.</param>
        /// <param name="element">The element.</param>
        /// <returns>
        /// The <see cref="ConstrainedValue{T}"/> specification value.
        /// </returns>
        /// <exception cref="ConstraintFailedException">The assertion failed.</exception>
        /// <remarks>This method will be obsolete in the future and is intentionally hidden from IntelliSense.</remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ConstrainedValue<T> ShouldNotContain<T>(
            this ConstrainedValue<T> self,
            object element)
            where T : ICollection
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.Should.Not.Contain(element, null);
            return self;
        }

        /// <summary>
        /// Verifies the collection is a subset of the specified collection.
        /// </summary>
        /// <typeparam name="T">The collection type.</typeparam>
        /// <param name="self">The specification value.</param>
        /// <param name="superset">The collection to compare to.</param>
        /// <param name="message">The message to use in failure exceptions.</param>
        /// <param name="parameters">The parameters used when formatting <paramref name="message"/>.</param>
        /// <returns>
        /// The <see cref="ConstrainedValue{T}"/> specification value.
        /// </returns>
        /// <exception cref="ConstraintFailedException">The assertion failed.</exception>
        /// <remarks>This method will be obsolete in the future and is intentionally hidden from IntelliSense.</remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ConstrainedValue<T> ShouldBeSubsetOf<T>(
            this ConstrainedValue<T> self,
            ICollection superset,
            string message,
            params object[] parameters)
            where T : ICollection
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.Should.BeSubsetOf(superset, message, parameters);
            return self;
        }

        /// <summary>
        /// Verifies the collection is a subset of the specified collection.
        /// </summary>
        /// <typeparam name="T">The collection type.</typeparam>
        /// <param name="self">The specification value.</param>
        /// <param name="superset">The collection to compare to.</param>
        /// <returns>
        /// The <see cref="ConstrainedValue{T}"/> specification value.
        /// </returns>
        /// <exception cref="ConstraintFailedException">The assertion failed.</exception>
        /// <remarks>This method will be obsolete in the future and is intentionally hidden from IntelliSense.</remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ConstrainedValue<T> ShouldBeSubsetOf<T>(
            this ConstrainedValue<T> self,
            ICollection superset)
            where T : ICollection
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.Should.BeSubsetOf(superset, null);
            return self;
        }

        /// <summary>
        /// Verifies the collection is not a subset of the specified collection.
        /// </summary>
        /// <typeparam name="T">The collection type.</typeparam>
        /// <param name="self">The specification value.</param>
        /// <param name="superset">The collection to compare to.</param>
        /// <param name="message">The message to use in failure exceptions.</param>
        /// <param name="parameters">The parameters used when formatting <paramref name="message"/>.</param>
        /// <returns>
        /// The <see cref="ConstrainedValue{T}"/> specification value.
        /// </returns>
        /// <exception cref="ConstraintFailedException">The assertion failed.</exception>
        /// <remarks>This method will be obsolete in the future and is intentionally hidden from IntelliSense.</remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ConstrainedValue<T> ShouldNotBeSubsetOf<T>(
            this ConstrainedValue<T> self,
            ICollection superset,
            string message,
            params object[] parameters)
            where T : ICollection
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.Should.Not.BeSubsetOf(superset, message, parameters);
            return self;
        }

        /// <summary>
        /// Verifies the collection is not a subset of the specified collection.
        /// </summary>
        /// <typeparam name="T">The collection type.</typeparam>
        /// <param name="self">The specification value.</param>
        /// <param name="superset">The collection to compare to.</param>
        /// <returns>
        /// The <see cref="ConstrainedValue{T}"/> specification value.
        /// </returns>
        /// <exception cref="ConstraintFailedException">The assertion failed.</exception>
        /// <remarks>This method will be obsolete in the future and is intentionally hidden from IntelliSense.</remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ConstrainedValue<T> ShouldNotBeSubsetOf<T>(
            this ConstrainedValue<T> self,
            ICollection superset)
            where T : ICollection
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.Should.Not.BeSubsetOf(superset, null);
            return self;
        }

        /// <summary>
        /// Determines if the collections are equal.
        /// </summary>
        /// <param name="expected">The expected collection.</param>
        /// <param name="actual">The actual collection.</param>
        /// <param name="comparer">The <see cref="IComparer"/> used to compare elements.</param>
        /// <param name="reason">The reason the collections are or are not equal.</param>
        /// <returns>
        /// <see langword="true"/> if the collections are equal; otherwise <see langowrd="false"/>.
        /// </returns>
        private static bool AreCollectionsEqual(
            IEnumerable expected,
            IEnumerable actual,
            IComparer comparer,
            out string reason)
        {
            reason = string.Empty;
            if (!object.ReferenceEquals(expected, actual))
            {
                if ((expected == null) || (actual == null))
                {
                    return false;
                }

                var expectedCollection = expected as ICollection;
                var actualCollection = actual as ICollection;
                if (expectedCollection != null && actualCollection != null)
                {
                    if (expectedCollection.Count != actualCollection.Count)
                    {
                        reason = string.Format(
                            CultureInfo.CurrentUICulture,
                            Properties.Resources.ElementNumbersDoNotMatch,
                            expectedCollection.Count,
                            actualCollection.Count);
                        return false;
                    }
                }

                IEnumerator expectedEnumerator = expected.GetEnumerator();
                IEnumerator actualEnumerator = actual.GetEnumerator();
                for (int i = 0; expectedEnumerator.MoveNext() && actualEnumerator.MoveNext(); ++i)
                {
                    if (0 != comparer.Compare(expectedEnumerator.Current, actualEnumerator.Current))
                    {
                        reason = string.Format(
                            CultureInfo.CurrentUICulture,
                            Properties.Resources.ElementsAtIndexDoNotMatch,
                            expectedEnumerator.Current,
                            actualEnumerator.Current,
                            i);
                        return false;
                    }
                }

                reason = Messages.ContainsSameElements;
                return true;
            }

            reason = Messages.BothSameCollection;
            return true;
        }

        /// <summary>
        /// Finds the first mismatched element.
        /// </summary>
        /// <param name="actual">The actual collection.</param>
        /// <param name="expected">The expected collection.</param>
        /// <param name="actualCount">The actual count.</param>
        /// <param name="expectedCount">The expected count.</param>
        /// <param name="mismatchedElement">The mismatched element.</param>
        /// <returns>
        /// <see langword="true"/> if a mismatched element is found; otherwise <see langword="false"/>.
        /// </returns>
        private static bool FindMismatchedElement(ICollection actual, ICollection expected, out int actualCount, out int expectedCount, out object mismatchedElement)
        {
            int expectedNullCount;
            int actualNullCount;
            Dictionary<object, int> expectedElementCounts = GetElementCounts(expected, out expectedNullCount);
            Dictionary<object, int> actualElementCounts = GetElementCounts(actual, out actualNullCount);
            if (expectedNullCount != actualNullCount)
            {
                expectedCount = expectedNullCount;
                actualCount = actualNullCount;
                mismatchedElement = null;
                return true;
            }

            foreach (object obj in expectedElementCounts.Keys)
            {
                expectedElementCounts.TryGetValue(obj, out expectedCount);
                actualElementCounts.TryGetValue(obj, out actualCount);
                if (expectedCount != actualCount)
                {
                    mismatchedElement = obj;
                    return true;
                }
            }

            expectedCount = actualCount = 0;
            mismatchedElement = null;
            return false;
        }

        /// <summary>
        /// Gets the total number of times that elements are found in the collection.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="nullCount">The null count.</param>
        /// <returns>
        /// A dictionary mapping the element to the number of times it was found in the collection.
        /// </returns>
        private static Dictionary<object, int> GetElementCounts(IEnumerable collection, out int nullCount)
        {
            Dictionary<object, int> dictionary = new Dictionary<object, int>();
            nullCount = 0;
            foreach (object obj in collection)
            {
                int num;
                if (obj == null)
                {
                    ++nullCount;
                    continue;
                }

                dictionary.TryGetValue(obj, out num);
                ++num;
                dictionary[obj] = num;
            }

            return dictionary;
        }

        /// <summary>
        /// Determines whether a collection is a subset of another.
        /// </summary>
        /// <param name="subset">The subset collection.</param>
        /// <param name="superset">The superset collection.</param>
        /// <returns>
        /// <see langword="true"/> if <paramref name="subset"/> is a subset of <paramref name="superset"/>; otherwise,
        /// <see langword="false"/>.
        /// </returns>
        private static bool IsSubsetOf(IEnumerable subset, IEnumerable superset)
        {
            int subsetNullCount;
            int supersetNullCount;
            Dictionary<object, int> subsetCounts = GetElementCounts(subset, out subsetNullCount);
            Dictionary<object, int> supersetCounts = GetElementCounts(superset, out supersetNullCount);
            if (subsetNullCount > supersetNullCount)
            {
                return false;
            }

            foreach (object obj in subsetCounts.Keys)
            {
                int subsetCount;
                int supersetCount;
                subsetCounts.TryGetValue(obj, out subsetCount);
                supersetCounts.TryGetValue(obj, out supersetCount);
                if (subsetCount > supersetCount)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
