﻿//-----------------------------------------------------------------------------
// <copyright file="When_calling_Should_BeInstanceOfType.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Test.Specificity.ObjectConstrainsSpec
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Testing.Specificity;

    public static class When_calling_Should_BeInstanceOfType
    {
        [TestClass]
        public class when_given_instance_of_type : TestScenario
        {
            public override void Because()
            {
                Specify.That("foo").Should.BeInstanceOfType(typeof(string));
            }

            [TestMethod]
            public void Should_not_fail()
            {
                this.ShouldNotHaveFailed();
            }
        }

        [TestClass]
        public class when_given_instance_of_derived_type : TestScenario
        {
            public override void Because()
            {
                Specify.That(this).Should.BeInstanceOfType(typeof(TestScenario));
            }

            [TestMethod]
            public void Should_not_fail()
            {
                this.ShouldNotHaveFailed();
            }
        }

        [TestClass]
        public class when_given_instance_of_different_type : TestScenario
        {
            public override void Because()
            {
                Specify.That("foo").Should.BeInstanceOfType(typeof(Scenario));
            }

            [TestMethod]
            public void Should_fail()
            {
                this.ShouldHaveFailed();
            }
        }

        [TestClass]
        public class when_given_instance_of_different_type_and_given_message : TestScenario
        {
            public override void Because()
            {
                Specify.That("foo").Should.BeInstanceOfType(typeof(Scenario), "magic {0}", "xyzzy");
            }

            [TestMethod]
            public void Should_fail()
            {
                this.ShouldHaveFailed("magic xyzzy");
            }
        }
    }
}