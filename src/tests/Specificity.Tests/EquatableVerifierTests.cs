//-----------------------------------------------------------------------------
// <copyright file="EquatableVerifierTests.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Testing.Specificity.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class EquatableVerifierTests
    {
        [TestMethod]
        public void VerifyForEquatableObjectShouldPass()
        {
            var verifier = new EquatableVerifier<EquatableObject>
            {
                EquivalenceClasses = new EquivalenceClassCollection<EquatableObject>
                {
                    () => new EquatableObject(1),
                    () => new EquatableObject(2),
                    () => new EquatableObject(3)
                }
            };

            verifier.Verify();
        }

        [TestMethod]
        public void VerifyForEquatableObjectWithBadGetHashCodeShouldFail()
        {
            var verifier = new EquatableVerifier<EquatableObject>
            {
                EquivalenceClasses = new EquivalenceClassCollection<EquatableObject>
                {
                    () => new EquatableObject(1) { IsGetHashCodeValid = false },
                    () => new EquatableObject(2) { IsGetHashCodeValid = false },
                    () => new EquatableObject(3) { IsGetHashCodeValid = false }
                }
            };

            Specify.ThatAction(delegate
            {
                verifier.Verify();
            }).Should.HaveThrown(typeof(AggregateAssertFailedException));
        }

        [TestMethod]
        public void VerifyForEquatableObjectWithBadObjectEqualsShouldFail()
        {
            var verifier = new EquatableVerifier<EquatableObject>
            {
                EquivalenceClasses = new EquivalenceClassCollection<EquatableObject>
                {
                    () => new EquatableObject(1) { IsObjectEqualsValid = false },
                    () => new EquatableObject(2) { IsObjectEqualsValid = false },
                    () => new EquatableObject(3) { IsObjectEqualsValid = false }
                }
            };

            Specify.ThatAction(delegate
            {
                verifier.Verify();
            }).Should.HaveThrown(typeof(AggregateAssertFailedException));
        }

        [TestMethod]
        public void VerifyForEquatableObjectWithBadEquatableEqualsShouldFail()
        {
            var verifier = new EquatableVerifier<EquatableObject>
            {
                EquivalenceClasses = new EquivalenceClassCollection<EquatableObject>
                {
                    () => new EquatableObject(1) { IsEquatableEqualsValid = false },
                    () => new EquatableObject(2) { IsEquatableEqualsValid = false },
                    () => new EquatableObject(3) { IsEquatableEqualsValid = false }
                }
            };

            Specify.ThatAction(delegate
            {
                verifier.Verify();
            }).Should.HaveThrown(typeof(AggregateAssertFailedException));
        }

        [TestMethod]
        public void VerifyForEquatableObjectWithBadOperatorNotEqualsShouldFail()
        {
            var verifier = new EquatableVerifier<EquatableObject>
            {
                EquivalenceClasses = new EquivalenceClassCollection<EquatableObject>
                {
                    () => new EquatableObject(1) { IsOperatorNotEqualsValid = false },
                    () => new EquatableObject(2) { IsOperatorNotEqualsValid = false },
                    () => new EquatableObject(3) { IsOperatorNotEqualsValid = false }
                }
            };

            Specify.ThatAction(delegate
            {
                verifier.Verify();
            }).Should.HaveThrown(typeof(AggregateAssertFailedException));
        }

        [TestMethod]
        public void VerifyForEquatableObjectWithBadOperatorqualsShouldFail()
        {
            var verifier = new EquatableVerifier<EquatableObject>
            {
                EquivalenceClasses = new EquivalenceClassCollection<EquatableObject>
                {
                    () => new EquatableObject(1) { IsOperatorEqualsValid = false },
                    () => new EquatableObject(2) { IsOperatorEqualsValid = false },
                    () => new EquatableObject(3) { IsOperatorEqualsValid = false }
                }
            };

            Specify.ThatAction(delegate
            {
                verifier.Verify();
            }).Should.HaveThrown(typeof(AggregateAssertFailedException));
        }

        [TestMethod]
        public void VerifyForUnsealedEquatableObjectShouldFail()
        {
            var verifier = new EquatableVerifier<UnsealedEquatableObject>
            {
                EquivalenceClasses = new EquivalenceClassCollection<UnsealedEquatableObject>
                {
                    () => new UnsealedEquatableObject(1),
                    () => new UnsealedEquatableObject(2),
                    () => new UnsealedEquatableObject(3)
                }
            };

            Specify.ThatAction(delegate
            {
                verifier.Verify();
            }).Should.HaveThrown(typeof(AggregateAssertFailedException));
        }

        [TestMethod]
        public void VerifyForUnsealedEquatableObjectWhenIsSealedSetToFalseShouldPass()
        {
            var verifier = new EquatableVerifier<UnsealedEquatableObject>
            {
                IsSealed = false,
                EquivalenceClasses = new EquivalenceClassCollection<UnsealedEquatableObject>
                {
                    () => new UnsealedEquatableObject(1),
                    () => new UnsealedEquatableObject(2),
                    () => new UnsealedEquatableObject(3)
                }
            };

            verifier.Verify();
        }

        [TestMethod]
        public void VerifyForSansEqualsEquatableObjectShouldFail()
        {
            var verifier = new EquatableVerifier<SansEqualsEquatableObject>
            {
                EquivalenceClasses = new EquivalenceClassCollection<SansEqualsEquatableObject>
                {
                    () => new SansEqualsEquatableObject(1),
                    () => new SansEqualsEquatableObject(2),
                    () => new SansEqualsEquatableObject(3)
                }
            };

            Specify.ThatAction(delegate
            {
                verifier.Verify();
            }).Should.HaveThrown(typeof(AggregateAssertFailedException));
        }

        [TestMethod]
        public void VerifyForSansGetHashCodeEquatableObjectShouldFail()
        {
            var verifier = new EquatableVerifier<SansGetHashCodeEquatableObject>
            {
                EquivalenceClasses = new EquivalenceClassCollection<SansGetHashCodeEquatableObject>
                {
                    () => new SansGetHashCodeEquatableObject(1),
                    () => new SansGetHashCodeEquatableObject(2),
                    () => new SansGetHashCodeEquatableObject(3)
                }
            };

            Specify.ThatAction(delegate
            {
                verifier.Verify();
            }).Should.HaveThrown(typeof(AggregateAssertFailedException));
        }

        [TestMethod]
        public void VerifyForSansOperatorsEquatableObjectShouldFail()
        {
            var verifier = new EquatableVerifier<SansOperatorsEquatableObject>
            {
                EquivalenceClasses = new EquivalenceClassCollection<SansOperatorsEquatableObject>
                {
                    () => new SansOperatorsEquatableObject(1),
                    () => new SansOperatorsEquatableObject(2),
                    () => new SansOperatorsEquatableObject(3)
                }
            };

            Specify.ThatAction(delegate
            {
                verifier.Verify();
            }).Should.HaveThrown(typeof(AggregateAssertFailedException));
        }

        [TestMethod]
        public void VerifyForSansOperatorsEquatableObjectWhenImplementsOperatorOverloadsSetToFalseShouldPass()
        {
            var verifier = new EquatableVerifier<SansOperatorsEquatableObject>
            {
                ImplementsOperatorOverloads = false,
                EquivalenceClasses = new EquivalenceClassCollection<SansOperatorsEquatableObject>
                {
                    () => new SansOperatorsEquatableObject(1),
                    () => new SansOperatorsEquatableObject(2),
                    () => new SansOperatorsEquatableObject(3)
                }
            };

            verifier.Verify();
        }

        private sealed class EquatableObject : IEquatable<EquatableObject>
        {
            private int badHashCode;
            private readonly int value;

            public EquatableObject(int value)
            {
                this.value = value;
                this.IsGetHashCodeValid = true;
                this.IsObjectEqualsValid = true;
                this.IsEquatableEqualsValid = true;
                this.IsOperatorNotEqualsValid = true;
                this.IsOperatorEqualsValid = true;
            }

            public bool IsGetHashCodeValid { get; set; }

            public bool IsObjectEqualsValid { get; set; }

            public bool IsEquatableEqualsValid { get; set; }

            public bool IsOperatorNotEqualsValid { get; set; }

            public bool IsOperatorEqualsValid { get; set; }

            public static bool operator !=(EquatableObject lhs, EquatableObject rhs)
            {
                bool result;
                if (object.ReferenceEquals(lhs, null))
                {
                    result = !object.ReferenceEquals(rhs, null);
                }
                else
                {
                    result = !lhs.Equals(rhs);
                }

                return (lhs ?? rhs).IsOperatorNotEqualsValid ? result : !result;
            }

            public static bool operator ==(EquatableObject lhs, EquatableObject rhs)
            {
                bool result;
                if (object.ReferenceEquals(lhs, null))
                {
                    result = object.ReferenceEquals(rhs, null);
                }
                else
                {
                    result = lhs.Equals(rhs);
                }

                return (lhs ?? rhs).IsOperatorEqualsValid ? result : !result;
            }

            public bool Equals(EquatableObject other)
            {
                var result = !object.ReferenceEquals(other, null) && EqualityComparer<int>.Default.Equals(this.value, other.value);
                return this.IsEquatableEqualsValid ? result : !result;
            }

            public override bool Equals(object obj)
            {
                var result = this.Equals(obj as EquatableObject);
                return this.IsObjectEqualsValid ? result : !result;
            }

            public override int GetHashCode()
            {
                if (!this.IsGetHashCodeValid)
                {
                    return this.badHashCode++;
                }

                return this.value.GetHashCode();
            }

            public override string ToString()
            {
                return this.value.ToString();
            }
        }

        private class UnsealedEquatableObject : IEquatable<UnsealedEquatableObject>
        {
            private readonly int value;

            public UnsealedEquatableObject(int value)
            {
                this.value = value;
            }

            public static bool operator !=(UnsealedEquatableObject lhs, UnsealedEquatableObject rhs)
            {
                if (object.ReferenceEquals(lhs, null))
                {
                    return !object.ReferenceEquals(rhs, null);
                }

                return !lhs.Equals(rhs);
            }

            public static bool operator ==(UnsealedEquatableObject lhs, UnsealedEquatableObject rhs)
            {
                if (object.ReferenceEquals(lhs, null))
                {
                    return object.ReferenceEquals(rhs, null);
                }

                return lhs.Equals(rhs);
            }

            public bool Equals(UnsealedEquatableObject other)
            {
                return other != null && EqualityComparer<int>.Default.Equals(this.value, other.value);
            }

            public override bool Equals(object obj)
            {
                return this.Equals(obj as UnsealedEquatableObject);
            }

            public override int GetHashCode()
            {
                return this.value.GetHashCode();
            }

            public override string ToString()
            {
                return this.value.ToString();
            }
        }

#pragma warning disable 660

        private sealed class SansEqualsEquatableObject : IEquatable<SansEqualsEquatableObject>
        {
            private readonly int value;

            public SansEqualsEquatableObject(int value)
            {
                this.value = value;
            }

            public static bool operator !=(SansEqualsEquatableObject lhs, SansEqualsEquatableObject rhs)
            {
                if (object.ReferenceEquals(lhs, null))
                {
                    return !object.ReferenceEquals(rhs, null);
                }

                return !lhs.Equals(rhs);
            }

            public static bool operator ==(SansEqualsEquatableObject lhs, SansEqualsEquatableObject rhs)
            {
                if (object.ReferenceEquals(lhs, null))
                {
                    return object.ReferenceEquals(rhs, null);
                }

                return lhs.Equals(rhs);
            }

            public bool Equals(SansEqualsEquatableObject other)
            {
                return other != null && EqualityComparer<int>.Default.Equals(this.value, other.value);
            }

            public override int GetHashCode()
            {
                return this.value.GetHashCode();
            }

            public override string ToString()
            {
                return this.value.ToString();
            }
        }

#pragma warning restore 660

#pragma warning disable 659,661

        private sealed class SansGetHashCodeEquatableObject : IEquatable<SansGetHashCodeEquatableObject>
        {
            private readonly int value;

            public SansGetHashCodeEquatableObject(int value)
            {
                this.value = value;
            }

            public static bool operator !=(SansGetHashCodeEquatableObject lhs, SansGetHashCodeEquatableObject rhs)
            {
                if (object.ReferenceEquals(lhs, null))
                {
                    return !object.ReferenceEquals(rhs, null);
                }

                return !lhs.Equals(rhs);
            }

            public static bool operator ==(SansGetHashCodeEquatableObject lhs, SansGetHashCodeEquatableObject rhs)
            {
                if (object.ReferenceEquals(lhs, null))
                {
                    return object.ReferenceEquals(rhs, null);
                }

                return lhs.Equals(rhs);
            }

            public bool Equals(SansGetHashCodeEquatableObject other)
            {
                return other != null && EqualityComparer<int>.Default.Equals(this.value, other.value);
            }

            public override bool Equals(object obj)
            {
                return this.Equals(obj as SansGetHashCodeEquatableObject);
            }

            public override string ToString()
            {
                return this.value.ToString();
            }
        }

#pragma warning restore 659,661

        // It's an error to define only one of == and !=, so we need only one test type and one test.
        private sealed class SansOperatorsEquatableObject : IEquatable<SansOperatorsEquatableObject>
        {
            private readonly int value;

            public SansOperatorsEquatableObject(int value)
            {
                this.value = value;
            }

            public bool Equals(SansOperatorsEquatableObject other)
            {
                return other != null && EqualityComparer<int>.Default.Equals(this.value, other.value);
            }

            public override bool Equals(object obj)
            {
                return this.Equals(obj as SansOperatorsEquatableObject);
            }

            public override int GetHashCode()
            {
                return this.value.GetHashCode();
            }

            public override string ToString()
            {
                return this.value.ToString();
            }
        }
    }
}