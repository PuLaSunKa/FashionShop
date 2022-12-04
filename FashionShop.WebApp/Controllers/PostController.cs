using FashionShop.ApiIntegration;
using FashionShop.Utilities.Constants;
using FashionShop.ViewModels.Common;
using FashionShop.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace FashionShop.WebApp.Controllers
{
    public class PostController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IUserApiClient _userApiClient;
        private readonly IPostApiClient _postApiClient;


        public PostController(IUserApiClient userApiClient,
            IConfiguration configuration,
            IPostApiClient postApiClient)
        {
            _userApiClient = userApiClient;
            _configuration = configuration;
            _postApiClient = postApiClient;
        }
        public async Task<IActionResult> Index(int pageIndex = 1, int pageSize = 10)
        {
            var culture = CultureInfo.CurrentCulture.Name;

            var request = new PagingRequestBase()
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
            };
            var data = await _postApiClient.GetPagings(request); 

            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            return View(data);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var result = await _postApiClient.GetById(id);
            return View(result);
        }
    }
}
