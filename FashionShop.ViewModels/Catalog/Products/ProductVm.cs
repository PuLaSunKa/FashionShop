using FashionShop.ViewModels.Catalog.Categories;
using System;
using System.Collections.Generic;
using System.Text;

namespace FashionShop.ViewModels.Catalog.Products
{
    public class ProductVm
    {
        public int Id { set; get; }
        public string ProductName { set; get; }
        public decimal Price { set; get; }
        public int QuantityInStock { set; get; }
        public DateTime DateCreate { set; get; }
        public string Description { set; get; }
        public bool? IsFeatured { get; set; }
        public string ThumbnailImage { get; set; }

        public List<string> Categories { get; set; } = new List<string>();
    }
}