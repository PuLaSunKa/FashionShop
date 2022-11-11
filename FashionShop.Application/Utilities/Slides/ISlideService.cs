using FashionShop.ViewModels.System.Roles;
using FashionShop.ViewModels.Utilities.Slides;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.Application.Utilities.Slides
{
    public interface ISlideService
    {
        Task<List<SlideVm>> GetAll();
    }
}