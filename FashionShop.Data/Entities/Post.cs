using FashionShop.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.Data.Entities
{
    public class Post
    {
        public int Id { set; get; }
        public string Title { set; get; }
        public string Description { set; get; }
        public string Url { set; get; }

        public string Image { get; set; }
        public int SortOrder { get; set; }
        public Status Status { set; get; }
    }
}
