using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FashionShop.ViewModels.Catalog.Products
{
    public class ProductCreateRequest
    {
        public decimal Price { set; get; }
        public decimal OriginalPrice { set; get; }
        public int Stock { set; get; }

        [Required(ErrorMessage = "Bạn phải nhập tên sản phẩm")]
        public string? Name { set; get; }

        public string? Description { set; get; }
        public string? Details { set; get; }
        
        public string? LanguageId { set; get; }

        public bool? IsFeatured { get; set; }

        public IFormFile? ThumbnailImage { get; set; }
    }
}