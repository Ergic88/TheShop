using System.Collections.Generic;
using System.Linq;
using TheShop.Models;

namespace TheShop.Service
{
    public class Supplier1 : ISupplier
    {
        private List<Article> Articles = new List<Article>{new Article()
        {
            ID = 1,
            Name = "Article from supplier1",
            Price = 458
        }};

        public Supplier1()
        {
        }

        public bool ArticleInInventory(int id)
        {
            return Articles.Where(a => a.ID == id).Any();
        }

        public Article GetArticle(int id)
        {
            return Articles.FirstOrDefault(a => a.ID == id);
        }
    }

}
