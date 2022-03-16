using HotelOtomasyonuWeb.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace HotelOtomasyonuWeb.Controllers
{
    [Authorize]
    public class MisafirController : Controller
    {
        public ActionResult Profilim()
        {
            string email = Session["KullaniciEmail"].ToString();
            var x = Baglanti.db.TKullaniciSite.Where(b => b.Email == email).FirstOrDefault();
            return View(x);
        }
        [HttpPost]
        public ActionResult Profilim(TKullaniciSite t)
        {
            var x2 = Baglanti.db.TKullaniciSite.Find(t.KullaniciID);
            x2.Parola = t.Parola;
            x2.Telefon = t.Telefon;
            x2.İsim = t.İsim;
            Baglanti.db.SaveChanges();
            return View();
        }
        public ActionResult Rezervasyonlarim()
        {
            string email = Session["KullaniciEmail"].ToString();
            var misafir = Baglanti.db.TMisafir.Where(b => b.Mail == email).Select(b => b.MisafirID).FirstOrDefault();
            var x = Baglanti.db.TRezervasyon.Where(b => b.Misafir == misafir).ToList();
            return View(x);
        }
        public ActionResult CikisYap()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("AnaSayfa", "AnaSayfa");
        }

        public ActionResult GelenMesajlar()
        {
            string mail = Session["KullaniciEmail"].ToString();
            var x = Baglanti.db.TKMesajSite.Where(n => n.Alici == mail).ToList();
            return View(x);
        }
        public ActionResult MesajDetay(int id)
        {
            var x = Baglanti.db.TKMesajSite.Find(id);
            return View(x);
        }

        public ActionResult YeniMesaj()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniMesaj(TKMesajSite t)
        {
            string mail = Session["KullaniciEmail"].ToString();
            t.Gonderen = mail;
            t.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            Baglanti.db.TKMesajSite.Add(t);
            Baglanti.db.SaveChanges();
            return RedirectToAction("GelenMesajlar");
        }
    }
}
