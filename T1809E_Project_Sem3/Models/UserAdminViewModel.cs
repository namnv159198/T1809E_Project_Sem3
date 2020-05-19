using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace T1809E_Project_Sem3.Models
{
    public class UserAdminViewModel
    {   
        [Key]
        public string Id { get; set; }
        [Required (ErrorMessage ="Email required")]
        public string Email { get; set; }
        [Required]
        public string PassWord { get; set; }
        [Required]
        public string PasswordConfirm {get;set;}
        public DateTime Birthday { get; set; }
        public string Address { get; set; }
        public EnumStatus Status { get; set; }
        public enum EnumStatus
        {
            Active = 0,
            Banned = 1,
            Delete = -1

        }

        public string Phonenumber { get; set; }
      
        public DateTime CreateAt { get; set; } = DateTime.Now;

    }
}