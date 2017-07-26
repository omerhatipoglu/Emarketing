using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EMarketting.Models.DTOs
{
    public class CategoryDTO
    {
        public int KategoriID { get; set; }
        public string KategoriAd { get; set; }
        public string Aciklama { get; set; }
        public List<SubCategoryDTO> Slist { get; set; }
    }
}