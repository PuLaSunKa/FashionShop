
using Microsoft.AspNetCore.Identity;

namespace FashionShop.Data.Entities
{
    public class NguoiDung : IdentityUser<Guid>
    {
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public List<GioHang> GioHangs { get; set; }

        public List<DonHang> DonHangs { get; set; }

        public List<GiaoDich> GiaoDiches { get; set; }
    }
}
