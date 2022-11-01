using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FashionShop.WebApp.Models
{
    [Table("SanPham")]
    public class SanPham
    {
        public int MaSanPham { get; set; }
        public string? TenSanPham { get; set; }
        public int MaLoai { get; set; }
        public int MaNhanHang { get; set; }
        public string? MoTa { get; set; }
        public decimal Gia { get; set; }
        public int SoLuong { get; set; }
        public string? TieuDe { get; set; }
        public DateTime NgayTao{ get; set; }
    }
}
