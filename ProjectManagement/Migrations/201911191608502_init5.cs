namespace ProjectManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init5 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CreateProjects", "Pdef", c => c.String(nullable: false));
            AlterColumn("dbo.CreateProjects", "Psub", c => c.String(nullable: false));
            DropColumn("dbo.CreateProjects", "Nmem");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CreateProjects", "Nmem", c => c.Int(nullable: false));
            AlterColumn("dbo.CreateProjects", "Psub", c => c.String());
            AlterColumn("dbo.CreateProjects", "Pdef", c => c.String());
        }
    }
}
