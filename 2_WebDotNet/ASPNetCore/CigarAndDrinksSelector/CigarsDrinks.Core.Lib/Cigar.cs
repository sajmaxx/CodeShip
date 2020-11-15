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
        public int YearManufactured {get; set;}
        public string  CountryOfOrigin { get; set; }
        public WrapperType WrapperLeaf {get; set;}

        public Cigar()
        {
            WrapperLeaf = WrapperType.none; 
            
        }

        public Cigar(int upc, string company, string brand, int yearManufactured, string countryOfOrigin)
        {
            UPC = upc;
            Company = company;
            Brand = brand;
            YearManufactured = yearManufactured;
            CountryOfOrigin = countryOfOrigin;
            WrapperLeaf = WrapperType.colorado;

        }

    }
}
