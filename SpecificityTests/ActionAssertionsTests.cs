//-----------------------------------------------------------------------------
// <copyright file="ActionAssertionsTests.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Testing.SpecificityTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Testing.Specificity;

    /// <summary>
    /// Provides tests for the <see cref="ActionAssertions"/> extension methods.
    /// </summary>
    [TestClass]
    public class ActionAssertionsTests
    {
        private static readonly Action DoNotThrow = () => { };
        private static readonly Action Throw = () => { throw new InvalidOperationException(); };

        [TestMethod]
        public void ShouldHaveThrown_GivenActionThatDoesNotThrow_ShouldFail()
        {
            Verify.That(() => Specify.ThatAction(DoNotThrow).Should.HaveThrown()).ShouldFail();
        }

        [TestMethod]
        public void ShouldHaveThrown_GivenActionThatThrows_ShouldNotFail()
        {
            Verify.That(() => Specify.ThatAction(Throw).Should.HaveThrown()).ShouldNotFail();
        }

        [TestMethod]
        public void ShouldNotHaveThrown_GivenActionThatThrows_ShouldFail()
        {
            Verify.That(() => Specify.ThatAction(Throw).Should.Not.HaveThrown()).ShouldFail();
        }

        [TestMethod]
        public void ShouldNotHaveThrown_GivenActionThatDoesNotThrow_ShouldNotFail()
        {
            Verify.That(() => Specify.ThatAction(DoNotThrow).Should.Not.HaveThrown()).ShouldNotFail();
        }

        [TestMethod]
        public void ShouldThrow_GivenActionThatDoesNotThrow_ShouldFail()
        {
            Verify.That(() => Specify.ThatAction(DoNotThrow).ShouldHaveThrown()).ShouldFail();
        }

        [TestMethod]
        public void ShouldThrow_GivenActionThatThrowsDifferentType_ShouldFail()
        {
            Verify.That(() => Specify.ThatAction(Throw).ShouldHaveThrown(typeof(ArgumentNullException))).ShouldFail();
        }

        [TestMethod]
        public void ShouldThrow_GivenActionThatThrowsCompatibleExceptionType_ShouldNotFail()
        {
            Verify.That(() => Specify.ThatAction(Throw).ShouldHaveThrown(typeof(InvalidOperationException))).ShouldNotFail();
        }

        [TestMethod]
        public void ShouldNotThrow_GivenActionThatThrows_ShouldFail()
        {
            Verify.That(() => Specify.ThatAction(Throw).ShouldNotHaveThrown()).ShouldFail();
        }

        [TestMethod]
        public void ShouldNotThrow_GivenActionThatDoesNotThrow_ShouldNotFail()
        {
            Verify.That(() => Specify.ThatAction(DoNotThrow).ShouldNotHaveThrown()).ShouldNotFail();
        }
    }
}
