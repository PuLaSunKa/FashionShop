using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.ViewModels.Catalog.Carts
{
    public class CartUpdateRequest
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
    }
}
