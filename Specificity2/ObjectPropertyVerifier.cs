﻿//-----------------------------------------------------------------------------
// <copyright file="ObjectPropertyVerifier.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Testing.Specificity2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Reflection;

    /// <summary>
    /// Provides a contract verifier that verifies the implementation of properties for the specified type.
    /// </summary>
    /// <typeparam name="T">The type to verify.</typeparam>
    [SuppressMessage(
        "Microsoft.Design",
        "CA1001:TypesThatOwnDisposableFieldsShouldBeDisposable",
        Justification = "The PropertyChangedWatcher is disposed of internally.")]
    public class ObjectPropertyVerifier<T> : ContractVerifier, IObjectFactoryRegistry
    {
        /// <summary>
        /// The factory.
        /// </summary>
        private readonly ObjectFactory factory;

        /// <summary>
        /// The properties (values) expected to be notified when another property (key) is raised.
        /// </summary>
        private Dictionary<string, List<string>> expectedNotifications = new Dictionary<string, List<string>>();

        /// <summary>
        /// The property factory methods
        /// </summary>
        private Dictionary<string, Func<IObjectFactory, object>> propertyFactoryMethods = new Dictionary<string, Func<IObjectFactory, object>>();

        /// <summary>
        /// The property changed watcher.
        /// </summary>
        private PropertyChangedWatcher watcher;

        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectPropertyVerifier{T}"/> class.
        /// </summary>
        public ObjectPropertyVerifier()
        {
            this.factory = new ObjectFactory();
            this.factory.Freeze<T>(this.factory.Any<T>());
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectPropertyVerifier{T}"/> class.
        /// </summary>
        /// <param name="instance">The instance to use when verifying properties.</param>
        public ObjectPropertyVerifier(T instance)
        {
            this.factory = new ObjectFactory();
            this.factory.Freeze(instance);
        }

        /// <summary>
        /// Registers a customization object that can change how objects are created.
        /// </summary>
        /// <param name="customization">The customization to apply.</param>
        public void Customize(ObjectFactoryCustomization customization)
        {
            this.factory.Customize(customization);
        }

        /// <summary>
        /// Gets the specified property details for declaring constraints on that property.
        /// </summary>
        /// <param name="name">The property name.</param>
        /// <returns>The property details that can be used to declare constraints on the specified property.</returns>
        public PropertyDetails Property(string name)
        {
            return new PropertyDetails(this, name);
        }

        /// <summary>
        /// Registers a factory method that can be used to create instances of the specified type.
        /// </summary>
        /// <param name="type">The type of object created by the factory.</param>
        /// <param name="factoryMethod">The factory method.</param>
        public void Register(Type type, Func<IObjectFactory, object> factoryMethod)
        {
            this.factory.Register(type, factoryMethod);
        }

        /// <summary>
        /// Registers a factory method that can be used to create instances of values for the specified property.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="factoryMethod">The factory method.</param>
        public void Register(string propertyName, Func<IObjectFactory, object> factoryMethod)
        {
            var property = this.GetProperties().FirstOrDefault(p => p.Name == propertyName);
            if (property == null)
            {
                throw new ArgumentOutOfRangeException(string.Format("{0} does not contain a property named {1}.", typeof(T), propertyName));
            }

            this.Register(property.PropertyType, factoryMethod);
        }

        /// <summary>
        /// Gets the test methods used to verify the contract.
        /// </summary>
        /// <returns>
        /// A collection of test methods.
        /// </returns>
        protected override IEnumerable<Action> GetTests()
        {
            foreach (var property in this.GetProperties())
            {
                foreach (var test in this.GetPropertyChangedTests())
                {
                    yield return () =>
                    {
                        var instance = this.factory.Any<T>();
                        object initialValue = property.GetValue(instance);
                        object newValue = null;
                        var comparer = EqualityComparer<object>.Default;
                        do
                        {
                            Func<IObjectFactory, object> factoryMethod;
                            if (this.propertyFactoryMethods.TryGetValue(property.Name, out factoryMethod))
                            {
                                newValue = factoryMethod(this.factory);
                            }
                            else
                            {
                                newValue = this.factory.Any(property.PropertyType);
                            }
                        }
                        while (comparer.Equals(initialValue, newValue));

                        this.SetValue(instance, property, newValue);
                        test(instance, property, initialValue, newValue);
                    };
                }

                foreach (var test in this.GetPropertyNotChangedTests())
                {
                    yield return () =>
                    {
                        var instance = this.factory.Any<T>();
                        object initialValue = property.GetValue(instance);
                        this.SetValue(instance, property, initialValue);
                        test(instance, property, initialValue, initialValue);
                    };
                }
            }
        }

        /// <summary>
        /// Sets the property to the specified value.
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <param name="property">The property.</param>
        /// <param name="newValue">The new value.</param>
        protected virtual void SetValue(T instance, PropertyInfo property, object newValue)
        {
            if (this.watcher != null)
            {
                this.watcher.Dispose();
            }

            var inpc = instance as INotifyPropertyChanged;
            if (inpc != null)
            {
                this.watcher = new PropertyChangedWatcher(inpc);
            }

            property.SetValue(instance, newValue);
        }

        /// <summary>
        /// Gets the property changed tests.
        /// </summary>
        /// <returns>A collection of property changed tests.</returns>
        private IEnumerable<Action<object, PropertyInfo, object, object>> GetPropertyChangedTests()
        {
            yield return (instance, property, initialValue, newValue) => Specify.That(property.GetValue(instance)).Should.BeEqualTo(newValue);
            if (typeof(INotifyPropertyChanged).IsAssignableFrom(typeof(T)))
            {
                yield return (instance, property, initialValue, newValue) => this.SpecifyThatPropertyChangedWasRaised(property);
                yield return (instance, property, initialValue, newValue) => this.SpecifyThatNoOtherPropertyChangedEventsWereRaised(property);
            }
        }

        /// <summary>
        /// Gets the property not changed tests.
        /// </summary>
        /// <returns>A collection of property not changed tests.</returns>
        private IEnumerable<Action<object, PropertyInfo, object, object>> GetPropertyNotChangedTests()
        {
            yield return (instance, property, initialValue, newValue) => Specify.That(property.GetValue(instance)).Should.BeEqualTo(newValue);
        }

        /// <summary>
        /// Gets the expected property notifications.
        /// </summary>
        /// <param name="propertyChanged">The property changed.</param>
        /// <param name="propertyNames">The property names.</param>
        private void GetExpectedPropertyNotifications(string propertyChanged, HashSet<string> propertyNames)
        {
            if (propertyNames.Add(propertyChanged))
            {
                List<string> dependentProperties;
                if (this.expectedNotifications.TryGetValue(propertyChanged, out dependentProperties))
                {
                    foreach (var propertyName in dependentProperties)
                    {
                        this.GetExpectedPropertyNotifications(propertyName, propertyNames);
                    }
                }
            }
        }

        /// <summary>
        /// Gets the properties.
        /// </summary>
        /// <returns>The properties.</returns>
        private IEnumerable<PropertyInfo> GetProperties()
        {
            return typeof(T).GetProperties()
                .Where(p => p.CanRead && p.CanWrite);
        }

        /// <summary>
        /// Specifies the that no other property changed events were raised.
        /// </summary>
        /// <param name="property">The property.</param>
        private void SpecifyThatNoOtherPropertyChangedEventsWereRaised(PropertyInfo property)
        {
            HashSet<string> propertyNames = new HashSet<string>();
            this.GetExpectedPropertyNotifications(property.Name, propertyNames);
            var notified = this.watcher.Select(e => e.PropertyName).Where(n => !propertyNames.Contains(n)).ToArray();
            Specify.That(notified.Any())
                .Should.Not.BeTrue(
                    "PropertyChanged was unexpectedly raised for {0} when '{1}' was changed.",
                    string.Join(",", notified.Select(n => "'" + n + "'")),
                    property.Name);
        }

        /// <summary>
        /// Specifies the that property changed was raised.
        /// </summary>
        /// <param name="property">The property.</param>
        private void SpecifyThatPropertyChangedWasRaised(PropertyInfo property)
        {
            HashSet<string> propertyNames = new HashSet<string>();
            this.GetExpectedPropertyNotifications(property.Name, propertyNames);
            var notNotified = propertyNames.Where(n => !this.watcher.Any(e => e.PropertyName == n)).ToArray();
            Specify.That(notNotified.Any())
                .Should.Not.BeTrue(
                    "PropertyChanged was not raised for {0} when '{1}' was changed.",
                    string.Join(",", notNotified.Select(n => "'" + n + "'")),
                    property.Name);
        }

        /// <summary>
        /// Property details that can be used to declare constraints on a given property.
        /// </summary>
        public sealed class PropertyDetails
        {
            /// <summary>
            /// The parent.
            /// </summary>
            private readonly ObjectPropertyVerifier<T> parent;

            /// <summary>
            /// The property name.
            /// </summary>
            private readonly string propertyName;

            /// <summary>
            /// Initializes a new instance of the <see cref="PropertyDetails"/> class.
            /// </summary>
            /// <param name="parent">The parent.</param>
            /// <param name="propertyName">Name of the property.</param>
            internal PropertyDetails(ObjectPropertyVerifier<T> parent, string propertyName)
            {
                this.parent = parent;
                this.propertyName = propertyName;
            }

            /// <summary>
            /// Declares the property depends on the specified properties.
            /// </summary>
            /// <param name="dependencies">The dependency properties.</param>
            public void DependsOn(params string[] dependencies)
            {
                foreach (var dependency in dependencies)
                {
                    List<string> expectedNotifications;
                    if (!this.parent.expectedNotifications.TryGetValue(dependency, out expectedNotifications))
                    {
                        expectedNotifications = this.parent.expectedNotifications[dependency] = new List<string>();
                    }

                    expectedNotifications.Add(this.propertyName);
                }
            }
        }
    }
}