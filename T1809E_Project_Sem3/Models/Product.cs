using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
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
        public ProductStatus Status { get; set; }
        public enum ProductStatus
        {
            Active = 0,
            DeActive = 1,
            Delete = -1
        }
        [Required]
        public string Description { get; set; }
        public string Thumbnails { get; set; }
        [Required]
        [Range(typeof(decimal), "0", "79228162514264337593543950335", ErrorMessage = "The Field Price Can Not < 0")]
        public decimal Price { get; set; }
        [Range(0, 100)]
        [Display(Name ="Discount (%)")]
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

        public string GetDefaultThumbnails()
        {
            if (this.Thumbnails != null && this.Thumbnails.Length > 0)
            {
                var arrayThumbnails = this.Thumbnails.Split(',');
                if (arrayThumbnails.Length > 0)
                {
                    return
                        ConfigurationManager.AppSettings["CloudinaryPrefix"] + arrayThumbnails[0];
                }

            }

            return
                ConfigurationManager.AppSettings["ImageNull"];
        }
        public string[] GetThumbnails()
        {
            if (this.Thumbnails != null && this.Thumbnails.Length > 0)
            {
                var arrayThumbnails = Thumbnails.Split(',');
                if (arrayThumbnails.Length > 0)
                {
                    return arrayThumbnails;
                }

            }

            return new string[0];
        }

        public string[] GetThumbnailIDs()
        {
            var idThumbnail = new List<string>();
            var thumbnails = GetThumbnails();
            foreach (var i in thumbnails)
            {
                // image/upload/v1587720852/trang-phuc-nakroth-bboy-cong-nghe-compressed_ewu3rb_qj7zct.jpg#81ad3dee47db0da23fae48523665b35024516448
                var SplittedThumbnails = i.Split('/');
                // [image,   upload,  v1587720852,  trang-phuc-nakroth-bboy-cong-nghe-compressed_ewu3rb_qj7zct.jpg#81ad3dee47db0da23fae48523665b35024516448] = 4
                //   0    ,  1 ,       2 ,             3]
                if (SplittedThumbnails.Length != 4)
                {
                    continue;
                }
                //[trang-phuc-nakroth-bboy-cong-nghe-compressed_ewu3rb_qj7zct.jpg#81ad3dee47db0da23fae48523665b35024516448]
                idThumbnail.Add(SplittedThumbnails[3].Split('.')[0]);
                // [trang-phuc-nakroth-bboy-cong-nghe-compressed_ewu3rb_qj7zct , jpg#81ad3dee47db0da23fae48523665b35024516448]
                // id = trang-phuc-nakroth-bboy-cong-nghe-compressed_ewu3rb_qj7zct 

            }
            return idThumbnail.ToArray();
        }
    }
}