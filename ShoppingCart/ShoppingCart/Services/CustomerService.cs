namespace ShoppingCart.Services
{
    using System;
    using System.Collections.Generic;

    using ShoppingCart.Interfaces;
    using ShoppingCart.Models;

    /// <summary>
    /// The customer service.
    /// </summary>
    public class CustomerService : ICustomerService
    {
        /// <summary>
        /// The customer list.
        /// </summary>
        private readonly IDictionary<string, Customer> customerList = new Dictionary<string, Customer>();

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerService"/> class.
        /// </summary>
        public CustomerService()
        {
            this.customerList.Add("user1@test.com", new Customer { Name = "user1", Type = CustomerTypeEnum.Standard, LastOrder = DateTime.Today.AddMonths(-6) });
            this.customerList.Add("user2@test.com", new Customer { Name = "user2", Type = CustomerTypeEnum.Gold, LastOrder = DateTime.Today.AddYears(-1) });
            this.customerList.Add("user3@test.com", new Customer { Name = "user3", Type = CustomerTypeEnum.Silver });
            this.customerList.Add("user4@test.com", new Customer { Name = "user4", Type = CustomerTypeEnum.Standard });
            this.customerList.Add("user5@test.com", new Customer { Name = "user5", Type = CustomerTypeEnum.Silver });
            this.customerList.Add("user6@test.com", new Customer { Name = "user6", Type = CustomerTypeEnum.Gold });
        }

        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Customer"/>.
        /// </returns>
        public Customer Get(string id)
        {
            Customer customer;

            if (this.customerList.TryGetValue(id, out customer))
            {
                return customer;
            }

            return null;
        }

        /// <summary>
        /// The set type.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="type">
        /// The type.
        /// </param>
        public void SetType(string id, CustomerTypeEnum type)
        {
            Customer customer;

            if (this.customerList.TryGetValue(id, out customer))
            {
                customer.Type = type;
                customer.LastOrder = DateTime.Today;

                this.customerList[id] = customer;
            }
        }
    }
}