namespace ShoppingCart.Services
{
    using System.Collections.Generic;

    using ShoppingCart.Interfaces;

    /// <summary>
    /// The payment service.
    /// </summary>
    public class PaymentService : IPaymentService
    {
        /// <summary>
        /// The customer list.
        /// </summary>
        private readonly IDictionary<string, double> customerList = new Dictionary<string, double>();

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentService"/> class.
        /// </summary>
        public PaymentService()
        {
            this.customerList.Add("user1@test.com", 790000);
            this.customerList.Add("user2@test.com", 600000);
            this.customerList.Add("user3@test.com", 56789);
            this.customerList.Add("user4@test.com", 567777);
            this.customerList.Add("user5@test.com", 567888);
        }

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
        public bool Payment(string customerName, double amount)
        {
            double balance;

            if (this.customerList.TryGetValue(customerName, out balance))
            {
                if (amount > balance)
                {
                    return false;
                }

                var newBlance = balance - amount;
                this.customerList["customerName"] = newBlance;

                return true;
            }

            return false;
        }
    }
}