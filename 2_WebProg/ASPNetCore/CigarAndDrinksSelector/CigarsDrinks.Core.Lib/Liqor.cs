using System;
using System.Collections.Generic;
using System.Text;

namespace CigarsDrinks.Core.Lib
{
    public class Liqor
    {
        public string Company { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public int Age { get; set; }

        public Liqor()
        {
            

        }

        public Liqor(string company, string name, int year, int age)
        {
            Company = company;
            Name = name;
            Year = year;
            Age = age;
        }
    }
}
