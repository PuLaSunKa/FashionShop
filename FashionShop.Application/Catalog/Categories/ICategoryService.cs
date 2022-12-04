using FashionShop.ViewModels.Catalog.Categories;
using FashionShop.ViewModels.Catalog.Products;
using FashionShop.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.Application.Catalog.Categories
{
    public interface ICategoryService
    {
        Task<List<CategoryVm>> GetAll(string languageId);

        Task<CategoryVm> GetById(string languageId, int id);

        Task<int> Create(CategoryCreateRequest request);

        Task<int> Update(CategoryUpdateRequest request);

        Task<int> Delete(int CategoryId);

        Task<PagedResult<CategoryVm>> GetAllPaging(GetCategoryPagingRequest request);
    }
}