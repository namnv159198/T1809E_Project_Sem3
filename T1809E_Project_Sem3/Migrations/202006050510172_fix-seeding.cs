namespace T1809E_Project_Sem3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixseeding : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "CustomerName", c => c.String());
            AlterColumn("dbo.Orders", "Address", c => c.String());
            AlterColumn("dbo.Orders", "Phone", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "Phone", c => c.String(nullable: false));
            AlterColumn("dbo.Orders", "Address", c => c.String(nullable: false));
            AlterColumn("dbo.Orders", "CustomerName", c => c.String(nullable: false));
        }
    }
}
