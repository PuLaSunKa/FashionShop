using FashionShop.ViewModels.Catalog.Categories;
using FashionShop.ViewModels.Catalog.Posts;
using FashionShop.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.ApiIntegration
{
    public interface IPostApiClient
    {
        Task<List<PostVm>> GetAll();

        Task<PostVm> GetById(int id);

        Task<bool> CreatePost(PostCreateRequest request);

        Task<bool> UpdatePost(PostUpdateRequest request);

        Task<bool> DeletePost(int PostId);

        Task<PagedResult<PostVm>> GetPagings(PagingRequestBase request );
        Task<List<PostVm>> GetLatestPosts(int take);
    }
}
