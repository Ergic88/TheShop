using System;

namespace TheShop
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var shopService = new ShopService();
            try
            {

                //order and sell
                var article = shopService.OrderArticle(1, 20);
                shopService.SellArticle(10, article);

                //print article on console
                article = shopService.GetArticleById(1);
                if (article == null)
                {
                    Console.WriteLine("Article not found: ");
                }
                Console.WriteLine("Found article with ID: " + article.ID);

                //print article on console				
                article = shopService.GetArticleById(12);
                if (article == null)
                {
                    Console.WriteLine("Article not found: ");
                }
                Console.WriteLine("Found article with ID: " + article.ID);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }

    }
}