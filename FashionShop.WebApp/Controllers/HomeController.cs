using FashionShop.ApiIntegration;
using FashionShop.Utilities.Constants;
using FashionShop.ViewModels.Utilities;
using FashionShop.WebApp.Models;
using LazZiya.ExpressLocalization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Globalization;

namespace FashionShop.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISharedCultureLocalizer _loc;
        private readonly IProductApiClient _productApiClient;
        private readonly IConfiguration _configuration;
        private readonly IContactApiClient _contactApiClient;
        private readonly IPostApiClient _postApiClient;

        public HomeController(ILogger<HomeController> logger,
            IProductApiClient productApiClient,
            IConfiguration configuration,
            IContactApiClient contactApiClient)
        {
            _logger = logger;
            _productApiClient = productApiClient;
            _configuration = configuration;
            _contactApiClient = contactApiClient;
        }

        public async Task<IActionResult> Index()
        {
            var culture = CultureInfo.CurrentCulture.Name;
            var viewModel = new HomeViewModel
            {
                FeaturedProducts = await _productApiClient.GetFeaturedProducts(culture, SystemConstants.ProductSettings.NumberOfFeaturedProducts),
                LatestProducts = await _productApiClient.GetLatestProducts(culture, SystemConstants.ProductSettings.NumberOfLatestProducts),
                LatestPosts = await _postApiClient.GetLatestPosts(culture, SystemConstants.PostSettings.NumberOfLatestPosts),
            };

            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult SetCultureCookie(string cltr, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(cltr)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
                );

            return LocalRedirect(returnUrl);
        }

        public IActionResult About()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Contact([FromForm] ContactCreateRequest request)
        {
            if (!ModelState.IsValid)
                return View(request);
            var result = await _contactApiClient.CreateContact(request);
            if (result)
            {
                TempData["result"] = "Thêm liên hệ thành công";
                return RedirectToAction("Contact");
            }

            ModelState.AddModelError("", "Thêm liên hệ thất bại");
            return View(request);
        }

    }
}