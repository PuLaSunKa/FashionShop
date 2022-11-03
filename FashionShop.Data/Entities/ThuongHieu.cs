using FashionShop.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.Data.Entities
{
    public class ThuongHieu
    {
        public int MaThuongHieu { get; set; }
        public string TenThuongHieu { get; set; }
        public string? HinhAnh{ get; set; }
        public TrangThai TrangThai { get; set; }
        public List<SanPhamTrongThuongHieu> SanPhamTrongThuongHieus { get; set; }
    }
}
