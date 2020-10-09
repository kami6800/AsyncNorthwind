using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class ExchangeRate
    {
        private double _rate;
        public double Rate
        {
            get { return _rate; }
            set { _rate = value; }
        }
        private string _currency;
        public string Currency
        {
            get { return _currency; }
            set { _currency = value; }
        }

        public ExchangeRate(string currency, double rate)
        {
            Rate = rate;
            Currency = currency;
        }
    }
}
