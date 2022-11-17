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
        public int Id { set; get; }
        public bool IsShowOnHome { set; get; }     
        public List<ProductInBrand>? ProductInBrands { get; set; }

        public List<BrandTranslation>? BrandTranslations { get; set; }

    }
}
