using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CEMIG.MapadoSite.Business.Business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CEMIG.MapadoSite.Controllers
{
    public class AnaliseAvaliacaoController : Controller
    {
        private readonly IMenuBusiness _menuBusiness;

        public AnaliseAvaliacaoController(IMenuBusiness menuBusiness)
        {
            _menuBusiness = menuBusiness;
        }

        // GET: AnaliseSite
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult PaginasSemAvaliacoes()
        {
            var menuQueNaoPossuemAvaliacoes = _menuBusiness.GetMenuQueNaoPossuemAvaliacoes();
            return View("PaginasSemAvaliacoes", menuQueNaoPossuemAvaliacoes);
        }

        public ActionResult PaginasAvaliadas()
        {
            var menuQuePossuemAvaliacoes = _menuBusiness.GetMenuQuePossuemAvaliacoes();
            return View("PaginasAvaliadas", menuQuePossuemAvaliacoes);
        }

        // GET: AnaliseSite/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AnaliseSite/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AnaliseSite/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AnaliseSite/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AnaliseSite/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AnaliseSite/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AnaliseSite/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}