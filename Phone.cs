﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracking
{
    internal class Phone : Asset
    {
        // child class for phones
        public Phone(string brand, string model, int price, DateTime date, Office office) 
        {
            this.model = model;
            this.brand = brand;
            this.price = price;
            this.purchaseDate = date;
            this.office = office;
        }
    }
}
