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
    public class GovernmentsController : Controller
    {
        private dbProject db = new dbProject();

        // GET: Governments
        public ActionResult Index()
        {
            var govs = (from item in db.Governments.ToList() where item.isdeleted==false select item).ToList();
            return View( govs );
        }
        // GET: Governments/Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: Governments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,isdeleted")] Government government)
        {
            if (ModelState.IsValid)
            {
                db.Governments.Add(government);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(government);
        }
        // GET: Governments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Government government = db.Governments.Find(id);
            if (government == null)
            {
                return HttpNotFound();
            }
            return View(government);
        }
        // POST: Governments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,isdeleted")] Government government)
        {
            if (ModelState.IsValid)
            {
                db.Entry(government).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(government);
        }
        // GET: Governments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Government government = db.Governments.Find(id);
            if (government == null)
            {
                return HttpNotFound();
            }
            return View(government);
        }
        // POST: Governments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Government government = db.Governments.Find(id);
            government.isdeleted = true;
            db.Entry(government).State = EntityState.Modified;
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
