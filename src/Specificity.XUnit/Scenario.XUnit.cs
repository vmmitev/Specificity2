//-----------------------------------------------------------------------------
// <copyright file="Scenario.XUnit.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Testing.Specificity
{
    using Xunit.Sdk;

    /// <summary>
    /// Base class for test scenarios.
    /// </summary>
    public abstract partial class Scenario
    {
        /// <summary>
        /// Executes the test command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>
        /// The test commands which will execute the test runs for the given method.
        /// </returns>
        internal MethodResult ExcecuteTestCommand(ITestCommand command)
        {
            try
            {
                this.BeforeEachObservation();
                return command.Execute(this);
            }
            finally
            {
                this.AfterEachObservation();
            }
        }
    }
}
