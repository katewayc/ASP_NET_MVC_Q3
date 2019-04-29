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
        CRUD crud = new CRUD();

        public ActionResult List()
        {
            IEnumerable<ListViewModel> listViewModel = GetListViewModel(crud.ReadAll());
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
        public ActionResult Create(CreateViewModel addData)
        {
            if (ModelState.IsValid)
            {
                crud.Insert(addData);
                IEnumerable<ListViewModel> listViewModel = GetListViewModel(crud.ReadAll());
                return RedirectToAction("List", listViewModel); // "redirect" to List page, not using View() for it will cause refreshing same page issue(F5)
            }

            addData.LocaleList = GetLocaleList();
            return View(addData);
        }

        public ActionResult Edit(int? Id)
        {
            Product data = crud.ReadById(Id);
            EditViewModel editViewModel = GetEditViewModel(data);
            editViewModel.LocaleList = GetLocaleList();
            return View(editViewModel);
        }

        [HttpPost]
        public ActionResult Edit(Product modifyData)
        {
            crud.Update(modifyData);
            IEnumerable<ListViewModel> listViewModel = GetListViewModel(GlobalVariables.source);
            return RedirectToAction("List", listViewModel);
        }

        public ActionResult Delete(int? Id)
        {
            Product data = crud.ReadById(Id);
            return View(data);
        }

        [HttpPost]
        public ActionResult Delete(Product deleteData)
        {
            crud.Delete(deleteData);
            IEnumerable<ListViewModel> listViewModel = GetListViewModel(GlobalVariables.source);
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

        public EditViewModel GetEditViewModel(Product data)
        {
            EditViewModel editViewModel = new EditViewModel();

            editViewModel.Id = data.Id;
            editViewModel.Name = data.Name;
            editViewModel.Locale = data.Locale;

            return editViewModel;
        }
        #endregion
    }
}