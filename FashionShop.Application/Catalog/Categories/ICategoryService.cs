using FashionShop.ViewModels.Catalog.Categories;

namespace FahionShop.Application.Catalog.Categories
{
    public interface ICategoryService
    {
        Task<List<CategoryVm>> GetAll();

        Task<CategoryVm> GetById(int id);
    }
}