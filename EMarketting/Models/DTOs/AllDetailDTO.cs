using EMarketting.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EMarketting.Models.DTOs
{
    public class AllDetailDTO
    {
        public SiparisDTO s { get; set; }
        public SiparisDetay sd { get; set; }
        public Kullanici k { get; set; }
        public AltUrunler a { get; set; }
    }
}