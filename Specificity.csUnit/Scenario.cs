// <copyright file="Scenario.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Testing.Specificity
{
    using System.ComponentModel;
    using csUnit;

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
        [SetUp]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Setup()
        {
            this.BeforeEachObservation();
        }

        /// <summary>
        /// Cleans up the scenario base.
        /// </summary>
        /// <remarks>
        /// This is an implementation detail.
        /// </remarks>
        [TearDown]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Teardown()
        {
            this.AfterEachObservation();
        }
    }
}
