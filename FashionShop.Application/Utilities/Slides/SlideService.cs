using FashionShop.Application.System.Roles;
using FashionShop.Data.EF;
using FashionShop.Data.Entities;
using FashionShop.ViewModels.System.Roles;
using FashionShop.ViewModels.Utilities.Slides;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.Application.Utilities.Slides
{
    public class SlideService : ISlideService
    {
        private readonly FashionShopDbContext _context;

        public SlideService(FashionShopDbContext context)
        {
            _context = context;
        }

        public async Task<List<SlideVm>> GetAll()
        {
            var slides = await _context.Slides.OrderBy(x => x.SortOrder)
                .Select(x => new SlideVm()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Url = x.Url,
                    Image = x.Image
                }).ToListAsync();

            return slides;
        }
    }
}