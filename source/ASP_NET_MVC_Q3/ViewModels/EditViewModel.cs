using ASP_NET_MVC_Q3.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP_NET_MVC_Q3.ViewModels
{
    public class EditViewModel : Product
    {
        public IEnumerable<SelectListItem> LocaleList { get; set; }
    }
}