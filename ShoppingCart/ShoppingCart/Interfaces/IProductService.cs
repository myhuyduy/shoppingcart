using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Interfaces
{
    using ShoppingCart.Models;

    public interface IProductService
    {
        Product Get(string id);
    }
}
