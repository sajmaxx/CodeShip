using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace CigarsDrinks.Core.Lib
{
    public class Gun : IDisposable
    {
        public int  DateYear { get; set; }
        public int ModelNo { get; set; }
        public string Mfg { get; set; }
        public string Name  {get; set;}
        public string TriggerMechanism { get; set; }

        public Gun()
        {
                
        }

        public Gun(int year, int modelNo, string mfg, string name, string triggerType)
        {
            if (true)
            {
                DateYear = year;
                ModelNo = modelNo;
                Mfg = mfg;
                Name = name;
                TriggerMechanism = triggerType;  
            }
        }

        public override string ToString()
        {
            return $"{nameof(DateYear)}: {DateYear}, {nameof(ModelNo)}: {ModelNo}, {nameof(Mfg)}: {Mfg}";
        }

        public void Dispose()
        {
        }
    }
}
