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
        List<Office> offices = new List<Office>();
        
        
        public List<Asset> getList()
        {

            offices.AddRange(getOffice());
            assets.Add(new Computer("HP", "Spectre", 120, new DateTime(2020, 10, 27), offices[0]));
            assets.Add(new Computer("Apple", "Air", 250, new DateTime(2022, 7, 1), offices[1]));
            assets.Add(new Computer("Lenovo", "Yoga", 90, new DateTime(2019, 10, 11), offices[2]));
            assets.Add(new Computer("Asus", "Vivo", 135, new DateTime(2020, 10, 30), offices[0]));
            assets.Add(new Computer("Acer", "Aspire", 99, new DateTime(2021, 5, 17), offices[1]));
            assets.Add(new Phone("Nokia", "3310", 25, new DateTime(2020, 4, 28), offices[2]));
            assets.Add(new Phone("Samsung", "Galaxy", 150, new DateTime(2022, 2, 1), offices[0]));
            assets.Add(new Phone("Apple", "iPhone", 127, new DateTime(2020, 4, 27), offices[1]));
            assets.Add(new Phone("Sony", "Xperia", 85, new DateTime(2020, 2, 18), offices[2]));
            assets.Add(new Phone("HTC", "Desire", 75, new DateTime(2018, 7, 8), offices[0]));


            return assets;
        }

        public List<Office> getOffice()
        {
            offices.Add(new Office("Spain", "EUR", 1.1));
            offices.Add(new Office("UK", "GBP", 1.28));
            offices.Add(new Office("Sweden", "SEK", 0.095));
            return offices;
        }
         

    }
}
