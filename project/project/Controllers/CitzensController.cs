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
    public class CitzensController : Controller
    {
        private dbProject db = new dbProject();

        // GET: Citzens
        public ActionResult Index()
        {
            var citzens = db.Citzens.Include(c => c.Admin).Include(c => c.city);
            return View(citzens.ToList());
        }

        // GET: Citzens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Citzen citzen = db.Citzens.Find(id);
            if (citzen == null)
            {
                return HttpNotFound();
            }
            return View(citzen);
        }

        // GET: Citzens/Create
        public ActionResult Create()
        {
            ViewBag.accptedBy = new SelectList(db.Admins, "id", "fName");
            ViewBag.cityId = new SelectList(db.cities, "id", "name");
            return View();
        }

        // POST: Citzens/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,fName,lName,mName,nationailnumber,nationalNumberImage,gender,userName,email,password,address,phone,mobile,reg_date,accept_date,works_on,accpted,isdeleated,blocked,cityId,accptedBy")] Citzen citzen)
        {
            if (ModelState.IsValid)
            {
                citzen.reg_date = DateTime.Now;

                db.Citzens.Add(citzen);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.accptedBy = new SelectList(db.Admins, "id", "fName", citzen.accptedBy);
            ViewBag.cityId = new SelectList(db.cities, "id", "name", citzen.cityId);
            return View(citzen);
        }

        // GET: Citzens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Citzen citzen = db.Citzens.Find(id);
            if (citzen == null)
            {
                return HttpNotFound();
            }
            ViewBag.accptedBy = new SelectList(db.Admins, "id", "fName", citzen.accptedBy);
            ViewBag.cityId = new SelectList(db.cities, "id", "name", citzen.cityId);
            return View(citzen);
        }

        // POST: Citzens/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,fName,lName,mName,nationailnumber,nationalNumberImage,gender,userName,email,password,address,phone,mobile,reg_date,accept_date,works_on,accpted,isdeleated,blocked,cityId,accptedBy")] Citzen citzen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(citzen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.accptedBy = new SelectList(db.Admins, "id", "fName", citzen.accptedBy);
            ViewBag.cityId = new SelectList(db.cities, "id", "name", citzen.cityId);
            return View(citzen);
        }


        public ActionResult login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult login(Citzen login)
        {

            
                dbProject db = new dbProject();
                var user = (from userlist in db.Citzens
                            where userlist.email == login.email && userlist.password == login.password
                            select new
                            {
                                userlist.id,
                               
                            }).ToList();
                if (user.FirstOrDefault() != null)
                {
                    Session["id"] = user.FirstOrDefault().id;
                   
                    return Redirect("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid login credentials.");
                }
            
            return View(login);
        }





        // GET: Citzens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Citzen citzen = db.Citzens.Find(id);
            if (citzen == null)
            {
                return HttpNotFound();
            }
            return View(citzen);
        }

        // POST: Citzens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Citzen citzen = db.Citzens.Find(id);
            db.Citzens.Remove(citzen);
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
