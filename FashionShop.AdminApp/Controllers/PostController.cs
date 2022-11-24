using FashionShop.ApiIntegration;
using FashionShop.Utilities.Constants;
using FashionShop.ViewModels.Catalog.Categories;
using FashionShop.ViewModels.Catalog.Posts;
using FashionShop.ViewModels.Common;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FashionShop.AdminApp.Controllers
{
    public class PostController : BaseController
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
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create([FromForm] PostCreateRequest request)
        {
            if (!ModelState.IsValid)
                return View(request);
            request.UserId = User.FindFirstValue(ClaimTypes.Sid);
            var result = await _postApiClient.CreatePost(request);
            if (result)
            {
                TempData["result"] = "Thêm mới bài viết thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Thêm bài viết thất bại");
            return View(request);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            
            var postedit = await _postApiClient.GetById(id);
            var editVm = new PostUpdateRequest()
            {
                Title = postedit.Title, 
                Description = postedit.Description,
            };
            return View(editVm);
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Edit([FromForm] PostUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return View(request);

            var result = await _postApiClient.UpdatePost(request);
            if (result)
            {
                TempData["result"] = "Cập nhật thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Cập nhật thất bại");
            return View(request);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(new PostDeleteRequest()
            {
                Id = id
            });
        }
        [HttpPost]
        public async Task<IActionResult> Delete(PostDeleteRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _postApiClient.DeletePost(request.Id);
            if (result)
            {
                TempData["result"] = "Xóa bài viết thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Xóa bài viết không thành công!");
            return View(request);
        }

        [HttpGet]
        public async Task<IActionResult> Details( int id)
        {
            var result = await _postApiClient.GetById( id);
            return View(result);
        }
    }
}
