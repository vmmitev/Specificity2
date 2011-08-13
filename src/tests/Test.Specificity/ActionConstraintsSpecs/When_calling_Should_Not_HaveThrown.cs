//-----------------------------------------------------------------------------
// <copyright file="When_calling_Should_Not_HaveThrown.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Test.Specificity.ActionConstraintsSpecs
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Testing.Specificity;

    public static class When_calling_Should_Not_HaveThrown
    {
        [TestClass]
        public class with_action_that_does_throw : TestScenario
        {
            public override void Because()
            {
                Specify.ThatAction(() => { throw new InvalidOperationException(); }).Should.Not.HaveThrown();
            }

            [TestMethod]
            public void Should_fail()
            {
                this.ShouldHaveFailed();
            }
        }

        [TestClass]
        public class with_action_that_does_not_throw : TestScenario
        {
            public override void Because()
            {
                Specify.ThatAction(() => { }).Should.Not.HaveThrown();
            }

            [TestMethod]
            public void Should_not_fail()
            {
                this.ShouldNotHaveFailed();
            }
        }

        [TestClass]
        public class with_action_that_does_throw_and_given_message : TestScenario
        {
            public override void Because()
            {
                Specify.ThatAction(() => { throw new InvalidOperationException(); }).Should.Not.HaveThrown("magic {0}", "xyzzy");
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
                Specify.ThatAction(() => { throw new ArgumentNullException(); }).Should.Not.HaveThrown(typeof(ArgumentException));
            }

            [TestMethod]
            public void Should_fail()
            {
                this.ShouldHaveFailed();
            }
        }

        [TestClass]
        public class with_action_that_throws_different_type : TestScenario
        {
            public override void Because()
            {
                Specify.ThatAction(() => { throw new InvalidOperationException(); }).Should.Not.HaveThrown(typeof(ArgumentException));
            }

            [TestMethod]
            public void Should_not_fail()
            {
                this.ShouldNotHaveFailed();
            }
        }

        [TestClass]
        public class with_action_that_throws_specified_type_and_given_message : TestScenario
        {
            public override void Because()
            {
                Specify.ThatAction(() => { throw new ArgumentNullException(); }).Should.Not.HaveThrown(typeof(ArgumentException), "magic {0}", "xyzzy");
            }

            [TestMethod]
            public void Should_fail_with_message()
            {
                this.ShouldHaveFailed("magic xyzzy");
            }
        }
    }
}