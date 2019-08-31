using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCon101.Models
{
    public class AbstractCars
    {
        private int _modelno = 0;
        private string modelname = "";
        
        
        public bool? Whodidthis {get; set;} = null;
        public int? YearofMfg {get; set;}
        public double? FuelMileage {get; set;}
        public byte? MyNameType {get; set;}
        public string DODO {get; set;} = null;


        public int Modelno
        {
            get { return _modelno; }
            set { _modelno = value; }
        }

        public string Modelname
        {
            get { return modelname; }
            set { modelname = value; }
        }


        public AbstractCars(int modno, string modna)
        {
            _modelno = modno;
            modelname = modna;
            YearofMfg = null;
            FuelMileage = null;
            MyNameType = null;
        }

        public void CheckNullableParams()
        {

            if (string.IsNullOrEmpty(DODO))
            {
                Console.WriteLine("Name Not Initialized");
            }

            int yearofint = YearofMfg.HasValue ? YearofMfg.Value : 200;


            double someval = FuelMileage.HasValue ? FuelMileage.Value : 777.77;


             var getsomething = MyNameType.HasValue ? MyNameType.Value : 4;


            Nullable<byte> getsomdefVal = MyNameType.HasValue ? MyNameType : 55;

            FuelMileage = 3000.4;

            Nullable<double> dodub =  (FuelMileage > 400) ? FuelMileage.Value : 2200;




        }


        public override string ToString()
        {
            return string.Format("well well well it is {0} {1}", Modelno, Modelname);
        }
    }
}
