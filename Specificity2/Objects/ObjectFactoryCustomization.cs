// <copyright file="ObjectFactoryCustomization.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>

namespace Testing.Specificity2.Objects
{
    /// <summary>
    /// Base class for objects that can customize the object creation strategy of an <see cref="IObjectFactory"/>.
    /// </summary>
    public abstract class ObjectFactoryCustomization
    {
        /// <summary>
        /// Try to obtain an instance of the specified type.
        /// </summary>
        /// <typeparam name="T">The type of object to obtain an instance of.</typeparam>
        /// <param name="factory">The factory associated with this customization.</param>
        /// <param name="context">The context in which the object is being obtained.</param>
        /// <param name="result">The object instance to return to the caller.</param>
        /// <returns><see langword="true"/> if an instance of the specified type was obtained; otherwise, <see langword="false"/>.</returns>
        public abstract bool TryGetAny<T>(IObjectFactory factory, CustomizationContext context, out T result)
            where T : class;
    }
}