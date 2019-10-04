using System;
using System.Collections.Generic;
using System.Text;

namespace CEMIG.MapadoSite.Data.Models
{
    public class MenuAvaliacao
    {
        public int Id { get; set; }        
        public int IdMenu { get; set; }
        public bool InfoCorreta { get; set; }
        public bool ePaginaRegulatoria { get; set; }
        public bool PaginaSeraMantida { get; set; }
        public string Justificativa { get; set; }
        public string Usuario { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
