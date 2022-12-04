using FashionShop.ViewModels.Catalog.Posts;
using FashionShop.ViewModels.Common;

namespace FashionShop.WebApp.Models
{
    public class PostViewModel
    {
        public PagedResult<PostVm> page { get; set; }
        public List<PostVm> LatestPosts { get; set; }
    }
}
