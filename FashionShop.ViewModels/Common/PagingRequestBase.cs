using System;
using System.Collections.Generic;
using System.Text;

namespace FashionShop.ViewModels.Common
{
    public class PagingRequestBase
    {
        public int PageIndex { get; set; }

        public int PageSize { get; set; }
    }
}