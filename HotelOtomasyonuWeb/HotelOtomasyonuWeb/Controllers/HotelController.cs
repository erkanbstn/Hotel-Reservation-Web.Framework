using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelOtomasyonuWeb.Models.Entity;
namespace HotelOtomasyonuWeb.Controllers
{
    public class HotelController : Controller
    {
        public ActionResult Hakkimda()
        {
            var x = Baglanti.db.THakkimdaSite.ToList();
            return View(x);
        }
        public PartialViewResult FooterPartial()
        {
            return PartialView();
        }
        public PartialViewResult ScriptPartial()
        {
            return PartialView();
        }
        public PartialViewResult HeaderPartial()
        {
            return PartialView();
        }
    }
}