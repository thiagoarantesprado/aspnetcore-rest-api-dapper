using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CEMIG.MapadoSite.Business.Contracts
{
    public class ProductRequest
    {
        [Required]
        public long CategoryId { get; set; }
        [Required(ErrorMessage = "O nome � obrigat�rio", AllowEmptyStrings = false)]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage ="N�meros e caracteres especiais n�o s�o permitidos no nome.")]
        public string Name { get; set; }
        public string Description { get; set; }
        [DataType(DataType.Currency)]
        public double Price { get; set; }
    }
}