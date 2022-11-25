using FashionShop.Data.EF;
using FashionShop.Data.Entities;
using FashionShop.Utilities.Constants;
using FashionShop.Utilities.Exceptions;
using FashionShop.ViewModels.Catalog.Categories;
using FashionShop.ViewModels.Catalog.Posts;
using FashionShop.ViewModels.Common;
using FashionShop.ViewModels.System.Languages;
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
                UserId = Guid.Parse(request.UserId),
                Author = request.Author
            };
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();
            return post.Id;
        }

        public async Task<int> Delete(int PostId)
        {
            var post = await _context.Posts.FindAsync(PostId);
            if (post == null) throw new FashionShopException($"Cannot find a post: {PostId}");
            _context.Posts.Remove(post);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<PostVm>> GetAll()
        {
            var query = from c in _context.Posts                     
                        select new { c };          
            return await query.Select(x => new PostVm()
            {
                Id = x.c.Id,
                Title = x.c.Title,
                Description = x.c.Description,
                DateCreate = x.c.DateCreate,
                UserId = x.c.UserId.ToString(),
                Author = x.c.Author
            }).ToListAsync();
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
                    Author = x.c.Author
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

        public async Task<PostVm> GetById(int id)
        {
            var query = from c in _context.Posts                      
                        where  c.Id == id
                        select new { c };
            return await query.Select(x => new PostVm()
            {
                Id = x.c.Id,
                Title = x.c.Title,
                Description = x.c.Description,
                DateCreate = x.c.DateCreate,
                UserId = x.c.UserId.ToString(),
                Author =x.c.Author
            }).FirstOrDefaultAsync();
        }

        public async Task<int> Update(PostUpdateRequest request)
        {
            var post = await _context.Posts.FindAsync(request.Id);         

            if (post == null) throw new FashionShopException($"Cannot find a post with id: {request.Id}");

            post.Title = request.Title;
            post.Description = request.Description;
            return await _context.SaveChangesAsync();
        }
    }
}
