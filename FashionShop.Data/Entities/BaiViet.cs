using FashionShop.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.Data.Entities
{
    public class BaiViet
    {
        public int MaBaiViet { set; get; }
        public string TieuDe { set; get; }
        public string MoTa { set; get; }
        public string Url { set; get; }
        public string HinhAnh { get; set; }
        public int ThuTuSapXep { get; set; }
        public TrangThai TrangThai { set; get; }
    }
}
