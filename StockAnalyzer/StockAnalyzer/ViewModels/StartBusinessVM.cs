using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockAnalyzer.Models;

namespace StockAnalyzer.ViewModels
{
    public class StartBusinessVM
    {

        public static NYSMarket NYSMrk {get; set;} = null;
        
        public static SPMarket SPMrk {get; set; } = null;

        public static void StartMarket()
        {
            Random dorando = new Random();


            var valu = dorando.Next(2,10);

            if (valu > 5)
            {
               StartBusinessVM.NYSMrk = new NYSMarket();
               StartBusinessVM.SPMrk = new SPMarket();
            }

        }

        public static void ForceMarketOpen()
        {
            NYSMrk = NYSMrk?? new NYSMarket();
        }
    }
}
