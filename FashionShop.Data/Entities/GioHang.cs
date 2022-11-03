using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.Data.Entities
{
    public class GioHang
    {
        public int MaGioHang { set; get; }
        public int MaSanPham { set; get; }
        public int SoLuong { set; get; }
        public decimal Gia { set; get; }
        public Guid MaNguoiDung { get; set; }

        public SanPham SanPham { get; set; }

        public DateTime NgayTao { get; set; }

        public NguoiDung NguoiDung { get; set; }
    }
}
