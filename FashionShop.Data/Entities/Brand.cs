using FashionShop.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.Data.Entities
{
    public class Brand
    {
        public int Id { get; set; }
        public string BrandName { get; set; }
        public string? Image{ get; set; }
        public Status Status { get; set; }
        public List<ProductInBrand> ProductInBrands { get; set; }
    }
}
