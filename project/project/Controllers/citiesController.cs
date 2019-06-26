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
    public class citiesController : Controller
    {
        private dbProject db = new dbProject();
        // GET: cities
        public ActionResult Index()
        {
            var cities = db.cities.Where(c=>c.isdeleted==false).Include(c => c.Government);
            return View(cities.ToList());
        }
        // GET: cities/Create
        public ActionResult Create()
        {
            ViewBag.gov_id = new SelectList(db.Governments.Where(g => g.isdeleted == false), "id", "name");
            return View();
        }

        // POST: cities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,gov_id,isdeleted")] city city)
        {
            if (ModelState.IsValid)
            {
                city.isdeleted = false;
                db.cities.Add(city);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.gov_id = new SelectList(db.Governments.Where(g=>g.isdeleted==false), "id", "name", city.gov_id);
            return View(city);
        }

        // GET: cities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            city city = db.cities.Find(id);
            if (city == null)
            {
                return HttpNotFound();
            }
            ViewBag.gov_id = new SelectList(db.Governments, "id", "name", city.gov_id);
            return View(city);
        }

        // POST: cities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,gov_id,isdeleted")] city city)
        {
            if (ModelState.IsValid)
            {
                city.isdeleted = false;
                db.Entry(city).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.gov_id = new SelectList(db.Governments, "id", "name", city.gov_id);
            return View(city);
        }

        // GET: cities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            city city = db.cities.Find(id);
            if (city == null)
            {
                return HttpNotFound();
            }
            return View(city);
        }
        // POST: cities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            city city = db.cities.Find(id);
            city.isdeleted = true;
            db.Entry(city).State = EntityState.Modified;
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
