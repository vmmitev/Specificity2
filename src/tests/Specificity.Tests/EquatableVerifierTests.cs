//-----------------------------------------------------------------------------
// <copyright file="EquatableVerifierTests.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Testing.Specificity.Tests
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class EquatableVerifierTests
    {
        [TestMethod]
        public void VerifyForIntsShouldPass()
        {
            var verifier = new EquatableVerifier<int>
            {
                EquivalenceClasses = new EquivalenceClassCollection<int>
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 3, 3 }
                }
            };

            verifier.Verify();
        }

        [TestMethod]
        public void VerifyForWrapperOfIntShouldPass()
        {
            var verifier = new EquatableVerifier<Wrapper<int>>
            {
                EquivalenceClasses = new EquivalenceClassCollection<Wrapper<int>>
                {
                    { new Wrapper<int>(1), new Wrapper<int>(1), new Wrapper<int>(1) },
                    { new Wrapper<int>(2), new Wrapper<int>(2), new Wrapper<int>(2) },
                    { new Wrapper<int>(3), new Wrapper<int>(3), new Wrapper<int>(3) }
                }
            };

            verifier.Verify();
        }

        private sealed class Wrapper<T> : IEquatable<Wrapper<T>>
        {
            private readonly T value;

            public Wrapper(T value)
            {
                this.value = value;
            }

            public static bool operator !=(Wrapper<T> lhs, Wrapper<T> rhs)
            {
                return !lhs.Equals(rhs);
            }

            public static bool operator ==(Wrapper<T> lhs, Wrapper<T> rhs)
            {
                return lhs.Equals(rhs);
            }

            public bool Equals(Wrapper<T> other)
            {
                return EqualityComparer<T>.Default.Equals(this.value, other.value);
            }

            public override bool Equals(object obj)
            {
                return this.Equals(obj as Wrapper<T>);
            }

            public override int GetHashCode()
            {
                return this.value.GetHashCode();
            }
        }
    }
}