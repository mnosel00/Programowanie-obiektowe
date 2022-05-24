using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_koncowy.Model
{

    /*public class CryptoModel
    {
        public CryptoCurrencyModel[] Property1 { get; set; }
    }*/

    public class CryptoCurrencyModel
    {
        public string symbol { get; set; }
        public string name { get; set; }
        public float current_price { get; set; }
        public long market_cap { get; set; }
        public int market_cap_rank { get; set; }
        public float high_24h { get; set; }
        public float low_24h { get; set; }
        public float price_change_24h { get; set; }

        public CryptoCurrencyModel(string symbol, string name, float current_price, long market_cap, int market_cap_rank, float high_24h, float low_24h, float price_change_24h)
        {
            this.symbol = symbol;
            this.name = name;
            this.current_price = current_price;
            this.market_cap = market_cap;
            this.market_cap_rank = market_cap_rank;
            this.high_24h = high_24h;
            this.low_24h = low_24h;
            this.price_change_24h = price_change_24h;
        }

    }
}