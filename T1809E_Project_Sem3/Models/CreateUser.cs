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
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Not a valid email.")]
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
        [Required]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string PhoneNumber { get; set; }
        public DateTime CreateAt { get; set; }
        public User.GenderEnum Gender { get; set; }
        public enum GenderEnum
        {
            Male = 0,
            Female = 1,
            Other = 2
        }
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
        public GenderEnum Gender { get; set; }
        public enum GenderEnum
        {
            Male = 0,
            Female = 1,
            Other = 2
        }
        public enum UserStatus
        {
            Active = 0,
            Banned = 1,
            Delete = -1
        }
        public User(ApplicationUser user)
        {
            Id = user.Id;
            Email = user.Email;
            Address = user.Address;
            UserName = user.UserName;
            PhoneNumber = user.PhoneNumber;
            CreateAt = user.CreateAt;
            Status = user.Status;
            Gender = user.Gender;
        }
        public User()
        {
            
        }

    }

}