using FashionShop.ViewModels.Catalog.Products;

namespace FashionShop.WebApp.Models
{
    public class HomeViewModel
    {
        public List<ProductVm>? FeaturedProducts { get; set; }

        public List<ProductVm>? LatestProducts { get; set; }
    }
}