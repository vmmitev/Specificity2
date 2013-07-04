﻿//-----------------------------------------------------------------------------
// <copyright file="When_calling_Should_BeSameAs.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Test.Specificity.ObjectConstrainsSpec
{
    using System.Diagnostics.CodeAnalysis;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Testing.Specificity;

    public static class When_calling_Should_BeSameAs
    {
        private static object reference = new object();

        [TestClass]
        public class with_same_reference : TestScenario
        {
            [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1126:PrefixCallsCorrectly", Justification = "Reviewed.")]
            public override void Because()
            {
                Specify.That(reference).Should.BeSameAs(reference);
            }

            [TestMethod]
            public void Should_not_fail()
            {
                this.ShouldNotHaveFailed();
            }
        }

        [TestClass]
        public class with_different_references : TestScenario
        {
            public override void Because()
            {
                Specify.That(reference).Should.BeSameAs(new object());
            }

            [TestMethod]
            public void Should_fail()
            {
                this.ShouldHaveFailed();
            }
        }

        [TestClass]
        public class with_different_references_and_given_message : TestScenario
        {
            public override void Because()
            {
                Specify.That(reference).Should.BeSameAs(new object(), "magic {0}", "xyzzy");
            }

            [TestMethod]
            public void Should_fail()
            {
                this.ShouldHaveFailed("magic xyzzy");
            }
        }
    }
}