using FashionShop.Data.EF;
using FashionShop.ViewModels.Catalog.Categories;
using Microsoft.EntityFrameworkCore;

namespace FahionShop.Application.Catalog.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly FashionShopDbContext _context;

        public CategoryService(FashionShopDbContext context)
        {
            _context = context;
        }

        public async Task<List<CategoryVm>> GetAll()
        {
            var query = from c in _context.Categories
                        select new { c };
            return await query.Select(x => new CategoryVm()
            {
                Id = x.c.Id,
                CategoryName = x.c.CategoryName,
            }).ToListAsync();
        }

        public async Task<CategoryVm> GetById( int id)
        {
            var query = from c in _context.Categories                       
                        where  c.Id == id
                        select new { c };
            return await query.Select(x => new CategoryVm()
            {
                Id = x.c.Id,
                CategoryName = x.c.CategoryName
            }).FirstOrDefaultAsync();
        }
    }
}