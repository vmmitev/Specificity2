//-----------------------------------------------------------------------------
// <copyright file="SpecifyTests.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Testing.Specificity.Tests
{
    using System;
    using System.Linq;
    using Gallio.Framework;
    using MbUnit.Framework;

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
            catch (TestFailedException)
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
            catch (TestFailedException e)
            {
                Assert.EndsWith(e.Message, message);
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
            catch (TestFailedException e)
            {
                Assert.EndsWith(e.Message, arg);
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
            catch (AggregateTestFailedException e)
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
            catch (AggregateTestFailedException e)
            {
                Assert.EndsWith(e.Message, message);
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
            catch (AggregateTestFailedException e)
            {
                Assert.EndsWith(e.Message, arg);
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
            catch (TestInconclusiveException)
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
            catch (TestInconclusiveException e)
            {
                Assert.EndsWith(e.Message, message);
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
            catch (TestInconclusiveException e)
            {
                Assert.EndsWith(e.Message, arg);
                return;
            }

            Assert.Fail("Specify.Fail did not throw an AssertInconclusiveException");
        }
    }
}
