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
    public class Entity_BranchsController : Controller
    {
        private dbProject db = new dbProject();

        // GET: Entity_Branchs
        public ActionResult Index()
        {
            var entity_Branchs = db.Entity_Branchs.Include(e => e.Entity);
            return View(entity_Branchs.ToList());
        }

        // GET: Entity_Branchs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entity_Branchs entity_Branchs = db.Entity_Branchs.Find(id);
            if (entity_Branchs == null)
            {
                return HttpNotFound();
            }
            return View(entity_Branchs);
        }

        // GET: Entity_Branchs/Create
        public ActionResult Create()
        {
            ViewBag.entity_id = new SelectList(db.Entities, "id", "Title");
            return View();
        }

        // POST: Entity_Branchs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,title,entity_id,is_deleted")] Entity_Branchs entity_Branchs)
        {
            if (ModelState.IsValid)
            {
                db.Entity_Branchs.Add(entity_Branchs);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.entity_id = new SelectList(db.Entities, "id", "Title", entity_Branchs.entity_id);
            return View(entity_Branchs);
        }

        // GET: Entity_Branchs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entity_Branchs entity_Branchs = db.Entity_Branchs.Find(id);
            if (entity_Branchs == null)
            {
                return HttpNotFound();
            }
            ViewBag.entity_id = new SelectList(db.Entities, "id", "Title", entity_Branchs.entity_id);
            return View(entity_Branchs);
        }

        // POST: Entity_Branchs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,title,entity_id,is_deleted")] Entity_Branchs entity_Branchs)
        {
            if (ModelState.IsValid)
            {
                db.Entry(entity_Branchs).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.entity_id = new SelectList(db.Entities, "id", "Title", entity_Branchs.entity_id);
            return View(entity_Branchs);
        }

        // GET: Entity_Branchs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entity_Branchs entity_Branchs = db.Entity_Branchs.Find(id);
            if (entity_Branchs == null)
            {
                return HttpNotFound();
            }
            return View(entity_Branchs);
        }

        // POST: Entity_Branchs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Entity_Branchs entity_Branchs = db.Entity_Branchs.Find(id);
            db.Entity_Branchs.Remove(entity_Branchs);
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
