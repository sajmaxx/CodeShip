using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAnalyzer.Models
{
    public class StockData : ITradeData
    {
        public StockData()
        {
            MarketPrice = 0;
            PurchasedPrice = 0;
            Quantity = 0;
        }


        //List UseTheOtherMethod _stockList

        public StockData(int quanta)
        {
            Quantity = quanta;
            //MarketPrice = MarketPrice ?? 100;

           // PurchasedPrice = PurchasedPrice ?? 100;

        }

        // What is life? os windows 10 is life?
        public double? MarketPrice { get; set; }
        
        // What is life? os windows 10 is life?
        public double? PurchasedPrice { get; set; }
        
       // What is life? os windows 10 is life?
       public int? Quantity { get; set; }
    }
}
