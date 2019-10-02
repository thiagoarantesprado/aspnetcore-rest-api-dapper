using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using LC.NCF.Business.Contracts;
using LC.NCF.Business.Interfaces;
using LC.NCF.Data.Models;

namespace LC.NCF.Business.Business
{
    public class MenuBusiness : IMenuBusiness
    {
        private readonly IMenuRepository _menuRepository;

        public MenuBusiness(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public MenuResponse GetAllMenu()
        {
            MenuResponse menuResponse = new MenuResponse();
            IEnumerable<Menu> menus = _menuRepository.GetAllMenu();

            if (menus.ToList().Count == 0)
            {
                menuResponse.Message = "Menu not found.";
            }
            else
            {
                menuResponse.Menus.AddRange(menus);
            }

            return menuResponse;
        }

        public Menu GetMenu(int Id)
        {
            Menu menu = _menuRepository.GetMenu(Id);

            return menu;
        }

        public void AddMenuAvaliacao(MenuAvaliacao menuAvaliacao)
        {
            _menuRepository.AddMenuAvaliacao(menuAvaliacao);
        }
        public MenuAvaliacao GetMenuAvaliacao(int id, string usuario)
        {
            MenuAvaliacao menuAvaliacao = _menuRepository.GetMenuAvaliacao(id, usuario);

            return menuAvaliacao;
        }

        public async Task<MenuResponse> GetAllMenuAsync()
        {
            MenuResponse menuResponse = new MenuResponse();
            IEnumerable<Menu> menus = await _menuRepository.GetAllMenuAsync();
            
            if(menus.ToList().Count == 0)
            {
                menuResponse.Message = "Menu not found.";
            }
            else
            {
                menuResponse.Menus.AddRange(menus);
            }

            return menuResponse;
        }
    }
}