using FashionShop.ViewModels.Common;
using FashionShop.ViewModels.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.Application.Sale
{
    public interface IOrderService
    {
        Task<List<OrderVm>> GetAll();

        Task<OrderVm> GetById( int id);

        Task<int> Create(OderCreateRequest request);
    
        Task<int> Update(OrderUpdateRequest request);

        Task<int> Delete(int OderId);
    
        Task<PagedResult<OrderVm>> GetAllPaging(GetOrderPagingRequest request);
    }
}
