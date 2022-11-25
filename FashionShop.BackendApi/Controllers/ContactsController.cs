using FashionShop.Application.Catalog.Posts;
using FashionShop.Application.Utilities;
using FashionShop.ViewModels.Catalog.Posts;
using FashionShop.ViewModels.Common;
using FashionShop.ViewModels.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FashionShop.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactsController(
            IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var posts = await _contactService.GetAll();
            return Ok(posts);
        }

        [HttpGet("paging")]
        public async Task<IActionResult> GetAllPaging([FromQuery] PagingRequestBase request)
        {
            var posts = await _contactService.GetAllPaging(request);
            return Ok(posts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var post = await _contactService.GetById(id);
            return Ok(post);
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        [Authorize]
        public async Task<IActionResult> Create([FromForm] ContactCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var postId = await _contactService.Create(request);
            if (postId == 0)
                return BadRequest();

            var post = await _contactService.GetById(postId);

            return CreatedAtAction(nameof(GetById), new { id = postId }, post);
        }

        [HttpPut("{contactId}")]
        [Consumes("multipart/form-data")]
        [Authorize]
        public async Task<IActionResult> Update([FromRoute] int contactId, [FromForm] ContactUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            request.Id = contactId;
            var affectedResult = await _contactService.Update(request);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }
        [HttpDelete("{contactId}")]
        [Authorize]
        public async Task<IActionResult> Delete(int contactId)
        {
            var affectedResult = await _contactService.Delete(contactId);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }
    }
}
