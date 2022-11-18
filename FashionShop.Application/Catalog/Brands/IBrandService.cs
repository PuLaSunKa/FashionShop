using FashionShop.ViewModels.Catalog.Brands;
using FashionShop.ViewModels.Catalog.Categories;

namespace FashionShop.Application.Catalog.Brands
{
    public interface IBrandService
    {
        Task<List<BrandVm>> GetAll(string languageId);

        Task<BrandVm> GetById(string languageId, int id);
        Task<int> Create(BrandCreateRequest request);

        Task<int> Update(BrandUpdateRequest request);

        Task<int> Delete(int CategoryId);
    }
}
