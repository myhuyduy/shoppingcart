using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCart.Services
{
    using ShoppingCart.Interfaces;
    using ShoppingCart.Models;

    public class DispatchOrderService : IDispatchOrderService
    {
        public bool Dispatch(Order order)
        {
            // Send email
            // save order

            return true;
        }
    }
}