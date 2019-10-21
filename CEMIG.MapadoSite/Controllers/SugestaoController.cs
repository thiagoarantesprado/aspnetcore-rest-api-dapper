using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CEMIG.MapadoSite.Business.Business;
using CEMIG.MapadoSite.Data.Models;
using CEMIG.MapadoSite.Models;
using Microsoft.AspNetCore.Mvc;

namespace CEMIG.MapadoSite.Controllers
{
    public class SugestaoController : Controller
    {

        private readonly ISugestaoBusiness _sugestaoBusiness;

        public SugestaoController(ISugestaoBusiness sugestaoBusiness)
        {
            _sugestaoBusiness = sugestaoBusiness;
        }
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult ListarSugestoes()
        {
            var sugestoes = _sugestaoBusiness.GetAllSugestoes();
            return View("Sugestoes", sugestoes);
        }

        public ActionResult CriarSugestao(Sugestao sugestao)
        {
            if (ModelState.IsValid)
            {
                _sugestaoBusiness.AddSugestao(sugestao);
                return RedirectToAction("ListarSugestoes");
            }
            else
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}