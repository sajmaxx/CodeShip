using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAnalyzer.Models
{
    public interface ITradeData
    {
        Nullable<double> MarketPrice {get; set;}
        
        double? PurchasedPrice {get; set;}

        Nullable<int> Quantity {get; set;}

        
    }
}
