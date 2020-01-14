using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebApplication5.Models
{
    public class ShopContext:DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Good> Goods { get; set; }
    }

    public class ShopDbInitializer:DropCreateDatabaseAlways<ShopContext>
    {
        protected override void Seed(ShopContext context)
        {
            context.Categories.Add(new Category { Id = 1, CategoryName = "Phones" });
            context.Categories.Add(new Category { Id = 2, CategoryName = "Tech" });
            context.Goods.Add(new Good { Id = 1, CategoryId = 1, Title = "iPhone 12", Price=899.9 });
            context.Goods.Add(new Good { Id = 2, CategoryId = 2, Title = "Whirpool WS204T", Price = 399.9 });
            context.Goods.Add(new Good { Id = 3, CategoryId = 2, Title = "Whirpool WX502S", Price = 599.9 });
            base.Seed(context);
        }
    }
}