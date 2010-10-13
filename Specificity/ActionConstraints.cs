//-----------------------------------------------------------------------------
// <copyright file="ActionConstraints.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Testing.Specificity
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.ComponentModel;

    /// <summary>
    /// Provides extension methods for assertions on <see cref="Action"/> delegates.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class ActionConstraints
    {
        /// <summary>
        /// Verifies the <see cref="Action"/> threw an exception.
        /// </summary>
        /// <param name="self">The action.</param>
        public static void HaveThrown(this IConstraint<Action> self)
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.HaveThrown(typeof(Exception), null);
        }

        /// <summary>
        /// Verifies the <see cref="Action"/> threw an exception.
        /// </summary>
        /// <param name="self">The action.</param>
        /// <param name="message">The message.</param>
        /// <param name="parameters">The parameters.</param>
        public static void HaveThrown(this IConstraint<Action> self, string message, params object[] parameters)
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            self.HaveThrown(typeof(Exception), message, parameters);
        }

        /// <summary>
        /// Verifies the <see cref="Action"/> threw an exception.
        /// </summary>
        /// <param name="self">The action.</param>
        /// <param name="exceptionType">Type of the exception.</param>
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
        /// Verifies the <see cref="Action"/> threw an exception.
        /// </summary>
        /// <param name="self">The action.</param>
        /// <param name="exceptionType">Type of the exception.</param>
        /// <param name="message">The message.</param>
        /// <param name="parameters">The parameters.</param>
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
                    self.Fail(
                        "ShouldHaveThrown",
                        Messages.UnexpectedExceptionType(expectedType, actualType),
                        message,
                        parameters);
                    return;
                }
                else
                {
                    self.FailIfNegated(
                        "ShouldNotHaveThrown",
                        Messages.UnexpectedExceptionType(expectedType, actualType),
                        message,
                        parameters);
                    return;
                }
            }

            self.Fail(
                "ShouldHaveThrown",
                Messages.NoExceptionThrown(exceptionType),
                message,
                parameters);
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

            return ShouldHaveThrown(self, typeof(Exception), message, parameters);
        }

        /// <summary>
        /// Verifies the <see cref="Action"/> throws an exception.
        /// </summary>
        /// <param name="self">The specification value.</param>
        /// <returns>
        /// The <see cref="ConstrainedValue{Action}"/> specification value.
        /// </returns>
        /// <exception cref="ConstraintFailedException">The assertion failed.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ConstrainedValue<Action> ShouldHaveThrown(this ConstrainedValue<Action> self)
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            return ShouldHaveThrown(self, typeof(Exception), null);
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
                    Specify.Fail(
                        "ShouldHaveThrown",
                        Messages.UnexpectedExceptionType(expectedType, actualType),
                        message,
                        parameters);
                }

                return self;
            }

            Specify.Fail(
                "ShouldHaveThrown",
                Messages.NoExceptionThrown(exceptionType),
                message,
                parameters);
            return null; // Will never get here, but must satisfy the compiler
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
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ConstrainedValue<Action> ShouldHaveThrown(
            this ConstrainedValue<Action> self,
            Type exceptionType)
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            return self.ShouldHaveThrown(exceptionType, null);
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

            Action action = self.Value;
            try
            {
                action();
            }
            catch (Exception e)
            {
                Specify.Fail(
                    "ShouldNotHaveThrown",
                    Messages.UnexpectedException(e.GetType()),
                    message,
                    parameters);
            }

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
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ConstrainedValue<Action> ShouldNotHaveThrown(this ConstrainedValue<Action> self)
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            return self.ShouldNotHaveThrown(null);
        }
    }
}
