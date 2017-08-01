namespace ShoppingCart.Services
{
    using System.Collections.Generic;
    using System.Linq;

    using ShoppingCart.Interfaces;
    using ShoppingCart.Models;

    /// <summary>
    /// The product service.
    /// </summary>
    public class ProductService : IProductService
    {
        /// <summary>
        /// The product list.
        /// </summary>
        private readonly IList<Product> productList;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductService"/> class.
        /// </summary>
        public ProductService()
        {
            this.productList = new List<Product>
                                   {
                                       new Product { Code = "Product1", Price = 15.99 },
                                       new Product { Code = "Product2", Price = 16.99 },
                                       new Product { Code = "Product3", Price = 6.99 },
                                       new Product { Code = "Product4", Price = 1.99 },
                                       new Product { Code = "Product5", Price = 10.99 },
                                       new Product { Code = "Product6", Price = 7.99 },
                                       new Product { Code = "Product7", Price = 8.99 }
                                   };
        }

        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Product"/>.
        /// </returns>
        public Product Get(string id)
        {
            return this.productList.FirstOrDefault(p => p.Code == id);
        }
    }
}