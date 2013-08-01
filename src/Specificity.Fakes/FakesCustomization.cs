//-----------------------------------------------------------------------------
// <copyright file="FakesCustomization.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Specificity.Fakes
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Testing.Specificity;

    /// <summary>
    /// Customizes an <see cref="ObjectFactory"/> to produce "auto-fakes" when asking for a type
    /// that has been stubbed by the Microsoft Fakes library.
    /// </summary>
    public sealed class FakesCustomization : ObjectFactoryCustomization
    {
        /// <summary>
        /// Referenced Fakes assemblies.
        /// </summary>
        private static readonly Assembly[] FakesAssemblies;

        /// <summary>
        /// Initializes static members of the <see cref="FakesCustomization"/> class.
        /// </summary>
        static FakesCustomization()
        {
            FakesAssemblies = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.GetReferencedAssemblies())
                .Where(n => n.Name.EndsWith(".Fakes"))
                .Distinct()
                .Select(n => Assembly.Load(n))
                .ToArray();
        }

        /// <summary>
        /// Try to obtain an instance of the specified type.
        /// </summary>
        /// <param name="type">The type of object to obtain.</param>
        /// <param name="factory">The factory associated with this customization.</param>
        /// <param name="context">The context in which the object is being obtained.</param>
        /// <param name="result">The object instance to return to the caller.</param>
        /// <returns><see langword="true"/> if an instance of the specified type was obtained; otherwise <see langword="false"/></returns>
        public override bool TryGetAny(Type type, IObjectFactory factory, CustomizationContext context, out object result)
        {
            var stubName = "Stub" + type.Name;
            var stubNamespace = type.Namespace + ".Fakes";
            var stubType = FakesAssemblies.SelectMany(a => a.GetTypes())
                .Where(t => t.Namespace == stubNamespace && t.Name == stubName)
                .FirstOrDefault();
            if (stubType != null)
            {
                result = factory.Any(stubType);
                return true;
            }

            return context.CallNextCustomization(type, factory, out result);
        }
    }
}