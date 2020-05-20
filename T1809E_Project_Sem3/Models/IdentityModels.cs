using System;
using System.ComponentModel.DataAnnotations;

using System.ComponentModel.DataAnnotations.Schema;

using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace T1809E_Project_Sem3.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {



        [Display(Name = "Address")]
        public string Address { get; set; }
        [Display(Name = "Birthday")]
        public DateTime? BirthdayAt { get; set; }
        [Display(Name = "Gender")]
        public GenderEnum Gender { get; set; }
        public enum GenderEnum
        {
            Male = 0,
            Female = 1,
            Other = 2
        }
        public EnumStatus Status { get; set; }
        public enum EnumStatus
        {
            Active = 0,
            Banned = 1,
            Delete = -1

        }
        public DateTime CreateAt { get; set; }
        public ApplicationUser()
        {
            this.CreateAt = DateTime.Now;
        } 



        

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole() : base() { }
        public ApplicationRole(string roleName) : base(roleName) { }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<T1809E_Project_Sem3.Models.Category> Categories { get; set; }

       
    }
}