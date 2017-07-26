using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EMarketting.Models.DTOs
{
    public class SubCategoryDTO
    {
        public int AltKategoriID { get; set; }
        public string AltKategoriAd { get; set; }
        public int KategoriID { get; set; }
        public List<ProductsDTO> Plist { get; set; }
    }
}