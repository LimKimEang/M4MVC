using M4MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace M4MVC.Controllers
{
    public class StudentAPIController : ApiController
    {
        private StudentDb db = new StudentDb();
        public IEnumerable<Student> GetAllStudents() { return db.Students; }
        public IHttpActionResult GetStudent(int StudentID)
        {
            var Student = db.Students.Find(StudentID);
            if (Student == null) return NotFound();
            return Ok(Student);
        }
    }
}
