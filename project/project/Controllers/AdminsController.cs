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
    public class AdminsController : Controller
    {
        private dbProject db = new dbProject();

        // GET: Admins
        public ActionResult Index()
        {
            if (Session["admin"] != null)
            {
                return View(db.Admins.ToList());
            }
            else
            {
                return RedirectToAction("login");
            }
        }
        public ActionResult home()
        {
            if (Session["admin"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("login");
            }
            
        }

        // GET: Admins/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Admin admin = db.Admins.Find(id);
            if (admin == null)
            {
                return HttpNotFound();
            }
            return View(admin);
        }

        // GET: Admins/Create
        public ActionResult Create()
        {
            if (Session["admin"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("login");
            }
        }

        // POST: Admins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Admin admin)
        {
            if (ModelState.IsValid)
            {
                db.Admins.Add(admin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(admin);
        }

        // GET: Admins/Edit/5
        public ActionResult Edit(int? id)
        {
           
            if (Session["admin"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Admin admin = db.Admins.Find(id);
                if (admin == null)
                {
                    return HttpNotFound();
                }
                return View(admin);
            }
            else
            {
                return RedirectToAction("login");
            }
        }

        // POST: Admins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Admin admin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(admin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(admin);
        }

        // GET: Admins/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Admin admin = db.Admins.Find(id);
            if (admin == null)
            {
                return HttpNotFound();
            }
            return View(admin);
        }

        // POST: Admins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Admin admin = db.Admins.Find(id);
            admin.isdeleted = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult login(Admin login)
        {


            //dbProject db = new dbProject();
            var admin = (from adminlist in db.Admins
                        where adminlist.email == login.email && adminlist.password == login.password && adminlist.isdeleted==false
                         select new
                        {
                            adminlist.id,
                            adminlist.fName
                        }).ToList();
            if (admin.FirstOrDefault() != null)
            {
                Session["admin"] = admin.FirstOrDefault().id;
                Session["name"] = admin.FirstOrDefault().fName;

                return Redirect("home");
            }
            else
            {
                ModelState.AddModelError("", "Invalid login credentials.");
            }

            return View(login);
        }



        public ActionResult logOut()
        {
            Session["admin"] = null;
            Session["name"] = null;
            return RedirectToAction("login");
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
