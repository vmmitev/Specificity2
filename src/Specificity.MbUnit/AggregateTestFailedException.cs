﻿//-----------------------------------------------------------------------------
// <copyright file="AggregateTestFailedException.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Testing.Specificity
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Runtime.Serialization;
    using Gallio.Framework;

    /// <summary>
    /// Used to indicate multiple failures for a test.
    /// </summary>
    [Serializable]
    public class AggregateTestFailedException : TestFailedException
    {
        /// <summary>
        /// The inner exceptions.
        /// </summary>
        private readonly ReadOnlyCollection<Exception> innerExceptions;

        /// <summary>
        /// Initializes a new instance of the <see cref="AggregateTestFailedException"/> class.
        /// </summary>
        public AggregateTestFailedException()
            : this(null, Enumerable.Empty<Exception>())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AggregateTestFailedException"/> class
        /// with the specified inner exceptions.
        /// </summary>
        /// <param name="innerExceptions">The inner exceptions.</param>
        public AggregateTestFailedException(IEnumerable<Exception> innerExceptions)
            : this(null, innerExceptions)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AggregateTestFailedException"/> class
        /// with the specified message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public AggregateTestFailedException(string message)
            : this(message, Enumerable.Empty<Exception>())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AggregateTestFailedException"/> class
        /// with the specified message and inner exception.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="inner">The inner exception.</param>
        public AggregateTestFailedException(string message, Exception inner)
            : this(message, Enumerable.Repeat(inner, 1))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AggregateTestFailedException"/> class
        /// with the specified message and inner exceptions.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="innerExceptions">The inner exceptions.</param>
        public AggregateTestFailedException(string message, IEnumerable<Exception> innerExceptions)
            : base(message, innerExceptions.FirstOrDefault())
        {
            this.innerExceptions = new ReadOnlyCollection<Exception>(innerExceptions.ToList());
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AggregateTestFailedException"/> class
        /// with serialized data.
        /// </summary>
        /// <param name="info">The <see cref="SerializationInfo"/> that holds the serialized object data
        /// about the exception being thrown.</param>
        /// <param name="context">The <see cref="StreamingContext"/> that contains contextual information
        /// about the source or destination.</param>
        protected AggregateTestFailedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        /// <summary>
        /// Gets the inner exceptions.
        /// </summary>
        public ReadOnlyCollection<Exception> InnerExceptions
        {
            get { return this.innerExceptions; }
        }

        /// <summary>
        /// Populates a <see cref="SerializationInfo"/> with the data needed to serialize the target object.
        /// </summary>
        /// <param name="info">The <see cref="SerializationInfo"/> to populate with data. </param>
        /// <param name="context">The destination (see <see cref="StreamingContext"/>) for this serialization.</param>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("InnerExceptions", this.innerExceptions);
        }
    }
}