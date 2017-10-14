namespace PopsConfectionary14.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class s : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        CusID = c.Int(nullable: false, identity: true),
                        Cname = c.String(),
                        Surname = c.String(),
                        Address = c.String(),
                        Contact = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.CusID);
            
            AddColumn("dbo.Orders", "Address", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "Address");
            DropTable("dbo.Clients");
        }
    }
}
