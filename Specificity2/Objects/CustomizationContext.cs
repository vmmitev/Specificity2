// <copyright file="CustomizationContext.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>

namespace Testing.Specificity2.Objects
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Context object used during object creation.
    /// </summary>
    public sealed class CustomizationContext
    {
        /// <summary>
        /// The list of next customizations.
        /// </summary>
        private readonly IEnumerable<ObjectFactoryCustomization> nextCustomizations;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomizationContext"/> class.
        /// </summary>
        /// <param name="nextCustomizations">The collection of remaining customizations.</param>
        internal CustomizationContext(IEnumerable<ObjectFactoryCustomization> nextCustomizations)
        {
            this.nextCustomizations = nextCustomizations;
        }

        /// <summary>
        /// Calls the next customization, allowing it to try and get an instance of the requested object type.
        /// </summary>
        /// <typeparam name="T">The type of object to obtain an instance of.</typeparam>
        /// <param name="factory">The <see cref="IObjectFactory"/> associated with this customization.</param>
        /// <param name="result">The object instance to return to the caller.</param>
        /// <returns><see langword="true"/> if an instance of the specified type was obtained; otherwise <see langword="false"/></returns>
        public bool TryNextCustomization<T>(IObjectFactory factory, out T result)
            where T : class
        {
            var nextCustomization = this.nextCustomizations.FirstOrDefault();
            if (nextCustomization == null)
            {
                result = null;

                return false;
            }

            var newContext = new CustomizationContext(this.nextCustomizations.Skip(1));

            return nextCustomization.TryGetAny(factory, newContext, out result);
        }
    }
}