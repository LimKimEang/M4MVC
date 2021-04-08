namespace M4MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataValidation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "StudentName", c => c.String(nullable: false, maxLength: 35));
            AlterColumn("dbo.Students", "sex", c => c.String(nullable: false, maxLength: 1));
            AlterColumn("dbo.Students", "Telephone", c => c.String(nullable: false, maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "Telephone", c => c.String());
            AlterColumn("dbo.Students", "sex", c => c.String());
            AlterColumn("dbo.Students", "StudentName", c => c.String());
        }
    }
}
