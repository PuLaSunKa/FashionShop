using FashionShop.ViewModels.Catalog.ProductImages;
using FashionShop.ViewModels.Catalog.Products;
using FashionShop.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductUpdateRequest = FashionShop.ViewModels.Catalog.Products.ProductUpdateRequest;

namespace FashionShop.Application.Catalog.Products
{
    public interface IProductService
    {
        Task<int> Create(ProductCreateRequest request);

        Task<int> Update(ProductUpdateRequest request);

        Task<int> Delete(int productId);

        Task<ProductVm> GetById(int productId);

        Task<bool> UpdatePrice(int productId, decimal newPrice);

        Task<bool> UpdateStock(int productId, int addedQuantity);

        Task<PagedResult<ProductVm>> GetAllPaging(GetManageProductPagingRequest request);

        Task<int> AddImage(int productId, ProductImageCreateRequest request);

        Task<int> RemoveImage(int imageId);

        Task<int> UpdateImage(int imageId, ProductImageUpdateRequest request);

        Task<ProductImageViewModel> GetImageById(int imageId);

        Task<List<ProductImageViewModel>> GetListImages(int productId);

        Task<PagedResult<ProductVm>> GetAllByCategoryId(GetPublicProductPagingRequest request);

        Task<ApiResult<bool>> CategoryAssign(int id, CategoryAssignRequest request);

        Task<List<ProductVm>> GetFeaturedProducts( int take);

        Task<List<ProductVm>> GetLatestProducts( int take);
    }
}
