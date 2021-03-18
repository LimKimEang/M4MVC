using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace M4MVC.Models
{
    public class Student
    {
        public int StudentID { get; set; }

        [Display(Name = "Student Name")]
        public string StudentName { get; set; }
        public string sex { get; set; }

        //[Display(Name="Title")]
        [Display(Name="Birth Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }
        public Decimal Height { get; set; }

    }

    //StudentDb is databaseName
    public class StudentDb : DbContext
    {
        //<Student> is table in DB
       public DbSet<Student> Students { get; set; }
    }
}