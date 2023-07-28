using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracking
{
    internal class Office
    {
        public string country { get; set; }
        public string currency { get; set; }
        public double exchange { get; set; }

        public Office(string country, string currency, double exchange)
        {
            this.country = country;
            this.currency = currency;
            this.exchange = exchange;
        }
    }
}
