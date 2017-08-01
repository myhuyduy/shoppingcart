namespace ShoppingCart.Interfaces
{
    /// <summary>
    /// The AuthenticationService interface.
    /// </summary>
    public interface IAuthenticationService
    {
        /// <summary>
        /// The authenticate.
        /// </summary>
        /// <param name="userName">
        /// The user name.
        /// </param>
        /// <param name="password">
        /// The password.
        /// </param>
        /// <returns>
        /// True if vald user.
        /// </returns>
        bool Authenticate(string userName, string password);
    }
}
