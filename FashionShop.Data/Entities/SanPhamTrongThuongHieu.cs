using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.Data.Entities
{
    public class SanPhamTrongThuongHieu
    {
        public int MaSanPham { get; set; }

        public SanPham SanPham { get; set; }

        public int MaThuongHieu { get; set; }

        public ThuongHieu ThuongHieu { get; set; }
    }
}
