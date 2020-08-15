using TheShop.Models;

namespace TheShop.Service
{
    public class Supplier1 : ISupplier
    {
        public bool ArticleInInventory(int id)
        {
            return true;
        }

        public Article GetArticle(int id)
        {
            return new Article()
            {
                ID = 1,
                Name = "Article from supplier1",
                Price = 458
            };
        }
    }

}
