//-----------------------------------------------------------------------------
// <copyright file="TestInitialize.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Testing.Specificity2.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TestInitialize
    {
        [AssemblyInitialize]
        public static void Initialize(TestContext context)
        {
            var fakesCustomization = new FakesCustomization();
            ObjectFactory.DefaultRegistry.Customize(fakesCustomization);
        }
    }
}