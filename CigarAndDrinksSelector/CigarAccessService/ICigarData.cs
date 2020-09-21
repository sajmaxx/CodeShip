using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CigarsDrinks.Core.Lib;

namespace CigarAccessService
{
    public interface ICigarData
    {
        IEnumerable<Cigar> GetCigarsList();
    }

    public class CigarDataReader : ICigarData
    {
        private List<Cigar> myCigars;
        public CigarDataReader()
        {
            myCigars =  new List<Cigar>()
            {
        
                new Cigar {UPC = 2020, Company = "Olvia", Brand = "V", YearofMfg = 2020, Country = "Nicaragua"},
                new Cigar {UPC = 3020, Company = "AJ", Brand = "Melanio", YearofMfg = 2020, Country = "Nicaragua"},
                new Cigar {UPC = 4020, Company = "Romeo", Brand = "O", YearofMfg = 2020, Country = "Nicaragua"},
                new Cigar {UPC = 6020, Company = "Plascencia", Brand = "Fatty", YearofMfg = 2020, Country = "Nicaragua"},
            };
        }
        public IEnumerable<Cigar> GetCigarsList()
        {
           return from cig in myCigars
               orderby  cig.Company
                   select cig;

        }
    }
}
