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

    /// <summary>
    /// Provides extension methods for ICollection assertions.
    /// </summary>
    public static class CollectionConstraints
    {
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

            if (self.Value.Count != 0)
            {
                Specify.Fail("ShouldBeEmpty", message, parameters);
            }

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
        public static ConstrainedValue<T> ShouldBeEmpty<T>(this ConstrainedValue<T> self)
            where T : ICollection
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            return self.ShouldBeEmpty(null);
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

            if (self.Value.Count == 0)
            {
                Specify.Fail("ShouldNotBeEmpty", message, parameters);
            }

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
        public static ConstrainedValue<T> ShouldNotBeEmpty<T>(this ConstrainedValue<T> self)
            where T : ICollection
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            return self.ShouldNotBeEmpty(null);
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

                    Specify.Fail(
                        "ShouldOnlyHaveItemsOfType",
                        reason,
                        message,
                        parameters);
                }

                ++num;
            }

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
        public static ConstrainedValue<T> ShouldOnlyHaveItemsOfType<T>(
            this ConstrainedValue<T> self,
            Type expectedType)
            where T : ICollection
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            return self.ShouldOnlyHaveItemsOfType(expectedType, null);
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

            int num = 0;
            foreach (object item in self.Value)
            {
                if (item == null)
                {
                    Specify.Fail(
                        "ShouldNotHaveNullItems",
                        message,
                        parameters);
                }

                ++num;
            }

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
        public static ConstrainedValue<T> ShouldNotHaveNullItems<T>(this ConstrainedValue<T> self)
            where T : ICollection
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            return self.ShouldNotHaveNullItems(null);
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
                        Specify.Fail(
                            "ShouldHaveUniqueItems",
                            Messages.DuplicateElement(Messages.NullValue),
                            message,
                            parameters);
                    }
                }
                else if (hashtable.Contains(item))
                {
                    Specify.Fail(
                        "ShouldHaveUniqueItems",
                        Messages.DuplicateElement(item),
                        message,
                        parameters);
                }
                else
                {
                    hashtable.Add(item, true);
                }

                ++index;
            }

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
        public static ConstrainedValue<T> ShouldHaveUniqueItems<T>(this ConstrainedValue<T> self)
            where T : ICollection
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            return self.ShouldHaveUniqueItems(null);
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

            string reason;
            if (!AreCollectionsEqual(expected, self.Value, comparer, out reason))
            {
                Specify.Fail(
                    "ShouldBeEqualTo",
                    reason,
                    message,
                    parameters);
            }

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

            return self.ShouldBeEqualTo(expected, comparer, null);
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

            if ((expected == null) != (self.Value == null))
            {
                Specify.Fail(
                    "ShouldBeEquivalentTo",
                    message,
                    parameters);
            }

            if (!object.ReferenceEquals(expected, self.Value) && (expected != null))
            {
                int actualCount;
                int expectedCount;
                object mismatchedObject;
                if (expected.Count != self.Value.Count)
                {
                    Specify.Fail(
                        "ShouldBeEquivalentTo",
                        Messages.ElementNumbersDoNotMatch(expected.Count, self.Value.Count),
                        message,
                        parameters);
                }

                if ((expected.Count != 0) &&
                    FindMismatchedElement(
                        expected,
                        self.Value,
                        out expectedCount,
                        out actualCount,
                        out mismatchedObject))
                {
                    Specify.Fail(
                        "ShouldBeEquivalentTo",
                        Messages.MismatchedElements(expectedCount, mismatchedObject, actualCount),
                        message,
                        parameters);
                }
            }

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
        public static ConstrainedValue<T> ShouldBeEquivalentTo<T>(
            this ConstrainedValue<T> self,
            ICollection expected)
            where T : ICollection
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            return self.ShouldBeEquivalentTo(expected, null);
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

            if ((expected == null) == (self.Value == null))
            {
                if (object.ReferenceEquals(expected, self.Value))
                {
                    Specify.Fail(
                        "ShouldNotBeEquivalentTo",
                        Messages.BothSameCollection,
                        message,
                        parameters);
                }

                if (expected != null)
                {
                    if (expected.Count == self.Value.Count)
                    {
                        if (expected.Count == 0)
                        {
                            Specify.Fail(
                                "ShouldNotBeEquivalentTo",
                                Messages.BothCollectionsEmpty,
                                message,
                                parameters);
                        }

                        int actualCount;
                        int expectedCount;
                        object mismatchedObject;
                        if (!FindMismatchedElement(
                            expected,
                            self.Value,
                            out expectedCount,
                            out actualCount,
                            out mismatchedObject))
                        {
                            Specify.Fail(
                                "ShouldNotBeEquivalentTo",
                                Messages.BothSameElements,
                                message,
                                parameters);
                        }
                    }
                }
            }

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
        public static ConstrainedValue<T> ShouldNotBeEquivalentTo<T>(
            this ConstrainedValue<T> self,
            ICollection expected)
            where T : ICollection
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            return self.ShouldNotBeEquivalentTo(expected, null);
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

            foreach (object item in self.Value)
            {
                if (object.Equals(item, element))
                {
                    return self;
                }
            }

            Specify.Fail("ShouldContain", message, parameters);
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
        public static ConstrainedValue<T> ShouldContain<T>(
            this ConstrainedValue<T> self,
            object element)
            where T : ICollection
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            return self.ShouldContain(element, null);
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

            int index = 0;
            foreach (object item in self.Value)
            {
                if (object.Equals(item, element))
                {
                    Specify.Fail(
                        "ShouldNotContain",
                        message,
                        parameters);
                }

                ++index;
            }

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
        public static ConstrainedValue<T> ShouldNotContain<T>(
            this ConstrainedValue<T> self,
            object element)
            where T : ICollection
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            return self.ShouldNotContain(element, null);
        }

        /// <summary>
        /// Verifies the collection is a subset of the specired collection.
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

            if (!IsSubsetOf(self.Value, superset))
            {
                Specify.Fail("ShouldBeSubsetOf", message, parameters);
            }

            return self;
        }

        /// <summary>
        /// Verifies the collection is a subset of the specired collection.
        /// </summary>
        /// <typeparam name="T">The collection type.</typeparam>
        /// <param name="self">The specification value.</param>
        /// <param name="superset">The collection to compare to.</param>
        /// <returns>
        /// The <see cref="ConstrainedValue{T}"/> specification value.
        /// </returns>
        /// <exception cref="ConstraintFailedException">The assertion failed.</exception>
        public static ConstrainedValue<T> ShouldBeSubsetOf<T>(
            this ConstrainedValue<T> self,
            ICollection superset)
            where T : ICollection
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            return self.ShouldBeSubsetOf(superset, null);
        }

        /// <summary>
        /// Verifies the collection is not a subset of the specired collection.
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

            if (IsSubsetOf(self.Value, superset))
            {
                Specify.Fail("ShouldNotBeSubsetOf", message, parameters);
            }

            return self;
        }

        /// <summary>
        /// Verifies the collection is not a subset of the specired collection.
        /// </summary>
        /// <typeparam name="T">The collection type.</typeparam>
        /// <param name="self">The specification value.</param>
        /// <param name="superset">The collection to compare to.</param>
        /// <returns>
        /// The <see cref="ConstrainedValue{T}"/> specification value.
        /// </returns>
        /// <exception cref="ConstraintFailedException">The assertion failed.</exception>
        public static ConstrainedValue<T> ShouldNotBeSubsetOf<T>(
            this ConstrainedValue<T> self,
            ICollection superset)
            where T : ICollection
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            return self.ShouldNotBeSubsetOf(superset, null);
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
            ICollection expected,
            ICollection actual,
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

                if (expected.Count != actual.Count)
                {
                    reason = string.Format(
                        CultureInfo.CurrentUICulture,
                        Properties.Resources.ElementNumbersDoNotMatch,
                        expected.Count,
                        actual.Count);
                    return false;
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
        private static Dictionary<object, int> GetElementCounts(ICollection collection, out int nullCount)
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
        private static bool IsSubsetOf(ICollection subset, ICollection superset)
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
