using ASP_NET_MVC_Q3.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_NET_MVC_Q3.ViewModels
{
    public class ListViewModel
    {
        public Product product { get; set; }
        public IEnumerable<ProductView> ProductList { get; set; }

        public class ProductView : Product
        {
            public string FormatedCreateTime { get; set; }
            public string FormatedUpdateTime { get; set; }
        }
    }
}