﻿using FashionShop.ViewModels.Catalog.Products;
using FashionShop.ViewModels.Utilities.Slides;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FashionShop.WebApp.Models
{
    public class HomeViewModel
    {
        public List<SlideVm> Slides { get; set; }

        public List<ProductVm> FeaturedProducts { get; set; }

        public List<ProductVm> LatestProducts { get; set; }
    }
}