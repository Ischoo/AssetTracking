using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AssetTracking;

namespace AssetTracking
{
    internal class TestData
    {
        List<Asset> assets = new List<Asset>();
        
        
        public List<Asset> getList()
        {

            assets.Add(new Computer("HP", "Spectre", 120, new DateTime(2020, 10, 27)));
            assets.Add(new Computer("Apple", "Air", 250, new DateTime(2022, 7, 1)));
            assets.Add(new Computer("Lenovo", "Yoga", 90, new DateTime(2019, 10, 11)));
            assets.Add(new Computer("Asus", "Vivo", 135, new DateTime(2020, 10, 30)));
            assets.Add(new Computer("Acer", "Aspire", 99, new DateTime(2021, 5, 17)));
            assets.Add(new Phone("Nokia", "3310", 25, new DateTime(2020, 4, 28)));
            assets.Add(new Phone("Samsung", "Galaxy", 150, new DateTime(2022, 2, 1)));
            assets.Add(new Phone("Apple", "iPhone", 127, new DateTime(2020, 4, 27)));
            assets.Add(new Phone("Sony", "Xperia", 85, new DateTime(2020, 2, 18)));
            assets.Add(new Phone("HTC", "Desire", 75, new DateTime(2018, 7, 8)));


            return assets;
        }
         

    }
}
