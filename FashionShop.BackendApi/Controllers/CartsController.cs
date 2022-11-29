using FashionShop.Application.Catalog.Carts;
using FashionShop.ViewModels.Catalog.Carts;
using FashionShop.ViewModels.Catalog.Posts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FashionShop.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartsController(
            ICartService cartService)
        {
            _cartService = cartService;
        }
        [HttpGet("{cartId}")]
        public async Task<IActionResult> GetById( string languageId, int cartId)
        {
            var cart = await _cartService.GetById(languageId, cartId);
            return Ok(cart);
        }

        [HttpPost("{languageId}")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create(string languageId, [FromForm] CartCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var cartId = await _cartService.Create(request);
            if (cartId == 0)
                return BadRequest();

            var cart = await _cartService.GetById(languageId, cartId);
    
            return CreatedAtAction(nameof(GetById), new { id = cartId }, cart);
        }

        [HttpPut("{cartId}")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Update([FromRoute] int cartId, [FromForm] CartUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            request.Id = cartId;
            var affectedResult = await _cartService.Update(request);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }
        [HttpDelete("{cartId}")]
        public async Task<IActionResult> Delete(int cartId)
        {
            var affectedResult = await _cartService.Delete(cartId);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }
        [HttpGet("{userId}/{languageId}")]
        public async Task<IActionResult> GetAllByUserId(string languageId , string userId)
        {
            var ListCart = await _cartService.GetAllByUserId(languageId, userId);
            if (ListCart == null)
                return BadRequest("Cannot find list cart of user");
            return Ok(ListCart);
        }
    }
}
