// <copyright file="CollectionConstraints.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>

namespace Testing.Specificity2
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using Properties;

    /// <summary>
    /// Provides extension methods for ICollection assertions.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class CollectionConstraints
    {
        /// <summary>
        /// Verifies the constrained collection is empty.
        /// </summary>
        /// <typeparam name="T">The collection type.</typeparam>
        /// <param name="self">The constrained collection.</param>
        /// <param name="message">The message to display in case of failure.</param>
        /// <param name="parameters">The parameters used to format the <paramref name="message"/>.</param>
        /// <exception cref="Exception">The constraint failed. The exact type of exception thrown will
        /// depend on the unit test framework, if any, in use.</exception>
        public static void BeEmpty<T>(this IConstraint<T> self, string message = null, params object[] parameters)
            where T : IEnumerable
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            if (self.Value.Cast<object>().Any())
            {
                self.FailIfNotNegated(self.FormatErrorMessage("BeEmpty", null, message, parameters));
            }
            else
            {
                self.FailIfNegated(self.FormatErrorMessage("BeEmpty", null, message, parameters));
            }
        }

        /// <summary>
        /// Verifies the constrained collection is equivalent (contains the same values, though possibly in a different
        /// order) to the specified collection.
        /// </summary>
        /// <typeparam name="T">The type of the constrained collection.</typeparam>
        /// <param name="self">The constrained collection.</param>
        /// <param name="expected">The expected collection.</param>
        /// <param name="message">The message to display in case of failure.</param>
        /// <param name="parameters">The parameters used to format the <paramref name="message"/>.</param>
        /// <exception cref="Exception">The constraint failed. The exact type of exception thrown will
        /// depend on the unit test framework, if any, in use.</exception>
        public static void BeEquivalentTo<T>(this IConstraint<T> self, IEnumerable expected, string message = null, params object[] parameters)
            where T : IEnumerable
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.BeEquivalentTo(expected, Comparer<object>.Default, message, parameters);
        }

        /// <summary>
        /// Verifies the constrained collection is equivalent (contains the same values, though possibly in a different
        /// order) to the specified collection.
        /// </summary>
        /// <typeparam name="T">The type of the constrained collection.</typeparam>
        /// <param name="self">The constrained collection.</param>
        /// <param name="expected">The expected collection.</param>
        /// <param name="comparer">The comparer used to compare the items.</param>
        /// <param name="message">The message to display in case of failure.</param>
        /// <param name="parameters">The parameters used to format the <paramref name="message"/>.</param>
        /// <exception cref="Exception">The constraint failed. The exact type of exception thrown will
        /// depend on the unit test framework, if any, in use.</exception>
        public static void BeEquivalentTo<T>(this IConstraint<T> self, IEnumerable expected, IComparer comparer, string message = null, params object[] parameters)
            where T : IEnumerable
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            if (comparer == null)
            {
                throw new ArgumentNullException("comparer");
            }

            if ((expected == null) != (self.Value == null))
            {
                self.FailIfNegated(
                    self.FormatErrorMessage(
                        "BeEquivalentTo",
                        null,
                        message,
                        parameters));
                return;
            }
            else if (expected == null && self.Value == null)
            {
                self.FailIfNegated(
                    self.FormatErrorMessage(
                        "BeEquivalentTo",
                        null,
                        message,
                        parameters));
                return;
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
                return;
            }

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

            self.FailIfNegated(
                self.FormatErrorMessage(
                    "BeEquivalentTo",
                    null,
                    message,
                    parameters));
        }

        /// <summary>
        /// Verifies the constrained collection is a subset of the specified collection.
        /// </summary>
        /// <typeparam name="T">The collection type.</typeparam>
        /// <param name="self">The constrained collection.</param>
        /// <param name="superset">The specified collection that should be a superset of constrained collection.</param>
        /// <param name="message">The user message to report on failure.</param>
        /// <param name="parameters">The parameters used to format the user message.</param>
        /// <exception cref="Exception">The constraint failed. The exact type of exception thrown will
        /// depend on the unit test framework, if any, in use.</exception>
        public static void BeSubsetOf<T>(
            this IConstraint<T> self,
            IEnumerable superset,
            string message = null,
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
        /// Verifies the constrained collection contains the specified element.
        /// </summary>
        /// <typeparam name="T">The type of the constrained collection.</typeparam>
        /// <param name="self">The constrained collection.</param>
        /// <param name="element">The expected element.</param>
        /// <param name="message">The message to display in case of failure.</param>
        /// <param name="parameters">The parameters used to format the <paramref name="message"/>.</param>
        /// <exception cref="Exception">The constraint failed. The exact type of exception thrown will
        /// depend on the unit test framework, if any, in use.</exception>
        public static void Contain<T>(this IConstraint<T> self, object element, string message = null, params object[] parameters)
            where T : IEnumerable
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            if (self.Value.Cast<object>().Contains(element))
            {
                self.FailIfNegated(
                    self.FormatErrorMessage(
                        "Contain",
                        null,
                        message,
                        parameters));
            }
            else
            {
                self.FailIfNotNegated(
                    self.FormatErrorMessage(
                        "Contain",
                        null,
                        message,
                        parameters));
            }
        }

        /// <summary>
        /// Verifies the constrained collection has at least one <see langword="null"/> item.
        /// </summary>
        /// <typeparam name="T">The type of the constrained collection.</typeparam>
        /// <param name="self">The constrained collection.</param>
        /// <param name="message">The message to display in case of failure.</param>
        /// <param name="parameters">The parameters used to format the <paramref name="message"/>.</param>
        /// <exception cref="Exception">The constraint failed. The exact type of exception thrown will
        /// depend on the unit test framework, if any, in use.</exception>
        public static void HaveNullItems<T>(this IConstraint<T> self, string message = null, params object[] parameters)
            where T : IEnumerable
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            if (self.Value.Cast<object>().Any(i => i == null))
            {
                self.FailIfNegated(self.FormatErrorMessage("HaveNullItems", null, message, parameters));
            }
            else
            {
                self.FailIfNotNegated(self.FormatErrorMessage("HaveNullItems", null, message, parameters));
            }
        }

        /// <summary>
        /// Verifies the constrained collection has only items of the specified type or not.
        /// </summary>
        /// <typeparam name="T">The type of the constrained collection.</typeparam>
        /// <param name="self">The constrained collection.</param>
        /// <param name="expectedType">The type expected for all items.</param>
        /// <param name="message">The message to display in case of failure.</param>
        /// <param name="parameters">The parameters used to format the <paramref name="message"/>.</param>
        /// <exception cref="Exception">The constraint failed. The exact type of exception thrown will
        /// depend on the unit test framework, if any, in use.</exception>
        public static void HaveOnlyItemsOfType<T>(this IConstraint<T> self, Type expectedType, string message = null, params object[] parameters)
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

        /// <summary>
        /// Verifies the constrained collection contains only unique items.
        /// </summary>
        /// <typeparam name="T">The type of the constrained collection.</typeparam>
        /// <param name="self">The constrained collection.</param>
        /// <param name="message">The message to display in case of failure.</param>
        /// <param name="parameters">The parameters used to format the <paramref name="message"/>.</param>
        /// <exception cref="Exception">The constraint failed. The exact type of exception thrown will
        /// depend on the unit test framework, if any, in use.</exception>
        public static void HaveUniqueItems<T>(this IConstraint<T> self, string message = null, params object[] parameters)
            where T : IEnumerable
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            bool flag = false;
            HashSet<object> set = new HashSet<object>();
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
                                Messages.DuplicateElement(Resources.NullValue),
                                message,
                                parameters));
                        return;
                    }
                }
                else if (!set.Add(item))
                {
                    self.FailIfNotNegated(
                        self.FormatErrorMessage(
                            "HaveUniqueItems",
                            Messages.DuplicateElement(item),
                            message,
                            parameters));
                    return;
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

        /// <summary>
        /// Finds the first mismatched element.
        /// </summary>
        /// <param name="actual">The actual collection.</param>
        /// <param name="expected">The expected collection.</param>
        /// <param name="actualCount">The actual count.</param>
        /// <param name="expectedCount">The expected count.</param>
        /// <param name="mismatchedElement">The mismatched element.</param>
        /// <returns>
        /// <see langword="true"/> if a mismatched element is Scenario; otherwise <see langword="false"/>.
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
        /// Gets the total number of times that elements are Scenario in the collection.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="nullCount">The null count.</param>
        /// <returns>
        /// A dictionary mapping the element to the number of times it was Scenario in the collection.
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