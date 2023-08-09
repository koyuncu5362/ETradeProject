using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class CategoryDetailDto:IDto
    {
        public int? CatId { get; set; }
        public string? CatTitle { get; set; }//ShoeEtc
        public string? SubCats { get; set; }
        public string? Cats { get; set; }
    }
}
