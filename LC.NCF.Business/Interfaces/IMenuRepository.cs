using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LC.NCF.Data.Models;

namespace LC.NCF.Business.Interfaces
{
    public interface IMenuRepository
    {
        Task<IEnumerable<Menu>> GetAllMenuAsync();
        IEnumerable<Menu> GetAllMenu();
        IEnumerable<Menu> GetAllMenus();
        Menu GetMenu(int Id);
        void AddMenuAvaliacao(MenuAvaliacao menuAvaliacao);
        List<MenuAvaliacao> GetMenuAvaliacoes(int idMenu);
        List<MenuAvaliacao> GetAllMenuAvaliacao();
    }
}