//-----------------------------------------------------------------------------
// <copyright file="SpecifyTests.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Testing.Specificity2.Tests
{
    using System;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class SpecifyTests
    {
        [TestMethod]
        public void AggregateGivenActionThatFailsMultipleAssertionsShouldThrowAggregateAssertFailedException()
        {
            try
            {
                Specify.Aggregate(delegate
                {
                    Specify.Failure();
                    Specify.Failure();
                });
            }
            catch (AggregateAssertFailedException e)
            {
                Assert.AreEqual(2, e.InnerExceptions.Count);
                return;
            }

            Assert.Fail("Specify.Fail did not throw an AggregateAssertFailedException");
        }

        [TestMethod]
        public void FailGivenInnerExceptionsAndMessageShouldThrowAggregateAssertFailedExceptionWithMessage()
        {
            var message = "xyzzy";
            var exception = new Exception();
            try
            {
                Specify.Failure(new[] { exception }, message);
            }
            catch (AggregateAssertFailedException e)
            {
                StringAssert.EndsWith(e.Message.Split()[0], message);
                Assert.AreSame(exception, e.InnerException);
                Assert.AreSame(exception, e.InnerExceptions.FirstOrDefault());
                return;
            }

            Assert.Fail("Specify.Fail did not throw an AggregateAssertFailedException");
        }

        [TestMethod]
        public void FailGivenInnerExceptionsMessageAndArgsShouldThrowAggregateAssertFailedExceptionWithFormattedMessage()
        {
            var message = "{0}";
            var arg = "xyzzy";
            var exception = new Exception();
            try
            {
                Specify.Failure(new[] { exception }, message, arg);
            }
            catch (AggregateAssertFailedException e)
            {
                StringAssert.EndsWith(e.Message.Split()[0], arg);
                Assert.AreSame(exception, e.InnerException);
                Assert.AreSame(exception, e.InnerExceptions.FirstOrDefault());
                return;
            }

            Assert.Fail("Specify.Fail did not throw an AggregateAssertFailedException");
        }

        [TestMethod]
        public void FailGivenInnerExceptionsShouldThrowAggregateAssertFailedException()
        {
            var exception = new Exception();
            try
            {
                Specify.Failure(new[] { exception });
            }
            catch (AggregateAssertFailedException e)
            {
                Assert.AreSame(exception, e.InnerException);
                Assert.AreSame(exception, e.InnerExceptions.FirstOrDefault());
                return;
            }

            Assert.Fail("Specify.Fail did not throw an AggregateAssertFailedException");
        }

        [TestMethod]
        public void FailGivenMessageAndArgsShouldThrowAssertFailedExceptionWithFormattedMessage()
        {
            string message = "{0}";
            string arg = "xyzzy";
            try
            {
                Specify.Failure(message, arg);
            }
            catch (AssertFailedException e)
            {
                StringAssert.EndsWith(e.Message, arg);
                return;
            }

            Assert.Fail("Specify.Fail did not throw an AssertFailedException");
        }

        [TestMethod]
        public void FailGivenMessageShouldThrowAssertFailedExceptionWithMessage()
        {
            var message = "xyzzy";
            try
            {
                Specify.Failure(message);
            }
            catch (AssertFailedException e)
            {
                StringAssert.EndsWith(e.Message, message);
                return;
            }

            Assert.Fail("Specify.Fail did not throw an AssertFailedException");
        }

        [TestMethod]
        public void FailShouldThrowAssertFailedException()
        {
            try
            {
                Specify.Failure();
            }
            catch (AssertFailedException)
            {
                return;
            }

            Assert.Fail("Specify.Fail did not throw an AssertFailedException");
        }

        [TestMethod]
        public void InconclusiveGivenMessageAndArgsShouldThrowAssertInconclusiveExceptionWithFormattedMessage()
        {
            string message = "{0}";
            string arg = "xyzzy";
            try
            {
                Specify.Inonclusive(message, arg);
            }
            catch (AssertInconclusiveException e)
            {
                StringAssert.EndsWith(e.Message, arg);
                return;
            }

            Assert.Fail("Specify.Fail did not throw an AssertInconclusiveException");
        }

        [TestMethod]
        public void InconclusiveGivenMessageShouldThrowAssertInconclusiveExceptionWithMessage()
        {
            string message = "xyzzy";
            try
            {
                Specify.Inonclusive(message);
            }
            catch (AssertInconclusiveException e)
            {
                StringAssert.EndsWith(e.Message, message);
                return;
            }

            Assert.Fail("Specify.Fail did not throw an AssertInconclusiveException");
        }

        [TestMethod]
        public void InconclusiveShouldThrowAssertInconclusiveException()
        {
            try
            {
                Specify.Inonclusive();
            }
            catch (AssertInconclusiveException)
            {
                return;
            }

            Assert.Fail("Specify.Fail did not throw an AssertInconclusiveException");
        }
    }
}