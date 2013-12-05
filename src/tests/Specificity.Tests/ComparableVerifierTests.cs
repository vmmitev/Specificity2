//-----------------------------------------------------------------------------
// <copyright file="ComparableVerifierTests.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Testing.Specificity.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ComparableVerifierTests
    {
        [TestMethod]
        public void VerifyForComparableObjectShouldPass()
        {
            var verifier = new ComparableVerifier<ComparableObject>
            {
                EquivalenceClasses = new EquivalenceClassCollection<ComparableObject>
                {
                    () => new ComparableObject(1),
                    () => new ComparableObject(2),
                    () => new ComparableObject(3)
                }
            };

            verifier.Verify();
        }

        [TestMethod]
        public void VerifyForComparableObjectWithBadEquatableEqualsShouldFail()
        {
            var verifier = new EquatableVerifier<ComparableObject>
            {
                EquivalenceClasses = new EquivalenceClassCollection<ComparableObject>
                {
                    () => new ComparableObject(1) { IsEquatableEqualsValid = false },
                    () => new ComparableObject(2) { IsEquatableEqualsValid = false },
                    () => new ComparableObject(3) { IsEquatableEqualsValid = false }
                }
            };

            Specify.ThatAction(delegate
            {
                verifier.Verify();
            }).Should.HaveThrown(typeof(AggregateAssertFailedException));
        }

        [TestMethod]
        public void VerifyForComparableObjectWithBadGetHashCodeShouldFail()
        {
            var verifier = new EquatableVerifier<ComparableObject>
            {
                EquivalenceClasses = new EquivalenceClassCollection<ComparableObject>
                {
                    () => new ComparableObject(1) { IsGetHashCodeValid = false },
                    () => new ComparableObject(2) { IsGetHashCodeValid = false },
                    () => new ComparableObject(3) { IsGetHashCodeValid = false }
                }
            };

            Specify.ThatAction(delegate
            {
                verifier.Verify();
            }).Should.HaveThrown(typeof(AggregateAssertFailedException));
        }

        [TestMethod]
        public void VerifyForComparableObjectWithBadObjectEqualsShouldFail()
        {
            var verifier = new EquatableVerifier<ComparableObject>
            {
                EquivalenceClasses = new EquivalenceClassCollection<ComparableObject>
                {
                    () => new ComparableObject(1) { IsObjectEqualsValid = false },
                    () => new ComparableObject(2) { IsObjectEqualsValid = false },
                    () => new ComparableObject(3) { IsObjectEqualsValid = false }
                }
            };

            Specify.ThatAction(delegate
            {
                verifier.Verify();
            }).Should.HaveThrown(typeof(AggregateAssertFailedException));
        }

        [TestMethod]
        public void VerifyForComparableObjectWithBadGenericCompareToShouldFail()
        {
            var verifier = new ComparableVerifier<ComparableObject>
            {
                EquivalenceClasses = new EquivalenceClassCollection<ComparableObject>
                {
                    () => new ComparableObject(1) { IsGenericCompareToValid = false },
                    () => new ComparableObject(2) { IsGenericCompareToValid = false },
                    () => new ComparableObject(3) { IsGenericCompareToValid = false }
                }
            };

            Specify.ThatAction(delegate
            {
                verifier.Verify();
            }).Should.HaveThrown(typeof(AggregateAssertFailedException));
        }

        [TestMethod]
        public void VerifyForComparableObjectWithBadCompareToShouldFail()
        {
            var verifier = new ComparableVerifier<ComparableObject>
            {
                EquivalenceClasses = new EquivalenceClassCollection<ComparableObject>
                {
                    () => new ComparableObject(1) { IsCompareToValid = false },
                    () => new ComparableObject(2) { IsCompareToValid = false },
                    () => new ComparableObject(3) { IsCompareToValid = false }
                }
            };

            Specify.ThatAction(delegate
            {
                verifier.Verify();
            }).Should.HaveThrown(typeof(AggregateAssertFailedException));
        }

        [TestMethod]
        public void VerifyForComparableObjectWithBadOperatorNotEqualsShouldFail()
        {
            var verifier = new ComparableVerifier<ComparableObject>
            {
                EquivalenceClasses = new EquivalenceClassCollection<ComparableObject>
                {
                    () => new ComparableObject(1) { IsOperatorNotEqualsValid = false },
                    () => new ComparableObject(2) { IsOperatorNotEqualsValid = false },
                    () => new ComparableObject(3) { IsOperatorNotEqualsValid = false }
                }
            };

            Specify.ThatAction(delegate
            {
                verifier.Verify();
            }).Should.HaveThrown(typeof(AggregateAssertFailedException));
        }

        [TestMethod]
        public void VerifyForComparableObjectWithBadOperatorEqualsShouldFail()
        {
            var verifier = new ComparableVerifier<ComparableObject>
            {
                EquivalenceClasses = new EquivalenceClassCollection<ComparableObject>
                {
                    () => new ComparableObject(1) { IsOperatorEqualsValid = false },
                    () => new ComparableObject(2) { IsOperatorEqualsValid = false },
                    () => new ComparableObject(3) { IsOperatorEqualsValid = false }
                }
            };

            Specify.ThatAction(delegate
            {
                verifier.Verify();
            }).Should.HaveThrown(typeof(AggregateAssertFailedException));
        }

        [TestMethod]
        public void VerifyForComparableObjectWithBadOperatorLessThanShouldFail()
        {
            var verifier = new ComparableVerifier<ComparableObject>
            {
                EquivalenceClasses = new EquivalenceClassCollection<ComparableObject>
                {
                    () => new ComparableObject(1) { IsOperatorLessThanValid = false },
                    () => new ComparableObject(2) { IsOperatorLessThanValid = false },
                    () => new ComparableObject(3) { IsOperatorLessThanValid = false }
                }
            };

            Specify.ThatAction(delegate
            {
                verifier.Verify();
            }).Should.HaveThrown(typeof(AggregateAssertFailedException));
        }

        [TestMethod]
        public void VerifyForComparableObjectWithBadOperatorGreaterThanShouldFail()
        {
            var verifier = new ComparableVerifier<ComparableObject>
            {
                EquivalenceClasses = new EquivalenceClassCollection<ComparableObject>
                {
                    () => new ComparableObject(1) { IsOperatorGreaterThanValid = false },
                    () => new ComparableObject(2) { IsOperatorGreaterThanValid = false },
                    () => new ComparableObject(3) { IsOperatorGreaterThanValid = false }
                }
            };

            Specify.ThatAction(delegate
            {
                verifier.Verify();
            }).Should.HaveThrown(typeof(AggregateAssertFailedException));
        }

        [TestMethod]
        public void VerifyForComparableObjectWithBadOperatorLessThanOrEqualShouldFail()
        {
            var verifier = new ComparableVerifier<ComparableObject>
            {
                EquivalenceClasses = new EquivalenceClassCollection<ComparableObject>
                {
                    () => new ComparableObject(1) { IsOperatorLessThanOrEqualValid = false },
                    () => new ComparableObject(2) { IsOperatorLessThanOrEqualValid = false },
                    () => new ComparableObject(3) { IsOperatorLessThanOrEqualValid = false }
                }
            };

            Specify.ThatAction(delegate
            {
                verifier.Verify();
            }).Should.HaveThrown(typeof(AggregateAssertFailedException));
        }

        [TestMethod]
        public void VerifyForComparableObjectWithBadOperatorGreaterThanOrEqualShouldFail()
        {
            var verifier = new ComparableVerifier<ComparableObject>
            {
                EquivalenceClasses = new EquivalenceClassCollection<ComparableObject>
                {
                    () => new ComparableObject(1) { IsOperatorGreaterThanOrEqualValid = false },
                    () => new ComparableObject(2) { IsOperatorGreaterThanOrEqualValid = false },
                    () => new ComparableObject(3) { IsOperatorGreaterThanOrEqualValid = false }
                }
            };

            Specify.ThatAction(delegate
            {
                verifier.Verify();
            }).Should.HaveThrown(typeof(AggregateAssertFailedException));
        }

        [TestMethod]
        public void VerifyForSansEqualsComparableObjectShouldFail()
        {
            var verifier = new EquatableVerifier<SansEqualsComparableObject>
            {
                EquivalenceClasses = new EquivalenceClassCollection<SansEqualsComparableObject>
                {
                    () => new SansEqualsComparableObject(1),
                    () => new SansEqualsComparableObject(2),
                    () => new SansEqualsComparableObject(3)
                }
            };

            Specify.ThatAction(delegate
            {
                verifier.Verify();
            }).Should.HaveThrown(typeof(AggregateAssertFailedException));
        }

        [TestMethod]
        public void VerifyForSansGetHashCodeComparableObjectShouldFail()
        {
            var verifier = new EquatableVerifier<SansGetHashCodeComparableObject>
            {
                EquivalenceClasses = new EquivalenceClassCollection<SansGetHashCodeComparableObject>
                {
                    () => new SansGetHashCodeComparableObject(1),
                    () => new SansGetHashCodeComparableObject(2),
                    () => new SansGetHashCodeComparableObject(3)
                }
            };

            Specify.ThatAction(delegate
            {
                verifier.Verify();
            }).Should.HaveThrown(typeof(AggregateAssertFailedException));
        }

        [TestMethod]
        public void VerifyForSansOperatorsComparableObjectShouldFail()
        {
            var verifier = new EquatableVerifier<SansOperatorsComparableObject>
            {
                EquivalenceClasses = new EquivalenceClassCollection<SansOperatorsComparableObject>
                {
                    () => new SansOperatorsComparableObject(1),
                    () => new SansOperatorsComparableObject(2),
                    () => new SansOperatorsComparableObject(3)
                }
            };

            Specify.ThatAction(delegate
            {
                verifier.Verify();
            }).Should.HaveThrown(typeof(AggregateAssertFailedException));
        }

        [TestMethod]
        public void VerifyForSansOperatorsComparableObjectWhenImplementsOperatorOverloadsSetToFalseShouldPass()
        {
            var verifier = new EquatableVerifier<SansOperatorsComparableObject>
            {
                ImplementsOperatorOverloads = false,
                EquivalenceClasses = new EquivalenceClassCollection<SansOperatorsComparableObject>
                {
                    () => new SansOperatorsComparableObject(1),
                    () => new SansOperatorsComparableObject(2),
                    () => new SansOperatorsComparableObject(3)
                }
            };

            verifier.Verify();
        }

        [TestMethod]
        public void VerifyForUnsealedComparableObjectShouldFail()
        {
            var verifier = new EquatableVerifier<UnsealedComparableObject>
            {
                EquivalenceClasses = new EquivalenceClassCollection<UnsealedComparableObject>
                {
                    () => new UnsealedComparableObject(1),
                    () => new UnsealedComparableObject(2),
                    () => new UnsealedComparableObject(3)
                }
            };

            Specify.ThatAction(delegate
            {
                verifier.Verify();
            }).Should.HaveThrown(typeof(AggregateAssertFailedException));
        }

        [TestMethod]
        public void VerifyForUnsealedComparableObjectWhenIsSealedSetToFalseShouldPass()
        {
            var verifier = new EquatableVerifier<UnsealedComparableObject>
            {
                IsSealed = false,
                EquivalenceClasses = new EquivalenceClassCollection<UnsealedComparableObject>
                {
                    () => new UnsealedComparableObject(1),
                    () => new UnsealedComparableObject(2),
                    () => new UnsealedComparableObject(3)
                }
            };

            verifier.Verify();
        }

        #region Test Helpers

#pragma warning disable 660,659,661

        private sealed class ComparableObject : IEquatable<ComparableObject>, IComparable<ComparableObject>, IComparable
        {
            private readonly int value;
            private int badHashCode;

            public ComparableObject(int value)
            {
                this.value = value;
                this.IsGetHashCodeValid = true;
                this.IsObjectEqualsValid = true;
                this.IsCompareToValid = true;
                this.IsGenericCompareToValid = true;
                this.IsEquatableEqualsValid = true;
                this.IsOperatorNotEqualsValid = true;
                this.IsOperatorEqualsValid = true;
                this.IsOperatorLessThanValid = true;
                this.IsOperatorGreaterThanValid = true;
                this.IsOperatorLessThanOrEqualValid = true;
                this.IsOperatorGreaterThanOrEqualValid = true;
            }

            public bool IsEquatableEqualsValid { get; set; }

            public bool IsGenericCompareToValid { get; set; }

            public bool IsCompareToValid { get; set; }

            public bool IsGetHashCodeValid { get; set; }

            public bool IsObjectEqualsValid { get; set; }

            public bool IsOperatorEqualsValid { get; set; }

            public bool IsOperatorNotEqualsValid { get; set; }

            public bool IsOperatorLessThanValid { get; set; }

            public bool IsOperatorGreaterThanValid { get; set; }

            public bool IsOperatorLessThanOrEqualValid { get; set; }

            public bool IsOperatorGreaterThanOrEqualValid { get; set; }

            public static bool operator !=(ComparableObject lhs, ComparableObject rhs)
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

            public static bool operator ==(ComparableObject lhs, ComparableObject rhs)
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

            public static bool operator <(ComparableObject lhs, ComparableObject rhs)
            {
                bool result = Compare(lhs, rhs) < 0;
                return (lhs ?? rhs).IsOperatorLessThanValid ? result : !result;
            }

            public static bool operator <=(ComparableObject lhs, ComparableObject rhs)
            {
                bool result = Compare(lhs, rhs) <= 0;
                return (lhs ?? rhs).IsOperatorLessThanOrEqualValid ? result : !result;
            }

            public static bool operator >(ComparableObject lhs, ComparableObject rhs)
            {
                bool result = Compare(lhs, rhs) > 0;
                return (lhs ?? rhs).IsOperatorGreaterThanValid ? result : !result;
            }

            public static bool operator >=(ComparableObject lhs, ComparableObject rhs)
            {
                bool result = Compare(lhs, rhs) >= 0;
                return (lhs ?? rhs).IsOperatorGreaterThanOrEqualValid ? result : !result;
            }

            public bool Equals(ComparableObject other)
            {
                var result = Compare(this, other) == 0;
                return this.IsEquatableEqualsValid ? result : !result;
            }

            public int CompareTo(ComparableObject other)
            {
                int result = Compare(this, other);
                return this.IsGenericCompareToValid ? result : (result == 0 ? -1 : -result);
            }

            public int CompareTo(object obj)
            {
                int result = Compare(this, obj as ComparableObject);
                return this.IsCompareToValid ? result : (result == 0 ? -1 : -result);
            }

            public override bool Equals(object obj)
            {
                var result = this.Equals(obj as ComparableObject);
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

            private static int Compare(ComparableObject first, ComparableObject second)
            {
                var firstIsNull = object.ReferenceEquals(first, null);
                var secondIsNull = object.ReferenceEquals(second, null);
                if (firstIsNull)
                {
                    return secondIsNull ? 0 : -1;
                }
                else if (secondIsNull)
                {
                    return 1;
                }

                return Comparer<int>.Default.Compare(first.value, second.value);
            }
        }

        private sealed class SansEqualsComparableObject : IEquatable<SansEqualsComparableObject>, IComparable<SansEqualsComparableObject>, IComparable
        {
            private readonly int value;

            public SansEqualsComparableObject(int value)
            {
                this.value = value;
            }

            public static bool operator !=(SansEqualsComparableObject lhs, SansEqualsComparableObject rhs)
            {
                return Compare(lhs, rhs) != 0;
            }

            public static bool operator ==(SansEqualsComparableObject lhs, SansEqualsComparableObject rhs)
            {
                return Compare(lhs, rhs) == 0;
            }

            public static bool operator <(SansEqualsComparableObject lhs, SansEqualsComparableObject rhs)
            {
                return Compare(lhs, rhs) < 0;
            }

            public static bool operator <=(SansEqualsComparableObject lhs, SansEqualsComparableObject rhs)
            {
                return Compare(lhs, rhs) <= 0;
            }

            public static bool operator >(SansEqualsComparableObject lhs, SansEqualsComparableObject rhs)
            {
                return Compare(lhs, rhs) > 0;
            }

            public static bool operator >=(SansEqualsComparableObject lhs, SansEqualsComparableObject rhs)
            {
                return Compare(lhs, rhs) >= 0;
            }

            public bool Equals(SansEqualsComparableObject other)
            {
                return Compare(this, other) == 0;
            }

            public int CompareTo(SansEqualsComparableObject other)
            {
                return Compare(this, other);
            }

            public int CompareTo(object obj)
            {
                return this.CompareTo(obj as SansEqualsComparableObject);
            }

            ////public override bool Equals(object obj)
            ////{
            ////    return this.Equals(obj as SansEqualsComparableObject);
            ////}

            public override int GetHashCode()
            {
                return this.value.GetHashCode();
            }

            public override string ToString()
            {
                return this.value.ToString();
            }

            private static int Compare(SansEqualsComparableObject first, SansEqualsComparableObject second)
            {
                var firstIsNull = object.ReferenceEquals(first, null);
                var secondIsNull = object.ReferenceEquals(second, null);
                if (firstIsNull)
                {
                    return secondIsNull ? 0 : -1;
                }
                else if (secondIsNull)
                {
                    return 1;
                }

                return Comparer<int>.Default.Compare(first.value, second.value);
            }
        }

        private sealed class SansGetHashCodeComparableObject : IEquatable<SansGetHashCodeComparableObject>, IComparable<SansGetHashCodeComparableObject>, IComparable
        {
            private readonly int value;

            public SansGetHashCodeComparableObject(int value)
            {
                this.value = value;
            }

            public static bool operator !=(SansGetHashCodeComparableObject lhs, SansGetHashCodeComparableObject rhs)
            {
                return Compare(lhs, rhs) != 0;
            }

            public static bool operator ==(SansGetHashCodeComparableObject lhs, SansGetHashCodeComparableObject rhs)
            {
                return Compare(lhs, rhs) == 0;
            }

            public static bool operator <(SansGetHashCodeComparableObject lhs, SansGetHashCodeComparableObject rhs)
            {
                return Compare(lhs, rhs) < 0;
            }

            public static bool operator <=(SansGetHashCodeComparableObject lhs, SansGetHashCodeComparableObject rhs)
            {
                return Compare(lhs, rhs) <= 0;
            }

            public static bool operator >(SansGetHashCodeComparableObject lhs, SansGetHashCodeComparableObject rhs)
            {
                return Compare(lhs, rhs) > 0;
            }

            public static bool operator >=(SansGetHashCodeComparableObject lhs, SansGetHashCodeComparableObject rhs)
            {
                return Compare(lhs, rhs) >= 0;
            }

            public bool Equals(SansGetHashCodeComparableObject other)
            {
                return Compare(this, other) == 0;
            }

            public int CompareTo(SansGetHashCodeComparableObject other)
            {
                return Compare(this, other);
            }

            public int CompareTo(object obj)
            {
                return this.CompareTo(obj as SansGetHashCodeComparableObject);
            }

            public override bool Equals(object obj)
            {
                return this.Equals(obj as SansGetHashCodeComparableObject);
            }

            ////public override int GetHashCode()
            ////{
            ////    return this.value.GetHashCode();
            ////}

            public override string ToString()
            {
                return this.value.ToString();
            }

            private static int Compare(SansGetHashCodeComparableObject first, SansGetHashCodeComparableObject second)
            {
                var firstIsNull = object.ReferenceEquals(first, null);
                var secondIsNull = object.ReferenceEquals(second, null);
                if (firstIsNull)
                {
                    return secondIsNull ? 0 : -1;
                }
                else if (secondIsNull)
                {
                    return 1;
                }

                return Comparer<int>.Default.Compare(first.value, second.value);
            }
        }

        private sealed class SansOperatorsComparableObject : IEquatable<SansOperatorsComparableObject>, IComparable<SansOperatorsComparableObject>, IComparable
        {
            private readonly int value;

            public SansOperatorsComparableObject(int value)
            {
                this.value = value;
            }

            ////public static bool operator !=(SansOperatorsComparableObject lhs, SansOperatorsComparableObject rhs)
            ////{
            ////    return Compare(lhs, rhs) != 0;
            ////}

            ////public static bool operator ==(SansOperatorsComparableObject lhs, SansOperatorsComparableObject rhs)
            ////{
            ////    return Compare(lhs, rhs) == 0;
            ////}

            ////public static bool operator <(SansOperatorsComparableObject lhs, SansOperatorsComparableObject rhs)
            ////{
            ////    return Compare(lhs, rhs) < 0;
            ////}

            ////public static bool operator <=(SansOperatorsComparableObject lhs, SansOperatorsComparableObject rhs)
            ////{
            ////    return Compare(lhs, rhs) <= 0;
            ////}

            ////public static bool operator >(SansOperatorsComparableObject lhs, SansOperatorsComparableObject rhs)
            ////{
            ////    return Compare(lhs, rhs) > 0;
            ////}

            ////public static bool operator >=(SansOperatorsComparableObject lhs, SansOperatorsComparableObject rhs)
            ////{
            ////    return Compare(lhs, rhs) >= 0;
            ////}

            public bool Equals(SansOperatorsComparableObject other)
            {
                return Compare(this, other) == 0;
            }

            public int CompareTo(SansOperatorsComparableObject other)
            {
                return Compare(this, other);
            }

            public int CompareTo(object obj)
            {
                return this.CompareTo(obj as SansOperatorsComparableObject);
            }

            public override bool Equals(object obj)
            {
                return this.Equals(obj as SansOperatorsComparableObject);
            }

            public override int GetHashCode()
            {
                return this.value.GetHashCode();
            }

            public override string ToString()
            {
                return this.value.ToString();
            }

            private static int Compare(SansOperatorsComparableObject first, SansOperatorsComparableObject second)
            {
                var firstIsNull = object.ReferenceEquals(first, null);
                var secondIsNull = object.ReferenceEquals(second, null);
                if (firstIsNull)
                {
                    return secondIsNull ? 0 : -1;
                }
                else if (secondIsNull)
                {
                    return 1;
                }

                return Comparer<int>.Default.Compare(first.value, second.value);
            }
        }

        private class UnsealedComparableObject : IEquatable<UnsealedComparableObject>, IComparable<UnsealedComparableObject>, IComparable
        {
            private readonly int value;

            public UnsealedComparableObject(int value)
            {
                this.value = value;
            }

            public static bool operator !=(UnsealedComparableObject lhs, UnsealedComparableObject rhs)
            {
                return Compare(lhs, rhs) != 0;
            }

            public static bool operator ==(UnsealedComparableObject lhs, UnsealedComparableObject rhs)
            {
                return Compare(lhs, rhs) == 0;
            }

            public static bool operator <(UnsealedComparableObject lhs, UnsealedComparableObject rhs)
            {
                return Compare(lhs, rhs) < 0;
            }

            public static bool operator <=(UnsealedComparableObject lhs, UnsealedComparableObject rhs)
            {
                return Compare(lhs, rhs) <= 0;
            }

            public static bool operator >(UnsealedComparableObject lhs, UnsealedComparableObject rhs)
            {
                return Compare(lhs, rhs) > 0;
            }

            public static bool operator >=(UnsealedComparableObject lhs, UnsealedComparableObject rhs)
            {
                return Compare(lhs, rhs) >= 0;
            }

            public bool Equals(UnsealedComparableObject other)
            {
                return Compare(this, other) == 0;
            }

            public int CompareTo(UnsealedComparableObject other)
            {
                return Compare(this, other);
            }

            public int CompareTo(object obj)
            {
                return this.CompareTo(obj as UnsealedComparableObject);
            }

            public override bool Equals(object obj)
            {
                return this.Equals(obj as UnsealedComparableObject);
            }

            public override int GetHashCode()
            {
                return this.value.GetHashCode();
            }

            public override string ToString()
            {
                return this.value.ToString();
            }

            private static int Compare(UnsealedComparableObject first, UnsealedComparableObject second)
            {
                var firstIsNull = object.ReferenceEquals(first, null);
                var secondIsNull = object.ReferenceEquals(second, null);
                if (firstIsNull)
                {
                    return secondIsNull ? 0 : -1;
                }
                else if (secondIsNull)
                {
                    return 1;
                }

                return Comparer<int>.Default.Compare(first.value, second.value);
            }
        }

#pragma warning restore 660,659,661

        #endregion Test Helpers
    }
}