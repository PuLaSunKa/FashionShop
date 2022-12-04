using FashionShop.Data.Enums;
using FashionShop.Utilities.Constants;
using FashionShop.ViewModels.Catalog.Posts;
using FashionShop.ViewModels.Common;
using FashionShop.ViewModels.Utilities;
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
    public class ContactApiClient : BaseApiClient, IContactApiClient
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        public ContactApiClient(IHttpClientFactory httpClientFactory,
                   IHttpContextAccessor httpContextAccessor,
                    IConfiguration configuration)
            : base(httpClientFactory, httpContextAccessor, configuration)
        {
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }
        public async Task<bool> CreateContact(ContactCreateRequest request)
        {
            var sessions = _httpContextAccessor
                .HttpContext
            .Session
                .GetString(SystemConstants.AppSettings.Token);
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var requestContent = new MultipartFormDataContent();

            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.Name) ? "" : request.Name.ToString()), "name");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.Email) ? "" : request.Email.ToString()), "email");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.PhoneNumber) ? "" : request.PhoneNumber.ToString()), "phoneNumber");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.Message) ? "" : request.Message.ToString()), "message");
            requestContent.Add(new StringContent(request.Status.ToString()), "status");

            var response = await client.PostAsync($"/api/contacts/", requestContent);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteContact(int ContactId)
        {
            return await Delete($"/api/contacts/" + ContactId);
        }

        public async Task<List<ContactVm>> GetAll()
        {
            return await GetListAsync<ContactVm>("/api/contacts/");
        }

        public async Task<ContactVm> GetById(int id)
        {
            return await GetAsync<ContactVm>($"/api/contacts/{id}/");
        }

        public async Task<PagedResult<ContactVm>> GetPagings(PagingRequestBase request)
        {
            var data = await GetAsync<PagedResult<ContactVm>>(
                $"/api/contacts/paging?pageIndex={request.PageIndex}" +
                $"&pageSize={request.PageSize}");

            return data;
        }

        public async Task<bool> UpdateContact(ContactUpdateRequest request)
        {
            var sessions = _httpContextAccessor
                .HttpContext
                .Session
                .GetString(SystemConstants.AppSettings.Token);
            request.Status = Status.Active;
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var requestContent = new MultipartFormDataContent();

            requestContent.Add(new StringContent(request.Status.ToString()), "status");
            var response = await client.PutAsync($"/api/contacts/" + request.Id, requestContent);
            return response.IsSuccessStatusCode;
        }
    }
}
