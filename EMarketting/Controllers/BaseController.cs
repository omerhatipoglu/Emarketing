using EMarketting.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EMarketting.Controllers
{
    public class BaseController : Controller
    {
        public EMarketModel db;
        public BaseController()
        {
            db = new EMarketModel();
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }
    }
}