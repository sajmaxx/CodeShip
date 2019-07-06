using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqSamples
{
    public static class EmploExtensions
    {
        public static string GetNameOfDev(this Employee emplo)
        {
            return emplo.Name + " _ " +  emplo.Id.ToString();

        }


        public static int WeightedId(this Employee emplo)
        {
            return emplo.Id + 2900;
        }


       // public static int TotalCountSoFar (this Employee emplo)
       // {
       //     return 
       // }

    }
}
