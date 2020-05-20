namespace T1809E_Project_Sem3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Entity_User : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Birthday", c => c.DateTime());
            DropColumn("dbo.AspNetUsers", "BirthdayAt");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "BirthdayAt", c => c.DateTime());
            DropColumn("dbo.AspNetUsers", "Birthday");
        }
    }
}
