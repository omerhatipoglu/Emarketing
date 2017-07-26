using EMarketting.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EMarketting.Models.DTOs
{
    public class BigDTO
    {
        public ModelDTO modeldto { get; set; }
        public List<ReklamliUrunler> Reklam { get; set; }
        public List<SezonSonuUrunler> Sezonsonu { get; set; }
        public List<EnCokSatilanlar> Encoksat { get; set; }
        public List<EnCokTiklananlar> Encoktik { get; set; }
        public List<KampanyaliUrunler> Kampanya { get; set; }
    }
}