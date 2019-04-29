using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_NET_MVC_Q3.Data
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Locale { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public static List<Product> Data = new List<Product>
        {
            new Product { Id = 1, Name = "Apple AirPods with Wireless Charging Case (Latest Model)", Locale = "US", CreateDate = DateTime.Now },
            new Product { Id = 2, Name = "Bluetooth Kopfhörer Mini Bluetooth Ohrhörer Stereo Wireless (Weiß 2019)", Locale = "US", CreateDate = DateTime.Now.AddDays(-20), UpdateDate = DateTime.Now.AddDays(-5) },
            new Product { Id = 3, Name = "ÅMÅŽÕÑ Funda Para Caja De Airpods De Silicon Máxima Protección", Locale = "CA", CreateDate = DateTime.Now.AddHours(-5), UpdateDate = DateTime.Now.AddDays(-1)},
            new Product { Id = 4, Name = "バラ売り Apple 純正 国内正規品 AirPods 完全ワイヤレスイヤホン Bluetooth対応 MMEF2J/A 片側 バラ売り (右耳イヤホン)", Locale = "JP", CreateDate = DateTime.Now },
            new Product { Id = 5, Name = "DnA Tech® - Set di 2 piercing per orecchie, in silicone morbido, per airpods e EarPods, tenuta imbattibile nell'orecchio, perfetti per lo sport e il tempo libero 2x EarPlugs Blu", Locale = "DE", CreateDate = DateTime.Now },
        };
    }
}
