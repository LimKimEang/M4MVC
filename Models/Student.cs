using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace M4MVC.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public string sex { get; set; }
        public DateTime BirthDate { get; set; }
        public Decimal Height { get; set; }

    }
}