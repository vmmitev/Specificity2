//-----------------------------------------------------------------------------
// <copyright file="NumericAssertionsTests.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Testing.SpecificityTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Testing.Specificity;

    /// <summary>
    /// Provides tests for the <see cref="NumericAssertions"/> extension methods.
    /// </summary>
    [TestClass]
    public class NumericAssertionsTests
    {
        /// <summary>
        /// Verifies that <see cref="NumericAssertions.ShouldBeEqualTo(ConstrainedValue{double}, double, double)"/> should
        /// fail when given values that differ by more than the delta.
        /// </summary>
        [TestMethod]
        public void ShouldBeEqualTo_GivenDoublesThatDifferByMoreThanDelta_ShouldFail()
        {
            Specify.ThatAction(delegate
            {
                Specify.That(10.0d).ShouldBeEqualTo(11.0d, 0.5d);
            }).ShouldHaveThrown(typeof(ConstraintFailedException));
        }

        /// <summary>
        /// Verifies that <see cref="NumericAssertions.ShouldBeEqualTo(ConstrainedValue{double}, double, double)"/> should
        /// not fail when given values that differ by less than the delta.
        /// </summary>
        [TestMethod]
        public void ShouldBeEqualTo_GivenDoublesThatDifferByLessThanDelta_ShouldNotFail()
        {
            Specify.ThatAction(delegate
            {
                Specify.That(10.0d).ShouldBeEqualTo(10.0d, 0.5d);
            }).ShouldNotHaveThrown();
        }

        /// <summary>
        /// Verifies that <see cref="NumericAssertions.ShouldBeEqualTo(ConstrainedValue{float}, float, float)"/> should
        /// fail when given values that differ by more than the delta.
        /// </summary>
        [TestMethod]
        public void ShouldBeEqualTo_GivenSinglesThatDifferByMoreThanDelta_ShouldFail()
        {
            Specify.ThatAction(delegate
            {
                Specify.That(10.0f).ShouldBeEqualTo(11.0f, 0.5f);
            }).ShouldHaveThrown(typeof(ConstraintFailedException));
        }

        /// <summary>
        /// Verifies that <see cref="NumericAssertions.ShouldBeEqualTo(ConstrainedValue{float}, float, float)"/> should
        /// not fail when given values that differ by less than the delta.
        /// </summary>
        [TestMethod]
        public void ShouldBeEqualTo_GivenSinglesThatDifferByLessThanDelta_ShouldNotFail()
        {
            Specify.ThatAction(delegate
            {
                Specify.That(10.0f).ShouldBeEqualTo(10.0f, 0.5f);
            }).ShouldNotHaveThrown();
        }

        /// <summary>
        /// Verifies that <see cref="NumericAssertions.ShouldNotBeEqualTo(ConstrainedValue{double}, double, double)"/> should
        /// not fail when given values that differ by more than the delta.
        /// </summary>
        [TestMethod]
        public void ShouldNotBeEqualTo_GivenDoublesThatDifferByMoreThanDelta_ShouldNotFail()
        {
            Specify.ThatAction(delegate
            {
                Specify.That(10.0d).ShouldNotBeEqualTo(11.0d, 0.5d);
            }).ShouldNotHaveThrown();
        }

        /// <summary>
        /// Verifies that <see cref="NumericAssertions.ShouldNotBeEqualTo(ConstrainedValue{double}, double, double)"/> should
        /// fail when given values that differ by less than the delta.
        /// </summary>
        [TestMethod]
        public void ShouldNotBeEqualTo_GivenDoublesThatDifferByLessThanDelta_ShouldFail()
        {
            Specify.ThatAction(delegate
            {
                Specify.That(10.0d).ShouldNotBeEqualTo(10.0d, 0.5d);
            }).ShouldHaveThrown(typeof(ConstraintFailedException));
        }

        /// <summary>
        /// Verifies that <see cref="NumericAssertions.ShouldNotBeEqualTo(ConstrainedValue{float}, float, float)"/> should
        /// not fail when given values that differ by more than the delta.
        /// </summary>
        [TestMethod]
        public void ShouldNotBeEqualTo_GivenSinglesThatDifferByMoreThanDelta_ShouldNotFail()
        {
            Specify.ThatAction(delegate
            {
                Specify.That(10.0f).ShouldNotBeEqualTo(11.0f, 0.5f);
            }).ShouldNotHaveThrown();
        }

        /// <summary>
        /// Verifies that <see cref="NumericAssertions.ShouldNotBeEqualTo(ConstrainedValue{float}, float, float)"/> should
        /// fail when given values that differ by more than the delta.
        /// </summary>
        [TestMethod]
        public void ShouldNotBeEqualTo_GivenSinglesThatDifferByLessThanDelta_ShouldFail()
        {
            Specify.ThatAction(delegate
            {
                Specify.That(10.0f).ShouldNotBeEqualTo(10.0f, 0.5f);
            }).ShouldHaveThrown(typeof(ConstraintFailedException));
        }
    }
}
