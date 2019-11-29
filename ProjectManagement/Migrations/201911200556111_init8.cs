namespace ProjectManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init8 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ActiveProjects", "PrjTitle", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ActiveProjects", "PrjTitle", c => c.String());
        }
    }
}
