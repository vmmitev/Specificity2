//-----------------------------------------------------------------------------
// <copyright file="ObjectFactoryCustomization.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Testing.Specificity
{
    using System;

    /// <summary>
    /// Base class for objects that can customize the object creation strategy of an <see cref="IObjectFactory"/>.
    /// </summary>
    public abstract class ObjectFactoryCustomization
    {
        /// <summary>
        /// Try to obtain an instance of the specified type.
        /// </summary>
        /// <param name="type">The type of object to obtain.</param>
        /// <param name="factory">The factory associated with this customization.</param>
        /// <param name="context">The context in which the object is being obtained.</param>
        /// <param name="result">The object instance to return to the caller.</param>
        /// <returns><see langword="true"/> if an instance of the specified type was obtained; otherwise <see langword="false"/></returns>
        public abstract bool TryGetAny(Type type, IObjectFactory factory, CustomizationContext context, out object result);
    }
}