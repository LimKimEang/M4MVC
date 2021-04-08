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
        [Required(ErrorMessage ="Student Name must be require")]
        [StringLength(35,ErrorMessage ="Student must be between 4 letter and 35 ",MinimumLength =4)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z'\s]*$",ErrorMessage ="Student Name can contain only character and space")]
        public string StudentName { get; set; }

        [Required(ErrorMessage ="Student Sex must be reqiure")]
        [StringLength(1,ErrorMessage ="Sex should contain only 1 letter")]
        [RegularExpression(@"[MmFf]",ErrorMessage ="Sex should contain 'M' 'm' 'F' 'f'")]
        public string sex { get; set; }

        //[Display(Name="Title")]
        [Display(Name="Birth Date")]
        [Required(ErrorMessage ="DateofBirth required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage ="Height required")]
        [RegularExpression(@"^[0-9]+[.]+[0-9]{2}$",ErrorMessage ="Height should start from 0-9 then '.' 2 fraction")]
        public Decimal Height { get; set; }

        [Required(ErrorMessage ="Phone number required")]
        [StringLength(10,ErrorMessage ="incorrect phone number",MinimumLength =9)]
        [Phone]
        public string Telephone { get; set; }
    }

    //StudentDb is databaseName
    public class StudentDb : DbContext
    {
        //<Student> is table in DB
       public DbSet<Student> Students { get; set; }
    }
}