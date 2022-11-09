using FashionShop.ApiIntegration;
using FashionShop.ViewModels.Utilities.Posts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace FashionShop.ApiIntegration

{
    public class PostApiClient : BaseApiClient, IPostApiClient
    {
        public PostApiClient(IHttpClientFactory httpClientFactory,
                   IHttpContextAccessor httpContextAccessor,
                    IConfiguration configuration)
            : base(httpClientFactory, httpContextAccessor, configuration)
        {
        }

        public async Task<List<PostVm>> GetAll()
        {
            return await GetListAsync<PostVm>("/api/posts");
        }
    }
}