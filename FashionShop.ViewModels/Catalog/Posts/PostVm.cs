using FashionShop.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.ViewModels.Catalog.Posts
{
    public class PostVm
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime DateCreate { get; set; }
        public string? UserId { get; set; }
        public string? Author { get; set;}
    }
}
