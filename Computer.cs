using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracking
{
    internal class Computer : Asset
    {
        // child class for computers
        public Computer(string brand, string model, int price, DateTime date) 
        {
            this.model = model;
            this.brand = brand; 
            this.price = price;
            this.purchaseDate = date;
        }
    }
}
