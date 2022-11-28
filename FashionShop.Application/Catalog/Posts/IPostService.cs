using FashionShop.ViewModels.Catalog.Categories;
using FashionShop.ViewModels.Catalog.Posts;
using FashionShop.ViewModels.Catalog.Products;
using FashionShop.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.Application.Catalog.Posts
{
    public interface IPostService
    {
        Task<List<PostVm>> GetAll();

        Task<PostVm> GetById(int id);

        Task<int> Create(PostCreateRequest request);

        Task<int> Update(PostUpdateRequest request);

        Task<int> Delete(int PostId);

        Task<PagedResult<PostVm>> GetAllPaging(PagingRequestBase request);
        Task<List<PostVm>> GetLatestPosts(int take);
    }
}
