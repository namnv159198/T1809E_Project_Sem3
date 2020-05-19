namespace T1809E_Project_Sem3.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using T1809E_Project_Sem3.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<T1809E_Project_Sem3.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(T1809E_Project_Sem3.Models.ApplicationDbContext context)
        {
            ////  This method will be called after migrating to the latest version.
            //context.Categories.AddOrUpdate(x => x.Id,
            //    new Category() { Id = 1, Name = "Đồng hồ Nam", Status = Category.StatusEnum.Active },
            //    new Category() { Id = 2, Name = "Đồng hồ Nữ", Status = Category.StatusEnum.Active },
            //    new Category() { Id = 3, Name = "Đồng hồ cho Trẻ Em", Status = Category.StatusEnum.Active },
            //    new Category() { Id = 4, Name = "Đồng hồ Apple", Status = Category.StatusEnum.Active },
            //    new Category() { Id = 5, Name = "Đồng hồ Rolex", Status = Category.StatusEnum.Active },
            //    new Category() { Id = 6, Name = "Đồng hồ Việt Nam", Status = Category.StatusEnum.Active }
            //);
            //var adminId = "Admin";
            //var adminRoleId = "Admin";
            //if (!context.Roles.Any(r => r.Id == adminRoleId))
            //{
            //    var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            //    var role = new IdentityRole { Id = adminRoleId, Name = "Admin" };
            //    roleManager.Create(role);
            //}
            //var adminId2 = "Employee";
            //var adminRoleId2 = "Employee";
            //if (!context.Roles.Any(r => r.Id == adminRoleId2))
            //{
            //    var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            //    var role = new IdentityRole { Id = adminRoleId2, Name = "Employee" };
            //    roleManager.Create(role);
            //}
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
