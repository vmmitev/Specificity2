// <copyright file="ScenarioBase.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Testing.Specificity
{
    using System;
    using System.ComponentModel;
    using System.Linq;

    /// <summary>
    /// Defines a base class that provides BDD style testing functionality.
    /// </summary>
    /// <remarks>
    /// This is an implementation detail and should not be used directly by client code.
    /// </remarks>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public abstract class ScenarioBase
    {
        /// <summary>
        /// The exception to observe.
        /// </summary>
        private Exception exception;

        /// <summary>
        /// Should exceptions be observed?
        /// </summary>
        private bool? observeExceptions;

        /// <summary>
        /// Gets the <see cref="Exception"/> thrown during <see cref="Because"/>.
        /// </summary>
        /// <value>The <see cref="Exception"/> thrown during <see cref="Because"/>.</value>
        /// <remarks>
        /// This value will be <see langword="null"/> unless it was requested that exceptions be observed through
        /// either decorating <see cref="Because"/> with <see cref="ObserveExceptionsAttribute"/> or thrown from
        /// the delegate specified in a call to <see cref="ObserveExceptions(Action)"/> or
        /// <see cref="ObserveExceptions{T}(Func{T})"/>.
        /// </remarks>
        public Exception Exception
        {
            get { return this.exception; }
        }

        /// <summary>
        /// Gets a value indicating whether exceptions should be observed.
        /// </summary>
        /// <value>
        /// <see langword="true"/> if exceptions should be observed; otherwise, <see langword="false"/>.
        /// </value>
        private bool RecordExceptions
        {
            get
            {
                if (!this.observeExceptions.HasValue)
                {
                    this.observeExceptions = this.GetType().GetMethod("Because", Type.EmptyTypes).GetCustomAttributes(true).OfType<ObserveExceptionsAttribute>().Any();
                }

                return this.observeExceptions.Value;
            }
        }

        /// <summary>
        /// Called after each observation in order to cleanup any state modified by <see cref="EstablishContext"/>
        /// or <see cref="Because"/>.
        /// </summary>
        public virtual void AfterEachObservation()
        {
        }

        /// <summary>
        /// Performs the action to be observed in this specification.
        /// </summary>
        public abstract void Because();

        /// <summary>
        /// Establishes the context for the observations made in this specification.
        /// </summary>
        public virtual void EstablishContext()
        {
        }

        /// <summary>
        /// Should be called before each observation.
        /// </summary>
        /// <remarks>
        /// This is an implementation detail and should not be called directly by client code.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected void BeforeEachObservation()
        {
            this.EstablishContext();
            this.exception = null;
            try
            {
                this.Because();
            }
            catch (Exception e)
            {
                if (this.RecordExceptions)
                {
                    this.exception = e;
                }
                else
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// Calls the <paramref name="action"/> delegate and records any exceptions thrown in order to allow
        /// the exception to be observed.
        /// </summary>
        /// <param name="action">The <see cref="Action"/> to invoke.</param>
        protected void ObserveExceptions(Action action)
        {
            bool? oldValue = this.observeExceptions;
            this.observeExceptions = true;
            action();
            this.observeExceptions = oldValue;
        }

        /// <summary>
        /// Calls the <paramref name="func"/> delegate and records any exceptions thrown in order to allow
        /// the exception to be observed.
        /// </summary>
        /// <typeparam name="T">The return type of the <paramref name="func"/>.</typeparam>
        /// <param name="func">The <see cref="Func{T}"/> to invoke.</param>
        /// <returns>
        /// The result of calling <paramref name="func"/>.
        /// </returns>
        protected T ObserveExceptions<T>(Func<T> func)
        {
            bool? oldValue = this.observeExceptions;
            this.observeExceptions = true;
            T result = func();
            this.observeExceptions = oldValue;
            return result;
        }
    }
}
