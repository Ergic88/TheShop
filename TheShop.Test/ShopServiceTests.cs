using NUnit.Framework;
using System;
using TheShop.Models;
using TheShop.Services;
using TheShop.Services.Exceptions;

namespace TheShop.Test
{
    [TestFixture]
    public class ShopServiceTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ShopService_OrderItemWhichDoesntExist_ThrowsException()
        {
            // Arrange
            var shopService = new ShopService();
            // Act and assert
            Assert.Throws<ArticleNotFoundException>(() => shopService.OrderArticle(2, 30));
        }

        [Test]
        public void ShopService_OrderItemTooExpensive_ThrowsException()
        {
            // Arrange
            var shopService = new ShopService();
            // Act and assert
            Assert.Throws<ArticleTooExpensiveException>(() => shopService.OrderArticle(1, 30));
        }

        [Test]
        public void ShopService_OrderItem_ItemOrdered()
        {
            // Arrange
            var shopService = new ShopService();

            // Act
            var article = shopService.OrderArticle(1, 500);

            // Assert
            Assert.IsNotNull(article);
        }

        [Test]
        public void ShopService_SellItem_ItemSold()
        {
            // Arrange
            var shopService = new ShopService();
            var article = new Article()
            {
                ID = 1,
                Name = "Article from supplier1",
                Price = 458
            };

            // Act
            shopService.SellArticle(10, article);

            // Assert
            Assert.IsTrue(article.IsSold);
            Assert.AreEqual(article.SoldDate, DateTime.Now.Date);
            Assert.AreEqual(article.BuyerUserId, 10);
        }
    }
}