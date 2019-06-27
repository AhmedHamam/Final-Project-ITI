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
    public class EntitiesController : Controller
    {
        private dbProject db = new dbProject();
        // GET: Entities
        public ActionResult Index()
        {
            if (Session["admin"] != null)
            {
                var entities = db.Entities.Where(e => e.is_deleted == false).Include(e => e.Official);
                return View(entities.ToList());
            }
            else
            {
                return RedirectToAction("login", "Admins");
            }
           
        }
        // GET: Entities/Create
        public ActionResult Create()
        {
            if (Session["admin"] != null)
            {
                ViewBag.mangerId = new SelectList(db.Officials, "id", "fName");
                return View();
            }
            else
            {
                return RedirectToAction("login", "Admins");
            }
          
        }

        // POST: Entities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Title,address,phone,fax,is_deleted,mangerId")] Entity entity)
        {
            if (ModelState.IsValid)
            {
                entity.is_deleted = false;
                db.Entities.Add(entity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.mangerId = new SelectList(db.Officials, "id", "fName", entity.mangerId);
            return View(entity);
        }

        // GET: Entities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["admin"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Entity entity = db.Entities.Find(id);
                if (entity == null)
                {
                    return HttpNotFound();
                }
                ViewBag.mangerId = new SelectList(db.Officials, "id", "fName", entity.mangerId);
                return View(entity);
            }
            else
            {
                return RedirectToAction("login", "Admins");
            }
           
        }

        // POST: Entities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Title,address,phone,fax,is_deleted,mangerId")] Entity entity)
        {
            if (ModelState.IsValid)
            {
                entity.is_deleted = false;
                db.Entry(entity).State = EntityState.Modified;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.mangerId = new SelectList(db.Officials, "id", "fName", entity.mangerId);
            return View(entity);
        }

        // GET: Entities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["admin"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Entity entity = db.Entities.Find(id);
                if (entity == null)
                {
                    return HttpNotFound();
                }
                return View(entity);
            }
            else
            {
                return RedirectToAction("login", "Admins");
            }
            
        }

        // POST: Entities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Entity entity = db.Entities.Find(id);

            entity.is_deleted = true;
            db.Entry(entity).State = EntityState.Modified;
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
