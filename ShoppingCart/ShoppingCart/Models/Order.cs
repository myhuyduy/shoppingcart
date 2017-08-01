namespace ShoppingCart.Models
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The order.
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the customer name.
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        public double Amount { get; set; }

        /// <summary>
        /// Gets or sets the orders.
        /// </summary>
        public IList<OrderLine> Orders { get; set; }
    }
}