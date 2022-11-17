using FashionShop.Data.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.ViewModels.Catalog.Brands
{
    public class BrandCreateRequest
    {

        public bool IsShowOnHome { set; get; }

        [Required(ErrorMessage = "Bạn phải nhập tên thương hiệu")]
        public string? Name { set; get; }
        public string? LanguageId { set; get; }
    }
}
