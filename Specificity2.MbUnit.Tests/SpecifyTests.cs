//-----------------------------------------------------------------------------
// <copyright file="SpecifyTests.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Testing.Specificity2.Tests
{
    using System;
    using System.Linq;
    using Gallio.Framework;
    using MbUnit.Framework;

    using NuTest = NUnit.Framework.TestAttribute;

    [TestFixture]
    public class SpecifyTests
    {
        [Test, NuTest]
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

        [Test, NuTest]
        public void FailGivenMessageShouldThrowTestFailedExceptionWithMessage()
        {
            var message = "xyzzy";
            try
            {
                Specify.Failure(message);
            }
            catch (TestFailedException e)
            {
                Assert.Contains(e.Message, message);
                return;
            }

            Assert.Fail("Specify.Fail did not throw an AssertFailedException");
        }

        [Test, NuTest]
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
                Assert.Contains(e.Message, arg);
                return;
            }

            Assert.Fail("Specify.Fail did not throw an AssertFailedException");
        }

        [Test, NuTest]
        public void FailGivenInnerExceptionsShouldThrowAggregateAssertionException()
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

        [Test, NuTest]
        public void FailGivenInnerExceptionsAndMessageShouldThrowAggregateAssertionExceptionWithMessage()
        {
            var message = "xyzzy";
            var exception = new Exception();
            try
            {
                Specify.Failure(new[] { exception }, message);
            }
            catch (AggregateAssertionException e)
            {
                Assert.StartsWith(e.Message, message);
                Assert.AreSame(exception, e.InnerException);
                Assert.AreSame(exception, e.InnerExceptions.FirstOrDefault());
                return;
            }

            Assert.Fail("Specify.Fail did not throw an AggregateAssertFailedException");
        }

        [Test, NuTest]
        public void FailGivenInnerExceptionsMessageAndArgsShouldThrowAggregateAssertionExceptionWithFormattedMessage()
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
                Assert.StartsWith(e.Message, arg);
                Assert.AreSame(exception, e.InnerException);
                Assert.AreSame(exception, e.InnerExceptions.FirstOrDefault());
                return;
            }

            Assert.Fail("Specify.Fail did not throw an AggregateAssertFailedException");
        }

        [Test, NuTest]
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

        [Test, NuTest]
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

        [Test, NuTest]
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