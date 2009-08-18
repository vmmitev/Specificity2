// This test class illustrates how to use only the assertions from Specificity in a traditional TDD fashion using
// MSTest.

namespace Banking.MSTest
{
    using Banking;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Testing.Specificity;

    /// <summary>
    /// Tests for the <see cref="Account"/> type.
    /// </summary>
    [TestClass]
    public class AccountTests
    {
        /// <summary>
        /// Verifies that depositing into the account modifies the balance accordingly.
        /// </summary>
        [TestMethod]
        public void DepositingShouldModifyTheBalance()
        {
            double originalBalance = 0.0;
            double depositedAmount = 100.0;
            Account account = new Account(originalBalance);
            account.Deposit(depositedAmount);
            Specify.That(account.Balance).ShouldBeEqualTo(originalBalance + depositedAmount);
        }

        /// <summary>
        /// Verifies that withdrawing from the account modifies the balance accordingly.
        /// </summary>
        [TestMethod]
        public void WithdrawingShouldModifyTheBalance()
        {
            double originalBalance = 100.0;
            double withdrawnAmount = 50.0;
            Account account = new Account(originalBalance);
            account.Withdraw(withdrawnAmount);
            Specify.That(account.Balance).ShouldBeEqualTo(originalBalance - withdrawnAmount);
        }

        /// <summary>
        /// Verifies that withdrawing more than the balance on the account should fail.
        /// </summary>
        [TestMethod]
        public void WithdrawingMoreThanBalanceShouldFail()
        {
            double originalBalance = 100.0;
            double withdrawnAmount = 150.0;
            Account account = new Account(originalBalance);

            Specify.ThatAction(delegate
            {
                account.Withdraw(withdrawnAmount);
            }).ShouldHaveThrown(typeof(InsufficientFundsException));
        }
    }
}
