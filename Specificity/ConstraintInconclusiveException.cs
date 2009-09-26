//-----------------------------------------------------------------------------
// <copyright file="ConstraintInconclusiveException.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Testing.Specificity
{
    using System;
    using System.Globalization;
    using System.Runtime.Serialization;

    /// <summary>
    /// Exception type raised when a specification is inconclusive.
    /// </summary>
    [Serializable]
    public class ConstraintInconclusiveException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConstraintInconclusiveException"/> class.
        /// </summary>
        public ConstraintInconclusiveException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConstraintInconclusiveException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public ConstraintInconclusiveException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConstraintInconclusiveException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="inner">The inner.</param>
        public ConstraintInconclusiveException(string message, Exception inner)
            : base(message, inner)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConstraintInconclusiveException"/> class.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"/> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext"/> that contains contextual information about the source or destination.</param>
        /// <exception cref="T:System.ArgumentNullException">
        /// The <paramref name="info"/> parameter is null.
        /// </exception>
        /// <exception cref="T:System.Runtime.Serialization.SerializationException">
        /// The class name is null or <see cref="P:System.Exception.HResult"/> is zero (0).
        /// </exception>
        protected ConstraintInconclusiveException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
