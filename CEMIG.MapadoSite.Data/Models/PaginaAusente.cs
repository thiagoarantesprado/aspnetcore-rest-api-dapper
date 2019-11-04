using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CEMIG.MapadoSite.Data.Models
{
    public class PaginaAusente
    {
            public int Id { get; set; }
            [Required]
            public string Link { get; set; }
            [Display(Name = "Observação", Description = "Observação sobre o site ausente.")]
            [Required(ErrorMessage = "A observação é obrigatória.")]
            public string Observacao { get; set; }
            public string Usuario { get; set; }
            public string Orgao { get; set; }
            public string NomeUsuario { get; set; }
            public string Telefone { get; set; }
            public DateTime DataCriacao { get; set; }
    }
}
