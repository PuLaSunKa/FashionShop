using FashionShop.Data.EF;
using FashionShop.ViewModels.Utilities.Posts;
using Microsoft.EntityFrameworkCore;

namespace FashionShop.Application.Utilities.Posts
{
    public class PostService : IPostService
    {
        private readonly FashionShopDbContext _context;

        public PostService(FashionShopDbContext context)
        {
            _context = context;
        }

        public async Task<List<PostVm>> GetAll()
        {
            var posts = await _context.Posts.OrderBy(x => x.SortOrder)
                .Select(x => new PostVm()
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description,
                    Url = x.Url,
                    Image = x.Image
                }).ToListAsync();

            return posts;
        }
    }
}