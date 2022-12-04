using FashionShop.ViewModels.Catalog.Products;
using FashionShop.ViewModels.Catalog.Posts;
using FashionShop.ViewModels.Common;

namespace FashionShop.WebApp.Models
{
    public class HomeViewModel
    {
        public List<ProductVm>? AllProducts { get; set; }

        public List<ProductVm>? FeaturedProducts { get; set; }

        public List<ProductVm>? LatestProducts { get; set; }

        public List<PostVm>? LatestPosts { get; set; }
    }
}