//-----------------------------------------------------------------------------
// <copyright file="SpecifyTests.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Testing.Specificity2.Tests
{
    using System;
    using System.Linq;
    using Xunit;
    using Xunit.Sdk;

    public class SpecifyTests
    {
        [Fact]
        public void FailGivenInnerExceptionsAndMessageShouldThrowAggregateExceptionWithMessage()
        {
            var message = "xyzzy";
            var exception = new Exception();
            try
            {
                Specify.Failure(new[] { exception }, message);
            }
            catch (AggregateException e)
            {
                Assert.True(e.Message.Contains(message));
                Assert.Same(exception, e.InnerException);
                Assert.Same(exception, e.InnerExceptions.FirstOrDefault());
                return;
            }

            throw new XunitException("Specify.Fail did not throw an AssertFailedException");
        }

        [Fact]
        public void FailGivenInnerExceptionsMessageAndArgsShouldThrowAggregateExceptionWithFormattedMessage()
        {
            var message = "{0}";
            var arg = "xyzzy";
            var exception = new Exception();
            try
            {
                Specify.Failure(new[] { exception }, message, arg);
            }
            catch (AggregateException e)
            {
                Assert.True(e.Message.Contains(arg));
                Assert.Same(exception, e.InnerException);
                Assert.Same(exception, e.InnerExceptions.FirstOrDefault());
                return;
            }

            throw new XunitException("Specify.Fail did not throw an AssertFailedException");
        }

        [Fact]
        public void FailGivenInnerExceptionsShouldThrowAggregateException()
        {
            var exception = new Exception();
            try
            {
                Specify.Failure(new[] { exception });
            }
            catch (AggregateException e)
            {
                Assert.Same(exception, e.InnerException);
                Assert.Same(exception, e.InnerExceptions.FirstOrDefault());
                return;
            }

            throw new XunitException("Specify.Fail did not throw an AssertFailedException");
        }

        [Fact]
        public void FailGivenMessageAndArgsShouldThrowTestFailedExceptionWithFormattedMessage()
        {
            string message = "{0}";
            string arg = "xyzzy";
            try
            {
                Specify.Failure(message, arg);
            }
            catch (XunitException e)
            {
                Assert.True(e.Message.EndsWith(arg));
                return;
            }

            throw new XunitException("Specify.Fail did not throw an AssertFailedException");
        }

        [Fact]
        public void FailGivenMessageShouldThrowTestFailedExceptionWithMessage()
        {
            var message = "xyzzy";
            try
            {
                Specify.Failure(message);
            }
            catch (XunitException e)
            {
                Assert.True(e.Message.EndsWith(message));
                return;
            }

            throw new XunitException("Specify.Fail did not throw an AssertFailedException");
        }

        [Fact]
        public void FailShouldThrowTestFailedException()
        {
            try
            {
                Specify.Failure();
            }
            catch (XunitException)
            {
                return;
            }

            throw new XunitException("Specify.Fail did not throw an AssertFailedException");
        }

        [Fact]
        public void InconclusiveGivenMessageAndArgsShouldThrowTestInconclusiveExceptionWithFormattedMessage()
        {
            string message = "{0}";
            string arg = "xyzzy";
            try
            {
                Specify.Inonclusive(message, arg);
            }
            catch (XunitException e)
            {
                Assert.True(e.Message.EndsWith(arg));
                return;
            }

            throw new XunitException("Specify.Fail did not throw an AssertFailedException");
        }

        [Fact]
        public void InconclusiveGivenMessageShouldThrowTestInconclusiveExceptionWithMessage()
        {
            string message = "xyzzy";
            try
            {
                Specify.Inonclusive(message);
            }
            catch (XunitException e)
            {
                Assert.True(e.Message.EndsWith(message));
                return;
            }

            throw new XunitException("Specify.Fail did not throw an AssertFailedException");
        }

        [Fact]
        public void InconclusiveShouldThrowTestInconclusiveException()
        {
            try
            {
                Specify.Inonclusive();
            }
            catch (XunitException)
            {
                return;
            }

            throw new XunitException("Specify.Fail did not throw an AssertFailedException");
        }
    }
}