using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.Data.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int QuantityInStock { get; set; }
        public DateTime DateCreate { get; set; }
        public bool? IsFeatured { get; set; }
        public List<ProductInCategory> ProductInCategories { get; set; }
        public List<ProductInBrand> ProductInBrands { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }

        public List<Cart> Carts { get; set; }

        public List<ProductImage> ProductImages { get; set; }
    }
}
