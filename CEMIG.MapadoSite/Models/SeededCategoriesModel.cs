using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CEMIG.MapadoSite.Models
{
    public class SeededCategoriesModel
    {
        public int? Seed { get; set; }
        public IList<CategoryModel> Categories { get; set; }
    }
}
