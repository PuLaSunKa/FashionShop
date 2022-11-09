using System;
using System.Collections.Generic;
using System.Text;

namespace FashionShop.ViewModels.Utilities.Posts
{
    public class PostVm
    {
        public int Id { set; get; }
        public string Title { set; get; }
        public string Description { set; get; }
        public string Url { set; get; }

        public string Image { get; set; }
        public int SortOrder { get; set; }
    }
}