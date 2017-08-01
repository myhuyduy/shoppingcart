namespace ShoppingCart.Interfaces
{
    using System;

    using ShoppingCart.Models;

    /// <summary>
    /// The PlaceOrderService interface.
    /// </summary>
    public interface IPlaceOrderService
    {
        /// <summary>
        /// The place order.
        /// </summary>
        /// <param name="customerName">
        /// The customer name.
        /// </param>
        /// <param name="shoppingCart">
        /// The shopping cart.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        bool PlaceOrder(string customerName, ShoppingCart shoppingCart);
    }
}
