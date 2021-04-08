namespace M4MVC.Migrations
{
    using M4MVC.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<M4MVC.Models.StudentDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(M4MVC.Models.StudentDb context)
        {
            //  This method will be called after migrating to the latest version.

            context.Students.AddOrUpdate(i => i.StudentName, new Student
            {
                StudentName = "Phy Phally",
                sex = "F",
                BirthDate = DateTime.Parse("2001-1-21"),
                Height = 1.6M,
                Telephone="011 123456"
            },
            new Student
            {
                StudentName = "Phy phally",
                sex = "M",
                BirthDate = DateTime.Parse("2000-2-22"),
                Height = 1.71M,
                Telephone="012 123456"
            });
        }
    }
}
