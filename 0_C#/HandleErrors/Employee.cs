using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace HandleErrors
{
    public class Employee
    {
        public string FirstName { get; set; }
        public string  LastName { get; set; }

        public Car DeFerrari { get; set; }
        //public int SSN { get; init;}

        public void CheckStuff()
        {
            if (string.IsNullOrWhiteSpace(FirstName) || string.IsNullOrWhiteSpace(LastName))
            {
                 FirstName = "lala";
                 LastName = "baba";
            }
        }

        public void DoAllCalculations(string memNO)
        {
            var number = int.Parse(memNO);

            long toto = 100;
            GetMyCaclToto(number, toto);
        }

        private static void GetMyCaclToto(int number, long toto)
        {
            for (long i = 2; i < number; i++)
            {
                if (toto > 400)
                {
                    toto += i * 100;
                    break;
                }
            }
        }


        private double GetCostofCar(Car thecar)
        {
            Car somecar = thecar ?? throw new ArgumentNullException(nameof(thecar));

            return 10000 - somecar.YearofMfg*2;
        }
        public Employee()
        {
             DeFerrari = new Car
             {
                Brand = "Ferrari" ,
                Model = "TestaRossa",
                YearofMfg = 1992
             };

            Car LotusExparanza = null;

            this.GetCostofCar(LotusExparanza);


        }
    }
}
