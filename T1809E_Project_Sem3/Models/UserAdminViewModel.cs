using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace T1809E_Project_Sem3.Models
{
    public class UserAdminViewModel
    {
        [Key]
        public string Id { get; set; }
        [StringLength(50)]
        [DisplayName("User Name")]
        [Required]
        public string UserName { get; set; }
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string PassWord { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string PasswordConfirm { get; set; }
        public DateTime? Birthday { get; set; }
        public DateTime? CreatedAt { get; set; }
        [Required]
        [StringLength(255)]
        public string Address { get; set; }
        [Required]
        public EnumStatus Status { get; set; }
        public enum EnumStatus
        {
            Active = 0,
            Banned = 1,
            Delete = -1

        }
        [Required]
        [StringLength(10)]
        [Phone(ErrorMessage = "Please enter a valid Phone No")]
        public string Phonenumber { get; set; }

        public UserAdminViewModel()
        {
            this.CreatedAt = DateTime.Now;
        }

    }
}