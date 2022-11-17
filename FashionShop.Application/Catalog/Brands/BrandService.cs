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
        public async Task<List<BrandVm>> GetAll(string languageId)
        {
            var query = from c in _context.Brands
                        join ct in _context.BrandTranslations on c.Id equals ct.BrandId
                        where ct.LanguageId == languageId
                        select new { c, ct };
            return await query.Select(x => new BrandVm()
            {
                Id = x.c.Id,
                Name = x.ct.Name,
            }).ToListAsync();
        }

        public async Task<BrandVm> GetById(string languageId, int id)
        {
            var query = from c in _context.Brands
                        join ct in _context.BrandTranslations on c.Id equals ct.BrandId
                        where ct.LanguageId == languageId && c.Id == id
                        select new { c, ct };
            return await query.Select(x => new BrandVm()
            {
                Id = x.c.Id,
                Name = x.ct.Name
            }).FirstOrDefaultAsync();
        }
    }
}
