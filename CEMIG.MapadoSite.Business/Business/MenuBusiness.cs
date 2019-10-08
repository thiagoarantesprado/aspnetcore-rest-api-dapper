using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CEMIG.MapadoSite.Business.Contracts;
using CEMIG.MapadoSite.Business.Interfaces;
using CEMIG.MapadoSite.Data.Models;

namespace CEMIG.MapadoSite.Business.Business
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

        public List<MenuAvaliacao> GetMenuAvaliacoes(int idMenu)
        {
            List<MenuAvaliacao> menuAvaliacao = _menuRepository.GetMenuAvaliacoes(idMenu);

            return menuAvaliacao;
        }

        public List<MenuAvaliacao> GetAllMenuAvaliacao()
        {
            List<MenuAvaliacao> menuAvaliacoes = _menuRepository.GetAllMenuAvaliacao();

            return menuAvaliacoes;
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

        public List<PaginaAusente> GetAllPaginasAusente()
        {
            List<PaginaAusente> paginasAusente = _menuRepository.GetAllPaginasAusente();

            return paginasAusente;
        }

        public void AddPaginaAusente(PaginaAusente paginaAusente)
        {
            _menuRepository.AddPaginaAusente(paginaAusente);
        }

        public List<MenuAnaliseAvaliacao> GetMenuQueNaoPossuemAvaliacoes()
        {
            List<MenuAnaliseAvaliacao> menuAnaliseAvaliacao = _menuRepository.GetMenuQueNaoPossuemAvaliacoes();

            return menuAnaliseAvaliacao;
        }

        public List<MenuAnaliseAvaliacao> GetMenuQuePossuemAvaliacoes()
        {
            List<MenuAnaliseAvaliacao> menuAnaliseAvaliacao = _menuRepository.GetMenuQuePossuemAvaliacoes();

            return menuAnaliseAvaliacao;
        }
    }
}