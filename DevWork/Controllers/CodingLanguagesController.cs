using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Data;
using Microsoft.AspNet.Identity;
using Services;

namespace DevWork.Controllers
{
    [Authorize]
    public class CodingLanguagesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private CodingLanguageService CreateCodingLanguageService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var codingLanguageService = new CodingLanguageService(userId);
            return codingLanguageService;
        }

        // GET: CodingLanguages
        public ActionResult Index()
        {
            CodingLanguageService codingLanguageService = CreateCodingLanguageService();
            var codingLanguages = codingLanguageService.GetCodingLanguages();
            return View(codingLanguages);
        }

        // GET: CodingLanguages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CodingLanguages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodingLanguageId,CodingLanguageName")] CodingLanguage codingLanguage)
        {
            if (ModelState.IsValid)
            {
                db.CodingLanguages.Add(codingLanguage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(codingLanguage);
        }

        // GET: CodingLanguages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CodingLanguage codingLanguage = db.CodingLanguages.Find(id);
            if (codingLanguage == null)
            {
                return HttpNotFound();
            }
            return View(codingLanguage);
        }

        // POST: CodingLanguages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CodingLanguage codingLanguage = db.CodingLanguages.Find(id);
            db.CodingLanguages.Remove(codingLanguage);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
