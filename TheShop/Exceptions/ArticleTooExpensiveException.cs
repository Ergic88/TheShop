using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheShop.Exceptions
{
    public class ArticleTooExpensiveException : Exception
    {
        public ArticleTooExpensiveException(string message) : base(message)
        {

        }
    }
}
