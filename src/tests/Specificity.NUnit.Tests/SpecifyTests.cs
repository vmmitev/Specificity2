//-----------------------------------------------------------------------------
// <copyright file="SpecifyTests.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Testing.Specificity.Tests
{
    using System;
    using System.Linq;
    using NUnit.Framework;

    [TestFixture]
    public class SpecifyTests
    {
        [Test]
        public void FailShouldThrowTestFailedException()
        {
            try
            {
                Specify.Failure();
            }
            catch (AssertionException)
            {
                return;
            }

            Assert.Fail("Specify.Fail did not throw an AssertFailedException");
        }

        [Test]
        public void FailGivenMessageShouldThrowTestFailedExceptionWithMessage()
        {
            var message = "xyzzy";
            try
            {
                Specify.Failure(message);
            }
            catch (AssertionException e)
            {
                StringAssert.EndsWith(e.Message, message);
                return;
            }

            Assert.Fail("Specify.Fail did not throw an AssertFailedException");
        }

        [Test]
        public void FailGivenMessageAndArgsShouldThrowTestFailedExceptionWithFormattedMessage()
        {
            string message = "{0}";
            string arg = "xyzzy";
            try
            {
                Specify.Failure(message, arg);
            }
            catch (AssertionException e)
            {
                StringAssert.EndsWith(e.Message, arg);
                return;
            }

            Assert.Fail("Specify.Fail did not throw an AssertFailedException");
        }

        [Test]
        public void FailGivenInnerExceptionsShouldThrowAggregateTestFailedException()
        {
            var exception = new Exception();
            try
            {
                Specify.Failure(new[] { exception });
            }
            catch (AggregateAssertionException e)
            {
                Assert.AreSame(exception, e.InnerException);
                Assert.AreSame(exception, e.InnerExceptions.FirstOrDefault());
                return;
            }

            Assert.Fail("Specify.Fail did not throw an AggregateAssertFailedException");
        }

        [Test]
        public void FailGivenInnerExceptionsAndMessageShouldThrowAggregateTestFailedExceptionWithMessage()
        {
            var message = "xyzzy";
            var exception = new Exception();
            try
            {
                Specify.Failure(new[] { exception }, message);
            }
            catch (AggregateAssertionException e)
            {
                StringAssert.EndsWith(e.Message, message);
                Assert.AreSame(exception, e.InnerException);
                Assert.AreSame(exception, e.InnerExceptions.FirstOrDefault());
                return;
            }

            Assert.Fail("Specify.Fail did not throw an AggregateAssertFailedException");
        }

        [Test]
        public void FailGivenInnerExceptionsMessageAndArgsShouldThrowAggregateTestFailedExceptionWithFormattedMessage()
        {
            var message = "{0}";
            var arg = "xyzzy";
            var exception = new Exception();
            try
            {
                Specify.Failure(new[] { exception }, message, arg);
            }
            catch (AggregateAssertionException e)
            {
                StringAssert.EndsWith(e.Message, arg);
                Assert.AreSame(exception, e.InnerException);
                Assert.AreSame(exception, e.InnerExceptions.FirstOrDefault());
                return;
            }

            Assert.Fail("Specify.Fail did not throw an AggregateAssertFailedException");
        }

        [Test]
        public void InconclusiveShouldThrowTestInconclusiveException()
        {
            try
            {
                Specify.Inonclusive();
            }
            catch (InconclusiveException)
            {
                return;
            }

            Assert.Fail("Specify.Fail did not throw an AssertInconclusiveException");
        }

        [Test]
        public void InconclusiveGivenMessageShouldThrowTestInconclusiveExceptionWithMessage()
        {
            string message = "xyzzy";
            try
            {
                Specify.Inonclusive(message);
            }
            catch (InconclusiveException e)
            {
                StringAssert.EndsWith(e.Message, message);
                return;
            }

            Assert.Fail("Specify.Fail did not throw an AssertInconclusiveException");
        }

        [Test]
        public void InconclusiveGivenMessageAndArgsShouldThrowTestInconclusiveExceptionWithFormattedMessage()
        {
            string message = "{0}";
            string arg = "xyzzy";
            try
            {
                Specify.Inonclusive(message, arg);
            }
            catch (InconclusiveException e)
            {
                StringAssert.EndsWith(e.Message, arg);
                return;
            }

            Assert.Fail("Specify.Fail did not throw an AssertInconclusiveException");
        }
    }
}