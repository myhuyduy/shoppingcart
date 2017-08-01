namespace ShoppingCart.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// The shopping cart.
    /// </summary>
    public class ShoppingCart
    {
        /// <summary>
        /// Gets or sets the customer name.
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        public IList<OrderProduct> Items { get; set; }
    }
}