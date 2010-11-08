// <copyright file="ObserveExceptionsAttribute.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Testing.Specificity
{
    using System;

    /// <summary>
    /// Indicates that <see cref="Scenario.Because"/> should record exceptions and not cause an immediate
    /// test failure.
    /// </summary>
    /// <remarks>
    /// Exceptions thrown in <see cref="Scenario.Because"/> still cause the stack to be unwound with an immediate
    /// end to the method. The exception thrown is recorded in <see cref="P:Scenario.Exception"/>.
    /// </remarks>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public sealed class ObserveExceptionsAttribute : Attribute
    {
    }
}
