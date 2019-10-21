using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CEMIG.MapadoSite.Data.Models
{
    public class Sugestao
    {
            public int Id { get; set; }
            [Required]
            public string Observacao { get; set; }
            public string Usuario { get; set; }
            public DateTime DataCriacao { get; set; }
    }
}
