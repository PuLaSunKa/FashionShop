using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.ViewModels.Sales
{
    public class OrderVm
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public string? Address { get; set; }

        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }

        public DateTime DateCreate { get; set; }
        public string? Status { get; set; }

        public List<OrderDetailVm> OrderDetails { set; get; } = new List<OrderDetailVm>();
    }
}
