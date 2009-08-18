﻿//-----------------------------------------------------------------------------
// <copyright file="ConstraintFailedException.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Testing.Specificity
{
    using System;
    using System.Globalization;
    using System.Runtime.Serialization;

    /// <summary>
    /// Exception type raised when a specification fails.
    /// </summary>
    [Serializable]
    public class ConstraintFailedException : Exception
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
        /// <param name="constraint">The constraint that failed.</param>
        /// <param name="message">The message.</param>
        public ConstraintFailedException(string constraint, string message)
            : base(string.Format(CultureInfo.CurrentCulture, Properties.Resources.ConstraintFailed, constraint, message))
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

        /// <summary>
        /// Initializes a new instance of the <see cref="ConstraintFailedException"/> class.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"/> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext"/> that contains contextual information about the source or destination.</param>
        /// <exception cref="T:System.ArgumentNullException">
        /// The <paramref name="info"/> parameter is null.
        /// </exception>
        /// <exception cref="T:System.Runtime.Serialization.SerializationException">
        /// The class name is null or <see cref="P:System.Exception.HResult"/> is zero (0).
        /// </exception>
        protected ConstraintFailedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
