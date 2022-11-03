using FashionShop.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.Data.Entities
{
    public class DonHang
    {
        public int MaDonHang { set; get; }
        public DateTime NgayDatHang { set; get; }
        public Guid MaNguoiDung { set; get; }
        public string NguoiNhan { set; get; }
        public string DiaChi { set; get; }
        public string Email { set; get; }
        public string SoDienThoai { set; get; }
        public TrangThaiDonHang TrangThai { set; get; }

        public List<ChiTietDonHang> ChiTietDonHangs { get; set; }

        public NguoiDung NguoiDung { get; set; }

    }
}
