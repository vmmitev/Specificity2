//-----------------------------------------------------------------------------
// <copyright file="ComparableVerifier.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Testing.Specificity2
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using Properties;

    /// <summary>
    /// Provides a contract verifier that verifies the implementation of <see cref="IComparable{T}" /> types.
    /// </summary>
    /// <typeparam name="T">The type to verify.</typeparam>
    public class ComparableVerifier<T> : EquatableVerifier<T>
        where T : IComparable<T>, IComparable, IEquatable<T>
    {
        /// <summary>
        /// The '&lt;' operator method info.
        /// </summary>
        private static MethodInfo LessThanOperator { get; } =
            typeof(T).GetMethod("op_LessThan", BindingFlags.Static | BindingFlags.Public, null, new Type[] { typeof(T), typeof(T) }, null);

        /// <summary>
        /// The '>' operator method info.
        /// </summary>
        private static MethodInfo GreaterThanOperator { get; } =
            typeof(T).GetMethod("op_GreaterThan", BindingFlags.Static | BindingFlags.Public, null, new Type[] { typeof(T), typeof(T) }, null);

        /// <summary>
        /// The '&lt;=' operator method info.
        /// </summary>
        private static MethodInfo LessThanOrEqualOperator { get; } =
            typeof(T).GetMethod("op_LessThanOrEqual", BindingFlags.Static | BindingFlags.Public, null, new Type[] { typeof(T), typeof(T) }, null);

        /// <summary>
        /// The '>=' operator method info.
        /// </summary>
        private static MethodInfo GreaterThanOrEqualOperator { get; }
            = typeof(T).GetMethod("op_GreaterThanOrEqual", BindingFlags.Static | BindingFlags.Public, null, new Type[] { typeof(T), typeof(T) }, null);

        /// <summary>
        /// Specifies that operators are defined.
        /// </summary>
        protected override void SpecifyThatOperatorsAreDefined()
        {
            base.SpecifyThatOperatorsAreDefined();
            Specify.That(LessThanOperator).Should.Not.BeNull(Resources.LessThanOperatorNotDefinedForType, typeof(T));
            Specify.That(GreaterThanOperator).Should.Not.BeNull(Resources.GreaterThanOperatorNotDefinedForType, typeof(T));
            Specify.That(LessThanOrEqualOperator).Should.Not.BeNull(Resources.LessThanOrEqualOperatorNotDefinedForType, typeof(T));
            Specify.That(GreaterThanOrEqualOperator).Should.Not.BeNull(Resources.GreaterThanOrEqualOperatorNotDefinedForType, typeof(T));
        }

        /// <summary>
        /// Gets tests for all of the comparison operations.
        /// </summary>
        /// <param name="leftHandSide">The left hand side value.</param>
        /// <param name="rightHandSide">The right hand side value.</param>
        /// <param name="comparison">How the values should compare.</param>
        /// <returns>A collection of tests.</returns>
        protected override IEnumerable<Action> GetOperationTests(T leftHandSide, T rightHandSide, int comparison)
        {
            var tests = new TestCollection(base.GetOperationTests(leftHandSide, rightHandSide, comparison));
            if (leftHandSide != null)
            {
                tests.Add(() =>
                    Specify.That(Math.Sign(leftHandSide.CompareTo((object)rightHandSide)))
                        .Should.BeEqualTo(comparison, Resources.TestingCompareToWithValuesFailed, leftHandSide, rightHandSide));

                tests.Add(() =>
                    Specify.That(Math.Sign(leftHandSide.CompareTo(rightHandSide)))
                        .Should.BeEqualTo(comparison, Resources.TestingGenericCompareToWithValuesFailed, leftHandSide, rightHandSide));
            }

            if (!typeof(T).IsPrimitive && this.ImplementsOperatorOverloads)
            {
                tests.Add(() =>
                    Specify.That((bool)LessThanOperator.Invoke(null, new object[] { leftHandSide, rightHandSide }))
                        .Should.BeEqualTo(comparison < 0, Resources.TestingLessThanOperatorWithValuesFailed, leftHandSide, rightHandSide));

                tests.Add(() =>
                    Specify.That((bool)GreaterThanOperator.Invoke(null, new object[] { leftHandSide, rightHandSide }))
                        .Should.BeEqualTo(comparison > 0, Resources.TestingGreaterThanOperatorWithValuesFailed, leftHandSide, rightHandSide));

                tests.Add(() =>
                    Specify.That((bool)LessThanOrEqualOperator.Invoke(null, new object[] { leftHandSide, rightHandSide }))
                        .Should.BeEqualTo(comparison <= 0, Resources.TestingLessThanOrEqualOperatorWithValuesFailed, leftHandSide, rightHandSide));

                tests.Add(() =>
                    Specify.That((bool)GreaterThanOrEqualOperator.Invoke(null, new object[] { leftHandSide, rightHandSide }))
                        .Should.BeEqualTo(comparison >= 0, Resources.TestingGreaterThanOrEqualOperatorWithValuesFailed, leftHandSide, rightHandSide));
            }

            return tests;
        }
    }
}