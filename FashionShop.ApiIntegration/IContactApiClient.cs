using FashionShop.ViewModels.Catalog.Posts;
using FashionShop.ViewModels.Common;
using FashionShop.ViewModels.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.ApiIntegration
{
    public interface IContactApiClient
    {
        Task<List<ContactVm>> GetAll();

        Task<ContactVm> GetById(int id);

        Task<bool> CreateContact(ContactCreateRequest request);

        Task<bool> UpdateContact(ContactUpdateRequest request);

        Task<bool> DeleteContact(int ContactId);

        Task<PagedResult<ContactVm>> GetPagings(PagingRequestBase request);
    }
}
