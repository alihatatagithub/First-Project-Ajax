namespace AjaxApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmpClass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Salary = c.Int(),
                        Office = c.String(nullable: false),
                        Postion = c.String(nullable: false),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.EmployeeId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Employees");
        }
    }
}
