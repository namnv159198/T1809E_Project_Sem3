using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace T1809E_Project_Sem3.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public EnumStatus Status { get; set; }
        public enum EnumStatus
        {
            Active = 0,
            DeActive = 1,
            Delete = -1
        }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Thumbnails { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Range (0, 100)]
        public int Discount { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;
        
        [Display(Name = "Category")]
        public String CategoryName { get; set; }
        [ForeignKey("Name")]
        public Category Category { get; set; }
        [Display(Name = "Create By")]
        public String CreateById { get; set; }
        [ForeignKey("CreateById")]
        public virtual ApplicationUser CreateBy { get; set; }
        [Display(Name = "Update By")]
        public string UpdateById { get; set; }
        [ForeignKey("UpdateById")]
        public virtual ApplicationUser UpdateBy { get; set; }
        [Display(Name = "Delete By")]
        public String DeleteById { get; set; }
        [ForeignKey("DeleteById")]
        public virtual ApplicationUser DeleteBy { get; set; }
    }
}