using FashionShop.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.ViewModels.Catalog.Categories
{
    public class CategoryUpdateRequest
    {
        public int Id { get; set; }
        public bool IsShowOnHome { set; get; }  
        public string? Name { set; get; }       
        public string? LanguageId { set; get; }

    }
}
