using FashionShop.ViewModels.Catalog.Products;
using FashionShop.ViewModels.Common;
using FashionShop.ViewModels.System.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FashionShop.ApiIntegration
{
    public interface IProductApiClient
    {
        Task<PagedResult<ProductVm>> GetPagings(GetManageProductPagingRequest request);

        Task<bool> CreateProduct(ProductCreateRequest request);

        Task<bool> UpdateProduct(ProductUpdateRequest request);

        Task<ApiResult<bool>> CategoryAssign(int id, CategoryAssignRequest request);

        Task<ProductVm> GetById(int id);

        Task<List<ProductVm>> GetFeaturedProducts( int take);

        Task<List<ProductVm>> GetLatestProducts( int take);

        Task<bool> DeleteProduct(int id);
    }
}