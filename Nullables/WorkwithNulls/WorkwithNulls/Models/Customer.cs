using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkwithNulls.Models
{


    public enum MapEnum
    {
        usa,
        russia,
        japan,
        brazil
    }
    public class Customer
    {
         public int? Age {get; set;}
         public DateTime? OriginDate {get; set;}
         public ClubStatus Clubystrat {get; set; } = ClubStatus.Null;



         public Customer()
         {
             Age = null;
             OriginDate = null;
         }



         ///IMPLEMENT A DO-NOTHING BEHAVIOR OBJECT THAT IS THE NULL OBJECT!

    }
}
