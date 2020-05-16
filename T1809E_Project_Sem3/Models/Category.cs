using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace T1809E_Project_Sem3.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public EnumStatus Status { get; set; }
        public enum EnumStatus
        {
            Active = 0,
            Deactive = 1,
            Deleted = -1
        }
    }
}