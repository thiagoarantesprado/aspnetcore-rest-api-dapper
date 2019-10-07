using System;
using System.Collections.Generic;
using System.Text;

namespace CEMIG.MapadoSite.Data.Models
{
    public class PaginaAusente
    {
            public int Id { get; set; }
            public string Link { get; set; }
            public string Observacao { get; set; }
            public string Usuario { get; set; }
            public DateTime DataCriacao { get; set; }
    }
}
