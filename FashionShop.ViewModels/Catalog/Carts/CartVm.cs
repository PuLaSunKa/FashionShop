using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.ViewModels.Catalog.Carts
{
    public class CartVm
    {
        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public string? Description { get; set; }

        public string? Name { get; set; }

        public string? Image { get; set; }

        public decimal Price { get; set; }
    }
}
