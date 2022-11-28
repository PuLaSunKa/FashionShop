using FashionShop.Application.Catalog.Categories;
using FashionShop.Application.Catalog.Posts;
using FashionShop.ViewModels.Catalog.Categories;
using FashionShop.ViewModels.Catalog.Posts;
using FashionShop.ViewModels.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FashionShop.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostsController(
            IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var posts = await _postService.GetAll();
            return Ok(posts);
        }

        [HttpGet("paging")]
        public async Task<IActionResult> GetAllPaging([FromQuery] PagingRequestBase request)
        {
            var posts = await _postService.GetAllPaging(request);
            return Ok(posts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var post = await _postService.GetById( id);
            return Ok(post);
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        [Authorize]
        public async Task<IActionResult> Create([FromForm] PostCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var postId = await _postService.Create(request);
            if (postId == 0)
                return BadRequest();

            var post = await _postService.GetById(postId);

            return CreatedAtAction(nameof(GetById), new { id = postId }, post);
        }

        [HttpPut("{postId}")]
        [Consumes("multipart/form-data")]
        [Authorize]
        public async Task<IActionResult> Update([FromRoute] int postId, [FromForm] PostUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            request.Id = postId;
            var affectedResult = await _postService.Update(request);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }
        [HttpDelete("{postId}")]
        [Authorize]
        public async Task<IActionResult> Delete(int postId)
        {
            var affectedResult = await _postService.Delete(postId);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }
        [HttpGet("latest/{take}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetLatestPosts(int take)
        {
            var products = await _postService.GetLatestPosts(take);
            return Ok(products);
        }
    }
}
