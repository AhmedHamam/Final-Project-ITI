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
    public class Common_QustionController : Controller
    {
        private dbProject db = new dbProject();

        // GET: Common_Qustion
        public ActionResult Index()
        {
            return View(db.Common_Qustion.ToList());
        }

        // GET: Common_Qustion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Common_Qustion common_Qustion = db.Common_Qustion.Find(id);
            if (common_Qustion == null)
            {
                return HttpNotFound();
            }
            return View(common_Qustion);
        }

        // GET: Common_Qustion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Common_Qustion/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Questation,answer")] Common_Qustion common_Qustion)
        {
            if (ModelState.IsValid)
            {
                db.Common_Qustion.Add(common_Qustion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(common_Qustion);
        }

        // GET: Common_Qustion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Common_Qustion common_Qustion = db.Common_Qustion.Find(id);
            if (common_Qustion == null)
            {
                return HttpNotFound();
            }
            return View(common_Qustion);
        }

        // POST: Common_Qustion/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Questation,answer")] Common_Qustion common_Qustion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(common_Qustion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(common_Qustion);
        }

        // GET: Common_Qustion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Common_Qustion common_Qustion = db.Common_Qustion.Find(id);
            if (common_Qustion == null)
            {
                return HttpNotFound();
            }
            return View(common_Qustion);
        }

        // POST: Common_Qustion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Common_Qustion common_Qustion = db.Common_Qustion.Find(id);
            db.Common_Qustion.Remove(common_Qustion);
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
