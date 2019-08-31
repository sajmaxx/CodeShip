using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentAsObj.Models
{
    public class TouristMan
    {

        public int TourId {get; set;}
        public string  TourName {get; set;}
        public string Description {get; set;}
        public bool MultiDay {get; set;}

        public override string ToString()
        {
            return TourName + Description + " " + TourName +  " " + TourId.ToString();
            }
    }
}
