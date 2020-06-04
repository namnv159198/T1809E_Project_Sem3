namespace T1809E_Project_Sem3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDB : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "CreatedAt", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "CreatedAt", c => c.DateTime(nullable: false));
        }
    }
}
