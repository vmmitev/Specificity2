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
        /// <summary>
        /// Verifies <see cref="BooleanAssertions.ShouldBeTrue(ConstrainedValue{bool})"/> should fail when <see langword="false"/>.
        /// </summary>
        [TestMethod]
        public void ShouldBeTrue_WhenFalse_ShouldFail()
        {
            Specify.ThatAction(delegate
            {
                Specify.That(false).ShouldBeTrue();
            }).ShouldHaveThrown(typeof(ConstraintFailedException));
        }

        /// <summary>
        /// Verifies <see cref="BooleanAssertions.ShouldBeTrue(ConstrainedValue{bool})"/> should not fail when <see langword="true"/>.
        /// </summary>
        [TestMethod]
        public void ShouldBeTrue_WhenTrue_ShouldNotFail()
        {
            Specify.ThatAction(delegate
            {
                Specify.That(true).ShouldBeTrue();
            }).ShouldNotHaveThrown();
        }

        /// <summary>
        /// Verifies <see cref="BooleanAssertions.ShouldBeFalse(ConstrainedValue{bool})"/> should not fail when <see langword="false"/>.
        /// </summary>
        [TestMethod]
        public void ShouldBeFalse_WhenFalse_ShouldNotFail()
        {
            Specify.ThatAction(delegate
            {
                Specify.That(false).ShouldBeFalse();
            }).ShouldNotHaveThrown();
        }

        /// <summary>
        /// Verifies <see cref="BooleanAssertions.ShouldBeFalse(ConstrainedValue{bool})"/> should fail when <see langword="true"/>.
        /// </summary>
        [TestMethod]
        public void ShouldBeFalse_WhenTrue_ShouldFail()
        {
            Specify.ThatAction(delegate
            {
                Specify.That(true).ShouldBeFalse();
            }).ShouldHaveThrown(typeof(ConstraintFailedException));
        }
    }
}
