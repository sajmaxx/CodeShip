using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CigarsDrinks.Core.Lib;

namespace CigarAccessService
{
    public interface ILiquorService
    {
        IEnumerable<Liqor> GetLiqorsList();
        IEnumerable<Liqor> GetLiqorListByName(string name);
    }


    public class LiqorsDataReader : ILiquorService
    {
        private List<Liqor> myLiqors;

        public bool shortListmode { get; set; }

        public LiqorsDataReader()
        {
            shortListmode = true;

                myLiqors = new List<Liqor>()
            {
                new Liqor("Whistle Pig", "Farm Rye Whiskey", 2020, 12),
                new Liqor("Whistle Pig", "Aged 12 Rye", 2020, 13),
                new Liqor("Michters", "Kentucky Bourbon", 2020, 4),
                new Liqor("Michters'","Rye Whiskey", 2020, 3)
            };
        }
        public IEnumerable<Liqor> GetLiqorsList()
        {
            return from liq in myLiqors
                orderby liq.Company
                    select liq;
        }

        public IEnumerable<Liqor> GetLiqorListByName(string name)
        {
            return from liq in myLiqors
                where string.IsNullOrEmpty(name) || (liq.Name.Contains(name))
                    orderby liq.Company
                        select liq;
                    
        }
    }
}
