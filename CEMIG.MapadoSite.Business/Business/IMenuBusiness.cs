using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CEMIG.MapadoSite.Business.Contracts;
using CEMIG.MapadoSite.Data.Models;

namespace CEMIG.MapadoSite.Business.Business
{
    public interface IMenuBusiness
    {
        Task<MenuResponse> GetAllMenuAsync();
        MenuResponse GetAllMenu();
        Menu GetMenu(int Id);
        void AddMenuAvaliacao(MenuAvaliacao menuAvaliacao);
        List<MenuAvaliacao> GetMenuAvaliacoes(int idMenu);
        List<MenuAvaliacao> GetAllMenuAvaliacao();
    }
}