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
            public DataPoint(double x, double y)
            {
                this.X = x;
                this.Y = y;
            }
            public DataPoint(string label, double y)
            {
                this.Label = label;
                this.Y = y;
            }
            public DataPoint(double y,string label )
            {
                this.Label = label;
                this.Y = y;
            }
            [DataMember(Name = "label")]
            public string Label = "";

            //Explicitly setting the name to be used while serializing to JSON.
            [DataMember(Name = "x")]
            public Nullable<double> X = null;

            //Explicitly setting the name to be used while serializing to JSON.
            [DataMember(Name = "y")]
            public Nullable<double> Y = null;
        }
	}
}