namespace ShoppingCart.Order
{
    using ShoppingCart.Models;

    /// <summary>
    /// The OrderGenerator interface.
    /// </summary>
    public interface IOrderGenerator
    {
        /// <summary>
        /// The generate.
        /// </summary>
        /// <param name="customer">
        /// The customer.
        /// </param>
        /// <param name="shoppingCart">
        /// The shopping cart.
        /// </param>
        /// <returns>
        /// The <see cref="Order"/>.
        /// </returns>
        Order Generate(Customer customer, ShoppingCart shoppingCart);
    }
}
