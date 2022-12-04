
using Microsoft.AspNetCore.Identity;

namespace FashionShop.Data.Entities
{
    public class AppUser : IdentityUser<Guid>
    {
        public string  FullName{ get; set; }
        public DateTime DateOfBirth { get; set; }
        public List<Cart> Carts { get; set; }

        public List<Order> Orders { get; set; }

        public List<Transaction> Transactions { get; set; }
    }
}
