using FashionShop.ViewModels.Catalog.Carts;
using FashionShop.ViewModels.Catalog.Categories;
using FashionShop.ViewModels.Catalog.Products;
using FashionShop.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.Application.Catalog.Carts
{
    public interface ICartService
    {
        Task<List<CartVm>> GetAllByUserId(string languageId, string userId);

        Task<CartVm> FindCartByProductIdOfUser(string languageId, string userId, int productId);

        Task<CartVm> GetById(string languageId, int id);

        Task<int> Create(CartCreateRequest request);

        Task<int> Update(CartUpdateRequest request);

        Task<int> Delete(int CartId);


    }
}
