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
        public string Thumbnails { get; set; }
        public decimal Price { get; set; }
        public int Discount { get; set; }
        public DateTime? CreateAt { get; set; }
        public Product()
        {
            this.CreateAt = DateTime.Now;
        }
        [Display(Name = "Category")]
        public int CategoryID { get; set; }
        [ForeignKey("CategoryID")]
        public Category category { get; set; }
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