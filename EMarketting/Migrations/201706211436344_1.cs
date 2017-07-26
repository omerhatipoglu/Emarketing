namespace EMarketting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AltKategoriler",
                c => new
                    {
                        AltKategoriID = c.Int(nullable: false, identity: true),
                        AltKategoriAd = c.String(),
                        KategoriID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AltKategoriID)
                .ForeignKey("dbo.Kategoriler", t => t.KategoriID, cascadeDelete: true)
                .Index(t => t.KategoriID);
            
            CreateTable(
                "dbo.Kategoriler",
                c => new
                    {
                        KategoriID = c.Int(nullable: false, identity: true),
                        KategoriAd = c.String(),
                        Aciklama = c.String(),
                    })
                .PrimaryKey(t => t.KategoriID);
            
            CreateTable(
                "dbo.Urunler",
                c => new
                    {
                        UrunlerID = c.Int(nullable: false, identity: true),
                        UrunlerAd = c.String(),
                        AltKategoriID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UrunlerID)
                .ForeignKey("dbo.AltKategoriler", t => t.AltKategoriID, cascadeDelete: true)
                .Index(t => t.AltKategoriID);
            
            CreateTable(
                "dbo.AltUrunler",
                c => new
                    {
                        AltUrunlerID = c.Int(nullable: false, identity: true),
                        AltUrunlerAd = c.String(),
                        UrunlerID = c.Int(nullable: false),
                        MarkaID = c.Int(nullable: false),
                        Fiyat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StokAdeti = c.Int(nullable: false),
                        Aciklama = c.String(),
                        Resim = c.String(),
                        SiparisAdet = c.Int(nullable: false),
                        Kampanya = c.Boolean(nullable: false),
                        TiklamaSayisi = c.Int(nullable: false),
                        SatilanAdet = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AltUrunlerID)
                .ForeignKey("dbo.Marka", t => t.MarkaID, cascadeDelete: true)
                .ForeignKey("dbo.Urunler", t => t.UrunlerID, cascadeDelete: true)
                .Index(t => t.UrunlerID)
                .Index(t => t.MarkaID);
            
            CreateTable(
                "dbo.KampanyaliUrunler",
                c => new
                    {
                        KampanyaID = c.Int(nullable: false, identity: true),
                        AltUrunlerID = c.Int(nullable: false),
                        IndirimOrani = c.Int(nullable: false),
                        Aciklama = c.String(),
                    })
                .PrimaryKey(t => t.KampanyaID)
                .ForeignKey("dbo.AltUrunler", t => t.AltUrunlerID, cascadeDelete: true)
                .Index(t => t.AltUrunlerID);
            
            CreateTable(
                "dbo.Marka",
                c => new
                    {
                        MarkaID = c.Int(nullable: false, identity: true),
                        MarkaAd = c.String(),
                    })
                .PrimaryKey(t => t.MarkaID);
            
            CreateTable(
                "dbo.EmailIzin",
                c => new
                    {
                        MailID = c.Int(nullable: false, identity: true),
                        KullaniciID = c.Int(nullable: false),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.MailID);
            
            CreateTable(
                "dbo.EnCokSatilanlar",
                c => new
                    {
                        EnCokSatilanID = c.Int(nullable: false, identity: true),
                        AltUrunlerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EnCokSatilanID);
            
            CreateTable(
                "dbo.EnCokTiklananlar",
                c => new
                    {
                        EnCokTiklananID = c.Int(nullable: false, identity: true),
                        AltUrunlerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EnCokTiklananID);
            
            CreateTable(
                "dbo.Ilceler",
                c => new
                    {
                        IlceID = c.Int(nullable: false, identity: true),
                        IlceAd = c.String(),
                        IlID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IlceID)
                .ForeignKey("dbo.Iller", t => t.IlID, cascadeDelete: true)
                .Index(t => t.IlID);
            
            CreateTable(
                "dbo.Iller",
                c => new
                    {
                        IlID = c.Int(nullable: false, identity: true),
                        IlAd = c.String(),
                    })
                .PrimaryKey(t => t.IlID);
            
            CreateTable(
                "dbo.Kullanicilar",
                c => new
                    {
                        KullaniciID = c.Int(nullable: false, identity: true),
                        KullaniciRol = c.String(),
                        Ad = c.String(),
                        Soyad = c.String(),
                        Email = c.String(),
                        TelNo = c.Int(nullable: false),
                        Adres = c.String(),
                        IlID = c.Int(nullable: false),
                        Sifre = c.String(),
                        MailIzin = c.Boolean(nullable: false),
                        DogumGunu = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.KullaniciID)
                .ForeignKey("dbo.Iller", t => t.IlID, cascadeDelete: true)
                .Index(t => t.IlID);
            
            CreateTable(
                "dbo.SezonSonuUrunler",
                c => new
                    {
                        SezonSonuID = c.Int(nullable: false, identity: true),
                        AltUrunlerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SezonSonuID);
            
            CreateTable(
                "dbo.ReklamliUrunler",
                c => new
                    {
                        ReklamliUrunID = c.Int(nullable: false, identity: true),
                        AltUrunlerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReklamliUrunID);
            
            CreateTable(
                "dbo.Sepet",
                c => new
                    {
                        SepetID = c.Int(nullable: false, identity: true),
                        KullaniciID = c.Int(nullable: false),
                        AltUrunlerID = c.Int(nullable: false),
                        SiparisAdeti = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SepetID);
            
            CreateTable(
                "dbo.Siparis",
                c => new
                    {
                        SiparisID = c.Int(nullable: false, identity: true),
                        KullaniciID = c.Int(nullable: false),
                        SiparisTarihi = c.DateTime(nullable: false),
                        PostalandigiTarih = c.DateTime(nullable: false),
                        Agirlik = c.Int(nullable: false),
                        GonderilenAdres = c.String(),
                        GonderilenSehir = c.String(),
                    })
                .PrimaryKey(t => t.SiparisID);
            
            CreateTable(
                "dbo.SiparisDetay",
                c => new
                    {
                        SiparisDetayID = c.Int(nullable: false, identity: true),
                        SiparisID = c.Int(nullable: false),
                        AltUrunlerID = c.Int(nullable: false),
                        Fiyat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SiparisAdeti = c.Int(nullable: false),
                        Indirim = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SiparisDetayID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Kullanicilar", "IlID", "dbo.Iller");
            DropForeignKey("dbo.Ilceler", "IlID", "dbo.Iller");
            DropForeignKey("dbo.AltUrunler", "UrunlerID", "dbo.Urunler");
            DropForeignKey("dbo.AltUrunler", "MarkaID", "dbo.Marka");
            DropForeignKey("dbo.KampanyaliUrunler", "AltUrunlerID", "dbo.AltUrunler");
            DropForeignKey("dbo.Urunler", "AltKategoriID", "dbo.AltKategoriler");
            DropForeignKey("dbo.AltKategoriler", "KategoriID", "dbo.Kategoriler");
            DropIndex("dbo.Kullanicilar", new[] { "IlID" });
            DropIndex("dbo.Ilceler", new[] { "IlID" });
            DropIndex("dbo.KampanyaliUrunler", new[] { "AltUrunlerID" });
            DropIndex("dbo.AltUrunler", new[] { "MarkaID" });
            DropIndex("dbo.AltUrunler", new[] { "UrunlerID" });
            DropIndex("dbo.Urunler", new[] { "AltKategoriID" });
            DropIndex("dbo.AltKategoriler", new[] { "KategoriID" });
            DropTable("dbo.SiparisDetay");
            DropTable("dbo.Siparis");
            DropTable("dbo.Sepet");
            DropTable("dbo.ReklamliUrunler");
            DropTable("dbo.SezonSonuUrunler");
            DropTable("dbo.Kullanicilar");
            DropTable("dbo.Iller");
            DropTable("dbo.Ilceler");
            DropTable("dbo.EnCokTiklananlar");
            DropTable("dbo.EnCokSatilanlar");
            DropTable("dbo.EmailIzin");
            DropTable("dbo.Marka");
            DropTable("dbo.KampanyaliUrunler");
            DropTable("dbo.AltUrunler");
            DropTable("dbo.Urunler");
            DropTable("dbo.Kategoriler");
            DropTable("dbo.AltKategoriler");
        }
    }
}
