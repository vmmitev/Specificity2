//-----------------------------------------------------------------------------
// <copyright file="ObjectPropertyVerifier.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Testing.Specificity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Reflection;

    /// <summary>
    /// Provides a contract verifier that verifies the implementation of properties for the specified type.
    /// </summary>
    /// <typeparam name="T">The type to verify.</typeparam>
    public class ObjectPropertyVerifier<T> : ContractVerifier
    {
        /// <summary>
        /// The factory.
        /// </summary>
        private readonly ObjectFactory factory;

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
        /// Gets the property changed tests.
        /// </summary>
        /// <returns>A collection of property changed tests.</returns>
        protected virtual IEnumerable<Action<object, PropertyInfo, object, object>> GetPropertyChangedTests()
        {
            yield return (instance, property, initialValue, newValue) => Specify.That(property.GetValue(instance)).Should.BeEqualTo(newValue);
            if (typeof(INotifyPropertyChanged).IsAssignableFrom(typeof(T)))
            {
                yield return (instance, property, initialValue, newValue) => this.SpecifyThatPropertyChangedWasRaised(property);
            }
        }

        /// <summary>
        /// Gets the property not changed tests.
        /// </summary>
        /// <returns>A collection of property not changed tests.</returns>
        protected virtual IEnumerable<Action<object, PropertyInfo, object, object>> GetPropertyNotChangedTests()
        {
            yield return (instance, property, initialValue, newValue) => Specify.That(property.GetValue(instance)).Should.BeEqualTo(newValue);
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
                    yield return delegate
                    {
                        var instance = this.factory.Any<T>();
                        object initialValue = property.GetValue(instance);
                        object newValue = null;
                        var comparer = EqualityComparer<object>.Default;
                        do
                        {
                            newValue = this.factory.Any(property.PropertyType);
                        }
                        while (comparer.Equals(initialValue, newValue));
                        this.SetValue(instance, property, newValue);
                        test(instance, property, initialValue, newValue);
                    };
                }

                foreach (var test in this.GetPropertyNotChangedTests())
                {
                    yield return delegate
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
        /// Gets the properties.
        /// </summary>
        /// <returns>The properties.</returns>
        private IEnumerable<PropertyInfo> GetProperties()
        {
            return typeof(T).GetProperties()
                .Where(p => p.CanRead && p.CanWrite);
        }

        /// <summary>
        /// Specifies the that property changed was raised.
        /// </summary>
        /// <param name="property">The property.</param>
        private void SpecifyThatPropertyChangedWasRaised(PropertyInfo property)
        {
            Specify.That(this.watcher.Any(e => e.PropertyName == property.Name)).Should.BeTrue("PropertyChanged not raised for '{0}' when '{1}' was changed.", property.Name, property.Name);
        }
    }
}