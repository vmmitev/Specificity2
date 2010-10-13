//-----------------------------------------------------------------------------
// <copyright file="AutomaticTellerMachine.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

using System;
namespace Banking
{
    /// <summary>
    /// The automatic teller machien (ATM).
    /// </summary>
    public class AutomaticTellerMachine
    {
        /// <summary>
        /// The available funds.
        /// </summary>
        private double availableFunds;

        /// <summary>
        /// Initializes a new instance of the <see cref="AutomaticTellerMachine"/> class.
        /// </summary>
        /// <param name="availableFunds">The available funds.</param>
        public AutomaticTellerMachine(double availableFunds)
        {
            this.availableFunds = availableFunds;
        }

        /// <summary>
        /// Gets the available funds.
        /// </summary>
        /// <value>The available funds.</value>
        public double AvailableFunds
        {
            get { return this.availableFunds; }
        }

        /// <summary>
        /// Withdraws the specified amount.
        /// </summary>
        /// <param name="card">The ATM card to use.</param>
        /// <param name="amount">The amount to withdraw.</param>
        public void Withdraw(Card card, double amount)
        {
            if (card == null)
            {
                throw new ArgumentNullException("card");
            }

            if (this.availableFunds < amount)
            {
                throw new InsufficientFundsException();
            }

            card.Account.Withdraw(amount);
            this.availableFunds -= amount;
        }
    }
}
