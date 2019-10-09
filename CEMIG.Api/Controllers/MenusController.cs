using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CEMIG.MapadoSite.Business.Business;
using CEMIG.MapadoSite.Business.Contracts;

using Microsoft.AspNetCore.Mvc;

namespace aspnetcore_rest_api_with_dapper.Controllers
{
    [Route("api/v1/[controller]")]
    public class MenusController : Controller
    {
        private readonly IMenuBusiness _menuBusiness;

        public MenusController(IMenuBusiness menuBusiness)
        {
            _menuBusiness = menuBusiness;
        }

        [Route("GetAllMenu")]
        [HttpGet]
        public async Task<MenuResponse> GetAllMenu()
        {
            return await _menuBusiness.GetAllMenuAsync();
        }
    }
}