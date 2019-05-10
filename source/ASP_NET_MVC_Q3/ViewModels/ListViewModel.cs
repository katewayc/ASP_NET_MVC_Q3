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

        public IEnumerable<ListViewModel> Mapping(IEnumerable<Product> product)
        {
            var model = from p in product
                        select new ListViewModel()
                        {
                            Id = p.Id,
                            Name = p.Name,
                            LocaleFullName = GetLocaleFullName(p.Locale),
                            CreateDate = p.CreateDate,
                            UpdateDate = p.UpdateDate,
                            Locale = p.Locale
                        };

            IEnumerable<ListViewModel> listViewModel = model;

            return listViewModel;
        }

        public string GetLocaleFullName(string Locale)
        {
            string LocaleFullName = "";

            switch (Locale)
            {
                case "US":
                    LocaleFullName = "United States";
                    break;
                case "DE":
                    LocaleFullName = "Germany";
                    break;
                case "CA":
                    LocaleFullName = "Canada";
                    break;
                case "ES":
                    LocaleFullName = "Spain";
                    break;
                case "FR":
                    LocaleFullName = "France";
                    break;
                case "JP":
                    LocaleFullName = "Japan";
                    break;
            }

            return LocaleFullName;
        }
    }
}
