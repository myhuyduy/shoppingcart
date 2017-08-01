using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShoppingCart.Controllers
{
    using System.Web;

    using ShoppingCart.Interfaces;
    using ShoppingCart.Models;

    /// <summary>
    /// The shopping cart controller.
    /// </summary>
    public class ShoppingCartController : ApiController
    {
        private readonly IShoppingCartService shoppingCartService;

        public ShoppingCartController(IShoppingCartService shoppingCartService)
        {
            this.shoppingCartService = shoppingCartService;
        }

        // GET api/<controller>
        public ShoppingCart Get()
        {
            return this.shoppingCartService.GetShoppingCart(HttpContext.Current.User.Identity.Name);
        }

        // POST api/<controller>
        public void Post([FromBody]OrderProduct order)
        {
            if (order == null || order.Quantity <= 0 || string.IsNullOrWhiteSpace(order.ProductCode))
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            this.shoppingCartService.AddItem(HttpContext.Current.User.Identity.Name, order);
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}