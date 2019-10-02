﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CEMIG.MapadoSite.Models;
using LC.NCF.Business.Business;
using LC.NCF.Business.Contracts;
using LC.NCF.Data.Models;

namespace CEMIG.MapadoSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMenuBusiness _menuBusiness;

        public HomeController(IMenuBusiness menuBusiness)
        {
            _menuBusiness = menuBusiness;
        }

        public IActionResult Index()
        {
            MenuResponse menus =  _menuBusiness.GetAllMenu();

            IList<CategoryModel> categories = new List<CategoryModel>();

            foreach (var menu in menus.Menus)
            {
                categories.Add(new CategoryModel { ID = menu.Id, Parent_ID = menu.IdPai == null ? null : menu.IdPai, Name = menu.Nome, Color = menu.Cor, Link = menu.Link });
            }

            Models.SeededCategoriesModel model = new Models.SeededCategoriesModel { Seed = null, Categories = categories };
            return View(model);
        }

        public IActionResult Edit(int idLink)
        {
            MenuResponse menus = _menuBusiness.GetAllMenu();

            IList<CategoryModel> categories = new List<CategoryModel>();

            foreach (var menu in menus.Menus)
            {
                categories.Add(new CategoryModel { ID = menu.Id, Parent_ID = menu.IdPai == null ? null : menu.IdPai, Name = menu.Nome, Color = menu.Cor, Link = menu.Link });
            }

            Models.SeededCategoriesModel model = new Models.SeededCategoriesModel { Seed = null, Categories = categories.Where(i => i.ID == idLink).ToList() };
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(MenuAvaliacao avaliacao)
        {
            if (ModelState.IsValid)
            {
                _menuBusiness.AddMenuAvaliacao(avaliacao);
                return RedirectToAction("Index");
            }
            else
                return View();
        }

        [HttpGet]
        public ActionResult GetMenuAvaliacao(int id)
        {
            var viewModel = new MenuAvaliacaoModelView();
            viewModel.Id = id;
            viewModel.Usuario = User.Identity.Name;
            return PartialView("_EditPersonPartial", viewModel);
        }


        [HttpGet]
        public ActionResult EditMenu(int id)
        {
            var viewModel = new MenuModel();
            viewModel.Id = id;
            return PartialView("_EditPersonPartial", viewModel);
        }

        public IActionResult MenuDetail(int id)
        {
            var menu = _menuBusiness.GetMenu(id);
            return View(menu);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
