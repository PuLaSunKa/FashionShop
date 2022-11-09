using FashionShop.ApiIntegration;
using FashionShop.ViewModels.Catalog.Categories;
using FashionShop.ViewModels.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FashionShop.ApiIntegration
{
    public class CategoryApiClient : BaseApiClient, ICategoryApiClient
    {
        public CategoryApiClient(IHttpClientFactory httpClientFactory,
                   IHttpContextAccessor httpContextAccessor,
                    IConfiguration configuration)
            : base(httpClientFactory, httpContextAccessor, configuration)
        {
        }

        public async Task<List<CategoryVm>> GetAll()
        {
            return await GetListAsync<CategoryVm>("/api/categories?");
        }

        public async Task<CategoryVm> GetById( int id)
        {
            return await GetAsync<CategoryVm>($"/api/categories/{id}");
        }
    }
}