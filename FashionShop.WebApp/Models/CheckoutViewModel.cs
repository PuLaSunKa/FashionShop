using FashionShop.ViewModels.Catalog.Carts;
using FashionShop.ViewModels.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FashionShop.WebApp.Models
{
    public class CheckoutViewModel
    {
        public List<CartVm>? CartItems { get; set; }

        public CheckoutRequest CheckoutModel { get; set; }
    }
}