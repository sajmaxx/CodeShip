using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockAnalyzer.Models;

namespace StockAnalyzer.Models
{
    public class SPMarket : ITradeMarket
    {
        private List<ITradeData> _stockList;

        public SPMarket()
        {
            _stockList = new List<ITradeData>(0);
        }

        public void Buy(ITradeData tradeob)
        {
            throw new NotImplementedException();
        }

        public bool MarketOpen()
        {
            throw new NotImplementedException();
        }

        public void Sell(ITradeData tradeob)
        {
            throw new NotImplementedException();
        }
    }



    public class NYSMarket : ITradeMarket
    {
        private List<ITradeData> _stockList;

        public NYSMarket()
        {
            _stockList = new List<ITradeData>();
        }

        public void Buy(ITradeData tradeob)
        {
            throw new NotImplementedException();
        }

        public bool MarketOpen()
        {
            throw new NotImplementedException();
        }

        public void Sell(ITradeData tradeob)
        {
            throw new NotImplementedException();
        }
    }
}
