//-----------------------------------------------------------------------------
// <copyright file="Specify.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Testing.Specificity
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;

    /// <summary>
    /// Provides a fluent and extensible API for specifying test assertions.
    /// </summary>
    public static class Specify
    {
        /// <summary>
        /// The platform adapter assembly names.
        /// </summary>
        private static readonly string[] PlatformAssemblies = new[]
            {
                "Specificity.MSTest",
                "Specificity.NUnit",
                "Specificity.XUnit"
            };

        /// <summary>
        /// The platform adapter instance.
        /// </summary>
        private static readonly ISpecifyAdapter Adapter;

        /// <summary>
        /// Records aggregate exceptions.
        /// </summary>
        private static readonly Stack<List<Exception>> AggregateExceptionStack = new Stack<List<Exception>>();

        /// <summary>
        /// Initializes static members of the <see cref="Specify"/> class.
        /// </summary>
        static Specify()
        {
            var assemblyName = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.GetReferencedAssemblies())
                .Where(a => PlatformAssemblies.Contains(a.Name)).FirstOrDefault();
            if (assemblyName != null)
            {
                var assembly = Assembly.Load(assemblyName);
                var adapterType = assembly.GetTypes()
                    .First(t => t.GetInterfaces().Any(i => i == typeof(ISpecifyAdapter)));
                Specify.Adapter = (ISpecifyAdapter)Activator.CreateInstance(adapterType);
            }
        }

        /// <summary>
        /// Fails the assertion without checking any conditions.
        /// </summary>
        /// <param name="message">A message to display. This message can be seen in the unit test results.</param>
        /// <param name="args">An array of parameters to use when formatting <paramref name="message"/>.</param>
        public static void Failure(string message = null, params object[] args)
        {
            try
            {
                Specify.Adapter.Fail(message == null ? null : string.Format(message, args));
            }
            catch (Exception e)
            {
                if (Specify.AggregateExceptionStack.Any())
                {
                    var exceptions = Specify.AggregateExceptionStack.Peek();
                    exceptions.Add(e);
                    return;
                }

                throw;
            }
        }

        /// <summary>
        /// Fails the assertion without checking any conditions, providing inner exceptions for an aggregate assertion.
        /// </summary>
        /// <param name="innerExceptions">The inner exceptions that are the cause of the failed aggregate assertion.</param>
        /// <param name="message">A message to display. This message can be seen in the unit test results.</param>
        /// <param name="args">An array of parameters to use when formatting <paramref name="message"/>.</param>
        public static void Failure(IEnumerable<Exception> innerExceptions, string message = null, params object[] args)
        {
            try
            {
                Specify.Adapter.Fail(innerExceptions, message == null ? null : string.Format(message, args));
            }
            catch (Exception e)
            {
                if (Specify.AggregateExceptionStack.Any())
                {
                    var exceptions = Specify.AggregateExceptionStack.Peek();
                    exceptions.Add(e);
                    return;
                }

                throw;
            }
        }

        /// <summary>
        /// Fails the assertion as inconclusive.
        /// </summary>
        /// <param name="message">A message to display. This message can be seen in the unit test results.</param>
        /// <param name="args">An array of parameters to use when formatting <paramref name="message"/>.</param>
        public static void Inonclusive(string message = null, params object[] args)
        {
            Specify.Adapter.Inconclusive(message == null ? null : string.Format(message, args));
        }

        /// <summary>
        /// Tests multiple assertions.
        /// </summary>
        /// <param name="action">Action that performs multiple assertions.</param>
        /// <param name="message">A message to display. This message can be seen in the unit test results.</param>
        /// <param name="args">An array of parameters to use when formatting <paramref name="message"/>.</param>
        public static void Aggregate(Action action, string message = null, params object[] args)
        {
            var exceptions = new List<Exception>();
            Specify.AggregateExceptionStack.Push(exceptions);
            action();
            Specify.AggregateExceptionStack.Pop();
            if (exceptions.Any())
            {
                Specify.Failure(exceptions, message, args);
            }
        }

        /// <summary>
        /// Starts an assertion chain in a fluent API.
        /// </summary>
        /// <typeparam name="T">The value type.</typeparam>
        /// <param name="value">The value to make assertions on.</param>
        /// <returns>
        /// An <see cref="ConstrainedValue{T}"/> instance which wraps the <paramref name="value"/>.
        /// </returns>
        [DebuggerStepThrough]
        public static ConstrainedValue<T> That<T>(T value)
        {
            return new ConstrainedValue<T>(value);
        }

        /// <summary>
        /// Starts an assertion chain on an <see cref="Action"/> in a fluent API.
        /// </summary>
        /// <param name="action">The action to make assertions on.</param>
        /// <returns>
        /// An <see cref="ConstrainedValue{T}"/> instance which wraps the <paramref name="action"/>.
        /// </returns>
        [DebuggerStepThrough]
        public static ConstrainedValue<Action> ThatAction(Action action)
        {
            return new ConstrainedValue<Action>(action);
        }

        /// <summary>
        /// Try to load the specified assembly.
        /// </summary>
        /// <param name="name">The assembly to load.</param>
        /// <returns>The loaded assembly or <see langname="null"/> if loading failed.</returns>
        private static Assembly TryLoadAssembly(string name)
        {
            try
            {
                return Assembly.Load(name);
            }
            catch
            {
                return null;
            }
        }
    }
}