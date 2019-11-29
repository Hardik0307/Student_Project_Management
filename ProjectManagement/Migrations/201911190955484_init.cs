namespace ProjectManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProjectEvaluations", "mem1_id", "dbo.Students");
            DropForeignKey("dbo.ProjectEvaluations", "mem2_id", "dbo.Students");
            DropForeignKey("dbo.ProjectEvaluations", "mem3_id", "dbo.Students");
            DropForeignKey("dbo.ProjectEvaluations", "Student_StudentId", "dbo.Students");
            DropForeignKey("dbo.ActiveProjects", "mem1_id", "dbo.Students");
            DropForeignKey("dbo.ActiveProjects", "mem2_id", "dbo.Students");
            DropForeignKey("dbo.ActiveProjects", "mem3_id", "dbo.Students");
            DropForeignKey("dbo.SubmittedProjects", "mem1_id", "dbo.Students");
            RenameColumn(table: "dbo.ProjectEvaluations", name: "Student_StudentId", newName: "Student_Id");
            RenameIndex(table: "dbo.ProjectEvaluations", name: "IX_Student_StudentId", newName: "IX_Student_Id");
            DropPrimaryKey("dbo.Students");
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        role = c.String(),
                        userId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Students", t => t.userId)
                .Index(t => t.userId);
            
            AddColumn("dbo.Students", "Id", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Students", "Dept", c => c.String());
            AddPrimaryKey("dbo.Students", "Id");
            AddForeignKey("dbo.ProjectEvaluations", "mem1_id", "dbo.Students", "Id");
            AddForeignKey("dbo.ProjectEvaluations", "mem2_id", "dbo.Students", "Id");
            AddForeignKey("dbo.ProjectEvaluations", "mem3_id", "dbo.Students", "Id");
            AddForeignKey("dbo.ProjectEvaluations", "Student_Id", "dbo.Students", "Id");
            AddForeignKey("dbo.ActiveProjects", "mem1_id", "dbo.Students", "Id");
            AddForeignKey("dbo.ActiveProjects", "mem2_id", "dbo.Students", "Id");
            AddForeignKey("dbo.ActiveProjects", "mem3_id", "dbo.Students", "Id");
            AddForeignKey("dbo.SubmittedProjects", "mem1_id", "dbo.Students", "Id");
            DropColumn("dbo.Students", "StudentId");
            DropTable("dbo.Faculties");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Faculties",
                c => new
                    {
                        FacultyId = c.String(nullable: false, maxLength: 128),
                        FacultyName = c.String(),
                        FacultyEmail = c.String(),
                        FacultyPass = c.String(),
                        FacultyDept = c.String(),
                    })
                .PrimaryKey(t => t.FacultyId);
            
            AddColumn("dbo.Students", "StudentId", c => c.String(nullable: false, maxLength: 128));
            DropForeignKey("dbo.SubmittedProjects", "mem1_id", "dbo.Students");
            DropForeignKey("dbo.ActiveProjects", "mem3_id", "dbo.Students");
            DropForeignKey("dbo.ActiveProjects", "mem2_id", "dbo.Students");
            DropForeignKey("dbo.ActiveProjects", "mem1_id", "dbo.Students");
            DropForeignKey("dbo.ProjectEvaluations", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.ProjectEvaluations", "mem3_id", "dbo.Students");
            DropForeignKey("dbo.ProjectEvaluations", "mem2_id", "dbo.Students");
            DropForeignKey("dbo.ProjectEvaluations", "mem1_id", "dbo.Students");
            DropForeignKey("dbo.UserRoles", "userId", "dbo.Students");
            DropIndex("dbo.UserRoles", new[] { "userId" });
            DropPrimaryKey("dbo.Students");
            DropColumn("dbo.Students", "Dept");
            DropColumn("dbo.Students", "Id");
            DropTable("dbo.UserRoles");
            AddPrimaryKey("dbo.Students", "StudentId");
            RenameIndex(table: "dbo.ProjectEvaluations", name: "IX_Student_Id", newName: "IX_Student_StudentId");
            RenameColumn(table: "dbo.ProjectEvaluations", name: "Student_Id", newName: "Student_StudentId");
            AddForeignKey("dbo.SubmittedProjects", "mem1_id", "dbo.Students", "StudentId");
            AddForeignKey("dbo.ActiveProjects", "mem3_id", "dbo.Students", "StudentId");
            AddForeignKey("dbo.ActiveProjects", "mem2_id", "dbo.Students", "StudentId");
            AddForeignKey("dbo.ActiveProjects", "mem1_id", "dbo.Students", "StudentId");
            AddForeignKey("dbo.ProjectEvaluations", "Student_StudentId", "dbo.Students", "StudentId");
            AddForeignKey("dbo.ProjectEvaluations", "mem3_id", "dbo.Students", "StudentId");
            AddForeignKey("dbo.ProjectEvaluations", "mem2_id", "dbo.Students", "StudentId");
            AddForeignKey("dbo.ProjectEvaluations", "mem1_id", "dbo.Students", "StudentId");
        }
    }
}
