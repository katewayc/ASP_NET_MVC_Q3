using ASP_NET_MVC_Q3.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_NET_MVC_Q3.ViewModels
{
    public class ListViewModel
    {
        public string LocaleFullName { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Locale { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }

}