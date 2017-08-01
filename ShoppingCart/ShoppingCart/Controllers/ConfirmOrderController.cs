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

    public class ConfirmOrderController : ApiController
    {
        /// <summary>
        /// The shopping cart service.
        /// </summary>
        private readonly IShoppingCartService shoppingCartService;

        /// <summary>
        /// The place order service.
        /// </summary>
        private readonly IPlaceOrderService placeOrderService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfirmOrderController"/> class.
        /// </summary>
        /// <param name="shoppingCartService">
        /// The shopping cart service.
        /// </param>
        /// <param name="placeOrderService">
        /// The place Order Service.
        /// </param>
        public ConfirmOrderController(IShoppingCartService shoppingCartService, IPlaceOrderService placeOrderService)
        {
            this.shoppingCartService = shoppingCartService;
            this.placeOrderService = placeOrderService;
        }

        // POST api/<controller>
        public HttpResponseMessage Post()
        {
            var shoppingCart = this.shoppingCartService.GetShoppingCart(HttpContext.Current.User.Identity.Name);
            if (shoppingCart == null)
            {
                return this.Request.CreateErrorResponse(HttpStatusCode.NotFound, "Shopping Cart not found");
            }

            if (this.placeOrderService.PlaceOrder(HttpContext.Current.User.Identity.Name, shoppingCart))
            {
                return this.Request.CreateResponse<string>(HttpStatusCode.OK, "Thank you, your order has been placed");
            }

            return this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Cannot place order");

        }
    }
}