using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Models
{
    public class FibonacciSeq : IEnumerable<int>
    {
         public int NumberOfValues {  get; set;}

         public Nullable<bool> UseAgain { get; set;}

         public bool? StartStatus { get; set;}

         public bool? InProgress {get; set;}

         public int? CurrentNum {get; set;}

         public Nullable<int> StartIndex { get; set;}


         public void SetPropsWithDefaults()
        {
            UseAgain = true;
            StartIndex = 1;
            StartStatus = true;
        }

         public FibonacciSeq(int numofval)
         {
             NumberOfValues = numofval;
         }



        IEnumerator IEnumerable.GetEnumerator()
        {
            return new FiboEnumera(NumberOfValues);
        }


        public IEnumerator<int> GetEnumerator()
        {
            return new FiboEnumera(NumberOfValues);
        }
    }
}
