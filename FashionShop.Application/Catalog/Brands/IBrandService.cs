using FashionShop.ViewModels.Catalog.Brands;

namespace FashionShop.Application.Catalog.Brands
{
    public interface IBrandService
    {
        Task<List<BrandVm>> GetAll(string languageId);

        Task<BrandVm> GetById(string languageId, int id);
    }
}
