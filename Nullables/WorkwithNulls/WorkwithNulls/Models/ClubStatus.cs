using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkwithNulls.Models
{
    public abstract class ClubStatus
    {
        public abstract int DiscountPercentage(double price);
        

        public static ClubStatus Null {get;} = new NullClub();

        private class NullClub : ClubStatus
        {

            public override int DiscountPercentage(double price)
            {
                return 0;
            }
        }


    }



    public class GoldClub : ClubStatus
    {

        public override int DiscountPercentage(double price)
        {
            return 80;
        }
    }


    public class PlatinumClub : ClubStatus
    {
        public override int DiscountPercentage(double price)
        {
            return 99;
        }
    } 



}




