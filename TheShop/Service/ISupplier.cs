using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheShop.Models;

namespace TheShop.Service
{
    public interface ISupplier
    {
        bool ArticleInInventory(int id);

        Article GetArticle(int id);
    }
}
