﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_koncowy
{
   

    public class CryptoModel
    {
        public CryptoModel(string id, string symbol, string name, float current_price, int market_cap_rank, float high_24h, float low_24h, float price_change_24h, float ath, DateTime ath_date, DateTime last_updated)
        {
            this.id = id;
            this.symbol = symbol;
            this.name = name;
            this.current_price = current_price;
            this.market_cap_rank = market_cap_rank;
            this.high_24h = high_24h;
            this.low_24h = low_24h;
            this.price_change_24h = price_change_24h;
            this.ath = ath;
            this.ath_date = ath_date;
            this.last_updated = last_updated;
        }

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
