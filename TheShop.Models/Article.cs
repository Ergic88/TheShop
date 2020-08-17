using System;

namespace TheShop.Models
{
    public class Article
	{
		public int ID { get; set; }

		public string Name { get; set; }

		public int Price { get; set; }
		public bool IsSold { get; set; }

		public DateTime SoldDate { get; set; }
		public int BuyerUserId { get; set; }

		public void Sell(int buyerId)
		{
			this.IsSold = true;
			this.SoldDate = DateTime.Now.Date;
			this.BuyerUserId = buyerId;
		}
	}

}
