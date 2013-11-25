//-----------------------------------------------------------------------------
// <copyright file="EquatableVerifier.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Testing.Specificity
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    /// <summary>
    /// Provides a contract verifier that verifies the implementation of <see cref="IEquatable{T}"/> types.
    /// </summary>
    /// <typeparam name="T">The type to verify.</typeparam>
    public class EquatableVerifier<T> : ContractVerifier
        where T : IEquatable<T>
    {
        /// <summary>
        /// The '==' operator method info.
        /// </summary>
        private static readonly MethodInfo EqualityOperator = typeof(T).GetMethod("op_Equality", BindingFlags.Static | BindingFlags.Public, null, new Type[] { typeof(T), typeof(T) }, null);

        /// <summary>
        /// The <see cref="m:Object.GetHashCode"/> method info.
        /// </summary>
        private static readonly MethodInfo GetHashCodeMethod = typeof(T).GetMethod("GetHashCode", BindingFlags.Instance | BindingFlags.Public, null, Type.EmptyTypes, null);

        /// <summary>
        /// The '!=' operator method info.
        /// </summary>
        private static readonly MethodInfo InequalityOperator = typeof(T).GetMethod("op_Inequality", BindingFlags.Static | BindingFlags.Public, null, new Type[] { typeof(T), typeof(T) }, null);

        /// <summary>
        /// The <see cref="m:Object.Equals"/> method info.
        /// </summary>
        private static readonly MethodInfo ObjectEqualsMethod = typeof(T).GetMethod("Equals", BindingFlags.Instance | BindingFlags.Public, null, new Type[] { typeof(object) }, null);

        /// <summary>
        /// Initializes a new instance of the <see cref="EquatableVerifier{T}"/> class.
        /// </summary>
        public EquatableVerifier()
        {
            this.IsSealed = true;
            this.ImplementsOperatorOverloads = true;
        }

        /// <summary>
        /// Gets or sets the equivalence classes to use when testing.
        /// </summary>
        public EquivalenceClassCollection<T> EquivalenceClasses { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether or not the equality operators should be implemented.
        /// </summary>
        public bool ImplementsOperatorOverloads { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether or not the type should be sealed.
        /// </summary>
        public bool IsSealed { get; set; }

        /// <summary>
        /// Gets the test methods used to verify the contract.
        /// </summary>
        /// <returns>A collection of test methods.</returns>
        protected override IEnumerable<Action> GetTests()
        {
            var tests = new TestCollection();
            tests.Add(this.ShouldBeSealedType);
            tests.Add(this.ShouldOverrideObjectEquals);
            tests.Add(this.ShouldOverrideGetHashCode);
            tests.Add(this.ShouldImplementOperators);
            tests.Add(this.ShouldNotBeEquatableToNull);

            var reflexiveTests = new TestCollection();
            var symmetryTests = new TestCollection();
            var transitiveTests = new TestCollection();
            var operationTests = new TestCollection();

            var list = new List<T>(3);
            int comparison = -1;
            foreach (var ac in this.EquivalenceClasses)
            {
                comparison = -1;
                foreach (var bc in this.EquivalenceClasses)
                {
                    if (object.ReferenceEquals(ac, bc))
                    {
                        list.Clear();
                        comparison = 0;
                        foreach (var a in ac)
                        {
                            if (list.Count < 3)
                            {
                                list.Add(a);
                            }

                            if (list.Count == 1)
                            {
                                reflexiveTests.AddRange(this.GetOperationTests(a, a, comparison));
                            }
                            else
                            {
                                operationTests.AddRange(this.GetOperationTests(list[0], a, comparison));
                            }
                        }
                    }
                    else
                    {
                        if (comparison == 0)
                        {
                            comparison = 1;
                        }

                        operationTests.AddRange(this.GetOperationTests(bc.First(), ac.First(), comparison));
                    }
                }
            }

            tests.Add(reflexiveTests);
            tests.Add(symmetryTests);
            tests.Add(transitiveTests);
            tests.Add(operationTests);

            return tests;
        }

        /// <summary>
        /// Gets tests for all of the comparison operations.
        /// </summary>
        /// <param name="lhs">The left hand side value.</param>
        /// <param name="rhs">The right hand side value.</param>
        /// <param name="comparison">How the values should compare.</param>
        /// <returns>A collection of tests.</returns>
        private IEnumerable<Action> GetOperationTests(T lhs, T rhs, int comparison)
        {
            return Enumerable.Empty<Action>();
        }

        /// <summary>
        /// Tests that the type has been sealed.
        /// </summary>
        private void ShouldBeSealedType()
        {
            if (!this.IsSealed)
            {
                return;
            }

            Specify.That(typeof(T).IsSealed).Should.BeTrue("The type '{0}' should be sealed as a best practice when implementing 'IEquatable<T>'.", typeof(T));
        }

        /// <summary>
        /// Tests that the type has implemented the equality operators.
        /// </summary>
        private void ShouldImplementOperators()
        {
            if (typeof(T).IsPrimitive || !this.ImplementsOperatorOverloads)
            {
                return;
            }

            Specify.Aggregate(
                delegate
                {
                    Specify.That(EqualityOperator).Should.Not.BeNull("Equality operator not defined for type '{0}'.", typeof(T));
                    Specify.That(InequalityOperator).Should.Not.BeNull("Inequality operator not defined for type '{0}'.", typeof(T));
                },
                "The type '{0}' does not define equality operators.",
                typeof(T));
        }

        /// <summary>
        /// Tests that comparing to null always fails.
        /// </summary>
        private void ShouldNotBeEquatableToNull()
        {
        }

        /// <summary>
        /// Tests that the <see cref="m:Object.GetHashCode"/> method has been overridden on the type.
        /// </summary>
        private void ShouldOverrideGetHashCode()
        {
            Specify.That(GetHashCodeMethod.DeclaringType).Should.BeEqualTo(typeof(T), "The type '{0}' did not override the 'Object.GetHashCode' method.", typeof(T));
        }

        /// <summary>
        /// Tests that the <see cref="m:Object.Equals"/> method has been overridden on the type.
        /// </summary>
        private void ShouldOverrideObjectEquals()
        {
            Specify.That(ObjectEqualsMethod.DeclaringType).Should.BeEqualTo(typeof(T), "The type '{0}' did not override the 'Object.Equals' method.", typeof(T));
        }
    }
}