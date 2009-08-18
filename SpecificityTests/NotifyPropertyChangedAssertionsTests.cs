//-----------------------------------------------------------------------------
// <copyright file="NotifyPropertyChangedAssertionsTests.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Testing.SpecificityTests
{
    using System.ComponentModel;
    using System.Diagnostics.CodeAnalysis;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Testing.Specificity;

    /// <summary>
    /// Provides extension methods for <see cref="NotifyPropertyChangedWatcher"/> assertions.
    /// </summary>
    [TestClass]
    public class NotifyPropertyChangedAssertionsTests
    {
        /// <summary>
        /// Verifies the <see cref="NotifyPropertyChangedWatcher"/> correctly records
        /// raised events.
        /// </summary>
        [TestMethod]
        public void ShouldHaveSeen_GivenWorkingProperty_ShouldNotThrow()
        {
            Tester tester = new Tester();
            PropertyChangedWatcher watcher = new PropertyChangedWatcher(tester);
            tester.Good = 10;
            Specify.ThatAction(delegate
            {
                Specify.That(watcher).ShouldHaveSeen("Good");
            }).ShouldNotHaveThrown();
        }

        /// <summary>
        /// Verifies the <see cref="NotifyPropertyChangedWatcher"/> won't see events
        /// that are raised with the wrong name.
        /// </summary>
        [TestMethod]
        public void ShouldHaveSeen_GivenPropertyThatRaisesWrongName_ShouldThrow()
        {
            Tester tester = new Tester();
            PropertyChangedWatcher watcher = new PropertyChangedWatcher(tester);
            tester.BadName = 10;
            Specify.ThatAction(delegate
            {
                Specify.That(watcher).ShouldHaveSeen("BadName");
            }).ShouldHaveThrown(typeof(ConstraintFailedException));
        }

        /// <summary>
        /// Verifies the <see cref="NotifyPropertyChangedWatcher"/> won't see events
        /// that are not raised.
        /// </summary>
        [TestMethod]
        public void ShouldHaveSeen_GivenPropertyThatDoesNotRaise_ShouldThrow()
        {
            Tester tester = new Tester();
            PropertyChangedWatcher watcher = new PropertyChangedWatcher(tester);
            tester.NoNotification = 10;
            Specify.ThatAction(delegate
            {
                Specify.That(watcher).ShouldHaveSeen("NoNotification");
            }).ShouldHaveThrown(typeof(ConstraintFailedException));
        }

        /// <summary>
        /// A test class that implements <see cref="INotifyPropertyChanged"/>.
        /// </summary>
        private class Tester : INotifyPropertyChanged
        {
            /// <summary>
            /// Occurs when a property value changes.
            /// </summary>
            public event PropertyChangedEventHandler PropertyChanged = delegate { };

            /// <summary>
            /// Sets a property that properly calls
            /// <see cref="INotifyPropertyChanged.PropertyChanged"/>.
            /// </summary>
            /// <value>A dummy value.</value>
            [SuppressMessage("Microsoft.Usage",
                "CA1801:ReviewUnusedParameters",
                MessageId = "value",
                Justification = "This is a contrived test class.")]
            public int Good
            {
                set
                {
                    this.OnPropertyChanged("Good");
                }
            }

            /// <summary>
            /// Sets a property that raises the wrong name in the call to
            /// <see cref="INotifyPropertyChanged.PropertyChanged"/>.
            /// </summary>
            /// <value>A dummy value.</value>
            [SuppressMessage("Microsoft.Usage",
                "CA1801:ReviewUnusedParameters",
                MessageId = "value",
                Justification = "This is a contrived test class.")]
            public int BadName
            {
                set
                {
                    this.OnPropertyChanged("WrongName");
                }
            }

            /// <summary>
            /// Sets a property that fails to call
            /// <see cref="INotifyPropertyChanged.PropertyChanged"/>.
            /// </summary>
            /// <value>A dummy value.</value>
            [SuppressMessage("Microsoft.Usage",
                "CA1801:ReviewUnusedParameters",
                MessageId = "value",
                Justification = "This is a contrived test class.")]
            [SuppressMessage("Microsoft.Performance",
                "CA1822:MarkMembersAsStatic",
                Justification = "This is a contrived test class.")]
            public int NoNotification
            {
                set
                {
                }
            }

            /// <summary>
            /// Called when a property value changes.
            /// </summary>
            /// <param name="propertyName">Name of the property.</param>
            private void OnPropertyChanged(string propertyName)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
