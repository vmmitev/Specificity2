// <copyright file="AggregateAssertFailedException.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>

namespace Testing.Specificity2
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Text;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Used to indicate multiple failures for a test.
    /// </summary>
    [Serializable]
    public class AggregateAssertFailedException : AssertFailedException
    {
        /// <summary>
        /// The inner exceptions.
        /// </summary>
        private readonly ReadOnlyCollection<Exception> innerExceptions;

        /// <summary>
        /// Initializes a new instance of the <see cref="AggregateAssertFailedException"/> class.
        /// </summary>
        public AggregateAssertFailedException()
            : this(null, Enumerable.Empty<Exception>())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AggregateAssertFailedException"/> class
        /// with the specified inner exceptions.
        /// </summary>
        /// <param name="innerExceptions">The inner exceptions.</param>
        public AggregateAssertFailedException(IEnumerable<Exception> innerExceptions)
            : this(null, innerExceptions)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AggregateAssertFailedException"/> class
        /// with the specified message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public AggregateAssertFailedException(string message)
            : this(message, Enumerable.Empty<Exception>())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AggregateAssertFailedException"/> class
        /// with the specified message and inner exception.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="inner">The inner exception.</param>
        public AggregateAssertFailedException(string message, Exception inner)
            : this(message, Enumerable.Repeat(inner, 1))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AggregateAssertFailedException"/> class
        /// with the specified message and inner exceptions.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="innerExceptions">The inner exceptions.</param>
        public AggregateAssertFailedException(string message, IEnumerable<Exception> innerExceptions)
            : base(message, innerExceptions.FirstOrDefault())
        {
            this.innerExceptions = new ReadOnlyCollection<Exception>(innerExceptions.ToList());
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AggregateAssertFailedException"/> class
        /// with serialized data.
        /// </summary>
        /// <param name="info">The <see cref="SerializationInfo"/> that holds the serialized object data
        /// about the exception being thrown.</param>
        /// <param name="context">The <see cref="StreamingContext"/> that contains contextual information
        /// about the source or destination.</param>
        protected AggregateAssertFailedException(SerializationInfo info, StreamingContext context)
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
        /// Gets a message that describes the current exception.
        /// </summary>
        /// <value>
        /// A message describing the exception.
        /// </value>
        public override string Message
        {
            get
            {
                var builder = new StringBuilder(base.Message);
                foreach (var message in this.InnerExceptions.Select(e => e.Message))
                {
                    builder.AppendLine();
                    builder.Append("\t");
                    builder.Append(message);
                }

                return builder.ToString();
            }
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