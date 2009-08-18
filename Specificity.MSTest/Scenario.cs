// <copyright file="Scenario.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Testing.Specificity
{
    using System.ComponentModel;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Testing.Specificity;

    /// <summary>
    /// Base class for BDD style test classes.
    /// </summary>
    public abstract class Scenario : ScenarioBase
    {
        /// <summary>
        /// Initializes the scenario base.
        /// </summary>
        /// <remarks>
        /// This is an implementation detail.
        /// </remarks>
        [TestInitialize]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void InitializeSpecificationBase()
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
        public void CleanupSpecificationBase()
        {
            this.AfterEachObservation();
        }
    }
}
