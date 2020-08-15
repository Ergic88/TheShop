using TheShop.Models;

namespace TheShop.Service
{
    public class Supplier2 : ISupplier
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
				Name = "Article from supplier2",
				Price = 459
			};
		}
	}

}
