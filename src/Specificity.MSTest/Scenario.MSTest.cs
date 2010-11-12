//-----------------------------------------------------------------------------
// <copyright file="Scenario.MSTest.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Testing.Specificity
{
    using System.ComponentModel;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Base class for test scenarios.
    /// </summary>
    public abstract partial class Scenario
    {
        /// <summary>
        /// Initializes the scenario base.
        /// </summary>
        /// <remarks>
        /// This is an implementation detail.
        /// </remarks>
        [TestInitialize]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void InitializeScenario()
        {
            this.BeforeEachObservation();
        }

        /// <summary>
        /// Cleans up the scenario base.
        /// </summary>
        /// <remarks>
        /// This is an implementation detail.
        /// </remarks>
        [TestCleanup]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void CleanupScenario()
        {
            this.AfterEachObservation();
        }
    }
}
