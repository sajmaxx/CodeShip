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

        public StockData(int quanta)
        {
            Quantity = quanta;
            //MarketPrice = MarketPrice ?? 100;

           // PurchasedPrice = PurchasedPrice ?? 100;

        }

        public double? MarketPrice { get; set; }
        
        public double? PurchasedPrice { get; set; }
        
        public int? Quantity { get; set; }
    }
}
