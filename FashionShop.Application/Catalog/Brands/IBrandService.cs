using FashionShop.ViewModels.Catalog.Brands;

namespace FashionShop.Application.Catalog.Brands
{
    public interface IBrandService
    {
        Task<List<BrandVm>> GetAll();

        Task<BrandVm> GetById(int id);
    }
}
