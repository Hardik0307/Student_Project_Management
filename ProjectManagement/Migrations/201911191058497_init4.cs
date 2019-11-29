namespace ProjectManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init4 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "branch");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "branch", c => c.String(nullable: false));
        }
    }
}
