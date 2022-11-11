using FashionShop.Data.EF;
using FashionShop.Data.Entities;
using FashionShop.ViewModels.Common;
using FashionShop.ViewModels.System.Languages;
using FashionShop.ViewModels.System.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.Application.System.Languages
{
    public class LanguageService : ILanguageService
    {
        private readonly IConfiguration _config;
        private readonly FashionShopDbContext _context;

        public LanguageService(FashionShopDbContext context,
            IConfiguration config)
        {
            _config = config;
            _context = context;
        }

        public async Task<ApiResult<List<LanguageVm>>> GetAll()
        {
            var languages = await _context.Languages.Select(x => new LanguageVm()
            {
                Id = x.Id,
                Name = x.Name,
                IsDefault = x.IsDefault
            }).ToListAsync();
            return new ApiSuccessResult<List<LanguageVm>>(languages);
        }
    }
}