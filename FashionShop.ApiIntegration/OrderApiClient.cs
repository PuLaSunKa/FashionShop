using FashionShop.Utilities.Constants;
using FashionShop.ViewModels.Catalog.Carts;
using FashionShop.ViewModels.Common;
using FashionShop.ViewModels.Sales;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace FashionShop.ApiIntegration
{
    public class OrderApiClient : BaseApiClient, IOrderApiClient
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        public OrderApiClient(IHttpClientFactory httpClientFactory,
                   IHttpContextAccessor httpContextAccessor,
                    IConfiguration configuration)
            : base(httpClientFactory, httpContextAccessor, configuration)
        {
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<bool> CreateOrder(OderCreateRequest request)
        {
            var sessions = _httpContextAccessor
                .HttpContext
                .Session
                .GetString(SystemConstants.AppSettings.Token);

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var requestContent = new MultipartFormDataContent();

            requestContent.Add(new StringContent(request.UserId.ToString()), "userId");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.Name) ? "" : request.Name.ToString()), "name");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.Address) ? "" : request.Address.ToString()), "address");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.Email) ? "" : request.Email.ToString()), "email");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.PhoneNumber) ? "" : request.PhoneNumber.ToString()), "phoneNumber");
            requestContent.Add(new StringContent(request.OrderDetails.ToString()), "orderDetails");
            var response = await client.PostAsync($"/api/Orders/", requestContent);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteOrder(int orderId)
        {
            return await Delete($"/api/Orders/" + orderId);
        }

        public async Task<List<OrderVm>> GetAll()
        {
            return await GetListAsync<OrderVm>("/api/Orders/");
        }

        public async Task<OrderVm> GetById(int id)
        {
            return await GetAsync<OrderVm>($"/api/Orders/{id}");
        }

        public async Task<PagedResult<OrderVm>> GetPagings(GetOrderPagingRequest request)
        {
            var data = await GetAsync<PagedResult<OrderVm>>(
                $"/api/Orders/paging?pageIndex={request.PageIndex}" +
                $"&pageSize={request.PageSize}");

            return data;
        }

        public async Task<bool> UpdateOrder(OrderUpdateRequest request)
        {
            var sessions = _httpContextAccessor
               .HttpContext
               .Session
               .GetString(SystemConstants.AppSettings.Token);

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var requestContent = new MultipartFormDataContent();

            requestContent.Add(new StringContent(request.Status.ToString()), "status");

            var response = await client.PutAsync($"/api/Orders/" + request.Id, requestContent);
            return response.IsSuccessStatusCode;
        }
    }
}
