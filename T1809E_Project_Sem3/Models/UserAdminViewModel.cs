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
        [Required(ErrorMessage = "Email required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "PassWord required")]
        public string PassWord { get; set; }
        [Required(ErrorMessage = "Password Confirm required")]
        public string PasswordConfirm { get; set; }
        public DateTime? Birthday { get; set; }
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
    }
}