using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace T1809E_Project_Sem3.Models
{
    public class MultipleTableJoin
    {
        public Category Category { get; set; }
        public Product Product { get; set; }
        public OrderDetails OrderDetails { get; set; }
        public Order Order { get; set; }
   
    }
}