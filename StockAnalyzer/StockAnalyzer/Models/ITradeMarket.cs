using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAnalyzer.Models
{
    public interface ITradeMarket
    {
        void Sell(ITradeData tradeob);
        void Buy(ITradeData tradeob);
        bool MarketOpen();
    }
}
