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
    public class OfficialsController : Controller
    {
        private dbProject db = new dbProject();

        // GET: Officials
        public ActionResult Index()
        {
            var officials = db.Officials.Include(o => o.Entity).Include(o => o.Official1).Include(o => o.OfficialJob);
            return View(officials.ToList());
        }

        // GET: Officials/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Official official = db.Officials.Find(id);
            if (official == null)
            {
                return HttpNotFound();
            }
            return View(official);
        }

        // GET: Officials/Create
        public ActionResult Create()
        {
            ViewBag.entityId = new SelectList(db.Entities, "id", "Title");
            ViewBag.leaderId = new SelectList(db.Officials, "id", "fName");
            ViewBag.job_id = new SelectList(db.OfficialJobs, "id", "Job");
            return View();
        }

        // POST: Officials/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,fName,mName,lName,userName,passWord,email,phone,mobile,job_id,isLeader,leaderId,entityId,isdeleted")] Official official)
        {
            if (ModelState.IsValid)
            {
                db.Officials.Add(official);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.entityId = new SelectList(db.Entities, "id", "Title", official.entityId);
            ViewBag.leaderId = new SelectList(db.Officials, "id", "fName", official.leaderId);
            ViewBag.job_id = new SelectList(db.OfficialJobs, "id", "Job", official.job_id);
            return View(official);
        }

        // GET: Officials/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Official official = db.Officials.Find(id);
            if (official == null)
            {
                return HttpNotFound();
            }
            ViewBag.entityId = new SelectList(db.Entities, "id", "Title", official.entityId);
            ViewBag.leaderId = new SelectList(db.Officials, "id", "fName", official.leaderId);
            ViewBag.job_id = new SelectList(db.OfficialJobs, "id", "Job", official.job_id);
            return View(official);
        }

        // POST: Officials/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,fName,mName,lName,userName,passWord,email,phone,mobile,job_id,isLeader,leaderId,entityId,isdeleted")] Official official)
        {
            if (ModelState.IsValid)
            {
                db.Entry(official).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.entityId = new SelectList(db.Entities, "id", "Title", official.entityId);
            ViewBag.leaderId = new SelectList(db.Officials, "id", "fName", official.leaderId);
            ViewBag.job_id = new SelectList(db.OfficialJobs, "id", "Job", official.job_id);
            return View(official);
        }

        // GET: Officials/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Official official = db.Officials.Find(id);
            if (official == null)
            {
                return HttpNotFound();
            }
            return View(official);
        }

        // POST: Officials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Official official = db.Officials.Find(id);
            db.Officials.Remove(official);
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
