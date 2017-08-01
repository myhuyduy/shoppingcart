using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ShoppingCart
{
    using Microsoft.Practices.Unity;
    using Microsoft.Practices.Unity.WebApi;

    using ShoppingCart.AuthenticationHandler;
    using ShoppingCart.Interfaces;
    using ShoppingCart.Order;
    using ShoppingCart.Services;

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.MessageHandlers.Add(new BasicAuthenticationHandler(new AuthenticationService()));

            var container = new UnityContainer();
            container.RegisterType<IShoppingCartService, ShoppingCartService>(new HierarchicalLifetimeManager());
            container.RegisterType<IPaymentService, PaymentService>(new HierarchicalLifetimeManager());
            container.RegisterType<IProductService, ProductService>(new HierarchicalLifetimeManager());
            container.RegisterType<ICustomerService, CustomerService>(new HierarchicalLifetimeManager());
            container.RegisterType<IOrderGenerator, OrderGenerator>(new HierarchicalLifetimeManager());
            container.RegisterType<IPlaceOrderService, PlaceOrderService>(new HierarchicalLifetimeManager());
            container.RegisterType<IDispatchOrderService, DispatchOrderService>(new HierarchicalLifetimeManager());

            config.DependencyResolver = new UnityDependencyResolver(container);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
