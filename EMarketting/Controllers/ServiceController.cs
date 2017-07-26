using AutoMapper;
using EMarketting.Models.Data;
using EMarketting.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EMarketting.Controllers
{
    public class ServiceController : BaseController
    {
        // GET: Service
        public ActionResult GetAllCategories()
        {
            db.Configuration.LazyLoadingEnabled = false;
            var clist = db.Kategoriler.ToList();
            return Json(clist,JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetSubCategoriesByCategoryID(int ID)
        {
            var clist = db.AltKategoriler.Where(x => x.kategoriler.KategoriID == ID).Select(x => new { x.AltKategoriID, x.AltKategoriAd, x.KategoriID }).ToList();
            return Json(clist, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Register(UserDTO User)
        {
            db.Configuration.LazyLoadingEnabled = false;
            if (User.Ad != null || User.Soyad != null || User.Adres != null || User.Email != null || User.IlID != 0 || User.Sifre != null || User.SifreTekrar != null || User.TelNo != 0)
            {
                Kullanici deneme = db.Kullanicilar.Where(x => x.Email == User.Email).FirstOrDefault();
                if (deneme == null)
                {
                    if (User.Sifre == User.SifreTekrar)
                    {
                        Kullanici k = new Kullanici();
                        k.KullaniciRol = "user";
                        k.Ad = User.Ad;
                        k.Soyad = User.Soyad;
                        k.Email = User.Email;
                        k.TelNo = User.TelNo;
                        k.Adres = User.Adres;
                        k.IlID = User.IlID;
                        k.Sifre = User.Sifre;
                        k.DogumGunu = User.DogumGunu;
                        k.MailIzin = User.MailIzin;
                        db.Kullanicilar.Add(k);
                        db.SaveChanges();
                        return Json(" ",JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json("Şifreler Aynı Olmalı", JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json("Bu Email Adına Hesap Bulunmaktadır.", JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json("Boş Alan Kalmamalı", JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GetAllCities()
        {
            db.Configuration.LazyLoadingEnabled = false;
            var cities = db.Iller.ToList();
            return Json(cities, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Login(LoginDTO user)
        {
            Kullanici k = db.Kullanicilar.Where(x => x.Email == user.Email).FirstOrDefault();
            if (k != null)
            {
                if (k.Sifre == user.Sifre)
                {
                    Session["Rol"] = k.KullaniciRol;
                    Session["Ad"] = k.Ad;
                    Session["Email"] = k.Email;
                    Session["KullaniciID"] = k.KullaniciID;
                    return Json(Session["Rol"],JsonRequestBehavior.AllowGet);
                }
                else
                {
                    Session["HataMsg"] = " Sifre Hatalı";
                    return Json(Session["HataMsg"], JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                Session["HataMsg"] = "E-Posta Hatalı";
                return Json(Session["HataMsg"],JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult Logout()
        {
            Session["Rol"] = null;
            Session["Ad"] = null;
            Session["Email"] = null;
            Session["KullaniciID"] = null;
            int x = 1;
            return Json(x,JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetCategoryByCategoryID(int ID)
        {
            db.Configuration.LazyLoadingEnabled = false;
            Kategoriler kategori = db.Kategoriler.Find(ID);
            return Json(kategori, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Edit(CategoryDTO category)
        {
            if (category.KategoriID != 0)
            {
                Kategoriler k = db.Kategoriler.Find(category.KategoriID);
                k.KategoriAd = category.KategoriAd;
                k.Aciklama = category.Aciklama;
                db.SaveChanges();
                return Json("Değişiklik Başarıyla Kaydedildi.", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Satır Seçmediniz.", JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ActionResult Add(CategoryDTO category)
        {
            Kategoriler k = new Kategoriler();
            k.KategoriAd = category.KategoriAd;
            k.Aciklama = category.Aciklama;
            db.Kategoriler.Add(k);
            db.SaveChanges();
            return Json("Başarıyla Eklendi.",JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Delete(int ID)
        {
            Kategoriler k = db.Kategoriler.Find(ID);
            db.Kategoriler.Remove(k);
            db.SaveChanges();
            return Json("Başarıyla Silindi.", JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetAllSubCategories()
        {
            var list = db.AltKategoriler.Select(x => new { x.AltKategoriID, x.AltKategoriAd, x.kategoriler.KategoriAd, x.KategoriID }).ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetSubCategoryBySubCategoryID(int ID)
        {
            db.Configuration.LazyLoadingEnabled = false;
            AltKategoriler a = db.AltKategoriler.Find(ID);
            return Json(a, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult SubCatEdit(SubCategoryDTO subcategory)
        {
            if (subcategory.AltKategoriID != 0)
            {
                AltKategoriler a = db.AltKategoriler.Find(subcategory.AltKategoriID);
                a.AltKategoriAd = subcategory.AltKategoriAd;
                a.KategoriID = subcategory.KategoriID;
                db.SaveChanges();
                return Json("Değişiklik Başarıyla Kaydedildi.", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Satır Seçmediniz.", JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ActionResult SubCatAdd(SubCategoryDTO subcategory)
        {
            if (subcategory.KategoriID != 0)
            {
                AltKategoriler a = new AltKategoriler();
                a.AltKategoriAd = subcategory.AltKategoriAd;
                a.KategoriID = subcategory.KategoriID;
                db.AltKategoriler.Add(a);
                db.SaveChanges();
                return Json("Başarıyla Eklendi.", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Kategori Seçmediniz.", JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ActionResult SubCatDelete(int ID)
        {
            AltKategoriler a = db.AltKategoriler.Find(ID);
            db.AltKategoriler.Remove(a);
            db.SaveChanges();
            return Json("Başarıyla Silindi.", JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetAllProducts()
        {
            db.Configuration.LazyLoadingEnabled = false;
            var list = db.Urunler.Select(x => new { x.UrunlerID, x.UrunlerAd, x.AltKategoriID, x.altkategori.AltKategoriAd }).ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetProductByProductID(int ID)
        {
            db.Configuration.LazyLoadingEnabled = false;
            Urunler u = db.Urunler.Find(ID);
            return Json(u, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult ProEdit(ProductsDTO product)
        {
            if (product.UrunlerID != 0)
            {
                Urunler u = db.Urunler.Find(product.UrunlerID);
                u.UrunlerAd = product.UrunlerAd;
                u.AltKategoriID = product.AltKategoriID;
                db.SaveChanges();
                return Json("Değişiklik Başarıyla Kaydedildi", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Satır Seçmediniz.", JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ActionResult ProAdd(ProductsDTO product)
        {
            if (product.AltKategoriID != 0)
            {
                Urunler u = new Urunler();
                u.UrunlerAd = product.UrunlerAd;
                u.AltKategoriID = product.AltKategoriID;
                db.Urunler.Add(u);
                db.SaveChanges();
                return Json("Başarıyla Eklendi", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Alt Kategori Seçmediniz.", JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ActionResult ProDelete(int ID)
        {
            Urunler u = db.Urunler.Find(ID);
            db.Urunler.Remove(u);
            db.SaveChanges();
            return Json("Başarıyla Silinmiştir", JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetAllSubProducts()
        {
            db.Configuration.LazyLoadingEnabled = false;
            var list = db.AltUrunler.Select(x => new { x.AltUrunlerID,x.Reklam,x.SezonSonu, x.AltUrunlerAd, x.urunler.UrunlerAd, x.UrunlerID, x.marka.MarkaAd, x.MarkaID, x.Resim, x.Resim2, x.Kampanya, x.Fiyat, x.Aciklama, x.SatilanAdet, x.StokAdeti, x.TiklamaSayisi, x.SiparisAdet }).ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetSubProductBySubProductID(int ID)
        {
            db.Configuration.LazyLoadingEnabled = false;
            var a = db.AltUrunler.Where(x => x.AltUrunlerID == ID).Select(x => new { x.AltUrunlerID, x.Reklam, x.SezonSonu, x.AltUrunlerAd, x.urunler.UrunlerAd, x.UrunlerID, x.marka.MarkaAd, x.MarkaID, x.Resim, x.Resim2, x.Kampanya, x.Fiyat, x.Aciklama, x.SatilanAdet, x.StokAdeti, x.TiklamaSayisi, x.SiparisAdet }).FirstOrDefault();
            return Json(a, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult SubProEdit(SubProductsDTO subproduct)
        {
            if (subproduct.AltUrunlerID != 0)
            {
                AltUrunler a = db.AltUrunler.Find(subproduct.AltUrunlerID);
                if (subproduct.Kampanya == true && a.Kampanya == false)
                {
                    KampanyaliUrunler k = new KampanyaliUrunler();
                    k.AltUrunlerID = a.AltUrunlerID;
                    db.KampanyaliUrunler.Add(k);
                    db.SaveChanges();
                }
                if (subproduct.Kampanya == false && a.Kampanya == true)
                {
                    KampanyaliUrunler k = db.KampanyaliUrunler.Where(x => x.AltUrunlerID == a.AltUrunlerID).FirstOrDefault();
                    db.KampanyaliUrunler.Remove(k);
                    db.SaveChanges();
                }
                if (subproduct.Reklam == true && a.Reklam == false)
                {
                    ReklamliUrunler rk = new ReklamliUrunler();
                    rk.AltUrunlerID = a.AltUrunlerID;
                    db.ReklamliUrunler.Add(rk);
                    db.SaveChanges();
                }
                if (subproduct.Reklam == false && a.Reklam == true)
                {
                    ReklamliUrunler rk = db.ReklamliUrunler.Where(x => x.AltUrunlerID == a.AltUrunlerID).FirstOrDefault();
                    db.ReklamliUrunler.Remove(rk);
                    db.SaveChanges();
                }
                if (subproduct.SezonSonu == true && a.SezonSonu == false)
                {
                    SezonSonuUrunler ss = new SezonSonuUrunler();
                    ss.AltUrunlerID = a.AltUrunlerID;
                    db.SezonSonuUrunler.Add(ss);
                    db.SaveChanges();
                }
                if (subproduct.SezonSonu == false && a.SezonSonu == true)
                {
                    SezonSonuUrunler ss = db.SezonSonuUrunler.Where(x => x.AltUrunlerID == a.AltUrunlerID).FirstOrDefault();
                    db.SezonSonuUrunler.Remove(ss);
                    db.SaveChanges();
                }
                a.AltUrunlerAd = subproduct.AltUrunlerAd;
                a.Aciklama = subproduct.Aciklama;
                a.Fiyat = subproduct.Fiyat;
                a.Kampanya = subproduct.Kampanya;
                a.Reklam = subproduct.Reklam;
                a.SezonSonu = subproduct.SezonSonu;
                a.MarkaID = subproduct.MarkaID;
                a.StokAdeti = subproduct.StokAdeti;
                a.UrunlerID = subproduct.UrunlerID;
                a.Resim = subproduct.Resim;
                a.Resim2 = subproduct.Resim2;
                db.SaveChanges();
                return Json("Değişiklik Başarıyla Kaydedildi.", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Satır Seçilmedi", JsonRequestBehavior.AllowGet);
            }
            
        }
        [HttpPost]
        public ActionResult SubProAdd(SubProductsDTO subproduct)
        {
            if (subproduct.UrunlerID != 0 || subproduct.MarkaID != 0)
            {
                AltUrunler a = new AltUrunler();
                a.AltUrunlerAd = subproduct.AltUrunlerAd;
                a.Aciklama = subproduct.Aciklama;
                a.Fiyat = subproduct.Fiyat;
                a.Kampanya = subproduct.Kampanya;
                a.Reklam = subproduct.Reklam;
                a.SezonSonu = subproduct.SezonSonu;
                a.MarkaID = subproduct.MarkaID;
                a.StokAdeti = subproduct.StokAdeti;
                a.UrunlerID = subproduct.UrunlerID;
                a.Resim = "http://localhost:53958/Resim/" + subproduct.Resim + ".jpg";
                a.Resim2 = "http://localhost:53958/Resim/" + subproduct.Resim2 + ".jpg";
                db.AltUrunler.Add(a);
                db.SaveChanges();
                if (subproduct.Kampanya == true)
                {
                    KampanyaliUrunler k = new KampanyaliUrunler();
                    AltUrunler a2 = db.AltUrunler.Where(x => x.AltUrunlerAd == a.AltUrunlerAd).FirstOrDefault();
                    k.AltUrunlerID = a2.AltUrunlerID;
                    db.KampanyaliUrunler.Add(k);
                    db.SaveChanges();
                }
                if (subproduct.Reklam == true)
                {
                    ReklamliUrunler rk = new ReklamliUrunler();
                    AltUrunler a3 = db.AltUrunler.Where(y => y.AltUrunlerAd == a.AltUrunlerAd).FirstOrDefault();
                    rk.AltUrunlerID = a3.AltUrunlerID;
                    db.ReklamliUrunler.Add(rk);
                    db.SaveChanges();
                }
                if (subproduct.SezonSonu == true)
                {
                    SezonSonuUrunler ss = new SezonSonuUrunler();
                    AltUrunler a4 = db.AltUrunler.Where(z => z.AltUrunlerAd == a.AltUrunlerAd).FirstOrDefault();
                    ss.AltUrunlerID = a4.AltUrunlerID;
                    db.SezonSonuUrunler.Add(ss);
                    db.SaveChanges();
                }
                return Json("Başarıyla Eklendi.", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Ürün veya Marka Seçmediniz.", JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ActionResult SubProDelete(int ID)
        {
            AltUrunler a = db.AltUrunler.Find(ID);
            if (a.Kampanya == true)
            {
                KampanyaliUrunler k = db.KampanyaliUrunler.Where(x => x.AltUrunlerID == a.AltUrunlerID).FirstOrDefault();
                db.KampanyaliUrunler.Remove(k);
                db.SaveChanges();
            }
            if (a.Reklam == true)
            {
                ReklamliUrunler rk = db.ReklamliUrunler.Where(y => y.AltUrunlerID == a.AltUrunlerID).FirstOrDefault();
                db.ReklamliUrunler.Remove(rk);
                db.SaveChanges();
            }
            if (a.SezonSonu == true)
            {
                SezonSonuUrunler ss = db.SezonSonuUrunler.Where(z => z.AltUrunlerID == a.AltUrunlerID).FirstOrDefault();
                db.SezonSonuUrunler.Remove(ss);
                db.SaveChanges();
            }
            db.AltUrunler.Remove(a);
            db.SaveChanges();
            return Json("Başarıyla Silinmiştir", JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetAllBrands()
        {
            db.Configuration.LazyLoadingEnabled = false;
            var list = db.Marka.Select(x => new { x.MarkaID, x.MarkaAd }).ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetBrandByBrandID(int ID)
        {
            db.Configuration.LazyLoadingEnabled = false;
            Marka m = db.Marka.Find(ID);
            return Json(m, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult BrandEdit(BrandDTO brand)
        {
            if (brand.MarkaID != 0)
            {
                Marka m = db.Marka.Find(brand.MarkaID);
                m.MarkaAd = brand.MarkaAd;
                db.SaveChanges();
                return Json("Değişiklik Başarıyla Kaydedildi.", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Satır Seçilmedi.", JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ActionResult BrandAdd(BrandDTO brand)
        {
            Marka m = new Marka();
            m.MarkaAd = brand.MarkaAd;
            db.Marka.Add(m);
            db.SaveChanges();
            return Json("Başarıyla Eklendi.", JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult BrandDelete(int ID)
        {
            Marka m = db.Marka.Find(ID);
            db.Marka.Remove(m);
            db.SaveChanges();
            return Json("Başarıyla Silindi.", JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetAllUsers()
        {
            db.Configuration.LazyLoadingEnabled = false;
            var list = db.Kullanicilar.Select(x => new
            {
                x.KullaniciID,
                x.Ad,
                x.Soyad,
                x.TelNo,
                x.Email,
                x.Adres,
                DogumGunu = x.DogumGunu.ToString(),
                x.IlID,
                x.il.IlAd,
                x.MailIzin,
                x.KullaniciRol
            }).ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetUserByUserID(int ID)
        {
            db.Configuration.LazyLoadingEnabled = false;
            var k = db.Kullanicilar.Where(x => x.KullaniciID == ID).Select(x => new
            {
                x.KullaniciID,
                x.Ad,
                x.Soyad,
                x.TelNo,
                x.Email,
                x.Adres,
                DogumGunu = x.DogumGunu.ToString(),
                x.IlID,
                x.il.IlAd,
                x.MailIzin,
                x.KullaniciRol
            }).FirstOrDefault() ;
            return Json(k, JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public ActionResult UserEdit(UserDTO kullanici)
        {
            if (kullanici.KullaniciID != 0)
            {
                Kullanici k = db.Kullanicilar.Find(kullanici.KullaniciID);
                if (kullanici.MailIzin == true && k.MailIzin == false)
                {
                    EmailIzin e = new EmailIzin();
                    e.KullaniciID = kullanici.KullaniciID;
                    e.Email = kullanici.Email;

                    db.EmailIzin.Add(e);
                    db.SaveChanges();
                }
                if (kullanici.MailIzin == false && k.MailIzin == true)
                {
                    EmailIzin e = db.EmailIzin.Where(x => x.KullaniciID == kullanici.KullaniciID).FirstOrDefault();
                    db.EmailIzin.Remove(e);
                    db.SaveChanges();
                }
                k.Ad = kullanici.Ad;
                k.Soyad = kullanici.Soyad;
                k.IlID = kullanici.IlID;
                k.TelNo = kullanici.TelNo;
                k.Adres = kullanici.Adres;
                k.DogumGunu = kullanici.DogumGunu;
                k.Email = kullanici.Email;
                k.KullaniciRol = kullanici.KullaniciRol;
                k.MailIzin = kullanici.MailIzin;
                db.SaveChanges();
                return Json("Değişiklik Başarıyla Güncellendi", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Satı Seçmediniz.", JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ActionResult UserAdd(UserDTO kullanici)
        {
            if (kullanici.IlID != 0)
            {
                Kullanici k = new Kullanici();
                k.Email = kullanici.Email;
                k.Ad = kullanici.Ad;
                k.Soyad = kullanici.Soyad;
                k.Adres = kullanici.Adres;
                k.DogumGunu = kullanici.DogumGunu;
                k.IlID = kullanici.IlID;
                k.KullaniciRol = kullanici.KullaniciRol;
                k.MailIzin = kullanici.MailIzin;
                k.TelNo = kullanici.TelNo;
                db.Kullanicilar.Add(k);
                db.SaveChanges();
                if (kullanici.MailIzin == true)
                {
                    EmailIzin e = new EmailIzin();
                    var em = db.Kullanicilar.Where(x => x.Email == kullanici.Email).FirstOrDefault();
                    e.KullaniciID = em.KullaniciID;
                    e.Email = em.Email;
                    db.EmailIzin.Add(e);
                    db.SaveChanges();
                }
                return Json("başarıyla eklendi", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("İl Seçmediniz", JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ActionResult UserDelete(int ID)
        {
            Kullanici k = db.Kullanicilar.Find(ID);
            if (k.MailIzin == true)
            {
                EmailIzin e = db.EmailIzin.Where(x => x.KullaniciID == k.KullaniciID).FirstOrDefault();
                db.EmailIzin.Remove(e);
                db.SaveChanges();
            }
            db.Kullanicilar.Remove(k);
            db.SaveChanges();
            return Json("Başarıyla Silindi.", JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetAllCam()
        {
            db.Configuration.LazyLoadingEnabled = false;
            var c = db.KampanyaliUrunler.Select(x => new
            {
                x.alturunler.AltUrunlerAd,
                x.alturunler.Fiyat,
                x.alturunler.AltUrunlerID,
                x.alturunler.Kampanya,
                x.KampanyaID,
                x.IndirimOrani,
                x.Aciklama,


            }).ToList();
            return Json(c, JsonRequestBehavior.AllowGet);

        }

        public ActionResult GetCamByCamID(int ID)
        {
            db.Configuration.LazyLoadingEnabled = false;
            KampanyaliUrunler k = db.KampanyaliUrunler.Find(ID);
            return Json(k, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult CamEdit(CamDTO c)
        {
            if (c.KampanyaID != 0)
            {
                KampanyaliUrunler k = db.KampanyaliUrunler.Find(c.KampanyaID);
                k.IndirimOrani = c.IndirimOrani;
                k.Aciklama = c.Aciklama;
                db.SaveChanges();
                return Json("Değişiklik Başarıyla Kaydedildi.", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Satır Seçilmedi", JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult CatCount()
        {
            int catcount = db.Kategoriler.Count();
            return Json(catcount, JsonRequestBehavior.AllowGet);
        }
        public ActionResult SubCatCount()
        {
            int subcatcount = db.AltKategoriler.Count();
            return Json(subcatcount, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ProCount()
        {
            int procount = db.Urunler.Count();
            return Json(procount, JsonRequestBehavior.AllowGet);

        }
        public ActionResult SubProCount()
        {
            int subprocount = db.AltUrunler.Count();
            return Json(subprocount, JsonRequestBehavior.AllowGet);
        }
        public ActionResult UserCount()
        {
            int usercount = db.Urunler.Count();
            return Json(usercount, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetAllOrders()
        {
            db.Configuration.LazyLoadingEnabled = false;
            var orders = db.Siparis.Select(x => new { x.SiparisID, x.KullaniciID, SiparisTarihi = x.SiparisTarihi.ToString(), PostalandigiTarih = x.PostalandigiTarih.ToString() }).ToList();
            return Json(orders, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetAllDetailByOrderID(int ID)
        {
            db.Configuration.LazyLoadingEnabled = false;
            AllDetailDTO AllDetail = new AllDetailDTO();
            AllDetail.s = db.Siparis.Where(x => x.SiparisID == ID).Select(x => new SiparisDTO{ SiparisID = x.SiparisID, KullaniciID = x.KullaniciID, Agirlik = x.Agirlik, GonderilenAdres = x.GonderilenAdres, GonderilenSehir = x.GonderilenSehir, PostalandigiTarih = x.PostalandigiTarih.ToString(), SiparisTarihi = x.SiparisTarihi.ToString() }).FirstOrDefault();
            AllDetail.sd = db.SiparisDetay.Where(x => x.SiparisID == ID).FirstOrDefault();
            AllDetail.k = db.Kullanicilar.Find(AllDetail.s.KullaniciID);
            AllDetail.a = db.AltUrunler.Find(AllDetail.sd.AltUrunlerID);

            return Json(AllDetail, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Address(int ID)
        {
            Session["ID"] = ID;
            return Json(Session["ID"], JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetSubProductsBySubCategoryID(int ID)
        {
            db.Configuration.LazyLoadingEnabled = false;
            var subproducts = db.AltUrunler.Where(x => x.urunler.AltKategoriID == ID).ToList();
            return Json(subproducts, JsonRequestBehavior.AllowGet);
        }
        public ActionResult CategoryAddressBySubCategoryID(int ID)
        {
            Session["SubCategory"] = ID;
            return Json(Session["SubCategory"], JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetSubProductsByProductID(int ID)
        {
            db.Configuration.LazyLoadingEnabled = false;
            var subproducts = db.AltUrunler.Where(x => x.UrunlerID == ID).ToList();
            return Json(subproducts, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ProductAddressByProductID(int ID)
        {
            Session["Product"] = ID;
            return Json(Session["Product"], JsonRequestBehavior.AllowGet); 
        }
        public ActionResult SubProductAddressBySubProductID(int ID)
        {
            var urun = db.AltUrunler.Find(ID);
            urun.TiklamaSayisi++;
            db.SaveChanges();
            Session["SubProduct"] = ID;
            return Json(Session["SubProduct"], JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetSubProductsByCategoryID(int ID)
        {
            db.Configuration.LazyLoadingEnabled = false;
            var urun = db.AltUrunler.Where(x => x.urunler.altkategori.KategoriID == ID).ToList();
            return Json(urun, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetAllRkProducts()
        {
            var rk = db.ReklamliUrunler.Select(x => new
            {
                x.ReklamliUrunID,
                x.alturunler.AltUrunlerAd,
                x.alturunler.Resim

            }).ToList();
            return Json(rk, JsonRequestBehavior.AllowGet);

        }
        public ActionResult GetAllSezonProducts()
        {
            var sezon = db.SezonSonuUrunler.Select(x => new
            {
                x.SezonSonuID,
                x.alturunler.AltUrunlerAd,
                x.alturunler.Resim

            }).ToList();
            return Json(sezon, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        [UserAuthentication]
        public ActionResult GetAddSepet(SepetDTO sepet)
        {


            Sepet s = new Sepet();
            s.SiparisAdet = sepet.SiparisAdet;
            s.KullaniciID = (int)Session["KullaniciID"];
            s.Email = (string)Session["Email"];
            var musteri = db.Kullanicilar.Find(s.KullaniciID);
            s.Adres = musteri.Adres;
            s.il = musteri.il.IlAd;
            s.AltUrunlerID = (int)Session["SubProduct"];
            var fiyat = db.AltUrunler.Where(x => x.AltUrunlerID == s.AltUrunlerID).Select(x => x.Fiyat).FirstOrDefault();
            s.ToplamFiyat = (double)(sepet.SiparisAdet * fiyat);
            var a = db.Sepet.Where(x => x.AltUrunlerID == s.AltUrunlerID && x.KullaniciID == s.KullaniciID).ToList();
            if (a.Count == 0)
            {

                db.Sepet.Add(s);
                db.SaveChanges();

                return Json("Değişiklik Başarıyla Kaydedildi.", JsonRequestBehavior.AllowGet);
            }


            return Json("Değişiklik Başarıyla Kaydedildi.", JsonRequestBehavior.AllowGet);
        }

        [UserAuthentication]
        public ActionResult GetAllSepet()
        {
            int ID = (int)(Session["KullaniciID"]);
            var s = db.Sepet.Where(x => x.KullaniciID == ID).Select(x => new SepetDTO
            {
                KullaniciID = x.KullaniciID,
                SepetID = x.SepetID,
                Email = x.Email,
                Adres = x.Adres,
                il = x.il,
                SiparisAdet = x.SiparisAdet,
                AltUrunlerID = x.AltUrunlerID,
                resim = x.alturunler.Resim,
                urunad = (string)(x.alturunler.AltUrunlerAd),
                marka = (string)(x.alturunler.marka.MarkaAd),
                fiyat = (decimal)(x.alturunler.Fiyat),
                ToplamFiyat = (decimal)((x.alturunler.Fiyat) * (x.SiparisAdet))
            }).ToList();


            return Json(s, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult SepetUpdate(SepetDTO crt)
        {

            var s = db.Sepet.Where(x => x.KullaniciID == crt.KullaniciID && x.AltUrunlerID == crt.AltUrunlerID).FirstOrDefault();
            s.SiparisAdet = crt.SiparisAdet;
            s.KullaniciID = crt.KullaniciID;
            s.Email = crt.Email;
            s.AltUrunlerID = crt.AltUrunlerID;
            s.il = crt.il;
            s.Adres = crt.Adres;
            s.ToplamFiyat = (double)(crt.SiparisAdet * crt.fiyat);
            db.SaveChanges();
            return Json("Değişiklik Başarıyla Kaydedildi.", JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public ActionResult SepetDelete(SepetDTO crt)
        {

            var id = db.Sepet.Where(x => x.SepetID == crt.SepetID).FirstOrDefault();
            db.Sepet.Remove(id);
            db.SaveChanges();
            return Json("Başarıyla Silindi.", JsonRequestBehavior.AllowGet);

        }
        [UserAuthentication]
        public ActionResult SepetCount()
        {
            int ID = (int)(Session["KullaniciID"]);
            int count = db.Sepet.Where(x => x.KullaniciID == ID).Count();
            return Json(count, JsonRequestBehavior.AllowGet);
        }
        [UserAuthentication]
        public ActionResult SepetTotal()
        {
            decimal s = 0;
            int ID = (int)(Session["KullaniciID"]);
            var a = db.Sepet.Where(x => x.KullaniciID == ID).ToList();
            if (a.Count != 0)
            {
                s = (decimal)(db.Sepet.Where(x => x.KullaniciID == ID).Sum(x => x.ToplamFiyat));
            }
            return Json(s, JsonRequestBehavior.AllowGet);
        }
        //public ActionResult SortByNameBySubCatID (int ID)
        //{

        //}
    }
}