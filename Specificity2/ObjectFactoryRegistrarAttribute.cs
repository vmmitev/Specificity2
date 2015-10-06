//-----------------------------------------------------------------------------
// <copyright file="ObjectFactoryRegistrarAttribute.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Testing.Specificity2
{
    using System;

    /// <summary>
    /// Used to indicate methods that register factory methods with <see cref="ObjectFactory"/>
    /// instances.
    /// </summary>
    /// <remarks>The method decorated with this attribute must be a public static method that
    /// takes a single <see cref="IObjectFactoryRegistry"/> parameter.</remarks>
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class ObjectFactoryRegistrarAttribute : Attribute
    {
    }
}