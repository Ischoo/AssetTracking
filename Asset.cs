using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracking
{
    internal class Asset
    {
        // parent class for all assets
        public string brand { get; set; }
        public string model { get; set; }
        public int price { get; set; }
        public DateTime purchaseDate { get; set; }

    }

    

}
