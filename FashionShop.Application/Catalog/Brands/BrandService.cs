using FahionShop.Application.Catalog.Categories;
using FashionShop.Data.EF;
using FashionShop.ViewModels.Catalog.Brands;
using Microsoft.EntityFrameworkCore;

namespace FashionShop.Application.Catalog.Brands
{
    public class BrandService : IBrandService
    {
        private readonly FashionShopDbContext _context;

        public BrandService(FashionShopDbContext context)
        {
            _context = context;
        }

        public async Task<List<BrandVm>> GetAll()
        {
            var query = from b in _context.Brands
                        select new { b };
            return await query.Select(x => new BrandVm()
            {
                Id = x.b.Id,
                BrandName = x.b.BrandName,
            }).ToListAsync();
        }

        public async Task<BrandVm> GetById(int id)
        {
            var query = from c in _context.Brands
                        where c.Id == id
                        select new { c };
            return await query.Select(x => new BrandVm()
            {
                Id = x.c.Id,
                BrandName = x.c.BrandName
            }).FirstOrDefaultAsync();
        }
    }
}
