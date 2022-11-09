using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FashionShop.ViewModels.Catalog.Products
{
    public class ProductCreateRequest
    {
        [Required(ErrorMessage = "Bạn phải nhập tên sản phẩm")]
        public string ProductName { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int QuantityInStock { get; set; }
        public DateTime DateCreate { get; set; }
        public bool? IsFeatured { get; set; }

        public IFormFile ThumbnailImage { get; set; }
    }
}