using System.Dynamic;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CEMIG.MapadoSite.Models;
using CEMIG.MapadoSite.Business.Business;
using CEMIG.MapadoSite.Business.Contracts;
using CEMIG.MapadoSite.Data.Models;
using System;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

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
            MenuResponse menus = _menuBusiness.GetAllMenu();

            IList<MenusModel> menusList = new List<MenusModel>();

            foreach (var menu in menus.Menus)
            {
                menusList.Add(new MenusModel { ID = menu.Id, Parent_ID = menu.IdPai == null ? null : menu.IdPai, Name = menu.Nome, Color = menu.Cor, Link = menu.Link });
            }

            Models.SeededMenusModel model = new Models.SeededMenusModel { Seed = null, Menus = menusList, Avaliacoes = getAvaliacoes() };

            return View(model);
        }

        public List<Menu> getMenus()
        {
            MenuResponse menus = _menuBusiness.GetAllMenu();

            IList<MenusModel> menusList = new List<MenusModel>();

            foreach (var menu in menus.Menus)
            {
                menusList.Add(new MenusModel { ID = menu.Id, Parent_ID = menu.IdPai == null ? null : menu.IdPai, Name = menu.Nome, Color = menu.Cor, Link = menu.Link });
            }

            Models.SeededMenusModel model = new Models.SeededMenusModel { Seed = null, Menus = menusList };

            return (List<Menu>)model.Menus;
        }

        public List<MenuAvaliacao> getAvaliacoes()
        {
            List<MenuAvaliacao> avaliacoes = _menuBusiness.GetAllMenuAvaliacao();

            return avaliacoes;
        }

        public IActionResult ListaComentarios(int idMenu)
        {
            List<MenuAvaliacao> avaliacoes = _menuBusiness.GetMenuAvaliacoes(idMenu);

            return View("_ListaComentarios", avaliacoes);
        }

        public IActionResult Edit(int idLink)
        {
            MenuResponse menus = _menuBusiness.GetAllMenu();

            IList<MenusModel> menuList = new List<MenusModel>();

            foreach (var menu in menus.Menus)
            {
                menuList.Add(new MenusModel { ID = menu.Id, Parent_ID = menu.IdPai == null ? null : menu.IdPai, Name = menu.Nome, Color = menu.Cor, Link = menu.Link });
            }

            Models.SeededMenusModel model = new Models.SeededMenusModel { Seed = null, Menus = menuList.Where(i => i.ID == idLink).ToList() };
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(MenuAvaliacao avaliacao)
        {
            if (ModelState.IsValid)
            {
                _menuBusiness.AddMenuAvaliacao(avaliacao);

                return RedirectToAction("MenuDetail", new { Id = avaliacao.IdMenu });
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
            if (id > 0)
            {
                var menu = _menuBusiness.GetMenu(id);
                menu.Avaliacoes = _menuBusiness.GetMenuAvaliacoes(id);
                return View(menu);
            }
            else
                return RedirectToAction("Index"); 

        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult PaginasAusente()
        {
            var retornoPaginasAusente = _menuBusiness.GetAllPaginasAusente();
            return View(retornoPaginasAusente);
        }

        [HttpPost]
        public IActionResult CriarPaginaAusente(PaginaAusente paginaAusente)
        {
            if (ModelState.IsValid)
            {
                _menuBusiness.AddPaginaAusente(paginaAusente);
                return RedirectToAction("PaginasAusente");
            }
            else
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
