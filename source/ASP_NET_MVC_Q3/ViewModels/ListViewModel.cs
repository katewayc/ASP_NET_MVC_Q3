using ASP_NET_MVC_Q3.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_NET_MVC_Q3.ViewModels
{
        public class ProductForView : Product
        {
            public string LocaleFullName { get; set; }
        }
    
}