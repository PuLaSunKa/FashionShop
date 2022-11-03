using FashionShop.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.Data.Entities
{
    public class KhuyenMai
    {
        public int MaKhuyenMai { set; get; }
        public DateTime TuNgay { set; get; }
        public DateTime DenNgay { set; get; }
        public bool ApDungChoTatCa { set; get; }
        public int? Phan { set; get; }
        public decimal? SoLuongGiamGia { set; get; }
        public string MaSanPham { set; get; }
        public string MaLoaiSanPham { set; get; }
        public TrangThai TrangThai { set; get; }
        public string TenKhuyenMai { set; get; }
    }
}
