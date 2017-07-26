using EMarketting.Models.Data;
using EMarketting.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace EMarketting.Controllers
{
    public class HomeController : Base2Controller
    {
        // GET: Home
        BigDTO bd = new BigDTO();
        public ActionResult Index()
        {
            bd.modeldto = md;
            bd.Encoksat = db.EnCokSatilanlar.Take(10).ToList();
            bd.Encoktik = db.EnCokTiklananlar.Take(10).ToList();
            bd.Reklam = db.ReklamliUrunler.Take(10).ToList();
            bd.Kampanya = db.KampanyaliUrunler.Take(10).ToList();
            bd.Sezonsonu = db.SezonSonuUrunler.Take(10).ToList();
            return View(bd);
        }
        public ActionResult Register()
        {
            bd.modeldto = md;
            return View(bd);
        }
        public ActionResult Login()
        {
            bd.modeldto = md;
            return View(bd);
        }
        public ActionResult NotFound()
        {
            bd.modeldto = md;
            return View(bd);
        }
        [UserAuthentication]
        public ActionResult Cart()
        {
            bd.modeldto = md;
            return View(bd);
        }
        [UserAuthentication]
        public ActionResult Checkout()
        {
            bd.modeldto = md;
            return View(bd);
        }
        public ActionResult Category()
        {
            bd.modeldto = md;
            return View(bd);
        }
        public ActionResult Product()
        {
            bd.modeldto = md;
            return View(bd);
        }
        public ActionResult Category2()
        {
            bd.modeldto = md;
            return View(bd);
        }
    }
}