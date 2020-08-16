using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheShop.Models;

namespace TheShop.Database
{
    public interface IDatabase
    {
        void Save(Article article);
        Article GetById(int id);
    }
}
