using FashionShop.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.Data.Entities
{
    public class LienHe
    {
        public int MaLienHe { set; get; }
        public string HoTen { set; get; }
        public string Email { set; get; }
        public string SoDienThoai { set; get; }
        public string TinNhan { set; get; }
        public TrangThai Status { set; get; }
    }
}
