using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EMarketting.Models.DTOs
{
    public class SubProductsDTO
    {
        public int AltUrunlerID { get; set; }
        public string AltUrunlerAd { get; set; }
        public int UrunlerID { get; set; }
        public int MarkaID { get; set; }
        public decimal Fiyat { get; set; }
        public int StokAdeti { get; set; }
        public string Aciklama { get; set; }
        public string Resim { get; set; }
        public string Resim2 { get; set; }
        public int SiparisAdet { get; set; }
        public bool Kampanya { get; set; }
        public bool Reklam { get; set; }
        public bool SezonSonu { get; set; }
        public int TiklamaSayisi { get; set; }
        public int SatilanAdet { get; set; }
    }
}