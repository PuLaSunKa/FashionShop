using System;
using System.Collections.Generic;
using System.Text;

namespace FashionShop.Utilities.Constants
{
    public class SystemConstants
    {
        public const string MainConnectionString = "FashionShopDb";
        public const string CartSession = "CartSession";

        public class AppSettings
        {
            public const string DefaultLanguageId = "DefaultLanguageId";
            public const string Token = "Token";
            public const string BaseAddress = "BaseAddress";
        }

        public class ProductSettings
        {
            public const int NumberOfFeaturedProducts = 4;
            public const int NumberOfLatestProducts = 6;
        }
        public class PostSettings
        {
            public const int NumberOfLatestPosts = 5;
        }

        public class ProductConstants
        {
            public const string NA = "N/A";
        }
        public class CategoryConstants
        {
            public const string NA = "N/A";
        }
    }
}