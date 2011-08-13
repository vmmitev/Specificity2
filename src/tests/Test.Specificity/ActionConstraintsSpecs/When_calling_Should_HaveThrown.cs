//-----------------------------------------------------------------------------
// <copyright file="When_calling_Should_HaveThrown.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Test.Specificity.ActionConstraintsSpecs
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Testing.Specificity;

    public static class When_calling_Should_HaveThrown
    {
        [TestClass]
        public class with_action_that_does_throw : TestScenario
        {
            public override void Because()
            {
                Specify.ThatAction(() => { throw new InvalidOperationException(); }).Should.HaveThrown();
            }

            [TestMethod]
            public void Should_not_fail()
            {
                this.ShouldNotHaveFailed();
            }
        }

        [TestClass]
        public class with_action_that_does_not_throw : TestScenario
        {
            public override void Because()
            {
                Specify.ThatAction(() => { }).Should.HaveThrown();
            }

            [TestMethod]
            public void Should_fail()
            {
                this.ShouldHaveFailed();
            }
        }

        [TestClass]
        public class with_action_that_does_not_throw_and_given_message : TestScenario
        {
            public override void Because()
            {
                Specify.ThatAction(() => { }).Should.HaveThrown("magic {0}", "xyzzy");
            }

            [TestMethod]
            public void Should_fail_with_message()
            {
                this.ShouldHaveFailed("magic xyzzy");
            }
        }

        [TestClass]
        public class with_action_that_throws_specified_type : TestScenario
        {
            public override void Because()
            {
                Specify.ThatAction(() => { throw new ArgumentNullException(); }).Should.HaveThrown(typeof(ArgumentException));
            }

            [TestMethod]
            public void Should_not_fail()
            {
                this.ShouldNotHaveFailed();
            }
        }

        [TestClass]
        public class with_action_that_throws_different_type : TestScenario
        {
            public override void Because()
            {
                Specify.ThatAction(() => { throw new InvalidOperationException(); }).Should.HaveThrown(typeof(ArgumentException));
            }

            [TestMethod]
            public void Should_fail()
            {
                this.ShouldHaveFailed();
            }
        }

        [TestClass]
        public class with_action_that_throws_different_type_and_given_message : TestScenario
        {
            public override void Because()
            {
                Specify.ThatAction(() => { throw new InvalidOperationException(); }).Should.HaveThrown(typeof(ArgumentException), "magic {0}", "xyzzy");
            }

            [TestMethod]
            public void Should_fail_with_message()
            {
                this.ShouldHaveFailed("magic xyzzy");
            }
        }
    }
}