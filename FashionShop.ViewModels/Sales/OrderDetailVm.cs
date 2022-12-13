using System;
using System.Collections.Generic;
using System.Text;

namespace FashionShop.ViewModels.Sales
{
    public class OrderDetailVm
    {
        public int OrderId { set; get; }
        public int ProductId { set; get; }
        public int Quantity { set; get; }
        public decimal Price { set; get; }
    }
}