using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.ViewModels.Catalog.Carts
{
    public class CartCreateRequest
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string? UserId { get; set; }
        public string? LanguageId { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
