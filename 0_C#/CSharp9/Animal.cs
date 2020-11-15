using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp9
{
    public class Animal
    {
        public int SpecID { get; set; } 
    }


    public class Zoo
    {
        private Animal anima1;
        private Animal anima2;

        public int ZipCode { get; init; }

        public Zoo()
        {
            anima1 = new Animal {  SpecID = 11};

            anima2 = new Animal { SpecID =  22};

        }
    }


    class SomethingToTry
    {
        public Zoo UCZoo { get; set; }
        
        public void DoThisNow()

        {
        }
    }

}
