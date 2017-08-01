namespace ShoppingCart.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Caching;

    using ShoppingCart.Interfaces;
    using ShoppingCart.Models;

    /// <summary>
    /// The shopping cart service.
    /// </summary>
    public class ShoppingCartService : IShoppingCartService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ShoppingCartService"/> class.
        /// </summary>
        public ShoppingCartService()
        {
            this.Cache = MemoryCache.Default;
        }


        /// <summary>
        /// Gets the cache.
        /// </summary>
        public MemoryCache Cache { get; private set; }

        /// <summary>
        /// The add item.
        /// </summary>
        /// <param name="customerName">
        /// The customer name.
        /// </param>
        /// <param name="orderProduct">
        /// The order product.
        /// </param>
        public void AddItem(string customerName, OrderProduct orderProduct)
        {
            ShoppingCart shoppingCart = this.Cache.Get(customerName) as ShoppingCart;

            if (shoppingCart == null)
            {
                shoppingCart = new ShoppingCart { CustomerName = customerName, Items = new List<OrderProduct>() };
            }

            var items = shoppingCart.Items.Where(i => i.ProductCode == orderProduct.ProductCode);

            if (items.Any())
            {
                shoppingCart.Items.Remove(items.First());
            }

            shoppingCart.Items.Add(orderProduct);

            this.Cache.AddOrGetExisting(customerName, shoppingCart, DateTimeOffset.MaxValue);
        }

        /// <summary>
        /// The get shopping cart.
        /// </summary>
        /// <param name="customerName">
        /// The customer name.
        /// </param>
        /// <returns>
        /// The <see cref="ShoppingCart"/>.
        /// </returns>
        public ShoppingCart GetShoppingCart(string customerName)
        {
            return this.Cache.Get(customerName) as ShoppingCart;
        }
    }
}