namespace ShoppingCart.Interfaces
{
    using ShoppingCart.Models;

    /// <summary>
    /// The CustomerService interface.
    /// </summary>
    public interface ICustomerService
    {
        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Customer"/>.
        /// </returns>
        Customer Get(string id);

        /// <summary>
        /// The set type.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="type">
        /// The type.
        /// </param>
        void SetType(string id, CustomerTypeEnum type);
    }
}
