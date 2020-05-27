using Microsoft.AspNet.Identity;
using Models.CodingLanguage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    [Authorize]
    public class CodingLanguageController : Controller
    {
        [HttpGet]
        public ActionResult Create()
        {
            return View(new CodingLanguageCreate());
        }

        [HttpPost]
        public ActionResult Create(CodingLanguageCreate createModel)
        {
            createModel.UserId = User.Identity.GetUserId();
            return View(createModel);
        }

        // GET: CodingLanguage
        public ActionResult Index()
        {
            return View();
        }
    }
}