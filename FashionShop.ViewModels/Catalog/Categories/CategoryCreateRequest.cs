using FashionShop.Data.Enums;
using FashionShop.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.ViewModels.Catalog.Categories
{
    public class CategoryCreateRequest
    {
        public bool IsShowOnHome { set; get; }

        [Required(ErrorMessage = "Bạn phải nhập tên loại sản phẩm")]
        public string? Name { set; get; }
        public string? LanguageId { set; get; }

    }
}
