// <copyright file="SpecifyTests.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>

namespace Testing.Specificity2.Tests
{
    using System;
    using System.Linq;
    using Xunit;
    using Xunit.Sdk;

    using NuTest = NUnit.Framework.TestAttribute;

    public class SpecifyTests
    {
        [Fact, NuTest]
        public void FailGivenInnerExceptionsAndMessageShouldThrowAggregateExceptionWithMessage()
        {
            var message = "Test Message";
            var exception = new InvalidOperationException();

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

            throw new XunitException("Specify.Failure did not throw an AssertFailedException");
        }

        [Fact, NuTest]
        public void FailGivenInnerExceptionsMessageAndArgsShouldThrowAggregateExceptionWithFormattedMessage()
        {
            var message = "{0}";
            var arg = "Test Message";
            var exception = new InvalidOperationException();

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

            throw new XunitException("Specify.Failure did not throw an AssertFailedException");
        }

        [Fact, NuTest]
        public void FailGivenInnerExceptionsShouldThrowAggregateException()
        {
            var exception = new InvalidOperationException();

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

            throw new XunitException("Specify.Failure did not throw an AssertFailedException");
        }

        [Fact, NuTest]
        public void FailGivenMessageAndArgsShouldThrowTestFailedExceptionWithFormattedMessage()
        {
            string message = "{0}";
            string arg = "Test Message";

            try
            {
                Specify.Failure(message, arg);
            }
            catch (XunitException e)
            {
                Assert.True(e.Message.EndsWith(arg, StringComparison.Ordinal));
                return;
            }

            throw new XunitException("Specify.Failure did not throw an AssertFailedException");
        }

        [Fact, NuTest]
        public void FailGivenMessageShouldThrowTestFailedExceptionWithMessage()
        {
            var message = "Test Message";

            try
            {
                Specify.Failure(message);
            }
            catch (XunitException e)
            {
                Assert.True(e.Message.EndsWith(message, StringComparison.Ordinal));
                return;
            }

            throw new XunitException("Specify.Failure did not throw an AssertFailedException");
        }

        [Fact, NuTest]
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

            throw new XunitException("Specify.Failure did not throw an AssertFailedException");
        }

        [Fact, NuTest]
        public void InconclusiveGivenMessageAndArgsShouldThrowTestInconclusiveExceptionWithFormattedMessage()
        {
            string message = "{0}";
            string arg = "Test Message";

            try
            {
                Specify.Inconclusive(message, arg);
            }
            catch (XunitException e)
            {
                Assert.True(e.Message.EndsWith(arg, StringComparison.Ordinal));
                return;
            }

            throw new XunitException("Specify.Failure did not throw an AssertFailedException");
        }

        [Fact, NuTest]
        public void InconclusiveGivenMessageShouldThrowTestInconclusiveExceptionWithMessage()
        {
            string message = "Test Message";

            try
            {
                Specify.Inconclusive(message);
            }
            catch (XunitException e)
            {
                Assert.True(e.Message.EndsWith(message, StringComparison.Ordinal));
                return;
            }

            throw new XunitException("Specify.Failure did not throw an AssertFailedException");
        }

        [Fact, NuTest]
        public void InconclusiveShouldThrowTestInconclusiveException()
        {
            try
            {
                Specify.Inconclusive();
            }
            catch (XunitException)
            {
                return;
            }

            throw new XunitException("Specify.Failure did not throw an AssertFailedException");
        }
    }
}