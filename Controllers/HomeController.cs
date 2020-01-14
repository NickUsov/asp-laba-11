using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication5.Models;
using WebApplication5.DAL;

namespace WebApplication5.Controllers
{
    public class HomeController : Controller
    {
        readonly IRepository<Category> repository;
        public HomeController(IRepository<Category> repository)
        {
            this.repository = repository;
        }
        public ActionResult Index()
        {

            return View(repository.GetList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}