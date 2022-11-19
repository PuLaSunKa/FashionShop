using FashionShop.ApiIntegration;
using FashionShop.Utilities.Constants;
using FashionShop.ViewModels.Catalog.Categories;
using FashionShop.ViewModels.Catalog.Products;
using FashionShop.ViewModels.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace FashionShop.AdminApp.Controllers
{
    public class CategoryController : Controller
    {       
        private readonly IConfiguration _configuration;

        private readonly ICategoryApiClient _categoryApiClient;

        public CategoryController(
            IConfiguration configuration,
            ICategoryApiClient categoryApiClient)
        {
            _configuration = configuration;
            _categoryApiClient = categoryApiClient;
        }
        public async Task<IActionResult> Index(int pageIndex = 1, int pageSize = 10)
        {
            var languageId = HttpContext.Session.GetString(SystemConstants.AppSettings.DefaultLanguageId);

            var request = new GetCategoryPagingRequest()
            {               
                PageIndex = pageIndex,
                PageSize = pageSize,
                LanguageId = languageId,
            };
            var data = await _categoryApiClient.GetPagings(request);

            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            return View(data);
        }
    }
}
