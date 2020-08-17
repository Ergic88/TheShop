using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheShop.Models;

namespace TheShop.Services.Interfaces
{
    public interface IShopService
    {
        Article OrderArticle(int id, int maxExpectedPrice);

        void SellArticle(int buyerId, Article article);

        Article GetArticleById(int id);
    }
}
