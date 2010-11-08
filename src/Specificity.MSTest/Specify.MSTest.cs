﻿//-----------------------------------------------------------------------------
// <copyright file="Specify.MSTest.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Testing.Specificity
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Static class used to declare fluent test constraints.
    /// </summary>
    public partial class Specify
    {
        /// <summary>
        /// Initializes static members of the <see cref="Specify"/> class.
        /// </summary>
        static Specify()
        {
            ConstraintResult.SetReporter(ReportResult);
        }

        /// <summary>
        /// Reports the result of the constraint.
        /// </summary>
        /// <param name="result">The result type.</param>
        /// <param name="message">The message to display in the test run.</param>
        private static void ReportResult(ConstraintResultType result, string message)
        {
            switch (result)
            {
                case ConstraintResultType.Failure:
                    throw new AssertFailedException(message);

                case ConstraintResultType.Inconclusive:
                    throw new AssertInconclusiveException(message);
            }
        }
    }
}
