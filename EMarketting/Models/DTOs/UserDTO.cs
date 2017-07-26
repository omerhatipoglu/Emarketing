using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EMarketting.Models.DTOs
{
    public class UserDTO
    {
        public int KullaniciID { get; set; }
        public string KullaniciRol { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Email { get; set; }
        public int TelNo { get; set; }
        public string Adres { get; set; }
        public int IlID { get; set; }
        public string Sifre { get; set; }
        public string SifreTekrar { get; set; }
        public bool MailIzin { get; set; }
        public DateTime DogumGunu { get; set; }
    }
}