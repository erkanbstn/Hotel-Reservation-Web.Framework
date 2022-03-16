using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelOtomasyonuWeb.Models.Entity;
namespace HotelOtomasyonuWeb.Controllers
{
    public class IletisimController : Controller
    {
        // GET: Iletisim
        public ActionResult Iletisim()
        {
            var x = Baglanti.db.TIletisimSite.ToList();
            return View(x);
        }
        public PartialViewResult MesajPartial()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult MesajGonder(TMesajSite t)
        {
            Baglanti.db.TMesajSite.Add(t);
            Baglanti.db.SaveChanges();
            return RedirectToAction("Iletisim");
        }
    }
}