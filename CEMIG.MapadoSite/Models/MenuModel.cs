﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CEMIG.MapadoSite.Models
{
    public class MenuModel
    {
        public int Id { get; set; }        
        public string Nome { get; set; }
        public string Link { get; set; }
        public string Cor { get; set; }
        public int? IdPai { get; set; }
        public int? QtdViewPage { get; set; }
        public int? QtdUnViewPage { get; set; }
        public int? QtdEnterAcess { get; set; }
        public decimal? MediumTimeAccess { get; set; }
        public decimal? RejectionTax { get; set; }
        public decimal? ExitTax { get; set; }
    }
}
