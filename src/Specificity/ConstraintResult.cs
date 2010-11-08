//-----------------------------------------------------------------------------
// <copyright file="ConstraintResult.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Testing.Specificity
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// Provides methods for reporting the result of a constraint.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class ConstraintResult
    {
        /// <summary>
        /// The action used to report the constraint results.
        /// </summary>
        private static Action<ConstraintResultType, string> reporter;

        /// <summary>
        /// Called to report a constraint failure.
        /// </summary>
        /// <param name="message">The message to display in the test results.</param>
        public static void Failure(string message)
        {
            if (reporter != null)
            {
                reporter(ConstraintResultType.Failure, message);
            }
            else
            {
                throw new ConstraintFailedException(message);
            }
        }

        /// <summary>
        /// Called to report that a constraint is inconclusive.
        /// </summary>
        /// <param name="message">The message to display in the test results.</param>
        public static void Inconclusive(string message)
        {
            if (reporter != null)
            {
                reporter(ConstraintResultType.Inconclusive, message);
            }
            else
            {
                throw new ConstraintFailedException(message);
            }
        }

        /// <summary>
        /// Sets the action that's called to report the constraint results in the testing framework currently in use.
        /// </summary>
        /// <param name="reporter">The action used to report the constraint results.</param>
        public static void SetReporter(Action<ConstraintResultType, string> reporter)
        {
            ConstraintResult.reporter = reporter;
        }
    }
}
