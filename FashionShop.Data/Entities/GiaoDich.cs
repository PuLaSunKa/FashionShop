using FashionShop.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace FashionShop.Data.Entities
{
    public class GiaoDich
    {
        public int MaGiaoDich { set; get; }
        public DateTime NgayGiaoDich { set; get; }
        public string MaGiaoDichBenNgoai { set; get; }
        public decimal SoLuong { set; get; }
        public decimal SoTien { set; get; }
        public string KetQua { set; get; }
        public string ThongBao { set; get; }
        public TrangThaiGiaoDich TrangThai { set; get; }
        public string NguoiCungCap { set; get; }
        public Guid MaNguoiDung { get; set; }
        public NguoiDung NguoiDung { get; set; }
    }
}
