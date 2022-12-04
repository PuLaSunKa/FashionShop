using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.Utilities.Exceptions
{
    public class FashionShopException : Exception
    {
        public FashionShopException()
        {
        }

        public FashionShopException(string message)
            : base(message)
        {
        }

        public FashionShopException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
