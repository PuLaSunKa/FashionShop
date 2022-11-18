using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.ViewModels.Catalog.Brands
{
    public class BrandUpdateRequest
    {
        public int Id { get; set; }
        public bool IsShowOnHome { set; get; }     
        public string? Name { set; get; }
        public string? LanguageId { set; get; }
    }
}
