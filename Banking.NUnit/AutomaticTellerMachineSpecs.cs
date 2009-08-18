//-----------------------------------------------------------------------------
// <copyright file="AutomaticTellerMachineSpecs.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

// These test classes illustrate how to use Specificity in a BDD fashion.

namespace Banking.MbUnitTests
{
    using Testing.Specificity;
    using NUnit.Framework;

    /// <summary>
    /// Base class for testing <see cref="AutomaticTellerMachine"/> scenarios.
    /// </summary>
    public abstract class AutomaticTellerMachineScenario : Scenario
    {
        /// <summary>
        /// The original balance on the account.
        /// </summary>
        public const double OriginalBalance = 3000.0;

        /// <summary>
        /// The original funds available in the ATM.
        /// </summary>
        public const double OriginalAvailableFunds = OriginalBalance / 4;

        /// <summary>
        /// The account on the card.
        /// </summary>
        private Account account;

        /// <summary>
        /// The card to use.
        /// </summary>
        private Card card;

        /// <summary>
        /// The ATM to use.
        /// </summary>
        private AutomaticTellerMachine machine;

        /// <summary>
        /// Gets the card holder's account.
        /// </summary>
        /// <value>The account.</value>
        public Account Account
        {
            get { return this.account; }
        }

        /// <summary>
        /// Gets the card to use for transactions.
        /// </summary>
        /// <value>The card used for transactions.</value>
        public Card Card
        {
            get { return this.card; }
        }

        /// <summary>
        /// Gets the machine.
        /// </summary>
        /// <value>The machine.</value>
        public AutomaticTellerMachine Machine
        {
            get { return this.machine; }
        }

        /// <summary>
        /// Arranges the test environment.
        /// </summary>
        public override void EstablishContext()
        {
            base.EstablishContext();
            this.account = new Account(OriginalBalance);
            this.card = new Card(this.account);
            this.machine = new AutomaticTellerMachine(OriginalAvailableFunds);
        }
    }

    /// <summary>
    /// Scenario for when account has insufficient funds.
    /// </summary>
    public class Account_has_insufficient_funds : AutomaticTellerMachineScenario
    {
        /// <summary>
        /// The amount to withdraw.
        /// </summary>
        public const double AmountToWithdraw = OriginalBalance + 10;

        /// <summary>
        /// Performs the test action.
        /// </summary>
        [ObserveExceptions]
        public override void Because()
        {
            this.Machine.Withdraw(this.Card, AmountToWithdraw);
        }

        /// <summary>
        /// Verifies that the ATM should not dispense money when there's insufficient funds.
        /// </summary>
        [Test]
        public void Machine_should_not_dispense_money()
        {
            Specify.That(this.Machine.AvailableFunds).ShouldBeEqualTo(OriginalAvailableFunds);
        }

        /// <summary>
        /// Verifies that the ATM should indicate there are insufficient funds.
        /// </summary>
        [Test]
        public void Machine_should_say_there_are_insufficient_funds()
        {
            Specify.That(this.Exception).ShouldBeInstanceOfType(typeof(InsufficientFundsException));
        }

        /// <summary>
        /// Verifies that the account balance ramins the same when there's insufficient funds.
        /// </summary>
        [Test]
        public void Account_balance_should_remain_the_same()
        {
            Specify.That(this.Account.Balance).ShouldBeEqualTo(OriginalBalance);
        }
    }

    /// <summary>
    /// Scenario for when account has sufficient funds.
    /// </summary>
    public class Account_has_sufficient_funds : AutomaticTellerMachineScenario
    {
        /// <summary>
        /// The amount to withdraw.
        /// </summary>
        public const double AmountToWithdraw = OriginalAvailableFunds / 2;

        /// <summary>
        /// Performs the test action.
        /// </summary>
        public override void Because()
        {
            this.Machine.Withdraw(this.Card, AmountToWithdraw);
        }

        /// <summary>
        /// Verifies that the account balance should have been adjusted accordingly.
        /// </summary>
        [Test]
        public void Account_balance_should_be_adjusted()
        {
            Specify.That(this.Account.Balance).ShouldBeEqualTo(OriginalBalance - AmountToWithdraw);
        }

        /// <summary>
        /// Verifies that the machine dispensed the proper amount of money.
        /// </summary>
        [Test]
        public void Machine_should_dispense_amount_requested()
        {
            Specify.That(this.Machine.AvailableFunds).ShouldBeEqualTo(OriginalAvailableFunds - AmountToWithdraw);
        }
    }

    /// <summary>
    /// Scenario for when the ATM has insufficient funds.
    /// </summary>
    public class Machine_has_insufficient_funds : AutomaticTellerMachineScenario
    {
        /// <summary>
        /// Amount to withdraw.
        /// </summary>
        public const double AmountToWithdraw = OriginalAvailableFunds * 2;

        /// <summary>
        /// Performs the test action.
        /// </summary>
        [ObserveExceptions]
        public override void Because()
        {
            this.Machine.Withdraw(this.Card, AmountToWithdraw);
        }

        /// <summary>
        /// Verifies that the ATM should not dispense money when there's insufficient funds.
        /// </summary>
        [Test]
        public void Machine_should_not_dispense_money()
        {
            Specify.That(this.Machine.AvailableFunds).ShouldBeEqualTo(OriginalAvailableFunds);
        }

        /// <summary>
        /// Verifies that the ATM should indicate there are insufficient funds.
        /// </summary>
        [Test]
        public void Machine_should_say_there_are_insufficient_funds()
        {
            Specify.That(this).ShouldThrow(typeof(InsufficientFundsException));
        }

        /// <summary>
        /// Verifies that the account balance ramins the same when there's insufficient funds.
        /// </summary>
        [Test]
        public void Account_balance_should_remain_the_same()
        {
            Specify.That(this.Account.Balance).ShouldBeEqualTo(OriginalBalance);
        }
    }
}
