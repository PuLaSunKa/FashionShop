using FashionShop.ViewModels.Utilities.Posts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.Application.Utilities.Posts
{
    public interface IPostService
    {
        Task<List<PostVm>> GetAll();
    }
}