using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.Data.Entities
{
    public class SanPhamTrongLoaiSanPham
    {
        public int MaSanPham { get; set; }

        public SanPham SanPham { get; set; }

        public int MaLoaiSanPham { get; set; }

        public LoaiSanPham LoaiSanPham { get; set; }
    }
}
