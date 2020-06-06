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
using Models.JobPost;
using Services;

namespace MVC.Controllers
{
    public class JobPostsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private JobPostService _jobPostService;
        private string _userId;

        // GET: JobPosts
        public ActionResult Index()
        {
            var jobPosts = db.JobPosts.Where(e => e.IsActive == true).Include(j => j.Employer).Include(j => j.Freelancer);
            return View(jobPosts.ToList());
        }

        // GET: JobPosts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobPost jobPost = db.JobPosts.Find(id);
            if (jobPost == null)
            {
                return HttpNotFound();
            }
            return View(jobPost);
        }

        // GET: JobPosts/Create
        public ActionResult Create()
        {
            ViewBag.EmployerId = new SelectList(db.Employers, "EmployerId", "FirstName");
            ViewBag.StateId = new SelectList(db.States, "StateId", "StateName");
            return View();
        }

        // POST: JobPosts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(JobPostCreate jobPost)
        {
            if (ModelState.IsValid)
            {
                _userId = User.Identity.GetUserId();
                _jobPostService = new JobPostService(_userId);
                _jobPostService.CreateJobPost(jobPost);
                return RedirectToAction("Index");
            }

            return View(jobPost);
        }

        // GET: JobPosts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobPost jobPost = db.JobPosts.Find(id);
            if (jobPost == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployerId = new SelectList(db.Employers, "EmployerId", "FirstName", jobPost.EmployerId);
            ViewBag.FreelancerId = new SelectList(db.Freelancers, "FreelancerId", "FirstName", jobPost.FreelancerId);
            ViewBag.StateId = new SelectList(db.States, "StateId", "StateName");
            return View(jobPost);
        }

        // POST: JobPosts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "JobPostId,JobTitle,Content,StateName,IsAwarded,CreatedDate,ModifiedDate,IsActive,EmployerId,FreelancerId")] JobPost jobPost)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jobPost).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployerId = new SelectList(db.Employers, "EmployerId", "FirstName", jobPost.EmployerId);
            ViewBag.FreelancerId = new SelectList(db.Freelancers, "FreelancerId", "FirstName", jobPost.FreelancerId);
            ViewBag.StateId = new SelectList(db.States, "StateId", "StateName");
            return View(jobPost);
        }

        // GET: JobPosts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobPost jobPost = db.JobPosts.Find(id);
            if (jobPost == null)
            {
                return HttpNotFound();
            }
            return View(jobPost);
        }

        // POST: JobPosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            JobPost jobPost = db.JobPosts.Find(id);
            db.JobPosts.Remove(jobPost);
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
