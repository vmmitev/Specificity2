//-----------------------------------------------------------------------------
// <copyright file="ObservationCommand.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Testing.Specificity
{
    using System.Xml;
    using Xunit.Sdk;

    /// <summary>
    /// Wraps an ITestCommand for <see cref="ObservationAttribute"/> methods.
    /// </summary>
    internal class ObservationCommand : ITestCommand
    {
        /// <summary>
        /// The inner command.
        /// </summary>
        private readonly ITestCommand innerCommand;

        /// <summary>
        /// Initializes a new instance of the <see cref="ObservationCommand"/> class.
        /// </summary>
        /// <param name="innerCommand">The inner command.</param>
        public ObservationCommand(ITestCommand innerCommand)
        {
            this.innerCommand = innerCommand;
        }

        /// <summary>
        /// Gets the display name of the test method.
        /// </summary>
        /// <value></value>
        public string DisplayName
        {
            get { return this.innerCommand.DisplayName; }
        }

        /// <summary>
        /// Gets a value indicating whether the test runner infrastructure should create a new instance of the
        /// test class before running the test.
        /// </summary>
        /// <value></value>
        public bool ShouldCreateInstance
        {
            get { return this.innerCommand.ShouldCreateInstance; }
        }

        /// <summary>
        /// Executes the test method.
        /// </summary>
        /// <param name="testClass">The instance of the test class</param>
        /// <returns>Returns information about the test run</returns>
        public MethodResult Execute(object testClass)
        {
            Scenario scenario = testClass as Scenario;
            if (scenario != null)
            {
                return scenario.ExcecuteTestCommand(this.innerCommand);
            }

            return this.innerCommand.Execute(testClass);
        }

        /// <summary>
        /// Creates the start XML to be sent to the callback when the test is about to start
        /// running.
        /// </summary>
        /// <returns>
        /// Return the <see cref="T:System.Xml.XmlNode"/> of the start node, or null if the test
        /// is known that it will not be running.
        /// </returns>
        public XmlNode ToStartXml()
        {
            return this.innerCommand.ToStartXml();
        }
    }
}
