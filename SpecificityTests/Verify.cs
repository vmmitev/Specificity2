//-----------------------------------------------------------------------------
// <copyright file="Verify.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Testing.SpecificityTests
{
    using System;
    using System.Globalization;
    using System.Linq.Expressions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Testing.Specificity;

    public class Verify
    {
        private Expression<Action> test;

        private Verify(Expression<Action> test)
        {
            this.test = test;
        }

        public static Verify That(Expression<Action> test)
        {
            return new Verify(test);
        }

        public void ShouldFail()
        {
            try
            {
                Action action = this.test.Compile();
                action();
            }
            catch (ConstraintFailedException)
            {
                return;
            }

            Assert.Fail(string.Format(CultureInfo.CurrentCulture, "{0}: expected failure but did not fail", this.test));
        }

        public void ShouldNotFail()
        {
            try
            {
                Action action = this.test.Compile();
                action();
            }
            catch (ConstraintFailedException)
            {
                Assert.Fail(string.Format(CultureInfo.CurrentCulture, "{0}: did not expect failure but failed", this.test));
            }
        }
    }
}
