using MVC.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    [CrawlerFilter]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // add once we have functionality built
            //if (User.Identity.IsAuthenticated)
            //{
            //    return RedirectToAction("Index", "?");
            //}
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Who we are";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Let's grab coffee and chat!";

            return View();
        }
    }
}