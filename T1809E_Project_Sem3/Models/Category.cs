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
        [Required(ErrorMessage = "Name is required.")]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Status")]
        public StatusEnum Status { get; set; }
        public enum StatusEnum
        {
            Active = 0,
            Deactive = 1,
            Delete = -1
        }
    }
}