//-----------------------------------------------------------------------------
// <copyright file="ActionConstraintsTests.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Testing.Specificity2.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ActionConstraintsTests
    {
        [TestMethod]
        public void HaveThrownForActionThatDoesNotThrowGivenExceptionTypeAndMessageShouldFail()
        {
            string message = "xyzzy";
            try
            {
                Specify.ThatAction(delegate
                {
                }).Should.HaveThrown(typeof(InvalidOperationException), message);
            }
            catch (AssertFailedException e)
            {
                StringAssert.EndsWith(e.Message, message);
                return;
            }

            Specify.Failure("Specification did not fail.");
        }

        [TestMethod]
        public void HaveThrownForActionThatDoesNotThrowGivenExceptionTypeMessageAndArgsShouldFail()
        {
            string message = "{0}";
            string arg = "xyzzy";
            try
            {
                Specify.ThatAction(delegate
                {
                }).Should.HaveThrown(typeof(InvalidOperationException), message, arg);
            }
            catch (AssertFailedException e)
            {
                StringAssert.EndsWith(e.Message, arg);
                return;
            }

            Specify.Failure("Specification did not fail.");
        }

        [TestMethod]
        public void HaveThrownForActionThatDoesNotThrowGivenExceptionTypeThrowShouldFail()
        {
            try
            {
                Specify.ThatAction(delegate
                {
                }).Should.HaveThrown(typeof(InvalidOperationException));
            }
            catch (AssertFailedException)
            {
                return;
            }

            Specify.Failure("Specification did not fail.");
        }

        [TestMethod]
        public void HaveThrownForActionThatDoesNotThrowGivenMessageAndArgsShouldFail()
        {
            string message = "{0}";
            string arg = "xyzzy";
            try
            {
                Specify.ThatAction(delegate
                {
                }).Should.HaveThrown(message, arg);
            }
            catch (AssertFailedException e)
            {
                StringAssert.EndsWith(e.Message, arg);
                return;
            }

            Specify.Failure("Specification did not fail.");
        }

        [TestMethod]
        public void HaveThrownForActionThatDoesNotThrowGivenMessageShouldFail()
        {
            string message = "xyzzy";
            try
            {
                Specify.ThatAction(delegate
                {
                }).Should.HaveThrown(message);
            }
            catch (AssertFailedException e)
            {
                StringAssert.EndsWith(e.Message, message);
                return;
            }

            Specify.Failure("Specification did not fail.");
        }

        [TestMethod]
        public void HaveThrownForActionThatDoesNotThrowShouldFail()
        {
            try
            {
                Specify.ThatAction(delegate
                {
                }).Should.HaveThrown();
            }
            catch (AssertFailedException)
            {
                return;
            }

            Specify.Failure("Specification did not fail.");
        }

        [TestMethod]
        public void HaveThrownForActionThatThrowsGivenExpectedExceptionTypeAndMessageShouldFail()
        {
            string message = "xyzzy";
            Specify.ThatAction(delegate
            {
                throw new InvalidOperationException();
            }).Should.HaveThrown(typeof(InvalidOperationException), message);
        }

        [TestMethod]
        public void HaveThrownForActionThatThrowsGivenExpectedExceptionTypeMessageAndArgsShouldNotFail()
        {
            string message = "{0}";
            string arg = "xyzzy";
            Specify.ThatAction(delegate
            {
                throw new InvalidOperationException();
            }).Should.HaveThrown(typeof(InvalidOperationException), message, arg);
        }

        [TestMethod]
        public void HaveThrownForActionThatThrowsGivenExpectedExceptionTypeThrowShouldNotFail()
        {
            Specify.ThatAction(delegate
            {
                throw new InvalidOperationException();
            }).Should.HaveThrown(typeof(InvalidOperationException));
        }

        [TestMethod]
        public void HaveThrownForActionThatThrowsGivenMessageAndArgsShouldNotFail()
        {
            string message = "{0}";
            string arg = "xyzzy";
            Specify.ThatAction(delegate
            {
                throw new InvalidOperationException();
            }).Should.HaveThrown(message, arg);
        }

        [TestMethod]
        public void HaveThrownForActionThatThrowsGivenMessageShouldNotFail()
        {
            string message = "xyzzy";
            Specify.ThatAction(delegate
            {
                throw new InvalidOperationException();
            }).Should.HaveThrown(message);
        }

        [TestMethod]
        public void HaveThrownForActionThatThrowsGivenUnexpectedExceptionTypeAndMessageShouldFail()
        {
            string message = "xyzzy";
            try
            {
                Specify.ThatAction(delegate
                {
                    throw new ArgumentException();
                }).Should.HaveThrown(typeof(InvalidOperationException), message);
            }
            catch (AssertFailedException e)
            {
                StringAssert.EndsWith(e.Message, message);
                return;
            }

            Specify.Failure("Specification did not fail.");
        }

        [TestMethod]
        public void HaveThrownForActionThatThrowsGivenUnexpectedExceptionTypeMessageAndArgsShouldFail()
        {
            string message = "{0}";
            string arg = "xyzzy";
            try
            {
                Specify.ThatAction(delegate
                {
                    throw new ArgumentException();
                }).Should.HaveThrown(typeof(InvalidOperationException), message, arg);
            }
            catch (AssertFailedException e)
            {
                StringAssert.EndsWith(e.Message, arg);
                return;
            }

            Specify.Failure("Specification did not fail.");
        }

        [TestMethod]
        public void HaveThrownForActionThatThrowsGivenUnexpectedExceptionTypeThrowShouldFail()
        {
            try
            {
                Specify.ThatAction(delegate
                {
                    throw new ArgumentException();
                }).Should.HaveThrown(typeof(InvalidOperationException));
            }
            catch (AssertFailedException)
            {
                return;
            }

            Specify.Failure("Specification did not fail.");
        }

        [TestMethod]
        public void HaveThrownForActionThatThrowsShouldNotFail()
        {
            Specify.ThatAction(delegate
            {
                throw new InvalidOperationException();
            }).Should.HaveThrown();
        }

        [TestMethod]
        public void HaveThrownNegatedForActionThatDoesNotThrowGivenMessageAndArgsShouldNotFail()
        {
            string message = "{0}";
            string arg = "xyzzy";
            Specify.ThatAction(delegate
            {
            }).Should.Not.HaveThrown(message, arg);
        }

        [TestMethod]
        public void HaveThrownNegatedForActionThatDoesNotThrowGivenMessageShouldNotFail()
        {
            string message = "xyzzy";
            Specify.ThatAction(delegate
            {
            }).Should.Not.HaveThrown(message);
        }

        [TestMethod]
        public void HaveThrownNegatedForActionThatDoesNotThrowShouldNotFail()
        {
            Specify.ThatAction(delegate
            {
            }).Should.Not.HaveThrown();
        }

        [TestMethod]
        public void HaveThrownNegatedForActionThatThrowsGivenExpectedExceptionTypeAndMessageShouldFail()
        {
            string message = "xyzzy";
            try
            {
                Specify.ThatAction(delegate
                {
                    throw new InvalidOperationException();
                }).Should.Not.HaveThrown(typeof(InvalidOperationException), message);
            }
            catch (AssertFailedException e)
            {
                StringAssert.EndsWith(e.Message, message);
                return;
            }

            Specify.Failure("Specification did not fail.");
        }

        [TestMethod]
        public void HaveThrownNegatedForActionThatThrowsGivenExpectedExceptionTypeMessageAndArgsShouldFail()
        {
            string message = "{0}";
            string arg = "xyzzy";
            try
            {
                Specify.ThatAction(delegate
                {
                    throw new InvalidOperationException();
                }).Should.Not.HaveThrown(typeof(InvalidOperationException), message, arg);
            }
            catch (AssertFailedException e)
            {
                StringAssert.EndsWith(e.Message, arg);
                return;
            }

            Specify.Failure("Specification did not fail.");
        }

        [TestMethod]
        public void HaveThrownNegatedForActionThatThrowsGivenExpectedExceptionTypeThrowShouldFail()
        {
            try
            {
                Specify.ThatAction(delegate
                {
                    throw new InvalidOperationException();
                }).Should.Not.HaveThrown(typeof(InvalidOperationException));
            }
            catch (AssertFailedException)
            {
                return;
            }

            Specify.Failure("Specification did not fail.");
        }

        [TestMethod]
        public void HaveThrownNegatedForActionThatThrowsGivenMessageAndArgsShouldFail()
        {
            string message = "{0}";
            string arg = "xyzzy";
            try
            {
                Specify.ThatAction(delegate
                {
                    throw new InvalidOperationException();
                }).Should.Not.HaveThrown(message, arg);
            }
            catch (AssertFailedException e)
            {
                StringAssert.EndsWith(e.Message, arg);
                return;
            }

            Specify.Failure("Specification did not fail.");
        }

        [TestMethod]
        public void HaveThrownNegatedForActionThatThrowsGivenMessageShouldFail()
        {
            string message = "xyzzy";
            try
            {
                Specify.ThatAction(delegate
                {
                    throw new InvalidOperationException();
                }).Should.Not.HaveThrown(message);
            }
            catch (AssertFailedException e)
            {
                StringAssert.EndsWith(e.Message, message);
                return;
            }

            Specify.Failure("Specification did not fail.");
        }

        [TestMethod]
        public void HaveThrownNegatedForActionThatThrowsGivenUnexpectedExceptionTypeAndMessageShouldFail()
        {
            string message = "xyzzy";
            Specify.ThatAction(delegate
            {
                throw new ArgumentException();
            }).Should.Not.HaveThrown(typeof(InvalidOperationException), message);
        }

        [TestMethod]
        public void HaveThrownNegatedForActionThatThrowsGivenUnexpectedExceptionTypeMessageAndArgsShouldNotFail()
        {
            string message = "{0}";
            string arg = "xyzzy";
            Specify.ThatAction(delegate
            {
                throw new ArgumentException();
            }).Should.Not.HaveThrown(typeof(InvalidOperationException), message, arg);
        }

        [TestMethod]
        public void HaveThrownNegatedForActionThatThrowsGivenUnexpectedExceptionTypeThrowShouldNotFail()
        {
            Specify.ThatAction(delegate
            {
                throw new ArgumentException();
            }).Should.Not.HaveThrown(typeof(InvalidOperationException));
        }

        [TestMethod]
        public void HaveThrownNegatedForActionThatThrowsShouldFail()
        {
            try
            {
                Specify.ThatAction(delegate
                {
                    throw new InvalidOperationException();
                }).Should.Not.HaveThrown();
            }
            catch (AssertFailedException)
            {
                return;
            }

            Specify.Failure("Specification did not fail.");
        }
    }
}