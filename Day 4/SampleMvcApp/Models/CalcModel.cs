using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleMvcApp.Models
{
    public class CalcModel
    {
        public double Value1 { get; set; }
        public double Value2 { get; set; }
        public double Result { get; set; }
        public string Operation { get; set; }

        public List<string> Operations {
            get
            {
                return new List<string>
                {
                    "Add","Subtract","Multiply","Divide"
                };
            }
        }
        //public override string ToString()
        //{
        //    return string.Format($"<h1>The Value1:{Value1}</h1><h1>The Value2:{Value2}</h1><h1>The Operation:{Operation}</h1>"); ;
        //}
    }
}