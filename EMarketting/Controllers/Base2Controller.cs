using EMarketting.Models.Data;
using EMarketting.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EMarketting.Controllers
{
    public class Base2Controller : Controller
    {
        public EMarketModel db;
        public ModelDTO md;
        public Base2Controller()
        {
            db = new EMarketModel();
            md = new ModelDTO();
            md.Clist = db.Kategoriler.Select(x => new CategoryDTO {
                KategoriID = x.KategoriID,
                KategoriAd = x.KategoriAd,
                Aciklama = x.Aciklama,
                Slist = db.AltKategoriler.Where(a => a.KategoriID == x.KategoriID).Select(b => new SubCategoryDTO {
                    AltKategoriID = b.AltKategoriID,
                    AltKategoriAd = b.AltKategoriAd,
                    KategoriID = b.KategoriID,
                    Plist = db.Urunler.Where(c => c.AltKategoriID == b.AltKategoriID).Select(d => new ProductsDTO {
                        UrunlerID = d.UrunlerID,
                        UrunlerAd = d.UrunlerAd,
                        AltKategoriID = d.AltKategoriID
                    }).ToList()
                }).ToList()
            }).ToList();
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }
    }
}