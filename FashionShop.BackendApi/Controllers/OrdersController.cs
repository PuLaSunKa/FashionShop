using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FashionShop.Application.Sale;
using FashionShop.ViewModels.Sales;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FashionShop.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(
            IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var posts = await _orderService.GetAll();
            return Ok(posts);
        }

        [HttpGet("paging")]
        public async Task<IActionResult> GetAllPaging([FromQuery] GetOrderPagingRequest request)
        {
            var posts = await _orderService.GetAllPaging(request);
            return Ok(posts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var order = await _orderService.GetById(id);
            return Ok(order);
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        [Authorize]
        public async Task<IActionResult> Create([FromForm] OderCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var orderId = await _orderService.Create(request);
            if (orderId == 0)
                return BadRequest();

            var order = await _orderService.GetById(orderId);

            return CreatedAtAction(nameof(GetById), new { id = orderId }, order);
        }

        [HttpPut("{orderId}")]
        [Consumes("multipart/form-data")]
        [Authorize]
        public async Task<IActionResult> Update([FromRoute] int orderId, [FromForm] OrderUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            request.Id = orderId;
            var affectedResult = await _orderService.Update(request);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }
        [HttpDelete("{orderId}")]
        [Authorize]
        public async Task<IActionResult> Delete(int orderId)
        {
            var affectedResult = await _orderService.Delete(orderId);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }
    }
}
