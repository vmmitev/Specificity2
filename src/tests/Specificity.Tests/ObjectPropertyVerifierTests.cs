//-----------------------------------------------------------------------------
// <copyright file="ObjectPropertyVerifierTests.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Testing.Specificity.Tests
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ObjectPropertyVerifierTests
    {
        [TestMethod]
        public void VerifyForSimpleObjectShouldPass()
        {
            var verifier = new ObjectPropertyVerifier<SimpleObject>(SimpleObject.CreateValid());

            verifier.Verify();
        }

        [TestMethod]
        public void VerifyForSimpleObjectWhenNotUsingValidSettersShouldFail()
        {
            var verifier = new ObjectPropertyVerifier<SimpleObject>(SimpleObject.CreateInvalid());

            Specify.ThatAction(delegate
            {
                verifier.Verify();
            }).Should.HaveThrown(typeof(AggregateAssertFailedException));
        }

        [TestMethod]
        public void VerifyForObservableObjectShouldPass()
        {
            var verifier = new ObjectPropertyVerifier<ObservableObject>(ObservableObject.CreateValid());

            verifier.Verify();
        }

        [TestMethod]
        public void VerifyForObservableObjectThatDoesNotNotifyShouldFail()
        {
            var verifier = new ObjectPropertyVerifier<ObservableObject>(ObservableObject.CreateWithOutNotifications());

            Specify.ThatAction(delegate
            {
                verifier.Verify();
            }).Should.HaveThrown(typeof(AggregateAssertFailedException));
        }

        private class ObservableObject : INotifyPropertyChanged
        {
            private int age;
            private string name;
            private bool shouldNotify;

            private ObservableObject(bool shouldNotify)
            {
                this.shouldNotify = shouldNotify;
            }

            public event PropertyChangedEventHandler PropertyChanged;

            public int Age
            {
                get { return this.age; }
                set { this.SetValue(ref this.age, value); }
            }

            public string Name
            {
                get { return this.name; }

                set { this.SetValue(ref this.name, value); }
            }

            public static ObservableObject CreateValid()
            {
                return new ObservableObject(true);
            }

            public static ObservableObject CreateWithOutNotifications()
            {
                return new ObservableObject(false);
            }

            private bool SetValue<T>(ref T backingField, T value, [CallerMemberName]string propertyName = null)
            {
                if (!EqualityComparer<T>.Default.Equals(backingField, value))
                {
                    backingField = value;
                    if (this.shouldNotify)
                    {
                        var handler = this.PropertyChanged;
                        if (handler != null)
                        {
                            handler(this, new PropertyChangedEventArgs(propertyName));
                        }
                    }

                    return true;
                }

                return false;
            }
        }

        private class SimpleObject
        {
            private int age;
            private string name;
            private bool useValidSetters;

            private SimpleObject(bool useValidSetters)
            {
                this.useValidSetters = useValidSetters;
            }

            public int Age
            {
                get
                {
                    return this.age;
                }

                set
                {
                    if (this.useValidSetters)
                    {
                        this.age = value;
                    }
                }
            }

            public string Name
            {
                get
                {
                    return this.name;
                }

                set
                {
                    if (this.useValidSetters)
                    {
                        this.name = value;
                    }
                }
            }

            public static SimpleObject CreateInvalid()
            {
                return new SimpleObject(false);
            }

            public static SimpleObject CreateValid()
            {
                return new SimpleObject(true);
            }
        }
    }
}