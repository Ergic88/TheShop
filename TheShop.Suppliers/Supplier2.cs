using System.Collections.Generic;
using System.Linq;
using TheShop.Models;
using TheShop.Suppliers.Interfaces;

namespace TheShop.Suppliers
{
    public class Supplier2 : ISupplier
    {
        private List<Article> Articles = new List<Article>{new Article()
        {
            ID = 1,
            Name = "Article from supplier2",
            Price = 459
        }};

        public Supplier2()
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
