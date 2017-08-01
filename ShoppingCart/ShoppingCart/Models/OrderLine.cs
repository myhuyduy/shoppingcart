namespace ShoppingCart.Models
{
    /// <summary>
    /// The order line.
    /// </summary>
    public class OrderLine
    {
        /// <summary>
        /// Gets or sets the product code.
        /// </summary>
        public string ProductCode { get; set; }

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the unit price.
        /// </summary>
        public double UnitPrice { get; set; }
    }
}