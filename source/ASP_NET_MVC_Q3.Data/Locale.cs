using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_NET_MVC_Q3.Data
{
    public class Locale
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static List<Locale> Data = new List<Locale>
     {
            new Locale { Id = 1, Name = "US" },
            new Locale { Id = 2, Name = "CA" },
            new Locale { Id = 3, Name = "UK" },
            new Locale { Id = 4, Name = "FR" },
            new Locale { Id = 5, Name = "DE" },
            new Locale { Id = 6, Name = "ES" },
            new Locale { Id = 7, Name = "IT" },
            new Locale { Id = 8, Name = "CN" },
            new Locale { Id = 9, Name = "JP" },
            new Locale { Id = 10, Name = "EU" },
            new Locale { Id = 11, Name = "MX" }
        };
    }
}
