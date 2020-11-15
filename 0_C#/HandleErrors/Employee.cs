using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace HandleErrors
{
    public class Car
    {
        public string Brand { get; init; }
        public string Model { get; init; }
        public int  YearofMfg { get; init; }


        public Car()
        {

        }
        public Car(string brand, string model, int yearofMfg)
        {
            this.Brand = brand;
            this.Model = model;
            this.YearofMfg = yearofMfg;
        }



    }

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
