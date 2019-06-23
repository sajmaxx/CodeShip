using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventListener101
{

    /// <summary>
    /// This application will demonstrate
    ///  Use of C# delegate EventHandler
    /// And also use of EventHandler<T>
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            OvenCooker someOven = new OvenCooker("GE",2009, 2045);


            someOven.OnBroilEnded += MyEventListenerOb.BroilListener;

            someOven.OnBakeEnded += MyEventListenerOb.BakeListener;

            someOven.OnOvenMalfunction += MyEventListenerOb.MalfunctionListener;



            someOven.StartTheOven();


            someOven.EndTheBake();


            someOven.OnStartEvent += MyEventListenerOb.StartMeUp;

            someOven.StartTheOven();

            someOven.EndTheBroil();


            someOven.Standby();
            

            //someOven

        }



    }
}
