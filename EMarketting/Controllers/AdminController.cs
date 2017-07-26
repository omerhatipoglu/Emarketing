using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EMarketting.Controllers
{
    [AdminAuthentication]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Admin()
        {
            return View();
        }
        public ActionResult Categories()
        {
            return View();
        }
        public ActionResult SubCategories()
        {
            return View();
        }
        public ActionResult Products()
        {
            return View();
        }
        public ActionResult SubProducts()
        {
            return View();
        }
        public ActionResult Brands()
        {
            return View();
        }
        public ActionResult Users()
        {
            return View();
        }
        public ActionResult CamProducts()
        {
            return View();
        }
        public ActionResult OrderDetail()
        {
            return View();
        }
        public ActionResult ReklamProducts()
        {
            return View();
        }
        public ActionResult SezonProducts()
        {
            return View();
        }
    }
}