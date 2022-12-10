using FashionShop.Utilities.Constants;
using FashionShop.ViewModels.Catalog.Carts;
using FashionShop.ViewModels.Catalog.Posts;
using FashionShop.ViewModels.Catalog.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.ApiIntegration
{
    public class CartApiClient : BaseApiClient, ICartApiClient
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        public CartApiClient(IHttpClientFactory httpClientFactory,
                   IHttpContextAccessor httpContextAccessor,
                    IConfiguration configuration)
            : base(httpClientFactory, httpContextAccessor, configuration)
        {
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<bool> CreateCart(CartCreateRequest request)
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
            requestContent.Add(new StringContent(request.Quantity.ToString()), "quantity");
            requestContent.Add(new StringContent(request.Price.ToString()), "price");
            requestContent.Add(new StringContent(request.ProductId.ToString()), "productId");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.LanguageId) ? "" : request.LanguageId.ToString()), "languageId");

            var response = await client.PostAsync($"/api/carts/", requestContent);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteCart(int CartId)
        {
            return await Delete($"/api/carts/" + CartId);
        }

        public async Task<List<CartVm>> GetAllByUserId(string languageId, string userId)
        {
            var data = await GetListAsync<CartVm>($"/api/carts/user/{userId}/{languageId}/");
            return data;
        }

        public async Task<CartVm> FindCartByProductIdOfUser(string languageId, string userId, int productId)
        {
            return  await GetAsync<CartVm>($"/api/carts/user/{userId}/product/{productId}/{languageId}/");
        }

        public async Task<CartVm> GetById(string languageId, int id)
        {
            return await GetAsync<CartVm>($"/api/carts/{id}/{languageId}");
        }

        public async Task<bool> UpdateCart(CartUpdateRequest request)
        {
            var sessions = _httpContextAccessor
                .HttpContext
                .Session
                .GetString(SystemConstants.AppSettings.Token);

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var requestContent = new MultipartFormDataContent();
            requestContent.Add(new StringContent(request.Quantity.ToString()), "quantity");

            var response = await client.PutAsync($"/api/carts/" + request.Id, requestContent);
            return response.IsSuccessStatusCode;
        }
    }
}
