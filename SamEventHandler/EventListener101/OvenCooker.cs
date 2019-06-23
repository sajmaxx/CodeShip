using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EventListener101
{

    
    public class OvenCooker
    {
        public string Brand {get; set;}
        public int Year {get; set;}
        public int ModelNo {get; set;}

        public OvenCooker(string bran, int year, int modelnum)
        {
            Brand = bran;
            Year = year;
            ModelNo = modelnum;
        }

        public override string ToString()
        {
            return string.Format(" {0}   {1} {2} ", Brand, Year, ModelNo);

        }

        public event EventHandler OnStartEvent;

        public  event EventHandler<CookEventArgs> OnBakeEnded;

        public event EventHandler<CookEventArgs> OnBroilEnded;

        public event EventHandler OnOvenMalfunction;



        public void StartTheOven()
        {
            OnStartEvent?.Invoke(this, new EventArgs());
            Thread.Sleep(4000);
        }

        public void EndTheBroil()
        {
            Thread.Sleep(500);
            OnBroilEnded?.Invoke(this, new CookEventArgs(300));
        }


        public void EndTheBake()
        {
            Thread.Sleep(1000);
            OnBakeEnded?.Invoke(this,new CookEventArgs(400));
        }

        public void Standby()
        {
            Thread.Sleep(2000);

            OnOvenMalfunction?.Invoke(sender: this, new EventArgs());
        }

    }


    public class CookEventArgs : EventArgs
    {
        public int Time { get; set;}
        public CookEventArgs(int cooktime)
        {
            Time = cooktime;
        }
    }
}
