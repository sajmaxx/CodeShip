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
}
