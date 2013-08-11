using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testing.Specificity.Tests
{
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
