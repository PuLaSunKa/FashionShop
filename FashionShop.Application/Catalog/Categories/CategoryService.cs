using FashionShop.Data.EF;
using FashionShop.ViewModels.Catalog.Categories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using FashionShop.Data.Entities;
using FashionShop.Utilities.Constants;
using FashionShop.Application.Common;
using FashionShop.Utilities.Exceptions;
using FashionShop.ViewModels.Catalog.Products;

namespace FashionShop.Application.Catalog.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly FashionShopDbContext _context;

        public CategoryService(FashionShopDbContext context)
        {
            _context = context;
        }

        public async Task<int> Create(CategoryCreateRequest request)
        {
            var languages = _context.Languages;
            var translations = new List<CategoryTranslation>();
            foreach (var language in languages)
            {
                if (language.Id == request.LanguageId)
                {
                    translations.Add(new CategoryTranslation()
                    {
                        Name = request.Name,                       
                        LanguageId = request.LanguageId
                    });
                }
                else
                {
                    translations.Add(new CategoryTranslation()
                    {
                        Name = SystemConstants.CategoryConstants.NA,                       
                        LanguageId = language.Id
                    });
                }
            }
            var category = new Category()
            {                
                IsShowOnHome = request.IsShowOnHome,
                CategoryTranslations = translations
            };
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return category.Id;
        }
        public async Task<int> Delete(int CategoryId)
        {
            var category = await _context.Categories.FindAsync(CategoryId);
            if (category == null) throw new FashionShopException($"Cannot find a category: {CategoryId}");

            _context.Categories.Remove(category);

            return await _context.SaveChangesAsync();
        }

        public async Task<List<CategoryVm>> GetAll(string languageId)
        {
            var query = from c in _context.Categories
                        join ct in _context.CategoryTranslations on c.Id equals ct.CategoryId
                        where ct.LanguageId == languageId
                        select new { c, ct };
            return await query.Select(x => new CategoryVm()
            {
                Id = x.c.Id,
                Name = x.ct.Name,
            }).ToListAsync();
        }

        public async Task<CategoryVm> GetById(string languageId, int id)
        {
            var query = from c in _context.Categories
                        join ct in _context.CategoryTranslations on c.Id equals ct.CategoryId
                        where ct.LanguageId == languageId && c.Id == id
                        select new { c, ct };
            return await query.Select(x => new CategoryVm()
            {
                Id = x.c.Id,
                Name = x.ct.Name,
            }).FirstOrDefaultAsync();
        }

        public async Task<int> Update(CategoryUpdateRequest request)
        {
            var category = await _context.Categories.FindAsync(request.Id);
            var categoryTranslations = await _context.CategoryTranslations.FirstOrDefaultAsync(x => x.CategoryId == request.Id
            && x.LanguageId == request.LanguageId);

            if (category == null || categoryTranslations == null) throw new FashionShopException($"Cannot find a category with id: {request.Id}");

            categoryTranslations.Name = request.Name;   

            return await _context.SaveChangesAsync();
        }
    }
}