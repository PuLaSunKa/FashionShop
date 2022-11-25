using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.Data.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime DateCreate { get; set; }
        public string? Author { get; set; }
        public Guid UserId { get; set; }

        public AppUser? AppUser { get; set; }
    }
}
