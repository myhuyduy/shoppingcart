namespace ShoppingCart.Order
{
    using System;
    using System.Collections.Generic;

    using ShoppingCart.Interfaces;
    using ShoppingCart.Models;

    /// <summary>
    /// The order generator.
    /// </summary>
    public class OrderGenerator : IOrderGenerator
    {
        private readonly IProductService productService;

        private readonly ICustomerService customerService;

        public OrderGenerator(IProductService productService, ICustomerService customerService)
        {
            this.productService = productService;
            this.customerService = customerService;
        }

        public Order Generate(Customer customer, ShoppingCart shoppingCart)
        {
            var order = new Order
                            {
                                Id = Guid.NewGuid().ToString(),
                                CustomerName = customer.Name,
                                Address = customer.Address,
                                Orders = new List<OrderLine>(),
                                Amount = 0.0,
                                Date = DateTime.Today
                            };

            foreach (var item in shoppingCart.Items)
            {
                var product = this.productService.Get(item.ProductCode);
                if (product != null)
                {
                    var orderLine = new OrderLine
                                        {
                                            ProductCode = product.Code,
                                            Quantity = item.Quantity,
                                            UnitPrice = product.Price
                                        };

                    order.Amount += orderLine.Quantity * orderLine.UnitPrice;

                    order.Orders.Add(orderLine);
                }
            }

            return order;
        }
    }
}