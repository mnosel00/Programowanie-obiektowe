using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_koncowy
{
    /*public class Date
    {

        public class Root
        {
            public List<CryptoModel> Property1 { get; set; }
        }

        public class CryptoModel
        {
            public string id { get; set; }
            public string symbol { get; set; }
            public string name { get; set; }
            public float current_price { get; set; }
            public int market_cap_rank { get; set; }
            public float high_24h { get; set; }
            public float low_24h { get; set; }
            public float price_change_24h { get; set; }
            public float ath { get; set; }
            public DateTime ath_date { get; set; }
            public DateTime last_updated { get; set; }
        }

       

    }*/


    public class CryptoModel
    {
        public string id { get; set; }
        public string symbol { get; set; }
        public string name { get; set; }
        public float current_price { get; set; }
        public int market_cap_rank { get; set; }
        public float high_24h { get; set; }
        public float low_24h { get; set; }
        public float price_change_24h { get; set; }
        public float ath { get; set; }
        public DateTime ath_date { get; set; }
        public DateTime last_updated { get; set; }
    }
}
