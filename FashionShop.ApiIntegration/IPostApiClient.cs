using FashionShop.ViewModels.Utilities.Posts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FashionShop.ApiIntegration


{
    public interface IPostApiClient
    {
        Task<List<PostVm>> GetAll();
    }
}