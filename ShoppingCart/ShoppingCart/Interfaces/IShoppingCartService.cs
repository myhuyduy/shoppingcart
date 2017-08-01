namespace ShoppingCart.Interfaces
{
    using ShoppingCart.Models;

    /// <summary>
    /// The ShoppingCartService interface.
    /// </summary>
    public interface IShoppingCartService
    {
        /// <summary>
        /// The add item.
        /// </summary>
        /// <param name="customerName">
        /// The customer name.
        /// </param>
        /// <param name="orderProduct">
        /// The order product.
        /// </param>
        void AddItem(string customerName, OrderProduct orderProduct);

        /// <summary>
        /// The get shopping cart.
        /// </summary>
        /// <param name="customerName">
        /// The customer name.
        /// </param>
        /// <returns>
        /// The <see cref="ShoppingCart"/>.
        /// </returns>
        ShoppingCart GetShoppingCart(string customerName);
    }
}
