using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.Data.Entities
{
    public class HinhAnhSanPham
    {
        public int MaHinhAnh { get; set; }

        public int MaSanPham { get; set; }

        public string DuongDanAnh { get; set; }

        public bool AnhMacDinh { get; set; }

        public DateTime NgayTao { get; set; }

        public int ThuTuSapXep { get; set; }

        public long KichThuoc { get; set; }

        public SanPham SanPham { get; set; }
    }
}
