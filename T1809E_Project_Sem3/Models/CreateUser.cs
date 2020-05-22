using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace T1809E_Project_Sem3.Models
{
    public class CreateUser
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name ="Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name ="Confirm Password")]
        [Compare("Password", ErrorMessage = "The Password and Confirm Password do not math.")]
        public string ConfirmPassword { get; set; }
        public string Address { get; set; }
        public string Username { get; set; }
        [Display(Name ="Phone Number")]
        public string PhoneNumber { get; set; }
        public DateTime CreateAt { get; set; }
        //public UserStatus Status { get; set; }
        //public enum UserStatus
        //{
        //    Active = 1,
        //    Block = 0
        //}
    }

    public class User
    {
        
        public string Id { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime CreateAt { get; set; }
        public UserStatus Status { get; set; }
        public enum UserStatus
        {
            Active = 1,
            Block = 0
        }
        public User(ApplicationUser user)
        {
            Id = user.Id;
            Email = user.Email;
            Address = user.Address;
            UserName = user.UserName;
            PhoneNumber = user.PhoneNumber;
            CreateAt = user.CreateAt;
        }
        public User()
        {
            
        }

    }

}