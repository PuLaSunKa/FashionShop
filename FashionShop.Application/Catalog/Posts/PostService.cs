using FashionShop.Data.EF;
using FashionShop.Data.Entities;
using FashionShop.Utilities.Constants;
using FashionShop.ViewModels.Catalog.Categories;
using FashionShop.ViewModels.Catalog.Posts;
using FashionShop.ViewModels.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.Application.Catalog.Posts
{
    public class PostService : IPostService
    {
        private readonly FashionShopDbContext _context;
        public PostService(FashionShopDbContext context)
        {
            _context = context;
        }
        public async Task<int> Create(PostCreateRequest request)
        {                       
            var post = new Post()
            {
                Title= request.Title,
                Description= request.Description,
                DateCreate= DateTime.Now,
                UserId = Guid.Parse(request.UserId)
            };
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();
            return post.Id;
        }

        public Task<int> Delete(int PostId)
        {
            throw new NotImplementedException();
        }

        public Task<List<PostVm>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<PagedResult<PostVm>> GetAllPaging(PagingRequestBase request)
        {
            var query = from c in _context.Posts                                           
                        select new { c };
            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new PostVm()
                {
                    Id = x.c.Id,
                    Title= x.c.Title,
                    Description= x.c.Description,
                    DateCreate= x.c.DateCreate,
                    UserId = x.c.UserId.ToString(),
                }).ToListAsync();

            //4. Select and projection
            var pagedResult = new PagedResult<PostVm>()
            {
                TotalRecords = totalRow,
                PageSize = request.PageSize,
                PageIndex = request.PageIndex,
                Items = data
            };
            return pagedResult;
        }

        public Task<PostVm> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(PostUpdateRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
