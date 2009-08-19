//-----------------------------------------------------------------------------
// <copyright file="ObservationAttribute.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Testing.Specificity
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using Xunit;
    using Xunit.Sdk;

    /// <summary>
    /// Attribute applied to observation methods in a <see cref="Scenario"/>.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public sealed class ObservationAttribute : FactAttribute
    {
        /// <summary>
        /// Enumerates the test commands represented by this test method. Derived classes should
        /// override this method to return instances of <see cref="T:Xunit.Sdk.ITestCommand"/>, one per execution
        /// of a test method.
        /// </summary>
        /// <param name="method">The test method</param>
        /// <returns>
        /// The test commands which will execute the test runs for the given method
        /// </returns>
        protected override IEnumerable<ITestCommand> EnumerateTestCommands(MethodInfo method)
        {
            foreach (ITestCommand command in this.BaseEnumerateTestCommands(method))
            {
                yield return new ObservationCommand(command);
            }
        }

        /// <summary>
        /// Calls the base <see cref="FactAttribute.EnumerateTestCommands"/>.
        /// </summary>
        /// <param name="method">The test method</param>
        /// <returns>
        /// The test commands which will execute the test runs for the given method
        /// </returns>
        private IEnumerable<ITestCommand> BaseEnumerateTestCommands(MethodInfo method)
        {
            return base.EnumerateTestCommands(method);
        }
    }
}
