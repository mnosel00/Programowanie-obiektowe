using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_koncowy
{
    /*public class ExchangeRates
    {*/

        public class Rootobject
        {
            public bool success { get; set; }
            public Query query { get; set; }
            public Info info { get; set; }
            public string date { get; set; }
            public float result { get; set; }
        }

        public class Query
        {
            public string from { get; set; }
            public string to { get; set; }
            public int amount { get; set; }
        }

        public class Info
        {
            public int timestamp { get; set; }
            public float rate { get; set; }
        }

    }
//}
