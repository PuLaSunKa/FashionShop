using FashionShop.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.ViewModels.Catalog.Categories
{
    public class GetCategoryPagingRequest: PagingRequestBase
    {
        public string? LanguageId { get; set; }
    }
}
