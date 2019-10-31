using System;
using System.Collections.Generic;
using System.Text;

namespace CEMIG.MapadoSite.Data.Models
{
    public class RelacaoAvaliacoes
    {
        public string Usuario { get; set; }
        public string Orgao { get; set; }
        public string NomeUsuario { get; set; }
        public string Telefone { get; set; }     
        public int IdMenu { get; set; }
        public bool InfoCorreta { get; set; }
        public bool ePaginaRegulatoria { get; set; }
        public bool PaginaSeraMantida { get; set; }        
        public string Link { get; set; }
        public string Cor { get; set; }
        public string Justificativa { get; set; }
    }
}
