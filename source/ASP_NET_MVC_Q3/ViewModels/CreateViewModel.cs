﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP_NET_MVC_Q3.Data;

namespace ASP_NET_MVC_Q3.ViewModels
{
    public class CreateViewModel : Product
    {
        public IEnumerable<SelectListItem> LocaleList { get; set; }
    }

}