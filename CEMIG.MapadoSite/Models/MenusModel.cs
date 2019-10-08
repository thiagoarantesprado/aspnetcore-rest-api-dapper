using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CEMIG.MapadoSite.Models
{
    public class MenusModel
    {
        public int ID { get; set; }
        public int? Parent_ID { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public string Color { get; set; }
    }
}
