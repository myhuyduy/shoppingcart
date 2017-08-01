namespace ShoppingCart.Services
{
    using System.Collections.Generic;

    using ShoppingCart.Interfaces;

    /// <summary>
    /// The Dummy authentication service.
    /// </summary>
    public class AuthenticationService : IAuthenticationService
    {
        /// <summary>
        /// The mock user list.
        /// </summary>
        private readonly IDictionary<string, string> userList = new Dictionary<string, string>();

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationService"/> class.
        /// </summary>
        public AuthenticationService()
        {
            this.userList.Add("user1@test.com", "Password1");
            this.userList.Add("user2@test.com", "Password2");
            this.userList.Add("user3@test.com", "Password3");
            this.userList.Add("user4@test.com", "Password4");
            this.userList.Add("user5@test.com", "Password5");
            this.userList.Add("user6@test.com", "Password6");
        }

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
        /// True if valid user.
        /// </returns>
        public bool Authenticate(string userName, string password)
        {
            string passwordStore;

            if (this.userList.TryGetValue(userName, out passwordStore))
            {
                return passwordStore == password;
            }

            return false;
        }
    }
}