using FashionShop.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.ViewModels.Sales
{
    public class OrderUpdateRequest
    {
        public int Id { get; set; }
        public OrderStatus Status { get; set; }
    }
}
