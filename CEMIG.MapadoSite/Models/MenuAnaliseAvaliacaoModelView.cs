using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CEMIG.MapadoSite.Models
{
    public class MenuAnaliseAvaliacaoModelView
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Link { get; set; }
        public string Cor { get; set; }
        public int quantAvaliacoes { get; set; }
    }
}
