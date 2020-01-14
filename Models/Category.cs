using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication5.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public ICollection<Good> Goods { get; set; }
        public Category()
        {
            Goods = new List<Good>();

        }
    }
}