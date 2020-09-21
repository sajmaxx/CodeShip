using System;
using System.Collections.Generic;
using System.Text;

namespace CigarsDrinks.Core.Lib
{
    public class Cigar
    {
        public int UPC { get; set; }
        public string  Company { get; set; }
        public string Brand  { get; set; }
        public int YearofMfg {get; set;}
        public string  Country { get; set; }
        public WrapperType Wrapper {get; set;}

        public Cigar()
        {
            

        }

        public Cigar(int upc, string company, string brand, int yearofMfg, string country)
        {
            UPC = upc;
            Company = company;
            Brand = brand;
            YearofMfg = yearofMfg;
            Country = country;

        }

    }
}
