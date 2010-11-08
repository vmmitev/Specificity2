//-----------------------------------------------------------------------------
// <copyright file="ConstraintFailedException.Full.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Testing.Specificity
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Exception type raised when a specification fails.
    /// </summary>
    [Serializable]
    public partial class ConstraintFailedException
    {
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
