using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace T1809E_Project_Sem3.Models
{
    public class Customer
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public EnumGender Gender { get; set; }
        public enum EnumGender 
        {
            Male = 0,
            Female = 1,
            Other = 2
        }
        public DateTime CreateAt { get; set; }
        public int Total_Quantity_Purchased { get; set; }
        public int Total_Money_Purchased { get; set; }
    }
}