//-----------------------------------------------------------------------------
// <copyright file="AggregateAssertException.cs" company="William E. Kempf">
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
    using Xunit.Sdk;

    /// <summary>
    /// Used to indicate multiple failures for a test.
    /// </summary>
    [Serializable]
    public class AggregateAssertException : AssertException
    {
        /// <summary>
        /// The inner exceptions.
        /// </summary>
        private readonly ReadOnlyCollection<Exception> innerExceptions;

        /// <summary>
        /// Initializes a new instance of the <see cref="AggregateAssertException"/> class.
        /// </summary>
        public AggregateAssertException()
            : this(null, Enumerable.Empty<Exception>())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AggregateAssertException"/> class
        /// with the specified inner exceptions.
        /// </summary>
        /// <param name="innerExceptions">The inner exceptions.</param>
        public AggregateAssertException(IEnumerable<Exception> innerExceptions)
            : this(null, innerExceptions)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AggregateAssertException"/> class
        /// with the specified message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public AggregateAssertException(string message)
            : this(message, Enumerable.Empty<Exception>())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AggregateAssertException"/> class
        /// with the specified message and inner exception.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="inner">The inner exception.</param>
        public AggregateAssertException(string message, Exception inner)
            : this(message, Enumerable.Repeat(inner, 1))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AggregateAssertException"/> class
        /// with the specified message and inner exceptions.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="innerExceptions">The inner exceptions.</param>
        public AggregateAssertException(string message, IEnumerable<Exception> innerExceptions)
            : base(message, innerExceptions.FirstOrDefault())
        {
            this.innerExceptions = new ReadOnlyCollection<Exception>(innerExceptions.ToList());
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AggregateAssertException"/> class
        /// with serialized data.
        /// </summary>
        /// <param name="info">The <see cref="SerializationInfo"/> that holds the serialized object data
        /// about the exception being thrown.</param>
        /// <param name="context">The <see cref="StreamingContext"/> that contains contextual information
        /// about the source or destination.</param>
        protected AggregateAssertException(SerializationInfo info, StreamingContext context)
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
