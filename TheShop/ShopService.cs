using System;
using System.Linq;
using TheShop.Models;
using TheShop.Log;
using TheShop.Database;
using TheShop.Service;
using System.Collections.Generic;

namespace TheShop
{
    public class ShopService
    {
        private DatabaseDriver DatabaseDriver;
        private Logger logger;

        private List<ISupplier> Suppliers;



        public ShopService()
        {
            DatabaseDriver = new DatabaseDriver();
            logger = new Logger();
            Suppliers = new List<ISupplier>() 
            {
                new Supplier1(), new Supplier2(),  new Supplier3()
            };
        }

        public Article OrderArticle(int id, int maxExpectedPrice)
        {
           Article article = Suppliers.Where(s => s.ArticleInInventory(id))
                               .Select(s => s.GetArticle(id))
                               .Where(a => a.Price <= maxExpectedPrice)
                               .OrderBy(a => a.Price)
                               .FirstOrDefault();

            if (article == null)
            {
                throw new Exception("Could not order article");
            }

            return article;
        }

        public void SellArticle(int buyerId, Article article)
        {          
            logger.Debug("Trying to sell article with id=" + article.ID);

            article.IsSold = true;
            article.SoldDate = DateTime.Now;
            article.BuyerUserId = buyerId;

            try
            {
                DatabaseDriver.Save(article);
                logger.Info("Article with id=" + article.ID + " is sold.");
            }
            catch (Exception ex)
            {
                logger.Error($"Could not save article with id= {article.ID} \n {ex.ToString()}");
                throw new Exception($"Could not save article with id= {article.ID}", ex);
            }
        }

        public Article GetArticleById(int id)
        {
            return DatabaseDriver.GetById(id);
        }
    }

}
