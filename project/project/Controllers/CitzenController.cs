using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace project.Controllers
{
    public class CitzenController : Controller
    {
        // GET: Citzen
        public ActionResult login()
        {
            return View();
        }

        public ActionResult signup()
        {
            return View();
        }
        public ActionResult aboutus()
        {
            return View();
        }

    }
}