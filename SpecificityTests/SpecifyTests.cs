//-----------------------------------------------------------------------------
// <copyright file="SpecifyTests.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Testing.SpecificityTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Testing.Specificity;

    /// <summary>
    /// Provides tests for the <see cref="Specify"/> static class.
    /// </summary>
    [TestClass]
    public class SpecifyTests
    {
        /// <summary>
        /// Verifies that <see cref="Specify.That"/> returns a <see cref="ConstrainedValue{T}"/> when given a value.
        /// </summary>
        [TestMethod]
        public void That_GivenValue_ShouldReturnConstrainedValue()
        {
            int expected = 10;
            ConstrainedValue<int> constrainedValue = Specify.That(expected);
            Assert.AreEqual(expected, constrainedValue.Value);
        }

        /// <summary>
        /// Verifies that <see cref="Specify.ThatAction"/> returns a <see cref="ConstrainedValue{T}"/> when given a value.
        /// </summary>
        [TestMethod]
        public void ThatAction_GivenAction_ShouldReturnConstrainedValue()
        {
            Action action = delegate { };
            ConstrainedValue<Action> constrainedValue = Specify.ThatAction(action);
            Assert.AreSame(action, constrainedValue.Value);
        }
    }
}
