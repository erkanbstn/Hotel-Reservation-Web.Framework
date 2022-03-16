using HotelOtomasyonuWeb.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelOtomasyonuWeb.Controllers
{
    [Authorize]
    public class RezervasyonController : Controller
    {
        public ActionResult Rezervasyon()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Rezervasyon(TRezervasyon t)
        {
            byte id = Convert.ToByte(Session["KullaniciID"]);
            Baglanti.db.TRezervasyon.Add(t);
            t.Misafir = id;
            t.Durum = 10;
            Baglanti.db.SaveChanges();
            ViewBag.rez = "Rezervasyon Başarıyla Oluşturuldu.";
            return RedirectToAction("Rezervasyonlarim","Misafir");
        }

    }
}