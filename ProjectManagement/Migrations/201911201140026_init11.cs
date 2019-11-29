namespace ProjectManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init11 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProjectEvaluations", "member1_id", "dbo.Users");
            DropIndex("dbo.ProjectEvaluations", new[] { "member1_id" });
            AlterColumn("dbo.ProjectEvaluations", "member1_id", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.ProjectEvaluations", "member1_id");
            AddForeignKey("dbo.ProjectEvaluations", "member1_id", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProjectEvaluations", "member1_id", "dbo.Users");
            DropIndex("dbo.ProjectEvaluations", new[] { "member1_id" });
            AlterColumn("dbo.ProjectEvaluations", "member1_id", c => c.String(maxLength: 128));
            CreateIndex("dbo.ProjectEvaluations", "member1_id");
            AddForeignKey("dbo.ProjectEvaluations", "member1_id", "dbo.Users", "Id");
        }
    }
}
