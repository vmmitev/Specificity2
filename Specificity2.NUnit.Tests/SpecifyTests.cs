// <copyright file="SpecifyTests.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>

namespace Testing.Specificity2.Tests
{
    using System;
    using System.Linq;
    using NUnit.Framework;

    [TestFixture]
    public class SpecifyTests
    {
        [Test]
        public void FailGivenInnerExceptionsAndMessageShouldThrowAggregateAssertionExceptionWithMessage()
        {
            var message = "Test Message";
            var exception = new AssertionException(message);

            try
            {
                Specify.Failure(new[] { exception }, message);
            }
            catch (AggregateAssertionException e)
            {
                StringAssert.Contains(message, e.Message);
                Assert.AreSame(exception, e.InnerException);
                Assert.AreSame(exception, e.InnerExceptions.FirstOrDefault());
                return;
            }

            Assert.Fail("Specify.Failure did not throw an AggregateAssertFailedException");
        }

        [Test]
        public void FailGivenInnerExceptionsMessageAndArgsShouldThrowAggregateAssertionExceptionWithFormattedMessage()
        {
            var message = "{0}";
            var arg = "Test Message";
            var exception = new AssertionException(message);

            try
            {
                Specify.Failure(new[] { exception }, message, arg);
            }
            catch (AggregateAssertionException e)
            {
                StringAssert.Contains(arg, e.Message);
                Assert.AreSame(exception, e.InnerException);
                Assert.AreSame(exception, e.InnerExceptions.FirstOrDefault());
                return;
            }

            Assert.Fail("Specify.Failure did not throw an AggregateAssertFailedException");
        }

        [Test]
        public void FailGivenInnerExceptionsShouldThrowAggregateAssertionException()
        {
            var exception = new AssertionException("Test Message");

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

            Assert.Fail("Specify.Failure did not throw an AggregateAssertFailedException");
        }

        [Test]
        public void FailGivenMessageAndArgsShouldThrowTestFailedExceptionWithFormattedMessage()
        {
            string message = "{0}";
            string arg = "Test Message";

            try
            {
                Specify.Failure(message, arg);
            }
            catch (AssertionException e)
            {
                StringAssert.EndsWith(e.Message, arg);
                return;
            }

            Assert.Fail("Specify.Failure did not throw an AssertFailedException");
        }

        [Test]
        public void FailGivenMessageShouldThrowTestFailedExceptionWithMessage()
        {
            var message = "Test Message";

            try
            {
                Specify.Failure(message);
            }
            catch (AssertionException e)
            {
                StringAssert.EndsWith(e.Message, message);
                return;
            }

            Assert.Fail("Specify.Failure did not throw an AssertFailedException");
        }

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

            Assert.Fail("Specify.Failure did not throw an AssertFailedException");
        }

        [Test]
        public void InconclusiveGivenMessageAndArgsShouldThrowTestInconclusiveExceptionWithFormattedMessage()
        {
            string message = "{0}";
            string arg = "Test Message";

            try
            {
                Specify.Inconclusive(message, arg);
            }
            catch (InconclusiveException e)
            {
                StringAssert.EndsWith(e.Message, arg);
                return;
            }

            Assert.Fail("Specify.Failure did not throw an AssertInconclusiveException");
        }

        [Test]
        public void InconclusiveGivenMessageShouldThrowTestInconclusiveExceptionWithMessage()
        {
            string message = "Test Message";

            try
            {
                Specify.Inconclusive(message);
            }
            catch (InconclusiveException e)
            {
                StringAssert.EndsWith(e.Message, message);
                return;
            }

            Assert.Fail("Specify.Failure did not throw an AssertInconclusiveException");
        }

        [Test]
        public void InconclusiveShouldThrowTestInconclusiveException()
        {
            try
            {
                Specify.Inconclusive();
            }
            catch (InconclusiveException)
            {
                return;
            }

            Assert.Fail("Specify.Failure did not throw an AssertInconclusiveException");
        }
    }
}