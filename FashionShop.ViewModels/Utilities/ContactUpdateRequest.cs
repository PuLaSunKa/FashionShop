using FashionShop.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.ViewModels.Utilities
{
    public class ContactUpdateRequest
    {
        public int Id { set; get; }
        public Status Status { set; get; }
    }
}
