using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EMarketting.Models.DTOs
{
    public class ProductsDTO
    {
        public int UrunlerID { get; set; }
        public string UrunlerAd { get; set; }
        public int AltKategoriID { get; set; }
    }
}