using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace FashionShop.ViewModels.Catalog.Products
{
    public class ProductUpdateRequest
    {
        public int Id { get; set; }
        public string? Name { set; get; }

        public string? Description { set; get; }
        public string? Details { set; get; }      
        public string? LanguageId { set; get; }
        public bool? IsFeatured { get; set; }

        public IFormFile ThumbnailImage { get; set; }
    }
}