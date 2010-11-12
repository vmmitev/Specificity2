//-----------------------------------------------------------------------------
// <copyright file="Scenario.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Test.Specificity
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Testing.Specificity;

    [TestClass]
    public abstract class Scenario
    {
        private string message;

        [TestInitialize]
        public void TestInitialize()
        {
            this.EstablishContext();
            try
            {
                this.Because();
            }
            catch (ConstraintFailedException ex)
            {
                this.message = ex.Message;
            }
        }

        protected ConstrainedValue<T> SpecifyThat<T>(T value)
        {
            return new ConstrainedValue<T>(value);
        }

        protected ConstrainedValue<Action> SpecifyThatAction(Action action)
        {
            return new ConstrainedValue<Action>(action);
        }

        protected void ShouldHaveFailed()
        {
            Assert.IsNotNull(this.message, "The specification constraint failed unexpectedly.");
        }

        protected void ShouldHaveFailed(string substring)
        {
            Assert.IsNotNull(this.message, "The specification constraint did not fail.");
            Assert.IsTrue(this.message.Contains(substring), "The specification constraint failure exception did not contain the user message.");
        }

        protected void ShouldNotHaveFailed()
        {
            Assert.IsNull(this.message, "The specification constraint failed.");
        }

        protected virtual void EstablishContext()
        {
        }

        protected abstract void Because();
    }
}
