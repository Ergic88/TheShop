using System;
using System.Linq;
using TheShop.Models;
using TheShop.Log;
using TheShop.Database;
using TheShop.Service;
using System.Collections.Generic;
using System.Reflection;
using TheShop.Exceptions;

namespace TheShop
{
    public class ShopService
    {
        private readonly IDatabase database;
        private readonly ILogger logger;

        private readonly List<ISupplier> Suppliers;

        public ShopService()
        {
            database = new DatabaseDriver();
            logger = new Logger();
            Suppliers = new List<ISupplier>();
            var supplierTypes = typeof(ISupplier).Assembly.DefinedTypes.Where(s => s.ImplementedInterfaces.Contains(typeof(ISupplier)));
            foreach (var item in supplierTypes)
            {
                var instantiatedSupplier = Activator.CreateInstance(Type.GetType(item.AssemblyQualifiedName)) as ISupplier;
                Suppliers.Add(instantiatedSupplier);
            }
        }

        public Article OrderArticle(int id, int maxExpectedPrice)
        {
            var articles = Suppliers.Where(s => s.ArticleInInventory(id))
                                .Select(s => s.GetArticle(id));

            if (!articles.Any())
            {
                throw new ArticleNotFoundException($"Article with id= {id} not found");
            };

            var article = articles.Where(a => a.Price <= maxExpectedPrice)
                                .OrderBy(a => a.Price)
                                .FirstOrDefault();

            if (article == null)
            {
                throw new ArticleTooExpensiveException($"Article too expensive for expected price of {maxExpectedPrice}");
            }

            return article;
        }

        public void SellArticle(int buyerId, Article article)
        {
            logger.Debug("Trying to sell article with id=" + article.ID);

            article.IsSold = true;
            article.SoldDate = DateTime.Now.Date;
            article.BuyerUserId = buyerId;

            try
            {
                database.Save(article);
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
            return database.GetById(id);
        }
    }

}
