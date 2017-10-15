namespace PopsConfectionary14.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Archhive : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "IsActive");
        }
    }
}
