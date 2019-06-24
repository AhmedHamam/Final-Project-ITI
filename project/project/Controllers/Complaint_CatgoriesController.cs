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
    public class Complaint_CatgoriesController : Controller
    {
        private dbProject db = new dbProject();

        // GET: Complaint_Catgories
        public ActionResult Index()
        {
            return View(db.Complaint_Catgories.ToList());
        }

        // GET: Complaint_Catgories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Complaint_Catgories complaint_Catgories = db.Complaint_Catgories.Find(id);
            if (complaint_Catgories == null)
            {
                return HttpNotFound();
            }
            return View(complaint_Catgories);
        }

        // GET: Complaint_Catgories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Complaint_Catgories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Cat_Name")] Complaint_Catgories complaint_Catgories)
        {
            if (ModelState.IsValid)
            {
                db.Complaint_Catgories.Add(complaint_Catgories);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(complaint_Catgories);
        }

        // GET: Complaint_Catgories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Complaint_Catgories complaint_Catgories = db.Complaint_Catgories.Find(id);
            if (complaint_Catgories == null)
            {
                return HttpNotFound();
            }
            return View(complaint_Catgories);
        }

        // POST: Complaint_Catgories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Cat_Name")] Complaint_Catgories complaint_Catgories)
        {
            if (ModelState.IsValid)
            {
                db.Entry(complaint_Catgories).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(complaint_Catgories);
        }

        // GET: Complaint_Catgories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Complaint_Catgories complaint_Catgories = db.Complaint_Catgories.Find(id);
            if (complaint_Catgories == null)
            {
                return HttpNotFound();
            }
            return View(complaint_Catgories);
        }

        // POST: Complaint_Catgories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Complaint_Catgories complaint_Catgories = db.Complaint_Catgories.Find(id);
            db.Complaint_Catgories.Remove(complaint_Catgories);
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
