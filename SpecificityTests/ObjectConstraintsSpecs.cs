//-----------------------------------------------------------------------------
// <copyright file="ObjectConstraintsSpecs.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Testing.SpecificityTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Testing.Specificity;

    /// <summary>
    /// Defines specifications for the ObjectConstraints.
    /// </summary>
    public static class ObjectConstraintsSpecs
    {
        /// <summary>
        /// Defines what happens when ShouldBeNull is given a null reference.
        /// </summary>
        [TestClass]
        public class When_ShouldBeNull_given_null : Scenario
        {
            /// <summary>
            /// Performs the test action.
            /// </summary>
            public override void Because()
            {
                Specify.That<object>(null).ShouldBeNull();
            }

            /// <summary>
            /// Specifies that it should have thrown an exception.
            /// </summary>
            [TestMethod]
            public void Should_not_throw()
            {
                Assert.AreEqual(null, this.Exception);
            }
        }

        /// <summary>
        /// Defines what happens when ShouldBeNull is given an object reference.
        /// </summary>
        [TestClass]
        public class When_ShouldBeNull_given_object : Scenario
        {
            /// <summary>
            /// Performs the test action.
            /// </summary>
            [ObserveExceptions]
            public override void Because()
            {
                Specify.That(new object()).ShouldBeNull();
            }

            /// <summary>
            /// Specifies that it should throw an exception.
            /// </summary>
            [TestMethod]
            public void Should_throw()
            {
                Assert.IsInstanceOfType(this.Exception, typeof(ConstraintFailedException));
            }
        }
    }
}
