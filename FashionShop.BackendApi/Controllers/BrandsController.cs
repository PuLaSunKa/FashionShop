using FashionShop.Application.Catalog.Brands;
using FashionShop.ViewModels.Catalog.Brands;
using FashionShop.ViewModels.Catalog.Categories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FashionShop.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandsController(
            IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(string languageId)
        {
            var products = await _brandService.GetAll(languageId);
            return Ok(products);
        }

        [HttpGet("{id}/{languageId}")]
        public async Task<IActionResult> GetById(string languageId, int id)
        {
            var brand = await _brandService.GetById(languageId, id);
            return Ok(brand);
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        [Authorize]
        public async Task<IActionResult> Create([FromForm] BrandCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var brandId = await _brandService.Create(request);
            if (brandId == 0)
                return BadRequest();

            var brand = await _brandService.GetById(request.LanguageId, brandId);

            return CreatedAtAction(nameof(GetById), new { id = brandId }, brand);
        }

        [HttpPut("{brandId}")]
        [Consumes("multipart/form-data")]
        [Authorize]
        public async Task<IActionResult> Update([FromRoute] int brandId, [FromForm] BrandUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            request.Id = brandId;
            var affectedResult = await _brandService.Update(request);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }
        [HttpDelete("{bradnId}")]
        [Authorize]
        public async Task<IActionResult> Delete(int brandId)
        {
            var affectedResult = await _brandService.Delete(brandId);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }
    }
}
