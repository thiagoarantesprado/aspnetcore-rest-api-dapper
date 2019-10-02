using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CEMIG.MapadoSite.Models
{
    public class MenuAvaliacaoViewModel
    {
        public IEnumerable<LC.NCF.Data.Models.Menu> Menus { get; set; }
        public IEnumerable<LC.NCF.Data.Models.MenuAvaliacao> Avaliacoes { get; set; }
    }
}
