using FashionShop.ViewModels.Catalog.Carts;
using FashionShop.ViewModels.Catalog.Posts;
using FashionShop.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.ApiIntegration
{
    public interface ICartApiClient 
    {       
        Task<List<CartVm>> GetAllByUserId(string languageId, string userId);

        Task<CartVm> FindCartByProductIdOfUser(string languageId, string userId, int productId);

        Task<CartVm> GetById(string languageId, int id);

        Task<bool> CreateCart(CartCreateRequest request);

        Task<bool> UpdateCart(CartUpdateRequest request);

        Task<bool> DeleteCart(int CartId);
    }
}
