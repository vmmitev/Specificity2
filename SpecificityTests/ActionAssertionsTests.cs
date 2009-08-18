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
        /// <summary>
        /// Verifies that <see cref="ActionAssertions.ShouldThrow{TException}(ConstrainedValue{Action})"/> should fail when the
        /// specified action does not throw an exception.
        /// </summary>
        [TestMethod]
        public void ShouldThrow_GivenActionThatDoesNotThrow_ShouldFail()
        {
            try
            {
                Specify.ThatAction(delegate
                {
                }).ShouldHaveThrown(typeof(ConstraintFailedException));
            }
            catch (ConstraintFailedException)
            {
                return;
            }

            Assert.Fail("ShouldThrow did not fail.");
        }

        /// <summary>
        /// Verifies that <see cref="ActionAssertions.ShouldThrow{TException}(ConstrainedValue{Action})"/> should fail when the
        /// specified action throws a different exception type.
        /// </summary>
        [TestMethod]
        public void ShouldThrow_GivenActionThatThrowsDifferentType_ShouldFail()
        {
            try
            {
                Specify.ThatAction(delegate
                {
                    throw new InvalidOperationException();
                }).ShouldHaveThrown(typeof(ArgumentNullException));
            }
            catch (ConstraintFailedException)
            {
                return;
            }

            Assert.Fail("ShouldThrow did not fail.");
        }

        /// <summary>
        /// Verifies that <see cref="ActionAssertions.ShouldThrow{TException}(ConstrainedValue{Action})"/> should not fail when the
        /// specified action throws the specified exception type.
        /// </summary>
        [TestMethod]
        public void ShouldThrow_GivenActionThatThrowsCompatibleExceptionType_ShouldNotFail()
        {
            try
            {
                Specify.ThatAction(delegate
                {
                    throw new InvalidOperationException();
                }).ShouldHaveThrown(typeof(InvalidOperationException));
            }
            catch (ConstraintFailedException)
            {
                Assert.Fail("ShouldThrow failed");
            }
        }

        /// <summary>
        /// Verifies that <see cref="ActionAssertions.ShouldNotThrow(ConstrainedValue{Action})"/> should fail when specified action throws.
        /// </summary>
        [TestMethod]
        public void ShouldNotThrow_GivenActionThatThrows_ShouldFail()
        {
            try
            {
                Specify.ThatAction(delegate
                {
                    throw new InvalidOperationException();
                }).ShouldNotHaveThrown();
            }
            catch (ConstraintFailedException)
            {
                return;
            }

            Assert.Fail("ShouldNotThrow did not fail.");
        }

        /// <summary>
        /// Verifies that <see cref="ActionAssertions.ShouldNotThrow(ConstrainedValue{Action})"/> should not fail when specified
        /// action does not throw.
        /// </summary>
        [TestMethod]
        public void ShouldNotThrow_GivenActionThatDoesNotThrow_ShouldNotFail()
        {
            try
            {
                Specify.ThatAction(delegate { }).ShouldNotHaveThrown();
            }
            catch (ConstraintFailedException)
            {
                Assert.Fail("ShouldNotThrow failed.");
            }
        }
    }
}
