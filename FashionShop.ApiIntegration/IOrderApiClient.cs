using FashionShop.ViewModels.Common;
using FashionShop.ViewModels.Sales;
using System;
using System.Collections.Generic;
using System.Text;

namespace FashionShop.ApiIntegration
{
    public interface IOrderApiClient
    {
        Task<List<OrderVm>> GetAll();

        Task<OrderVm> GetById( int id);

        Task<bool> CreateOrder(OderCreateRequest request);

        Task<bool> UpdateOrder(OrderUpdateRequest request);

        Task<bool> DeleteOrder(int orderId);

        Task<PagedResult<OrderVm>> GetPagings(GetOrderPagingRequest request);
    }
}