using FashionShop.ViewModels.Catalog.Categories;
using FashionShop.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FashionShop.ApiIntegration
{
    public interface ICategoryApiClient
    {
        Task<List<CategoryVm>> GetAll();

        Task<CategoryVm> GetById( int id);
    }
}