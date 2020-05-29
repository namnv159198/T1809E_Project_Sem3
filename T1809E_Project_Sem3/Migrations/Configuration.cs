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

            //  This method will be called after migrating to the latest version.
            context.Categories.AddOrUpdate(x => x.Id,
                new Category() { Id = 0, Name = "Men", Status = Category.StatusEnum.Active },
                new Category() { Id = 1, Name = "Women", Status = Category.StatusEnum.Active }
            );
            var adminId = "Admin";
            var adminRoleId = "Admin";
            if (!context.Roles.Any(r => r.Id == adminRoleId))
            {
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
                var role = new IdentityRole { Id = adminRoleId, Name = "Admin" };
                roleManager.Create(role);
            }
            var adminId2 = "Employee";
            var adminRoleId2 = "Employee";
            if (!context.Roles.Any(r => r.Id == adminRoleId2))
            {
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
                var role = new IdentityRole { Id = adminRoleId2, Name = "Employee" };
                roleManager.Create(role);
            }

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
