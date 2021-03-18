using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using M4MVC.Models;

namespace M4MVC.Controllers
{
    public class StudentsController : Controller
    {
        //private contextClass objectname = new contextClass(); Create a database object
        private StudentDb db = new StudentDb();

        // GET: Students

        public ActionResult Index(string yearBorn, string searchName)
        {
            var yearLst = new List<string>(); //Create a List of yearLst to store BirthDate from Students with s
                                                
                                                
            var yearQry = from s in db.Students
                          orderby s.BirthDate   //then filter(orderby)
                          select s.BirthDate.Year.ToString();   //then choose(select) only Year from Birthdate
                                                                //and convert to string


            yearLst.AddRange(yearQry.Distinct()); //Distinct()
            ViewBag.yearBorn = new SelectList(yearLst); //in ViewBag create yearBorn property to store List of yearLst

            var students = from s in db.Students // From Students with s will store data in variable students
                         select s;

            //if searchName have a value 
            if (!String.IsNullOrEmpty(searchName))
            {
                //choose a student when user enter name in argument(searchName)
                students = students.Where(s => s.StudentName.Contains(searchName));
            }

            if (!string.IsNullOrEmpty(yearBorn))
            {
                //Choose a student wtih the same argument(yearBorn)
                students = students.Where(y => y.BirthDate.Year.ToString() == yearBorn);
            }

            return View(students);
        }

        // GET: Students/Details/5
        public ActionResult Details(int? id)  // int? id is optional parameter
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id); //Student is table
                                                    //Find(id) method fine information from primaray key of id 
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentID,StudentName,sex,BirthDate,Height")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(student);
        }

        // GET: Students/Edit/5
        //GET is method from HTML that allow data tranfer from client to server fast but not secure
        public ActionResult Edit(int? id) //parameter is optional
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentID,StudentName,sex,BirthDate,Height")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
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
