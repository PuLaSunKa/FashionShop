using FashionShop.ApiIntegration;
using FashionShop.ViewModels.Sales;
using Microsoft.AspNetCore.Mvc;

namespace FashionShop.AdminApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IOrderApiClient _orderApiClient;


        public OrderController(IOrderApiClient orderApiClient,
            IConfiguration configuration
            )
        {
            _orderApiClient = orderApiClient;
            _configuration = configuration;
      
        }
        public async Task<IActionResult> Index(int pageIndex = 1, int pageSize = 10)
        {

            var request = new GetOrderPagingRequest()
            {
                PageIndex = pageIndex,
                PageSize = pageSize,

            };
            var data = await _orderApiClient.GetPagings(request);

            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            return View(data);
        }
    }
}
