﻿//-----------------------------------------------------------------------------
// <copyright file="Scenario.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Testing.Specificity
{
    using Xunit.Sdk;

    /// <summary>
    /// Base class for BDD style test classes.
    /// </summary>
    public abstract class Scenario : ScenarioBase
    {
        /// <summary>
        /// Excecutes the test command.
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
