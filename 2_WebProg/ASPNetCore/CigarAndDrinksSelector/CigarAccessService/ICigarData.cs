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
        IEnumerable<Cigar> GetCigarsByCompanyName(string name);
    }

    public class CigarDataReader : ICigarData
    {
        private List<Cigar> myCigars;
        public CigarDataReader()
        {
            myCigars =  new List<Cigar>()
            {
        
                new Cigar {UPC = 2020, Company = "Olvia", Brand = "V", YearManufactured = 2020, CountryOfOrigin = "Nicaragua"},
                new Cigar {UPC = 3020, Company = "AJ", Brand = "Melanio", YearManufactured = 2020, CountryOfOrigin = "Nicaragua"},
                new Cigar {UPC = 4020, Company = "Romeo", Brand = "O", YearManufactured = 2020, CountryOfOrigin = "Nicaragua"},
                new Cigar {UPC = 6020, Company = "Plascencia", Brand = "Fatty", YearManufactured = 2020, CountryOfOrigin = "Nicaragua"},
            };
        }
        public IEnumerable<Cigar> GetCigarsList()
        {
           return from cig in myCigars
               orderby  cig.Company
                   select cig;

        }

        public IEnumerable<Cigar> GetCigarsByCompanyName(string name)
        {
            return from cig in myCigars
                where string.IsNullOrEmpty(name) || cig.Company.StartsWith(name)
                orderby cig.Brand
                    select cig;
        }
    }
}
