using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace M4MVC.Controllers
{
    public class GreetingController : Controller
    {
        // action or method is the same meaning in here
        // ActionResult is like return type function
        public ActionResult M4()
        {
            return View();
        }
        public ActionResult GoodMorning(int year=4,string ClassName="M4")
        {
            ViewBag.Year = year;
            ViewBag.ClassName = ClassName;
            return View();
        }
    }
}