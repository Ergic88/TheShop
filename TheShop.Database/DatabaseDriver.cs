﻿using System.Collections.Generic;
using System.Linq;
using TheShop.Models;

namespace TheShop.Database
{
    //in memory implementation
    public class DatabaseDriver : IDatabase
	{
		private List<Article> _articles = new List<Article>();

		public Article GetById(int id)
		{
            return _articles.FirstOrDefault(x => x.ID == id);
		}

		public void Save(Article article)
		{
			_articles.Add(article);
		}
	}

}
