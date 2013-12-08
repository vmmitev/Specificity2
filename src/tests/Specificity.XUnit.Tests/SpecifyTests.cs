//-----------------------------------------------------------------------------
// <copyright file="SpecifyTests.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Testing.Specificity.Tests
{
    using System;
    using System.Linq;
    using Xunit;
    using Xunit.Sdk;

    public class SpecifyTests
    {
        [Fact]
        public void FailGivenInnerExceptionsAndMessageShouldThrowAggregateTestFailedExceptionWithMessage()
        {
            var message = "xyzzy";
            var exception = new Exception();
            try
            {
                Specify.Failure(new[] { exception }, message);
            }
            catch (AggregateAssertException e)
            {
                Assert.True(e.Message.Contains(message));
                Assert.Same(exception, e.InnerException);
                Assert.Same(exception, e.InnerExceptions.FirstOrDefault());
                return;
            }

            throw new AssertException("Specify.Fail did not throw an AssertFailedException");
        }

        [Fact]
        public void FailGivenInnerExceptionsMessageAndArgsShouldThrowAggregateTestFailedExceptionWithFormattedMessage()
        {
            var message = "{0}";
            var arg = "xyzzy";
            var exception = new Exception();
            try
            {
                Specify.Failure(new[] { exception }, message, arg);
            }
            catch (AggregateAssertException e)
            {
                Assert.True(e.Message.Contains(arg));
                Assert.Same(exception, e.InnerException);
                Assert.Same(exception, e.InnerExceptions.FirstOrDefault());
                return;
            }

            throw new AssertException("Specify.Fail did not throw an AssertFailedException");
        }

        [Fact]
        public void FailGivenInnerExceptionsShouldThrowAggregateTestFailedException()
        {
            var exception = new Exception();
            try
            {
                Specify.Failure(new[] { exception });
            }
            catch (AggregateAssertException e)
            {
                Assert.Same(exception, e.InnerException);
                Assert.Same(exception, e.InnerExceptions.FirstOrDefault());
                return;
            }

            throw new AssertException("Specify.Fail did not throw an AssertFailedException");
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
            catch (AssertException e)
            {
                Assert.True(e.Message.EndsWith(arg));
                return;
            }

            throw new AssertException("Specify.Fail did not throw an AssertFailedException");
        }

        [Fact]
        public void FailGivenMessageShouldThrowTestFailedExceptionWithMessage()
        {
            var message = "xyzzy";
            try
            {
                Specify.Failure(message);
            }
            catch (AssertException e)
            {
                Assert.True(e.Message.EndsWith(message));
                return;
            }

            throw new AssertException("Specify.Fail did not throw an AssertFailedException");
        }

        [Fact]
        public void FailShouldThrowTestFailedException()
        {
            try
            {
                Specify.Failure();
            }
            catch (AssertException)
            {
                return;
            }

            throw new AssertException("Specify.Fail did not throw an AssertFailedException");
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
            catch (AssertException e)
            {
                Assert.True(e.Message.EndsWith(arg));
                return;
            }

            throw new AssertException("Specify.Fail did not throw an AssertFailedException");
        }

        [Fact]
        public void InconclusiveGivenMessageShouldThrowTestInconclusiveExceptionWithMessage()
        {
            string message = "xyzzy";
            try
            {
                Specify.Inonclusive(message);
            }
            catch (AssertException e)
            {
                Assert.True(e.Message.EndsWith(message));
                return;
            }

            throw new AssertException("Specify.Fail did not throw an AssertFailedException");
        }

        [Fact]
        public void InconclusiveShouldThrowTestInconclusiveException()
        {
            try
            {
                Specify.Inonclusive();
            }
            catch (AssertException)
            {
                return;
            }

            throw new AssertException("Specify.Fail did not throw an AssertFailedException");
        }
    }
}