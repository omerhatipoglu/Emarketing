using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EMarketting.Models.DTOs
{
    public class SepetDTO
    {
        public int SepetID { get; set; }
        public int KullaniciID { get; set; }
        public int AltUrunlerID { get; set; }
        public string Email { get; set; }
        public int SiparisAdet { get; set; }
        public string Adres { get; set; }
        public string il { get; set; }
        public string resim { get; set; }
        public string urunad { get; set; }
        public string marka { get; set; }
        public decimal fiyat { get; set; }
        public decimal ToplamFiyat { get; set; }

    }
}