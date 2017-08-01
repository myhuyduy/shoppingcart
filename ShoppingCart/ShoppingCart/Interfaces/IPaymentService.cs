namespace ShoppingCart.Interfaces
{
    /// <summary>
    /// The PaymentService interface.
    /// </summary>
    public interface IPaymentService
    {
        /// <summary>
        /// The payment.
        /// </summary>
        /// <param name="customerName">
        /// The customer name.
        /// </param>
        /// <param name="amount">
        /// The amount.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        bool Payment(string customerName, double amount);
    }
}
