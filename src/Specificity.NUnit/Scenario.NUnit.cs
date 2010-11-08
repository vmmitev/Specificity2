//-----------------------------------------------------------------------------
// <copyright file="Scenario.NUnit.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Testing.Specificity
{
    using System.ComponentModel;
    using NUnit.Framework;

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
