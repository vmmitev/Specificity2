//-----------------------------------------------------------------------------
// <copyright file="PropertyChangedWatcherConstraints.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Testing.Specificity
{
    using System;
    using System.Linq;

    /// <summary>
    /// Provides extension methods for <see cref="PropertyChangedWatcher"/> assertions.
    /// </summary>
    public static class PropertyChangedWatcherConstrains
    {
        public static void HaveSeen(this IConstraint<PropertyChangedWatcher> self, string propertyName)
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.HaveSeen(propertyName, null);
        }

        public static void HaveSeen(this IConstraint<PropertyChangedWatcher> self, string propertyName, string message, params object[] parameters)
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            if (self.Value.Where(e => e.PropertyName == propertyName).FirstOrDefault() == null)
            {
                self.FailIfNotNegated(
                    self.FormatErrorMessage(
                        "HaveSeen",
                        null,
                        message,
                        parameters));
            }
            else
            {
                self.FailIfNegated(
                    self.FormatErrorMessage(
                        "HaveSeen",
                        null,
                        message,
                        parameters));
            }
        }

        /// <summary>
        /// Verifies that a specified property change notification was raised.
        /// </summary>
        /// <param name="self">A <see cref="PropertyChangedWatcher"/> instance.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="message">The message to use in failure exceptions.</param>
        /// <param name="parameters">The parameters used when formatting <paramref name="message"/>.</param>
        /// <returns>
        /// The <see cref="ConstrainedValue{PropertyChangedWatcher}"/> specification value.
        /// </returns>
        /// <exception cref="ConstraintFailedException">The assertion failed.</exception>
        public static ConstrainedValue<PropertyChangedWatcher> ShouldHaveSeen(this ConstrainedValue<PropertyChangedWatcher> self, string propertyName, string message, params object[] parameters)
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.Should.HaveSeen(propertyName, message, parameters);
            return self;
        }

        /// <summary>
        /// Verifies that a specified property change notification was raised.
        /// </summary>
        /// <param name="self">A <see cref="PropertyChangedWatcher"/> instance.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns>
        /// The <see cref="ConstrainedValue{PropertyChangedWatcher}"/> specification value.
        /// </returns>
        /// <exception cref="ConstraintFailedException">The assertion failed.</exception>
        public static ConstrainedValue<PropertyChangedWatcher> ShouldHaveSeen(this ConstrainedValue<PropertyChangedWatcher> self, string propertyName)
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.Should.HaveSeen(propertyName, null);
            return self;
        }
    }
}
