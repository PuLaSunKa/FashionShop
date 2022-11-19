using FashionShop.ViewModels.Catalog.Categories;
using FashionShop.ViewModels.Catalog.Products;
using FashionShop.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FashionShop.ApiIntegration
{
    public interface ICategoryApiClient
    {
        Task<List<CategoryVm>> GetAll(string languageId);

        Task<CategoryVm> GetById(string languageId, int id);

        Task<bool> CreateCategory(CategoryCreateRequest request);

        Task<bool> UpdateCategory(CategoryUpdateRequest request);

        Task<bool> DeleteCategory(int CategoryId);

        Task<PagedResult<CategoryVm>> GetPagings(GetCategoryPagingRequest request);
    }
}