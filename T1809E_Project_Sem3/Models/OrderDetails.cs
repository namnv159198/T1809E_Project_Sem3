using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace T1809E_Project_Sem3.Models
{
    public class OrderDetails
    {
        [Key, Column(Order = 0)]
        public string OrderId { get; set; }
        [ForeignKey("OrderId")]
        public virtual Order Order { get; set; }


        [Key, Column(Order = 1)]
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
        [Range(0,int.MaxValue)]
        public int Quantity { get; set; }
        [Range(0,double.MaxValue)]
        public decimal UnitPrice { get; set; }
        [Range(0,100)]
        public Double Discount { get; set; }

        
    }
}