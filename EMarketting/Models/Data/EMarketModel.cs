namespace EMarketting.Models.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Linq;

    public class EMarketModel : DbContext
    {
        public EMarketModel()
            : base("Baglanti")
        {
        }
        public virtual DbSet<Kategoriler> Kategoriler { get; set; }
        public virtual DbSet<AltKategoriler> AltKategoriler { get; set; }
        public virtual DbSet<Urunler> Urunler { get; set; }
        public virtual DbSet<AltUrunler> AltUrunler { get; set; }
        public virtual DbSet<Kullanici> Kullanicilar { get; set; }
        public virtual DbSet<Il> Iller { get; set; }
        public virtual DbSet<Ilce> Ilceler { get; set; }
        public virtual DbSet<Sepet> Sepet { get; set; }
        public virtual DbSet<EmailIzin> EmailIzin { get; set; }
        public virtual DbSet<KampanyaliUrunler> KampanyaliUrunler { get; set; }
        public virtual DbSet<Marka> Marka { get; set; }
        public virtual DbSet<EnCokSatilanlar> EnCokSatilanlar { get; set; }
        public virtual DbSet<ReklamliUrunler> ReklamliUrunler { get; set; }
        public virtual DbSet<EnCokTiklananlar> EnCokTiklananlar { get; set; }
        public virtual DbSet<Siparis> Siparis { get; set; }
        public virtual DbSet<SiparisDetay> SiparisDetay { get; set; }
        public virtual DbSet<SezonSonuUrunler> SezonSonuUrunler { get; set; }
    }
    [Table("Kategoriler")]
    public class Kategoriler
    {
        public Kategoriler()
        {
            this.altKategoriler = new HashSet<AltKategoriler>();
        }
        [Key]
        public int KategoriID { get; set; }
        public string KategoriAd { get; set; }
        public string Aciklama { get; set; }

        public virtual ICollection<AltKategoriler> altKategoriler { get; set; }
    }
    [Table("AltKategoriler")]
    public class AltKategoriler
    {
        public AltKategoriler()
        {
            this.urunler = new HashSet<Urunler>();
        }
        [Key]
        public int AltKategoriID { get; set; }
        public string AltKategoriAd { get; set; }
        public int KategoriID { get; set; }

        public virtual Kategoriler kategoriler { get; set; }
        public virtual ICollection<Urunler> urunler { get; set; }
    }
    [Table("Urunler")]
    public class Urunler
    {
        public Urunler()
        {
            this.alturunler = new HashSet<AltUrunler>();
        }
        [Key]
        public int UrunlerID { get; set; }
        public string UrunlerAd { get; set; }
        public int AltKategoriID { get; set; }

        [ForeignKey("UrunlerID")]
        public virtual ICollection<AltUrunler> alturunler { get; set; }
        public virtual AltKategoriler altkategori { get; set; }
    }
    [Table("AltUrunler")]
    public class AltUrunler
    {
        public AltUrunler()
        {
            this.kampanyaliUrunler = new HashSet<KampanyaliUrunler>();
            this.reklamliurunler = new HashSet<ReklamliUrunler>();
            this.sezonsonuurunler = new HashSet<SezonSonuUrunler>();
            this.encoksatilanlar = new HashSet<EnCokSatilanlar>();
            this.encoktiklananlar = new HashSet<EnCokTiklananlar>();
            this.sepet = new HashSet<Sepet>();
        }
        [Key]
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

        [ForeignKey("AltUrunlerID")]

        public virtual ICollection<KampanyaliUrunler>kampanyaliUrunler { get; set; }
        public virtual ICollection<EnCokSatilanlar> encoksatilanlar { get; set; }
        public virtual ICollection<EnCokTiklananlar> encoktiklananlar { get; set; }
        public virtual ICollection<SezonSonuUrunler> sezonsonuurunler { get; set; }
        public virtual ICollection<ReklamliUrunler> reklamliurunler { get; set; }
        public virtual Marka marka { get; set; }
        public virtual Urunler urunler { get; set; }
        public virtual ICollection<Sepet> sepet { get; set; }

    }
    [Table("Kullanicilar")]
    public class Kullanici
    {
        [Key]
        public int KullaniciID { get; set; }
        public string KullaniciRol { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Email { get; set; }
        public int TelNo { get; set; }
        public string Adres { get; set; }
        public int IlID { get; set; }
        public string Sifre { get; set; }
        public bool MailIzin { get; set; }
        public DateTime DogumGunu { get; set; }
        
        public virtual Il il { get; set; }
        [ForeignKey("KullaniciID")]
        public virtual ICollection<Sepet> sepet { get; set; }
    }
    [Table("Iller")]
    public class Il
    {
        public Il()
        {
            this.kullanici = new HashSet<Kullanici>();
            this.ilce = new HashSet<Ilce>();
        }
        [Key]
        public int IlID { get; set; }
        public string IlAd { get; set; }

        public virtual ICollection<Ilce> ilce { get; set; }
        public virtual ICollection<Kullanici> kullanici { get; set; }
    }
    [Table("Ilceler")]
    public class Ilce
    {
        [Key]
        public int IlceID { get; set; }
        public string IlceAd { get; set; }
        public int IlID { get; set; }

        public virtual Il il { get; set; }
    }
    [Table("Sepet")]
    public class Sepet
    {
        [Key]
        public int SepetID { get; set; }
        public int KullaniciID { get; set; }
        public int AltUrunlerID { get; set; }
        public string Email { get; set; }
        public int SiparisAdet { get; set; }
        public double ToplamFiyat { get; set; }
        public string Adres { get; set; }
        public string il { get; set; }

        public virtual AltUrunler alturunler { get; set; }
        public virtual Kullanici kullanici { get; set; }

    }
    [Table("EmailIzin")]
    public class EmailIzin
    {
        [Key]
        public int MailID { get; set; }
        public int KullaniciID { get; set; }
        public string Email { get; set; }
    }
    [Table("KampanyaliUrunler")]
    public class KampanyaliUrunler
    {
        [Key]
        public int KampanyaID { get; set; }
        public int AltUrunlerID { get; set; }
        public int IndirimOrani { get; set; }
        public string Aciklama { get; set; }
        public virtual AltUrunler alturunler { get; set; }
    }
    [Table("Marka")]
    public class Marka
    {
        public Marka()
        {
            this.alturunler = new HashSet<AltUrunler>();
        }
        [Key]
        public int MarkaID { get; set; }
        public string MarkaAd { get; set; }

        public virtual ICollection<AltUrunler> alturunler { get; set; }
    }
    [Table("EnCokSatilanlar")]
    public class EnCokSatilanlar
    {
        [Key]
        public int EnCokSatilanID { get; set; }
        public int AltUrunlerID { get; set; }

        public virtual AltUrunler alturunler { get; set; }
    }
    [Table("ReklamliUrunler")]
    public class ReklamliUrunler
    {
        [Key]
        public int ReklamliUrunID { get; set; }
        public int AltUrunlerID { get; set; }

        public virtual AltUrunler alturunler { get; set; }
    }
    [Table("EnCokTiklananlar")]
    public class EnCokTiklananlar
    {
        [Key]
        public int EnCokTiklananID { get; set; }
        public int AltUrunlerID { get; set; }

        public virtual AltUrunler alturunler { get; set; }
    }
    [Table("SezonSonuUrunler")]
    public class SezonSonuUrunler
    {
        [Key]
        public int SezonSonuID { get; set; }
        public int AltUrunlerID { get; set; }

        public virtual AltUrunler alturunler { get; set; }
    }
    [Table("Siparis")]
    public class Siparis
    {
        [Key]
        public int SiparisID { get; set; }
        public int KullaniciID { get; set; }
        public DateTime SiparisTarihi { get; set; }
        public DateTime PostalandigiTarih { get; set; }
        public int Agirlik { get; set; }
        public string GonderilenAdres { get; set; }
        public string GonderilenSehir { get; set; }
    }
    [Table("SiparisDetay")]
    public class SiparisDetay
    {
        [Key]
        public int SiparisDetayID { get; set; }
        public int SiparisID { get; set; }
        public int AltUrunlerID { get; set; }
        public decimal Fiyat { get; set; }
        public int SiparisAdeti { get; set; }
        public int Indirim { get; set; }     
    }
}