using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace T1809E_Project_Sem3.Models
{
    public class Order
    {
        [Key]
        public String Id { get; set; }
        public double TotalPrice { get; set; }
        public double Discount { get; set; }
   
        public String CustomerName { get; set; }
   
        public string Address { get; set; }
     
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string Phone { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Not a valid email.")]
        public string Email { get; set; }
        public OrderEnumGender Gender { get; set; }
        public enum OrderEnumGender
        {
            Male = 1,
            Female = 0,
            Other = -1
        }
        public string CreatedById { get; set; }
        public string UpdatedById { get; set; }
        [ForeignKey("CreatedById")]
        public ApplicationUser CreatedBy { get; set; }
        [ForeignKey("UpdatedById")]
        public ApplicationUser UpdatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
       
        public DateTime? UpdatedAt { get; set; }
        public DateTime? deletedAt { get; set; }
        public OrderStatus Status { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }

        public void AddOrderDetails(OrderDetails orderDetails)
        {
            if (this.OrderDetails == null)
            {
                this.OrderDetails = new List<OrderDetails>();
            }

            this.OrderDetails.Add(orderDetails);
            this.TotalPrice += orderDetails.Product.Price * orderDetails.Quantity;
        }

    }

    public enum OrderStatus
    {
        New = 0,
        Pending = 1,
        Processing = 2,
        Complete = 3,
        Shipping = 4,
        Payment_completed = 5,
        Order_Completed = 6,
        Delete = -1,
    }
}