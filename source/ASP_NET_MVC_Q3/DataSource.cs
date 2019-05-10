using ASP_NET_MVC_Q3.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP_NET_MVC_Q3
{
    public class DataSource
    {
        private static int _lastInsertedId = 0;
        public static int ReadLastInsertedId()
        {
            _lastInsertedId = ProductList.OrderByDescending(p => p.Id).FirstOrDefault().Id;
            return _lastInsertedId;
        }
        public static int GetNewId()
        {
            _lastInsertedId = _lastInsertedId + 1;
            return _lastInsertedId;
        }
        public static List<Product> ProductList = Product.Data;

        public static SelectList GetLocaleSelectList()
        {
            SelectList localeSelectList = new SelectList(Locale.Data, "Name", "FullName");

            return localeSelectList;
        }
    }
}