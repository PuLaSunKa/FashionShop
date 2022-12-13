using FashionShop.Data.EF;
using FashionShop.Data.Entities;
using FashionShop.Utilities.Exceptions;
using FashionShop.ViewModels.Common;
using FashionShop.ViewModels.Sales;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.Application.Sale
{
    public class OrderService : IOrderService
    {
        private readonly FashionShopDbContext _context;
        public OrderService(FashionShopDbContext context)
        {
            _context = context;
        }
        public async Task<int> Create(OderCreateRequest request)
        {
            var order = new Order()
            {
                OrderDate = DateTime.Now,
                UserId = Guid.Parse(request.UserId),
                ShipName = request.Name,
                ShipAddress = request.Address,
                ShipEmail = request.Email,
                ShipPhoneNumber = request.PhoneNumber,
                Status = 0,

            };
            order.OrderDetails = new List<OrderDetail>();
            foreach (var orderDetail in request.OrderDetails)
            {
                var abc = new OrderDetail(){
                    Price = orderDetail.Price,
                    Quantity = orderDetail.Quantity,
                    ProductId = orderDetail.ProductId,
                };
                order.OrderDetails.Add(abc);
            }
           _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return order.Id;
        }

        public async Task<int> Delete(int OderId)
        {
            var order = await _context.Orders.FindAsync(OderId);
            if (order == null) throw new FashionShopException($"Cannot find order: {OderId}");
            _context.Orders.Remove(order);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<OrderVm>> GetAll()
        {
            var query = from c in _context.Orders
                        join ct in _context.OrderDetails on c.Id equals ct.OrderId                      
                        select new { c, ct};
            return await query.Select(x => new OrderVm()
            {
                Name = x.c.ShipName,
                Address = x.c.ShipAddress,
                Email = x.c.ShipEmail,
                PhoneNumber = x.c.ShipPhoneNumber,
                DateCreate = x.c.OrderDate,
                Status = x.c.Status.ToString(),

            }).ToListAsync();
        }

        public async Task<PagedResult<OrderVm>> GetAllPaging(GetOrderPagingRequest request)
        {
            var query = from c in _context.Orders
                        join ct in _context.OrderDetails on c.Id equals ct.OrderId
                        select new { c, ct };
            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new OrderVm()
                {
                    Name = x.c.ShipName,
                    Address = x.c.ShipAddress,
                    Email = x.c.ShipEmail,
                    PhoneNumber = x.c.ShipPhoneNumber,
                    DateCreate = x.c.OrderDate,
                    Status = x.c.Status.ToString(),
                }).ToListAsync();

            //4. Select and projection
            var pagedResult = new PagedResult<OrderVm>()
            {
                TotalRecords = totalRow,
                PageSize = request.PageSize,
                PageIndex = request.PageIndex,
                Items = data
            };
            return pagedResult;
        }

        public async Task<OrderVm> GetById( int id)
        {
            var query = from c in _context.Orders
                        join ct in _context.OrderDetails on c.Id equals ct.OrderId
                        where c.Id == id && ct.OrderId == id
                        select new { c, ct };
            return await query.Select(x => new OrderVm()
            {
                Name = x.c.ShipName,
                Address = x.c.ShipAddress,
                Email = x.c.ShipEmail,
                PhoneNumber = x.c.ShipPhoneNumber,
                DateCreate = x.c.OrderDate,
                Status = x.c.Status.ToString(),
            }).FirstOrDefaultAsync();
        }

        public async Task<int> Update(OrderUpdateRequest request)
        {
            var order = await _context.Orders.FindAsync(request.Id);
            var orderDetails = await _context.OrderDetails.FirstOrDefaultAsync(x => x.OrderId == request.Id);

            if (order == null || orderDetails == null) throw new FashionShopException($"Cannot find order with id: {request.Id}");

            order.Status = request.Status;

            return await _context.SaveChangesAsync();
        }
    }
}
