using FashionShop.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.Data.Entities
{
    public class LoaiSanPham
    {
        public int MaLoaiSanPham { get; set; }
        public string TenLoai { get; set; }
        public TrangThai TrangThai { get; set; }
        public List<SanPhamTrongLoaiSanPham> SanPhamTrongLoaiSanPhams { get; set; }
    }
}
