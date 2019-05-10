﻿using ASP_NET_MVC_Q3.Data;
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
        ListViewModel vmList = new ListViewModel();

        public ActionResult List()
        {
            IEnumerable<ListViewModel> model = vmList.Mapping(crud.ReadAll());
            return View(model);
        }

        public ActionResult Create()
        {
            CreateViewModel model = new CreateViewModel();
            model.LocaleList = DataSource.GetLocaleSelectList();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateViewModel product)
        {
            if (ModelState.IsValid)
            {
                IEnumerable<ListViewModel> model = vmList.Mapping(crud.Insert(product));
                return RedirectToAction("List", model);
            }

            product.LocaleList = DataSource.GetLocaleSelectList();
            return View(product);
        }

        public ActionResult Edit(int? Id)
        {
            EditViewModel model = new EditViewModel();
            model = model.Mapping(crud.ReadBy(Id));
            model.LocaleList = DataSource.GetLocaleSelectList();
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            IEnumerable<ListViewModel> model = vmList.Mapping(crud.Update(product));
            return RedirectToAction("List", model);
        }

        public ActionResult Delete(int? Id)
        {
            Product data = crud.ReadBy(Id);
            return View(data);
        }

        [HttpPost]
        public ActionResult Delete(Product product)
        {
            IEnumerable<ListViewModel> model = vmList.Mapping(crud.Delete(product));
            return RedirectToAction("List", model);
        }

    }
}