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
        public string FullName { get; set; }

        public static List<Locale> Data = new List<Locale>
     {
            new Locale { Id = 1, Name = "US", FullName="United States" },
            new Locale { Id = 5, Name = "DE", FullName="Germany" },
            new Locale { Id = 2, Name = "CA", FullName="Canada" },
            new Locale { Id = 6, Name = "ES" , FullName="Spain"},
            new Locale { Id = 4, Name = "FR", FullName="France" },
            new Locale { Id = 9, Name = "JP" , FullName="Japan"},
        };
    }
}
