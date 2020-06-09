using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace T1809E_Project_Sem3.Models
{
    public class ModelsChart
    {
        [DataContract]
        public class DataPoint
        {
            public DataPoint(int x, double y)
            {
                this.X = x;
                this.Y = y;
            }

            //Explicitly setting the name to be used while serializing to JSON.
            [DataMember(Name = "x")]
            public Nullable<int> X = null;

            //Explicitly setting the name to be used while serializing to JSON.
            [DataMember(Name = "y")]
            public Nullable<Double> Y = null;
        }
    }
}