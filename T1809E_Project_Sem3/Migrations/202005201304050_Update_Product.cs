namespace T1809E_Project_Sem3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_Product : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Status = c.Int(nullable: false),
                        Description = c.String(nullable: false),
                        Thumbnails = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Discount = c.Int(nullable: false),
                        CreateAt = c.DateTime(),
                        CategoryID = c.Int(nullable: false),
                        CreateById = c.String(maxLength: 128),
                        UpdateById = c.String(maxLength: 128),
                        DeleteById = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.CreateById)
                .ForeignKey("dbo.AspNetUsers", t => t.DeleteById)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdateById)
                .Index(t => t.CategoryID)
                .Index(t => t.CreateById)
                .Index(t => t.UpdateById)
                .Index(t => t.DeleteById);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "UpdateById", "dbo.AspNetUsers");
            DropForeignKey("dbo.Products", "DeleteById", "dbo.AspNetUsers");
            DropForeignKey("dbo.Products", "CreateById", "dbo.AspNetUsers");
            DropForeignKey("dbo.Products", "CategoryID", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "DeleteById" });
            DropIndex("dbo.Products", new[] { "UpdateById" });
            DropIndex("dbo.Products", new[] { "CreateById" });
            DropIndex("dbo.Products", new[] { "CategoryID" });
            DropTable("dbo.Products");
        }
    }
}
