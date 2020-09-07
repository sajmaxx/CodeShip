using System;

namespace CarShop.CarProcessor
{
    public class Car
    {
        public Car()
        {
        }

        public  CarProperties BookCar(CarProperties carprop)
        {
            if (carprop == null)
            {
                throw new ArgumentNullException(nameof(carprop));
            }

            CarProperties Carmod = new CarProperties();

            Carmod.Brand = carprop.Brand;
            Carmod.Model = carprop.Model + "GT";
            Carmod.Year  = carprop.Year + 13;
            return Carmod;
        }
    }
}