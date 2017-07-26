using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EMarketting.Models.DTOs
{
    public class SiparisDTO
    {
        public int SiparisID { get; set; }
        public int KullaniciID { get; set; }
        public string SiparisTarihi { get; set; }
        public string PostalandigiTarih { get; set; }
        public int Agirlik { get; set; }
        public string GonderilenAdres { get; set; }
        public string GonderilenSehir { get; set; }
    }
}