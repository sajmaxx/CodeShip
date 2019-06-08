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
            _stockList.Add(tradeob);
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
            bool zerostate = _stockList.Count == 0;
            //UseTheOtherMethod
        }

        public void Buy(ITradeData tradeob)
        {//Deprecate this for now!
           _stockList.Add(tradeob);
        }

        public bool MarketOpen()
        {//Deprecate this for now!
            _stockList.Clear();
            return true;
        }

        public void Sell(ITradeData tradeob)
        {//Deprecate this for now!
            throw new NotImplementedException();
        }
    }
}
