using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_DataSourceBindOb
{
    public class WorkerMan
    {
        string FirstName {get; set;} = "";
        int? Age { get; set;} = null;
        int? StreetNo {get; set;} = null;

        public WorkerMan( string afirstnam, int age, int stretno)
        {
            FirstName = afirstnam;

            Age = age;

            StreetNo = stretno;
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}", FirstName, Age, StreetNo);
        }

    }
}
