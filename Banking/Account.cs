//-----------------------------------------------------------------------------
// <copyright file="Account.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Banking
{
    using System;

    /// <summary>
    /// Defines operations on a bank account.
    /// </summary>
    public class Account
    {
        /// <summary>
        /// The current balance.
        /// </summary>
        private double balance;

        /// <summary>
        /// Initializes a new instance of the <see cref="Account"/> class.
        /// </summary>
        /// <param name="balance">The initial balance.</param>
        public Account(double balance)
        {
            this.balance = balance;
        }

        /// <summary>
        /// Gets the current balance.
        /// </summary>
        /// <value>The current balance.</value>
        public double Balance
        {
            get
            {
                return this.balance;
            }
        }

        /// <summary>
        /// Deposits the specified amount.
        /// </summary>
        /// <param name="amount">The amount to deposit.</param>
        public void Deposit(double amount)
        {
            this.balance += amount;
        }

        /// <summary>
        /// Withdraws the specified amount.
        /// </summary>
        /// <param name="amount">The amount to withdraw.</param>
        public void Withdraw(double amount)
        {
            if (this.balance < amount)
            {
                throw new InsufficientFundsException();
            }

            this.balance -= amount;
        }
    }
}
