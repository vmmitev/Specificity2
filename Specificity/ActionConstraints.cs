//-----------------------------------------------------------------------------
// <copyright file="ActionConstraints.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Testing.Specificity
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Provides extension methods for specifications on <see cref="Action"/> delegates.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class ActionConstraints
    {
        /// <summary>
        /// Tests whether or not the <see cref="Action"/> threw an exception.
        /// </summary>
        /// <param name="self">The action constraint.</param>
        public static void HaveThrown(this IConstraint<Action> self)
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.HaveThrown(typeof(Exception), null);
        }

        /// <summary>
        /// Tests whether or not the <see cref="Action"/> threw an exception.
        /// </summary>
        /// <param name="self">The action constraint.</param>
        /// <param name="message">The message to display in case of failure.</param>
        /// <param name="parameters">The parameters used to format the <paramref name="message"/>.</param>
        public static void HaveThrown(this IConstraint<Action> self, string message, params object[] parameters)
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.HaveThrown(typeof(Exception), message, parameters);
        }

        /// <summary>
        /// Tests whether or not the <see cref="Action"/> threw an exception of the specified type.
        /// </summary>
        /// <param name="self">The action constraint.</param>
        /// <param name="exceptionType">Type of the exception to test for.</param>
        public static void HaveThrown(this IConstraint<Action> self, Type exceptionType)
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            if (exceptionType == null)
            {
                throw new ArgumentNullException("exceptionType");
            }

            self.HaveThrown(exceptionType, null);
        }

        /// <summary>
        /// Tests whether or not the <see cref="Action"/> threw an exception of the specified type.
        /// </summary>
        /// <param name="self">The action constraint.</param>
        /// <param name="exceptionType">Type of the exception to test for.</param>
        /// <param name="message">The message to display in case of failure.</param>
        /// <param name="parameters">The parameters used to format the <paramref name="message"/>.</param>
        [SuppressMessage("Microsoft.Design",
            "CA1031:DoNotCatchGeneralExceptionTypes",
            Justification = "The point is to report exception failures.")]
        public static void HaveThrown(this IConstraint<Action> self, Type exceptionType, string message, params object[] parameters)
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            if (exceptionType == null)
            {
                throw new ArgumentNullException("exceptionType");
            }

            Action action = self.Value;
            try
            {
                action();
            }
            catch (Exception e)
            {
                Type actualType = e.GetType();
                Type expectedType = exceptionType;
                if (!expectedType.IsAssignableFrom(actualType))
                {
                    self.FailIfNotNegated(
                        self.FormatErrorMessage(
                            "HaveThrown",
                            Messages.UnexpectedExceptionType(expectedType, actualType),
                            message,
                            parameters));
                    return;
                }
                else
                {
                    self.FailIfNegated(
                        self.FormatErrorMessage(
                            "HaveThrown",
                            Messages.UnexpectedException(actualType),
                            message,
                            parameters));
                    return;
                }
            }

            self.FailIfNotNegated(
                self.FormatErrorMessage(
                    "HaveThrown",
                    Messages.NoExceptionThrown(exceptionType),
                    message,
                    parameters));
        }

        /// <summary>
        /// Verifies the <see cref="Action"/> throws an exception.
        /// </summary>
        /// <param name="self">The specification value.</param>
        /// <param name="message">The message to use in failure exceptions.</param>
        /// <param name="parameters">The parameters used when formatting <paramref name="message"/>.</param>
        /// <returns>
        /// The <see cref="ConstrainedValue{Action}"/> specification value.
        /// </returns>
        /// <exception cref="ConstraintFailedException">The assertion failed.</exception>
        /// <remarks>This method will be obsolete in the future and is intentionally hidden from IntelliSense.</remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ConstrainedValue<Action> ShouldHaveThrown(
            this ConstrainedValue<Action> self,
            string message,
            params object[] parameters)
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.Should.HaveThrown(typeof(Exception), message, parameters);
            return self;
        }

        /// <summary>
        /// Verifies the <see cref="Action"/> throws an exception.
        /// </summary>
        /// <param name="self">The specification value.</param>
        /// <returns>
        /// The <see cref="ConstrainedValue{Action}"/> specification value.
        /// </returns>
        /// <exception cref="ConstraintFailedException">The assertion failed.</exception>
        /// <remarks>This method will be obsolete in the future and is intentionally hidden from IntelliSense.</remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ConstrainedValue<Action> ShouldHaveThrown(this ConstrainedValue<Action> self)
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.Should.HaveThrown();
            return self;
        }

        /// <summary>
        /// Verifies the <see cref="Action"/> throws an exception of the specified type.
        /// </summary>
        /// <param name="self">The specification value.</param>
        /// <param name="exceptionType">Type of the exception.</param>
        /// <param name="message">The message to use in failure exceptions.</param>
        /// <param name="parameters">The parameters used when formatting <paramref name="message"/>.</param>
        /// <returns>
        /// The <see cref="ConstrainedValue{Action}"/> specification value.
        /// </returns>
        /// <exception cref="ConstraintFailedException">The assertion failed.</exception>
        /// <remarks>This method will be obsolete in the future and is intentionally hidden from IntelliSense.</remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [SuppressMessage("Microsoft.Design",
            "CA1031:DoNotCatchGeneralExceptionTypes",
            Justification = "The point is to report exception failures.")]
        public static ConstrainedValue<Action> ShouldHaveThrown(
            this ConstrainedValue<Action> self,
            Type exceptionType,
            string message,
            params object[] parameters)
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            if (exceptionType == null)
            {
                throw new ArgumentNullException("exceptionType");
            }

            self.Should.HaveThrown(exceptionType, message, parameters);
            return self;
        }

        /// <summary>
        /// Verifies the <see cref="Action"/> throws an exception of the specified type.
        /// </summary>
        /// <param name="self">The specification value.</param>
        /// <param name="exceptionType">Type of the exception.</param>
        /// <returns>
        /// The <see cref="ConstrainedValue{Action}"/> specification value.
        /// </returns>
        /// <exception cref="ConstraintFailedException">The assertion failed.</exception>
        /// <remarks>This method will be obsolete in the future and is intentionally hidden from IntelliSense.</remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ConstrainedValue<Action> ShouldHaveThrown(
            this ConstrainedValue<Action> self,
            Type exceptionType)
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.Should.HaveThrown(exceptionType);
            return self;
        }

        /// <summary>
        /// Verifies the <see cref="Action"/> doesn't throw any exceptions.
        /// </summary>
        /// <param name="self">The specification value.</param>
        /// <param name="message">The message to use in failure exceptions.</param>
        /// <param name="parameters">The parameters used when formatting <paramref name="message"/>.</param>
        /// <returns>
        /// The <see cref="ConstrainedValue{Action}"/> specification value.
        /// </returns>
        /// <exception cref="ConstraintFailedException">The assertion failed.</exception>
        /// <remarks>This method will be obsolete in the future and is intentionally hidden from IntelliSense.</remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [SuppressMessage("Microsoft.Design",
            "CA1031:DoNotCatchGeneralExceptionTypes",
            Justification = "The purpose is to capture the exceptions here.")]
        public static ConstrainedValue<Action> ShouldNotHaveThrown(
            this ConstrainedValue<Action> self,
            string message,
            params object[] parameters)
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.Should.Not.HaveThrown(message, parameters);
            return self;
        }

        /// <summary>
        /// Verifies the <see cref="Action"/> doesn't throw any exceptions.
        /// </summary>
        /// <param name="self">The specification value.</param>
        /// <returns>
        /// The <see cref="ConstrainedValue{Action}"/> specification value.
        /// </returns>
        /// <exception cref="ConstraintFailedException">The assertion failed.</exception>
        /// <remarks>This method will be obsolete in the future and is intentionally hidden from IntelliSense.</remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ConstrainedValue<Action> ShouldNotHaveThrown(this ConstrainedValue<Action> self)
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.Should.Not.HaveThrown();
            return self;
        }
    }
}
