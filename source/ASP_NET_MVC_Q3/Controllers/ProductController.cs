using ASP_NET_MVC_Q3.Data;
using ASP_NET_MVC_Q3.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP_NET_MVC_Q3.Controllers
{
    public class ProductController : Controller
    {
        List<Product> source = Product.Data; // get static source data
        static int Id = 6; // use static variable for id generating

        public ActionResult List()
        {
            IEnumerable<ListViewModel> listViewModel = GetListViewModel(source); // mapping Model to ViewModel
            return View(listViewModel);
        }

        public ActionResult Create()
        {
            CreateViewModel createViewModel = new CreateViewModel();
            createViewModel.LocaleList = GetLocaleList();
            return View(createViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateViewModel data)
        {
            if (ModelState.IsValid)
            {
                source.Add(new Product
                {
                    Id = Id++,
                    Name = data.Name,
                    Locale = data.Locale,
                    CreateDate = DateTime.Now
                });

                IEnumerable<ListViewModel> listViewModel = GetListViewModel(source); // mapping Model to ViewModel
                return RedirectToAction("List", listViewModel); // "redirect" to List page, not using View() for it will cause refreshing same page issue(F5)
            }

            data.LocaleList = GetLocaleList();
            return View(data);
        }

        public ActionResult Edit(int? Id)
        {
            EditViewModel editViewModel = new EditViewModel();
            editViewModel.LocaleList = GetLocaleList();

            var data = source
                .Where(n => n.Id == Id).FirstOrDefault();

            editViewModel.Id = data.Id;
            editViewModel.Name = data.Name;
            editViewModel.Locale = data.Locale;

            return View(editViewModel);
        }

        [HttpPost]
        public ActionResult Edit(Product modifyData)
        {
            var data = source
                .Where(n => n.Id == modifyData.Id)
                .FirstOrDefault();

            if (data != null)
            {
                data.Name = modifyData.Name;
                data.Locale = modifyData.Locale;
                data.UpdateDate = DateTime.Now;
            }

            IEnumerable<ListViewModel> listViewModel = GetListViewModel(source);
            return RedirectToAction("List", listViewModel);
        }

        public ActionResult Delete(int? Id)
        {
            var data = source
             .Where(n => n.Id == Id).FirstOrDefault();
            return View(data);
        }

        [HttpPost]
        public ActionResult Delete(Product deleteData)
        {
            var data = source.RemoveAll(n => n.Id == deleteData.Id);

            IEnumerable<ListViewModel> listViewModel = GetListViewModel(source);
            return RedirectToAction("List", listViewModel);
        }

        #region 自訂方法

        public SelectList GetLocaleList()
        {
            List<Locale> localedata = Locale.Data;
            SelectList selectLists = new SelectList(localedata, "Name", "FullName");

            return selectLists;
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

        public IEnumerable<ListViewModel> GetListViewModel(IEnumerable<Product> data)
        {
            IEnumerable<ListViewModel> listViewModel = null;

            var x = from b in data
                    select new ListViewModel()
                    {
                        Id = b.Id,
                        Name = b.Name,
                        LocaleFullName = GetLocaleFullName(b.Locale),
                        CreateDate = b.CreateDate,
                        UpdateDate = b.UpdateDate,
                        Locale = b.Locale
                    };

            listViewModel = x;

            return listViewModel;
        }

        #endregion
    }
}