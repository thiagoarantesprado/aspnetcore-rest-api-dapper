using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LC.NCF.Business.Contracts;
using LC.NCF.Data.Models;

namespace LC.NCF.Business.Business
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