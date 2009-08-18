//-----------------------------------------------------------------------------
// <copyright file="Card.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Banking
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// An ATM card.
    /// </summary>
    public class Card
    {
        /// <summary>
        /// The account associated with the card.
        /// </summary>
        private readonly Account account;

        /// <summary>
        /// Initializes a new instance of the <see cref="Card"/> class.
        /// </summary>
        /// <param name="account">The account.</param>
        public Card(Account account)
        {
            this.account = account;
        }

        /// <summary>
        /// Gets the account associated with the card.
        /// </summary>
        /// <value>The account associated with the card.</value>
        public Account Account
        {
            get { return this.account; }
        }
    }
}
