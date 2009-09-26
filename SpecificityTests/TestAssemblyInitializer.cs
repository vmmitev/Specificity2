//-----------------------------------------------------------------------------
// <copyright file="TestAssemblyInitializer.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Testing.SpecificityTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Testing.Specificity;

    /// <summary>
    /// Defines an <see cref="AssemblyInitializeAttribute"/> annotated method to initialize
    /// the test assembly.
    /// </summary>
    [TestClass]
    public static class TestAssemblyInitializer
    {
        /// <summary>
        /// Initializes the test assembly, ensuring that <see cref="Specify"/> uses the
        /// <see cref="DefaultReportSpecificationResults"/> service in all tests.
        /// </summary>
        /// <param name="context">The test context.</param>
        [AssemblyInitialize]
        public static void Initialize(TestContext context)
        {
            Specify.SetReportingService(new DefaultReportSpecificationResults());
        }
    }
}
