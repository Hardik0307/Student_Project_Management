namespace ProjectManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init14 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.ProjectEvaluations");
            AlterColumn("dbo.ProjectEvaluations", "ProjectEvalId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.ProjectEvaluations", "ProjectEvalId");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.ProjectEvaluations");
            AlterColumn("dbo.ProjectEvaluations", "ProjectEvalId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.ProjectEvaluations", "ProjectEvalId");
        }
    }
}
