using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication5.Models;
using WebApplication5.DAL;

namespace WebApplication5.Controllers
{
    public class ShopController : Controller
    {
        // GET: Shop
        readonly IRepository<Good> repository;
        public ShopController(IRepository<Good> repository)
        {
            this.repository = repository;
        }
        public ActionResult Index()
        {
            return View(repository.GetList("Category"));
        }
    }
}