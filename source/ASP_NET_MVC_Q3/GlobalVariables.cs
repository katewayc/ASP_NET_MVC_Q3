using ASP_NET_MVC_Q3.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_NET_MVC_Q3
{
    public class GlobalVariables
    {
        public static List<Product> source = Product.Data; // get static source data
        public static int Id = 6; // use static variable for id generating
    }
}