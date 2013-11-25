﻿//-----------------------------------------------------------------------------
// <copyright file="FakesCustomizationTests.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Testing.Specificity.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TestTypes;
    using TestTypes.Fakes;

    [TestClass]
    public class FakesCustomizationTests
    {
        [TestMethod]
        public void AnyGivenInterfaceShouldAutoFake()
        {
            var factory = new ObjectFactory();
            var service = factory.Any<ISimpleInterface>();
            Specify.That(service.GetType()).Should.BeEqualTo(typeof(StubISimpleInterface));
        }
    }
}