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
    public class EntityBranchsController : Controller
    {
        private dbProject db = new dbProject();

        // GET: EntityBranchs
        public ActionResult Index()
        {
            if (Session["admin"] != null)
            {
                var entity_Branchs = db.Entity_Branchs.Where(eb => eb.is_deleted == false).Include(e => e.Entity);
                return View(entity_Branchs.ToList());
            }
            else
            {
                return RedirectToAction("login", "Admins");
            }
    
        }

        // GET: EntityBranchs/Create
        public ActionResult Create()
        {
            if (Session["admin"] != null)
            {
                ViewBag.entity_id = new SelectList(db.Entities, "id", "Title");
                return View();
            }
            else
            {
                return RedirectToAction("login", "Admins");
            }
           
        }

        // POST: EntityBranchs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,title,entity_id,is_deleted")] EntityBranchs entityBranchs)
        {
            if (ModelState.IsValid)
            {
                db.Entity_Branchs.Add(entityBranchs);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.entity_id = new SelectList(db.Entities, "id", "Title", entityBranchs.entity_id);
            return View(entityBranchs);
        }

        // GET: EntityBranchs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["admin"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                EntityBranchs entityBranchs = db.Entity_Branchs.Find(id);
                if (entityBranchs == null)
                {
                    return HttpNotFound();
                }
                ViewBag.entity_id = new SelectList(db.Entities, "id", "Title", entityBranchs.entity_id);
                return View(entityBranchs);
            }
            else
            {
                return RedirectToAction("login", "Admins");
            }
            
        }

        // POST: EntityBranchs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,title,entity_id,is_deleted")] EntityBranchs entityBranchs)
        {
            if (ModelState.IsValid)
            {
                db.Entry(entityBranchs).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.entity_id = new SelectList(db.Entities, "id", "Title", entityBranchs.entity_id);
            return View(entityBranchs);
        }

        // GET: EntityBranchs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["admin"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                EntityBranchs entityBranchs = db.Entity_Branchs.Find(id);
                if (entityBranchs == null)
                {
                    return HttpNotFound();
                }
                return View(entityBranchs);
            }
            else
            {
                return RedirectToAction("login", "Admins");
            }
           
        }

        // POST: EntityBranchs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EntityBranchs entityBranchs = db.Entity_Branchs.Find(id);
            entityBranchs.is_deleted = true;
            db.Entry(entityBranchs).State = EntityState.Modified;
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
