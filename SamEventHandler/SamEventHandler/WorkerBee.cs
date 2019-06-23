using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamEventHandler
{
    public class WorkerBee
    {

       public event EventHandler OnJajaBoink;


        public event EventHandler<SpecialWorkEventArgs> OnAchievingWork;

        private double  force {get; set;} = 0;
        private double time {get; set; } = 0;


        public WorkerBee(double aforce, double atime)
        {
            force = aforce;
            time = atime;
        }

        public void DothaWork()
        {
            var wokwok = force*time;

            if (wokwok > 1000)
            {
              OnAchievingWork?.Invoke(this, new SpecialWorkEventArgs(wokwok));
              
            }

            if (wokwok > 3000)
            {
                OnJajaBoink?.Invoke(this, new EventArgs()) ;

            }
        }


        

    }


    public class SpecialWorkEventArgs : EventArgs
    {
        public SpecialWorkEventArgs(double awork)
        {
            Work = awork;
        }
        public double Work {get; set;} = 0;
    }
}
