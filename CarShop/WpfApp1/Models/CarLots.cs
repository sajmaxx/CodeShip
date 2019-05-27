using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Models
{
    public static class CarLots
    {
        private static List<Car> CarList;
        public static void LoadFromDB()
        {
            CarList = new List<Car>();
        }

        public static List<Car> GetMyCars()
        {
            LoadFromDB();

            CarList.Add(new Car() { VIN=33, Model="GT", Brand="Ford"} );
            CarList.Add(new Car() { VIN=33, Model="Hysteria", Brand="Ford"} );
            CarList.Add(new Car() { VIN=33, Model="Edge", Brand="Ford"} );
            CarList.Add(new Car() { VIN=33, Model="Focus", Brand="Ford"} );

            CarList.Add(new Car() {VIN=77, Model="Toyota", Brand="Celica"});
            CarList.Add(new Car() {VIN=771, Model="Honda", Brand="Budge"});


            return CarList;
        }
    }

    public class Car
    {
        public int VIN {get; set;}
        public string Model {get; set;}
        public string Brand { get; set;}

        public override string ToString()
        {
            return String.Format("Brand {0} Model{1} VIN{2}",Brand, Model, VIN);
        }
    }
}
