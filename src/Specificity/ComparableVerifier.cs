//-----------------------------------------------------------------------------
// <copyright file="ComparableVerifier.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Testing.Specificity
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

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
        private static readonly MethodInfo LessThanOperator = typeof(T).GetMethod("op_LessThan", BindingFlags.Static | BindingFlags.Public, null, new Type[] { typeof(T), typeof(T) }, null);

        /// <summary>
        /// The '>' operator method info.
        /// </summary>
        private static readonly MethodInfo GreaterThanOperator = typeof(T).GetMethod("op_GreaterThan", BindingFlags.Static | BindingFlags.Public, null, new Type[] { typeof(T), typeof(T) }, null);

        /// <summary>
        /// The '&lt;=' operator method info.
        /// </summary>
        private static readonly MethodInfo LessThanOrEqualOperator = typeof(T).GetMethod("op_LessThanOrEqual", BindingFlags.Static | BindingFlags.Public, null, new Type[] { typeof(T), typeof(T) }, null);

        /// <summary>
        /// The '>=' operator method info.
        /// </summary>
        private static readonly MethodInfo GreaterThanOrEqualOperator = typeof(T).GetMethod("op_GreaterThanOrEqual", BindingFlags.Static | BindingFlags.Public, null, new Type[] { typeof(T), typeof(T) }, null);

        /// <summary>
        /// Specifies that operators are defined.
        /// </summary>
        protected override void SpecifyThatOperatorsAreDefined()
        {
            base.SpecifyThatOperatorsAreDefined();
            Specify.That(LessThanOperator).Should.Not.BeNull("Less than operator not defined for type '{0}'.", typeof(T));
            Specify.That(GreaterThanOperator).Should.Not.BeNull("Greater than operator not defined for type '{0}'", typeof(T));
            Specify.That(LessThanOrEqualOperator).Should.Not.BeNull("Greater than operator not defined for type '{0}'", typeof(T));
            Specify.That(GreaterThanOrEqualOperator).Should.Not.BeNull("Greater than operator not defined for type '{0}'", typeof(T));
        }

        /// <summary>
        /// Gets tests for all of the comparison operations.
        /// </summary>
        /// <param name="lhs">The left hand side value.</param>
        /// <param name="rhs">The right hand side value.</param>
        /// <param name="comparison">How the values should compare.</param>
        /// <returns>A collection of tests.</returns>
        protected override IEnumerable<Action> GetOperationTests(T lhs, T rhs, int comparison)
        {
            var tests = new TestCollection(base.GetOperationTests(lhs, rhs, comparison));
            if (lhs != null)
            {
                tests.Add(() => Specify.That(Math.Sign(lhs.CompareTo((object)rhs))).Should.BeEqualTo(comparison, "Testing CompareTo with '{0}' and '{1}' failed.", lhs, rhs));
                tests.Add(() => Specify.That(Math.Sign(lhs.CompareTo(rhs))).Should.BeEqualTo(comparison, "Testing generic CompareTo with '{0}' and '{1}' failed.", lhs, rhs));
            }

            if (!typeof(T).IsPrimitive && this.ImplementsOperatorOverloads)
            {
                tests.Add(() => Specify.That((bool)LessThanOperator.Invoke(null, new object[] { lhs, rhs })).Should.BeEqualTo(comparison < 0, "Testing operator < with '{0}' and '{1}' failed.", lhs, rhs));
                tests.Add(() => Specify.That((bool)GreaterThanOperator.Invoke(null, new object[] { lhs, rhs })).Should.BeEqualTo(comparison > 0, "Testing operator > with '{0}' and '{1}' failed.", lhs, rhs));
                tests.Add(() => Specify.That((bool)LessThanOrEqualOperator.Invoke(null, new object[] { lhs, rhs })).Should.BeEqualTo(comparison <= 0, "Testing operator <= with '{0}' and '{1}' failed.", lhs, rhs));
                tests.Add(() => Specify.That((bool)GreaterThanOrEqualOperator.Invoke(null, new object[] { lhs, rhs })).Should.BeEqualTo(comparison >= 0, "Testing operator >= with '{0}' and '{1}' failed.", lhs, rhs));
            }

            return tests;
        }
    }
}