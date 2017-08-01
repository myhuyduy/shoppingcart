namespace ShoppingCart.Models
{
    /// <summary>
    /// The order product.
    /// </summary>
    public class OrderProduct
    {
        /// <summary>
        /// Gets or sets the product code.
        /// </summary>
        public string ProductCode { get; set; }

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        public int Quantity { get; set; }
    }
}