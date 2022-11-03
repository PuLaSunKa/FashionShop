using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.Data.Entities
{
    public class ChiTietDonHang
    {
        public int MaDonHang { set; get; }
        public int MaSanPham { set; get; }
        public int SoLuong { set; get; }
        public decimal Gia { set; get; }

        public DonHang DonHang { get; set; }

        public SanPham SanPham { get; set; }
    }
}
