using FashionShop.Data.EF;
using FashionShop.Data.Entities;
using FashionShop.Utilities.Constants;
using FashionShop.Utilities.Exceptions;
using FashionShop.ViewModels.Catalog.Brands;
using FashionShop.ViewModels.Catalog.Categories;
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
        public async Task<int> Create(BrandCreateRequest request)
        {
            var languages = _context.Languages;
            var translations = new List<BrandTranslation>();
            foreach (var language in languages)
            {
                if (language.Id == request.LanguageId)
                {
                    translations.Add(new BrandTranslation()
                    {
                        Name = request.Name,
                        LanguageId = request.LanguageId
                    });
                }
                else
                {
                    translations.Add(new BrandTranslation()
                    {
                        Name = SystemConstants.CategoryConstants.NA,
                        LanguageId = language.Id
                    });
                }
            }
            var brand = new Brand()
            {
                IsShowOnHome = request.IsShowOnHome,
                BrandTranslations = translations
            };
            _context.Brands.Add(brand);
            await _context.SaveChangesAsync();
            return brand.Id;
        }
        public async Task<int> Delete(int BrandId)
        {
            var brand = await _context.Brands.FindAsync(BrandId);
            if (brand == null) throw new FashionShopException($"Cannot find a brand: {BrandId}");

            _context.Brands.Remove(brand);

            return await _context.SaveChangesAsync();
        }
        public async Task<int> Update(BrandUpdateRequest request)
        {
            var brand = await _context.Brands.FindAsync(request.Id);
            var brandTranslations = await _context.BrandTranslations.FirstOrDefaultAsync(x => x.BrandId == request.Id
            && x.LanguageId == request.LanguageId);

            if (brand == null || brandTranslations == null) throw new FashionShopException($"Cannot find a brand with id: {request.Id}");

            brandTranslations.Name = request.Name;
            brand.IsShowOnHome = request.IsShowOnHome;

            return await _context.SaveChangesAsync();
        }
    }
}
