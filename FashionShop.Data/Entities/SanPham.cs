using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.Data.Entities
{
    public class SanPham
    {
        public int MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public string? MoTa { get; set; }
        public decimal Gia { get; set; }
        public int SoLuong { get; set; }
        public DateTime NgayTao { get; set; }
        public List<SanPhamTrongLoaiSanPham> SanPhamTrongLoaiSanPhams { get; set; }
        public List<SanPhamTrongThuongHieu> SanPhamTrongThuongHieus { get; set; }
        public List<ChiTietDonHang> ChiTietDonHangs { get; set; }

        public List<GioHang> GioHangs { get; set; }

        public List<HinhAnhSanPham> HinhAnhSanPhams { get; set; }
    }
}
