using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace M4MVC.Controllers
{
    public class ActionResultController : Controller
    {
        // GET: ActionResult
        
        //ActionResult is a standard class that built-in MVC
        public ActionResult NotSpecifyViewName()
        {
            return View(); //return View that the same as MethodName;
        }

        public ActionResult SpecifyViewName()
        {
            return View("iView"); //return iView;
        }

        public ActionResult Empty()
        {
            return null;
        }

        public ActionResult Content()
        {
            return Content("text as Content");
        }

        public ActionResult File() //open file
        {
            return File("~/app_data/WAD.txt","text/plain");
        }

        public ActionResult DownloadFile() //For user to download file
        {
            return File(Url.Content("~/app_data/WAD.txt"), "text/plain","WAD Make Up.txt");
        }

        public ActionResult JSON() //give us JSON file
        {
            return Json(new { Student = "Kimeang lim", StuID = "1" }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Google() // Redirect to google.com
        {
            return Redirect("https://www.google.com");
        }

        public ActionResult Action2Action()
        {
            return RedirectToAction("SpecifyViewName");
        }

        public ActionResult UA() //UA stand for Unauthorized
        {
           return new HttpUnauthorizedResult("Restricted");
        }

        public ActionResult NF() //NF stand for Not Found
        {
            return HttpNotFound(); //give back to user Not Found
        }

        public ActionResult SC() //give back to user Bad request
        {
            return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
        }
    }
}