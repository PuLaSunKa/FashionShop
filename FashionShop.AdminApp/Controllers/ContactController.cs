using FashionShop.ApiIntegration;
using FashionShop.ViewModels.Catalog.Posts;
using FashionShop.ViewModels.Common;
using FashionShop.ViewModels.Utilities;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FashionShop.AdminApp.Controllers
{
    public class ContactController : BaseController
    {
        private readonly IConfiguration _configuration;
        private readonly IContactApiClient _contactApiClient;

        public ContactController(
            IConfiguration configuration,
            IContactApiClient contactApiClient)
        {
            _configuration = configuration;
            _contactApiClient = contactApiClient;
        }
        public async Task<IActionResult> Index(int pageIndex = 1, int pageSize = 10)
        {

            var request = new PagingRequestBase()
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
            };
            var data = await _contactApiClient.GetPagings(request);

            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create([FromForm] ContactCreateRequest request)
        {
            if (!ModelState.IsValid)
                return View(request);         
            var result = await _contactApiClient.CreateContact(request);
            if (result)
            {
                TempData["result"] = "Thêm liên hệ thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Thêm liên hệ thất bại");
            return View(request);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {

            var postedit = await _contactApiClient.GetById(id);
            var editVm = new ContactUpdateRequest()
            {
                Id = id,
                Status = postedit.Status
            };
            return View();
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Edit([FromForm] ContactUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return View(request);

            var result = await _contactApiClient.UpdateContact(request);
            if (result)
            {
                TempData["result"] = "Cập nhật thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Cập nhật thất bại");
            return View(request);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var deleteVm = new ContactDeleteRequest()
            {
                Id= id,               
            };
            return View(deleteVm);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(ContactDeleteRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _contactApiClient.DeleteContact(request.Id);
            if (result)
            {
                TempData["result"] = "Đã xóa liên hệ thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Xóa không thành công!");
            return View(request);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var result = await _contactApiClient.GetById(id);
            return View(result);
        }
    }
}
