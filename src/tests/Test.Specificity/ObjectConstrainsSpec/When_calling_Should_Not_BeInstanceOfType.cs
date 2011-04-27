﻿//-----------------------------------------------------------------------------
// <copyright file="When_calling_Should_Not_BeInstanceOfType.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Test.Specificity.ObjectConstrainsSpec
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Testing.Specificity;

    public static class When_calling_Should_Not_BeInstanceOfType
    {
        [TestClass]
        public class when_given_instance_of_type : Scenario
        {
            protected override void Because()
            {
                SpecifyThat("foo").Should.Not.BeInstanceOfType(typeof(string));
            }

            [TestMethod]
            public void Should_fail()
            {
                this.ShouldHaveFailed();
            }
        }

        [TestClass]
        public class when_given_instance_of_derived_type : Scenario
        {
            protected override void Because()
            {
                SpecifyThat(this).Should.Not.BeInstanceOfType(typeof(Scenario));
            }

            [TestMethod]
            public void Should_fail()
            {
                this.ShouldHaveFailed();
            }
        }

        [TestClass]
        public class when_given_instance_of_different_type : Scenario
        {
            protected override void Because()
            {
                SpecifyThat("foo").Should.Not.BeInstanceOfType(typeof(Scenario));
            }

            [TestMethod]
            public void Should_not_fail()
            {
                this.ShouldNotHaveFailed();
            }
        }

        [TestClass]
        public class when_given_instance_of_type_and_given_message : Scenario
        {
            protected override void Because()
            {
                SpecifyThat("foo").Should.Not.BeInstanceOfType(typeof(string), "magic {0}", "xyzzy");
            }

            [TestMethod]
            public void Should_fail()
            {
                this.ShouldHaveFailed("magic xyzzy");
            }
        }
    }
}