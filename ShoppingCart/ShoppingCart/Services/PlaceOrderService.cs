namespace ShoppingCart.Services
{
    using System;
    using System.Collections.Generic;

    using ShoppingCart.Interfaces;
    using ShoppingCart.Models;
    using ShoppingCart.Order;

    /// <summary>
    /// The place order service.
    /// </summary>
    public class PlaceOrderService : IPlaceOrderService
    {
        /// <summary>
        /// The payment service.
        /// </summary>
        private readonly IPaymentService paymentService;

        /// <summary>
        /// The order generator.
        /// </summary>
        private readonly IOrderGenerator orderGenerator;

        /// <summary>
        /// The customer service.
        /// </summary>
        private readonly ICustomerService customerService;

        /// <summary>
        /// The dispatch service.
        /// </summary>
        private readonly IDispatchOrderService dispatchService;

        public PlaceOrderService(IPaymentService paymentService, IOrderGenerator orderGenerator, ICustomerService customerService, IDispatchOrderService dispatchService)
        {
            this.paymentService = paymentService;
            this.orderGenerator = orderGenerator;
            this.customerService = customerService;
            this.dispatchService = dispatchService;
        }

        public bool PlaceOrder(string customerName, ShoppingCart shoppingCart)
        {
            if (shoppingCart == null)
            {
                throw new ArgumentNullException(nameof(shoppingCart));
            }

            var customer = this.customerService.Get(customerName);

            // get order
            var order = this.orderGenerator.Generate(customer, shoppingCart);

            double discount = 0.0;

            if(customer.LastOrder > DateTime.Today.AddYears(1))
            {
                // get discount
                if (customer.Type == CustomerTypeEnum.Silver)
                {
                    discount = (order.Amount * 2) * 100;
                }

                if (customer.Type == CustomerTypeEnum.Gold)
                {
                    discount = (order.Amount * 3) * 100;
                }
            }

            // Set customer type
            if (order.Amount > 800)
            {
                this.customerService.SetType(customerName, CustomerTypeEnum.Gold);
            }

            if (order.Amount > 800)
            {
                this.customerService.SetType(customerName, CustomerTypeEnum.Gold);
            }

            order.Amount = order.Amount - discount;

            var payment = this.paymentService.Payment(customerName, order.Amount);

            if (payment)
            {
                // Save order

                // Send to courier
                this.dispatchService.Dispatch(order);
            }

            return payment;
        }
    }
}