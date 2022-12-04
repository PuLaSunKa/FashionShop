using FashionShop.ViewModels.Catalog.Posts;
using FashionShop.ViewModels.Common;
using FashionShop.ViewModels.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.Application.Utilities
{
    public interface IContactService
    {
        Task<List<ContactVm>> GetAll();

        Task<ContactVm> GetById(int id);

        Task<int> Create(ContactCreateRequest request);

        Task<int> Update(ContactUpdateRequest request);

        Task<int> Delete(int ContactId);

        Task<PagedResult<ContactVm>> GetAllPaging(PagingRequestBase request);
    }
}
