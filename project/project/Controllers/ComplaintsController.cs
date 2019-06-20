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
    public class ComplaintsController : Controller
    {
        private dbModel db = new dbModel();

        // GET: Complaints
        public ActionResult Index()
        {
            var complaints = db.Complaints.Include(c => c.city).Include(c => c.Entity).Include(c => c.Entity_Branchs);
            return View(complaints.ToList());
        }

        // GET: Complaints/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Complaint complaint = db.Complaints.Find(id);
            if (complaint == null)
            {
                return HttpNotFound();
            }
            return View(complaint);
        }

        // GET: Complaints/Create
        public ActionResult Create()
        {
            ViewBag.comCity = new SelectList(db.cities, "id", "name");
            ViewBag.comEntity_id = new SelectList(db.Entities, "id", "Title");
            ViewBag.comEntitybranch_id = new SelectList(db.Entity_Branchs, "id", "title");
            return View();
        }

        // POST: Complaints/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,comNumber,comTitle,comDescription,comEntitybranch_id,comEntity_id,comDate,comStatus,comCity")] Complaint complaint, HttpPostedFileBase comFile)
        {
            if (ModelState.IsValid)
            {
                string image = System.IO.Path.GetFileName(comFile.FileName);
                string myPath = Server.MapPath("~/images/" + image);
                comFile.SaveAs(myPath);
                complaint.comFile = image;
                db.Complaints.Add(complaint);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.comCity = new SelectList(db.cities, "id", "name", complaint.comCity);
            ViewBag.comEntity_id = new SelectList(db.Entities, "id", "Title", complaint.comEntity_id);
            ViewBag.comEntitybranch_id = new SelectList(db.Entity_Branchs, "id", "title", complaint.comEntitybranch_id);
            return View(complaint);
        }

        // GET: Complaints/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Complaint complaint = db.Complaints.Find(id);
            if (complaint == null)
            {
                return HttpNotFound();
            }
            ViewBag.comCity = new SelectList(db.cities, "id", "name", complaint.comCity);
            ViewBag.comEntity_id = new SelectList(db.Entities, "id", "Title", complaint.comEntity_id);
            ViewBag.comEntitybranch_id = new SelectList(db.Entity_Branchs, "id", "title", complaint.comEntitybranch_id);
            return View(complaint);
        }

        // POST: Complaints/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,comNumber,comTitle,comDescription,comEntitybranch_id,comEntity_id,comFile,comDate,comStatus,comCity")] Complaint complaint)
        {
            if (ModelState.IsValid)
            {
                db.Entry(complaint).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.comCity = new SelectList(db.cities, "id", "name", complaint.comCity);
            ViewBag.comEntity_id = new SelectList(db.Entities, "id", "Title", complaint.comEntity_id);
            ViewBag.comEntitybranch_id = new SelectList(db.Entity_Branchs, "id", "title", complaint.comEntitybranch_id);
            return View(complaint);
        }

        // GET: Complaints/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Complaint complaint = db.Complaints.Find(id);
            if (complaint == null)
            {
                return HttpNotFound();
            }
            return View(complaint);
        }

        // POST: Complaints/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Complaint complaint = db.Complaints.Find(id);
            db.Complaints.Remove(complaint);
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
