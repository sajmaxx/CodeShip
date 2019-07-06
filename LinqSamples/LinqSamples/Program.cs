using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqSamples
{

    public static class EmployeeExtensions
    {
        static public double ToDouble(this Employee empro)
        {
            double resultval = empro.Id + 100.456;
            return resultval;
        }
    }

    class Program
    {




        static void Main(string[] args)
        {

            IEnumerable<Employee> developers = new Employee[]
            {
                new Employee {Id = 1, Name = "VijayK"},
                new Employee {Id = 2, Name = "KyleH"},
                new Employee {Id = 5, Name = "PranavT"},
                new Employee {Id = 6, Name = "Brendor"},
                new Employee {Id = 14, Name = "Robin"},
                new Employee {Id = 26, Name = "ABrendor"}
            };


            IEnumerable<Employee> salesmgrs = new List<Employee>()
            {
                new Employee {Id = 3, Name = "RyanL"}
            };


            foreach (var dev in developers)
            {
                Console.WriteLine("\nDeveloper {0} has id {1}", dev.Name, dev.Id);
                Console.WriteLine("Developer Special Val is " + dev.ToDouble());
                Console.WriteLine(" Dev Extender  Name of Dev" + dev.GetNameOfDev());
                Console.WriteLine(" Dev Extender Special id is " + dev.WeightedId());

            }


            Console.WriteLine("\n\n=========  Comemencing use of  IEnumerator");

            IEnumerator<Employee> empenum = developers.GetEnumerator();
            while (empenum.MoveNext())
            {
                Console.WriteLine(" Dev Employee is " + empenum.Current.Name);
            }

            Console.ReadKey();
        }
    }
}
