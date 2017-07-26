using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EMarketting.Models.DTOs
{
    public class CamDTO
    {
        public int KampanyaID { get; set; }
        public int AltUrunlerID { get; set; }
        public int IndirimOrani { get; set; }
        public string Aciklama { get; set; }
    }
}