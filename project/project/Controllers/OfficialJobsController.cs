using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using project.Models;

namespace project.Controllers
{
    public class OfficialJobsController : Controller
    {
        private dbProject db = new dbProject();

        // GET: OfficialJobs
        public ActionResult Index()
        {
            if (Session["admin"] != null)
            {
                return View(db.OfficialJobs.Where(oj => oj.isdeleted == false).ToList());
            }
            else
            {
                return RedirectToAction("login", "Admins");
            }
            
        }

        // GET: OfficialJobs/Create
        public ActionResult Create()
        {
            if (Session["admin"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("login", "Admins");
            }
            
        }

        // POST: OfficialJobs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Job,jobDescriptaion")] OfficialJob officialJob)
        {
            if (ModelState.IsValid)
            {
                officialJob.isdeleted = false;
                db.OfficialJobs.Add(officialJob);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(officialJob);
        }

        // GET: OfficialJobs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["admin"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                OfficialJob officialJob = db.OfficialJobs.Find(id);
                if (officialJob == null)
                {
                    return HttpNotFound();
                }
                return View(officialJob);
            }
            else
            {
                return RedirectToAction("login", "Admins");
            }
         
        }

        // POST: OfficialJobs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Job,jobDescriptaion")] OfficialJob officialJob)
        {
            if (ModelState.IsValid)
            {
                officialJob.isdeleted = false;
                db.Entry(officialJob).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(officialJob);
        }

        // GET: OfficialJobs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["admin"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                OfficialJob officialJob = db.OfficialJobs.Find(id);
                if (officialJob == null)
                {
                    return HttpNotFound();
                }
                return View(officialJob);
            }
            else
            {
                return RedirectToAction("login", "Admins");
            }
        }

        // POST: OfficialJobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OfficialJob officialJob = db.OfficialJobs.Find(id);
            officialJob.isdeleted = true;
            db.Entry(officialJob).State = EntityState.Modified;
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
