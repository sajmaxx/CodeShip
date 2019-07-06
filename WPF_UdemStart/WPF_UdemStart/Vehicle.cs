using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_UdemStart
{
   public class Vehicle
    {
        public int Year  {get; set;}

        public string Make { get; set;} 

        public string Model { get; set;}


        public override string ToString()
        {
            return String.Format("Vehicle infor {0} {1} ",Year,Make);
    }


        //Vehicle()
        //{
        //    Year = 0;
        //    Make = "Unknown";
        //    Model = "Unknown";
        //}

    }
}
