namespace ShoppingCart.Models
{
    using System;

    /// <summary>
    /// The customer.
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        public CustomerTypeEnum Type { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the last order.
        /// </summary>
        public DateTime LastOrder { get; set; }
    }
}