using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventListener101
{
    public static class MyEventListenerOb
    {
        
        public static void StartMeUp(object s, EventArgs e)
        {
            Console.WriteLine("\n\nSTART ME UP\n\n");
        }

        public static void BroilListener(object sender, CookEventArgs cooke)
        {
            Console.WriteLine("Broil Done ", cooke.Time);

        }


        public static void BakeListener(object send, CookEventArgs cooke)
        {
            Console.WriteLine("Baking is done ", cooke.Time);
        }


        public static void MalfunctionListener(object s, EventArgs e)
        {
            Console.WriteLine("Major Malfunction");
        }
    }
}
