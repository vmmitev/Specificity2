//-----------------------------------------------------------------------------
// <copyright file="TestScenario.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Test.Specificity
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public abstract class TestScenario
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
            catch (AssertFailedException ex)
            {
                this.message = ex.Message;
            }
        }

        ////protected ConstrainedValue<T> Specify.That<T>(T value)
        ////{
        ////    return new ConstrainedValue<T>(value);
        ////}

        ////protected ConstrainedValue<Action> Specify.ThatAction(Action action)
        ////{
        ////    return new ConstrainedValue<Action>(action);
        ////}

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

        public virtual void EstablishContext()
        {
        }

        public abstract void Because();
    }
}