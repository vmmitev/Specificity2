//-----------------------------------------------------------------------------
// <copyright file="BooleanAssertionsTests.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Testing.SpecificityTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Testing.Specificity;

    /// <summary>
    /// Provides tests for the <see cref="BooleanAssertions"/> extension methods.
    /// </summary>
    [TestClass]
    public class BooleanAssertionsTests
    {
        [TestMethod]
        public void ShouldBeTrue_GivenFalse_ShouldFail()
        {
            Verify.That(() => Specify.That(false).Should.BeTrue()).ShouldFail();
        }

        [TestMethod]
        public void ShouldBeTrue_GivenTrue_ShouldNotFail()
        {
            Verify.That(() => Specify.That(true).Should.BeTrue()).ShouldNotFail();
        }

        [TestMethod]
        public void ShouldNotBeTrue_GivenFalse_ShouldNotFail()
        {
            Verify.That(() => Specify.That(false).Should.Not.BeTrue()).ShouldNotFail();
        }

        [TestMethod]
        public void ShouldNotBeTrue_GivenTrue_ShouldFail()
        {
            Verify.That(() => Specify.That(true).Should.Not.BeTrue()).ShouldFail();
        }

        [TestMethod]
        public void ShouldBeFalse_GivenFalse_ShouldNotFail()
        {
            Verify.That(() => Specify.That(false).Should.BeFalse()).ShouldNotFail();
        }

        [TestMethod]
        public void ShouldBeFalse_GivenTrue_ShouldFail()
        {
            Verify.That(() => Specify.That(true).Should.BeFalse()).ShouldFail();
        }

        [TestMethod]
        public void ShouldNotBeFalse_GivenFalse_ShouldFail()
        {
            Verify.That(() => Specify.That(false).Should.Not.BeFalse()).ShouldFail();
        }

        [TestMethod]
        public void ShouldNotBeFalse_GivenTrue_ShouldNotFail()
        {
            Verify.That(() => Specify.That(true).Should.Not.BeFalse()).ShouldNotFail();
        }

        [TestMethod]
        public void ShouldBeTrue_WhenFalse_ShouldFail()
        {
            Verify.That(() => Specify.That(false).ShouldBeTrue()).ShouldFail();
        }

        [TestMethod]
        public void ShouldBeTrue_WhenTrue_ShouldNotFail()
        {
            Verify.That(() => Specify.That(true).ShouldBeTrue()).ShouldNotFail();
        }

        [TestMethod]
        public void ShouldBeFalse_WhenFalse_ShouldNotFail()
        {
            Verify.That(() => Specify.That(false).ShouldBeFalse()).ShouldNotFail();
        }

        [TestMethod]
        public void ShouldBeFalse_WhenTrue_ShouldFail()
        {
            Verify.That(() => Specify.That(true).ShouldBeFalse()).ShouldFail();
        }
    }
}
