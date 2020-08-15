using TheShop.Models;

namespace TheShop.Service
{
    public class Supplier3 : ISupplier
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
				Name = "Article from supplier3",
				Price = 460
			};
		}
	}

}
