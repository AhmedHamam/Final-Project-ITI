using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using project.Models;
namespace project.Controllers
{
    public class HomeController : Controller
    {
        private dbModel db = new dbModel();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult kk()
        {
            return View();
        }
        public ActionResult CreatingComplaint()
        {

            return View();
        }
        [HttpPost]
        public ActionResult CreatingComplaint(Complaint complaint)
        {
            db.Complaints.Add(complaint);
            db.SaveChanges();
            return RedirectToAction("kk");
        }
    }
}