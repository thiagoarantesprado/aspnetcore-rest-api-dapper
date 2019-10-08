using CEMIG.MapadoSite.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CEMIG.MapadoSite.Models
{
    public class SeededMenusModel
    {
        public int? Seed { get; set; }
        public IList<MenusModel> Menus { get; set; }
        public IList<MenuAvaliacao> Avaliacoes { get; set; }
    }
}
