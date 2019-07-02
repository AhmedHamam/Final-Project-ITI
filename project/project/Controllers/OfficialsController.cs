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
    public class OfficialsController : Controller
    {
        private dbProject db = new dbProject();


        public ActionResult home()
        {
            if (Session["official"] != null)
            {
                var complaints = db.Complaints.Include(c => c.city).Include(c => c.Citzen).Include(c => c.Complaint_Catgories).Include(c => c.Official).Include(c => c.Official1);
                return View(complaints.ToList());
            }
            else { return RedirectToAction("login"); }
        }

        public ActionResult DetailsOfComp(int? id)
        {
            if (Session["official"] != null)
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
            else { return RedirectToAction("login"); }
        }

        public ActionResult SolveOfComp(int? id)
        {
            if (Session["official"] != null)
            {
                ViewBag.id = id;
                return View();
            }
            else { return RedirectToAction("login"); }
        }
        [HttpPost]
        public ActionResult SolveOfComp(int id,string message)

        {
           
                var complaint = db.Complaints.FirstOrDefault(c => c.id == id);
                complaint.solveDescription = message;

                db.SaveChanges();
                return RedirectToAction("home");
            
            

        }


        public ActionResult logout()
        {
            Session["official"] = null;
            return RedirectToAction("login");
        }






        public ActionResult login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult login(Official login)
        {


            dbProject db = new dbProject();
            var offical = (from officiallist in db.Officials
                        where officiallist.email == login.email && officiallist.passWord == login.passWord
                        select new
                        {
                            officiallist.id,
                            officiallist.fName
                        }).ToList();
            if (offical.FirstOrDefault() != null)
            {
                Session["official"] = offical.FirstOrDefault().id;
                Session["name"] = offical.FirstOrDefault().fName;

                return Redirect("home");
            }
            else
            {
                ModelState.AddModelError("", "Invalid login credentials.");
            }

            return View(login);
        }























        // GET: Officials
        public ActionResult Index()
        {
            if (Session["official"] != null)
            {
                var officials = db.Officials.Include(o => o.Entity).Include(o => o.Official1).Include(o => o.OfficialJob);
                return View(officials.ToList());
            }
            else { return RedirectToAction("login"); }
           
        }

        // GET: Officials/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["official"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Official official = db.Officials.Find(id);
                if (official == null)
                {
                    return HttpNotFound();
                }
                return View(official);
            }
            else { return RedirectToAction("login"); } 
        }

        // GET: Officials/Create
        public ActionResult Create()
        {
            if (Session["official"] != null)
            {
                ViewBag.entityId = new SelectList(db.Entities, "official", "Title");
                ViewBag.leaderId = new SelectList(db.Officials, "official", "fName");
                ViewBag.job_id = new SelectList(db.OfficialJobs, "official", "Job");
                return View();
            }
            else { return RedirectToAction("login"); }
        }

        // POST: Officials/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,fName,mName,lName,userName,passWord,email,phone,mobile,job_id,isLeader,leaderId,entityId,isdeleted")] Official official)
        {
            if (ModelState.IsValid)
            {
                db.Officials.Add(official);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.entityId = new SelectList(db.Entities, "official", "Title", official.entityId);
            ViewBag.leaderId = new SelectList(db.Officials, "official", "fName", official.leaderId);
            ViewBag.job_id = new SelectList(db.OfficialJobs, "official", "Job", official.job_id);
            return View(official);
        }

        // GET: Officials/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["official"] != null)
            {


                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Official official = db.Officials.Find(id);
                if (official == null)
                {
                    return HttpNotFound();
                }
                ViewBag.entityId = new SelectList(db.Entities, "official", "Title", official.entityId);
                ViewBag.leaderId = new SelectList(db.Officials, "official", "fName", official.leaderId);
                ViewBag.job_id = new SelectList(db.OfficialJobs, "official", "Job", official.job_id);
                return View(official);
            }
            else { return RedirectToAction("login"); }
        }

        // POST: Officials/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,fName,mName,lName,userName,passWord,email,phone,mobile,job_id,isLeader,leaderId,entityId,isdeleted")] Official official)
        {
            if (ModelState.IsValid)
            {
                db.Entry(official).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.entityId = new SelectList(db.Entities, "official", "Title", official.entityId);
            ViewBag.leaderId = new SelectList(db.Officials, "official", "fName", official.leaderId);
            ViewBag.job_id = new SelectList(db.OfficialJobs, "official", "Job", official.job_id);
            return View(official);
        }

        // GET: Officials/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["official"]!=null)
            {
                Official offi = db.Officials.FirstOrDefault(a => a.id == id);
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Official official = db.Officials.Find(id);
                if (official == null)
                {
                    return HttpNotFound();
                }
                return View(official);
            }
            else { return RedirectToAction("login"); }
        }

        // POST: Officials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Official official = db.Officials.Find(id);
            db.Officials.Remove(official);
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
