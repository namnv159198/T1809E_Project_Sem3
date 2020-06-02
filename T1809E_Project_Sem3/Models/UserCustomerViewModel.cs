using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace T1809E_Project_Sem3.Models
{
    public class UserCustomerViewModel
    {
        [Key]
        public string Id { get; set; }
        [StringLength(50)]
        [DisplayName("User Name")]
        [Required]
        public string UserName { get; set; }
        [StringLength(100)]
        [DisplayName("Address")]
        [Required]
        public string Address { get; set; }
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Not a valid email.")]
        public string Email { get; set; }
        [Required]
        [StringLength(10)]
        [Display(Name = "Phone Number")]
        [Phone(ErrorMessage = "Please enter a valid Phone Number")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string Phonenumber { get; set; }
        public DateTime? CreatedAt { get; set; }
        public EnumStatus Status { get; set; }
        public enum EnumStatus
        {
            Active = 0,
            Deactive = 1,
            Delete = -1
        }
        [Required]
        public EnumGender Gender { get; set; }
        public enum EnumGender
        {
            Male = 0,
            Female = 1,
            Other = 2
        }
        [Required]
        [Display(Name = "Customer Type")]
        public EnumCustomer_Type Customer_Type { get; set; }
        public enum EnumCustomer_Type
        {
            Normal = 0,
            Loyal = 1,
            Vip = 2
        }
        [Range(typeof(decimal), "0", "79228162514264337593543950335", ErrorMessage = "the field total money purchased cannot be negative.")]
        [Display(Name = "Total Money Purchased")]
        public decimal Total_Money_Purchased { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "the field total quantity purchased cannot be negative.")]
        [Display(Name = "Total Quantity Purchased")]
        public int Total_Quantity_Purchased { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "the field total purchased cannot be negative.")]
        [Display(Name = "Total Purchased")]
        public int Total_Purchased { get; set; }
    }
}