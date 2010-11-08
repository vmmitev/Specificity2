//-----------------------------------------------------------------------------
// <copyright file="ConstraintFailedException.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Testing.Specificity
{
    using System;
    using System.Globalization;

    /// <summary>
    /// Exception type raised when a specification fails.
    /// </summary>
    public partial class ConstraintFailedException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConstraintFailedException"/> class.
        /// </summary>
        public ConstraintFailedException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConstraintFailedException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public ConstraintFailedException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConstraintFailedException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="inner">The inner.</param>
        public ConstraintFailedException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
