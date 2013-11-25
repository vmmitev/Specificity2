//-----------------------------------------------------------------------------
// <copyright file="EquatableVerifierTests.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Testing.Specificity.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class EquatableVerifierTests
    {
        [TestMethod]
        public void VerifyForIntsShouldPass()
        {
            var verifier = new EquatableVerifier<int>
            {
                EquivalenceClasses = new EquivalenceClassCollection<int>
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 3, 3 }
                }
            };

            verifier.Verify();
        }
    }
}