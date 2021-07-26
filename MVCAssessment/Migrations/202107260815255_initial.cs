namespace MVCAssessment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DeptID = c.Int(nullable: false, identity: true),
                        DptName = c.String(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.DeptID);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        DeptId = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        DOJ = c.DateTime(nullable: false),
                        Mobile = c.Int(nullable: false),
                        Email = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.Departments", t => t.DeptId, cascadeDelete: true)
                .Index(t => t.DeptId);
            
            CreateTable(
                "dbo.Salaries",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false),
                        SalaryAmount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Salaries", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Employees", "DeptId", "dbo.Departments");
            DropIndex("dbo.Salaries", new[] { "EmployeeId" });
            DropIndex("dbo.Employees", new[] { "DeptId" });
            DropTable("dbo.Salaries");
            DropTable("dbo.Employees");
            DropTable("dbo.Departments");
        }
    }
}
