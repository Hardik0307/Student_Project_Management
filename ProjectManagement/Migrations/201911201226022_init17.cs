namespace ProjectManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init17 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SubmittedProjects", "member1_id", "dbo.Users");
            DropIndex("dbo.SubmittedProjects", new[] { "member1_id" });
            AlterColumn("dbo.SubmittedProjects", "member1_id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.SubmittedProjects", "ProjectFile", c => c.String(nullable: false));
            CreateIndex("dbo.SubmittedProjects", "member1_id");
            AddForeignKey("dbo.SubmittedProjects", "member1_id", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubmittedProjects", "member1_id", "dbo.Users");
            DropIndex("dbo.SubmittedProjects", new[] { "member1_id" });
            AlterColumn("dbo.SubmittedProjects", "ProjectFile", c => c.String());
            AlterColumn("dbo.SubmittedProjects", "member1_id", c => c.String(maxLength: 128));
            CreateIndex("dbo.SubmittedProjects", "member1_id");
            AddForeignKey("dbo.SubmittedProjects", "member1_id", "dbo.Users", "Id");
        }
    }
}
