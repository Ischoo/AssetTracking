﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracking
{
    internal class Phone : Asset
    {
        public Phone(string brand, string model, int price, DateTime date) 
        {
            this.model = model;
            this.brand = brand;
            this.price = price;
            this.purchaseDate = date;
        }
    }
}