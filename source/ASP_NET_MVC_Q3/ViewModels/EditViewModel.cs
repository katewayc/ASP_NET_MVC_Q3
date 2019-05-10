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
        public EditViewModel Mapping(Product product)
        {
            EditViewModel editViewModel = new EditViewModel();

            editViewModel.Id = product.Id;
            editViewModel.Name = product.Name;
            editViewModel.Locale = product.Locale;

            return editViewModel;
        }
        public IEnumerable<SelectListItem> LocaleList { get; set; }
    }
}