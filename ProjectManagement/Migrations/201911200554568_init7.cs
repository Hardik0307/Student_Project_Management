namespace ProjectManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init7 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.ActiveProjects", name: "mem1_id", newName: "member1_id");
            RenameColumn(table: "dbo.ActiveProjects", name: "mem2_id", newName: "member2_id");
            RenameColumn(table: "dbo.ActiveProjects", name: "mem3_id", newName: "member3_id");
            RenameColumn(table: "dbo.ProjectEvaluations", name: "mem1_id", newName: "member1_id");
            RenameColumn(table: "dbo.ProjectEvaluations", name: "mem2_id", newName: "member2_id");
            RenameColumn(table: "dbo.ProjectEvaluations", name: "mem3_id", newName: "member3_id");
            RenameColumn(table: "dbo.SubmittedProjects", name: "mem1_id", newName: "member1_id");
            RenameIndex(table: "dbo.ActiveProjects", name: "IX_mem1_id", newName: "IX_member1_id");
            RenameIndex(table: "dbo.ActiveProjects", name: "IX_mem2_id", newName: "IX_member2_id");
            RenameIndex(table: "dbo.ActiveProjects", name: "IX_mem3_id", newName: "IX_member3_id");
            RenameIndex(table: "dbo.ProjectEvaluations", name: "IX_mem1_id", newName: "IX_member1_id");
            RenameIndex(table: "dbo.ProjectEvaluations", name: "IX_mem2_id", newName: "IX_member2_id");
            RenameIndex(table: "dbo.ProjectEvaluations", name: "IX_mem3_id", newName: "IX_member3_id");
            RenameIndex(table: "dbo.SubmittedProjects", name: "IX_mem1_id", newName: "IX_member1_id");
            AddColumn("dbo.ActiveProjects", "member1_name", c => c.String());
            AddColumn("dbo.ActiveProjects", "member2_name", c => c.String());
            AddColumn("dbo.ActiveProjects", "member3_name", c => c.String());
            DropColumn("dbo.ActiveProjects", "mem1_name");
            DropColumn("dbo.ActiveProjects", "mem2_name");
            DropColumn("dbo.ActiveProjects", "mem3_name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ActiveProjects", "mem3_name", c => c.String());
            AddColumn("dbo.ActiveProjects", "mem2_name", c => c.String());
            AddColumn("dbo.ActiveProjects", "mem1_name", c => c.String());
            DropColumn("dbo.ActiveProjects", "member3_name");
            DropColumn("dbo.ActiveProjects", "member2_name");
            DropColumn("dbo.ActiveProjects", "member1_name");
            RenameIndex(table: "dbo.SubmittedProjects", name: "IX_member1_id", newName: "IX_mem1_id");
            RenameIndex(table: "dbo.ProjectEvaluations", name: "IX_member3_id", newName: "IX_mem3_id");
            RenameIndex(table: "dbo.ProjectEvaluations", name: "IX_member2_id", newName: "IX_mem2_id");
            RenameIndex(table: "dbo.ProjectEvaluations", name: "IX_member1_id", newName: "IX_mem1_id");
            RenameIndex(table: "dbo.ActiveProjects", name: "IX_member3_id", newName: "IX_mem3_id");
            RenameIndex(table: "dbo.ActiveProjects", name: "IX_member2_id", newName: "IX_mem2_id");
            RenameIndex(table: "dbo.ActiveProjects", name: "IX_member1_id", newName: "IX_mem1_id");
            RenameColumn(table: "dbo.SubmittedProjects", name: "member1_id", newName: "mem1_id");
            RenameColumn(table: "dbo.ProjectEvaluations", name: "member3_id", newName: "mem3_id");
            RenameColumn(table: "dbo.ProjectEvaluations", name: "member2_id", newName: "mem2_id");
            RenameColumn(table: "dbo.ProjectEvaluations", name: "member1_id", newName: "mem1_id");
            RenameColumn(table: "dbo.ActiveProjects", name: "member3_id", newName: "mem3_id");
            RenameColumn(table: "dbo.ActiveProjects", name: "member2_id", newName: "mem2_id");
            RenameColumn(table: "dbo.ActiveProjects", name: "member1_id", newName: "mem1_id");
        }
    }
}
