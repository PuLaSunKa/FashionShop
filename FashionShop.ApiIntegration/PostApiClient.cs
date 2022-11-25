using FashionShop.Utilities.Constants;
using FashionShop.ViewModels.Catalog.Categories;
using FashionShop.ViewModels.Catalog.Posts;
using FashionShop.ViewModels.Common;
using FashionShop.ViewModels.System.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.ApiIntegration
{
    public class PostApiClient : BaseApiClient, IPostApiClient
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        public PostApiClient(IHttpClientFactory httpClientFactory,
                   IHttpContextAccessor httpContextAccessor,
                    IConfiguration configuration)
            : base(httpClientFactory, httpContextAccessor, configuration)
        {
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }
        public async Task<bool> CreatePost(PostCreateRequest request)
        {
            var sessions = _httpContextAccessor
                .HttpContext
            .Session
                .GetString(SystemConstants.AppSettings.Token);           
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var requestContent = new MultipartFormDataContent();

            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.UserId) ? "" : request.UserId.ToString()), "userId");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.Author) ? "" : request.Author.ToString()), "author");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.Title) ? "" : request.Title.ToString()), "title");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.Description) ? "" : request.Description.ToString()), "description");
            requestContent.Add(new StringContent(request.DateCreate.ToString()), "dateCreate");

            var response = await client.PostAsync($"/api/posts/", requestContent);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeletePost(int PostId)
        {
            return await Delete($"/api/posts/" + PostId);
        }

        public async Task<List<PostVm>> GetAll()
        {
            return await GetListAsync<PostVm>("/api/posts/");
        }

        public async Task<PostVm> GetById( int id)
        {          
            return await GetAsync<PostVm>($"/api/posts/{id}/");
        }

        public async Task<PagedResult<PostVm>> GetPagings(PagingRequestBase request)
        {
            var data = await GetAsync<PagedResult<PostVm>>(
                $"/api/posts/paging?pageIndex={request.PageIndex}" +
                $"&pageSize={request.PageSize}");

            return data;
        }

        public async Task<bool> UpdatePost(PostUpdateRequest request)
        {
            var sessions = _httpContextAccessor
                .HttpContext
                .Session
                .GetString(SystemConstants.AppSettings.Token);

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var requestContent = new MultipartFormDataContent();      
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.Title) ? "" : request.Title.ToString()), "title");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.Description) ? "" : request.Description.ToString()), "description");
           
            var response = await client.PutAsync($"/api/posts/" + request.Id, requestContent);
            return response.IsSuccessStatusCode;
        }
    }
}
