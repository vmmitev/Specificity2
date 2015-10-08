namespace Testing.Specificity2
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Property details that can be used to declare constraints on a given property.
    /// </summary>
    /// <typeparam name="T">The type to verify.</typeparam>
    public sealed class PropertyDetails<T>
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
        /// Initializes a new instance of the <see cref="PropertyDetails{T}"/> class.
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
            if (dependencies == null)
            {
                throw new ArgumentNullException("dependencies");
            }

            foreach (var dependency in dependencies)
            {
                List<string> expectedNotifications;
                if (!this.parent.ExpectedNotifications.TryGetValue(dependency, out expectedNotifications))
                {
                    expectedNotifications = this.parent.ExpectedNotifications[dependency] = new List<string>();
                }

                expectedNotifications.Add(this.propertyName);
            }
        }
    }
}