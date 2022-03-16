using HotelOtomasyonuWeb.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace HotelOtomasyonuWeb.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        public ActionResult GirisYap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GirisYap(TKullaniciSite t)
        {
            var x = Baglanti.db.TKullaniciSite.FirstOrDefault(b => b.Email == t.Email && b.Parola == t.Parola);
            if (x != null)
            {
                FormsAuthentication.SetAuthCookie(x.Email, false);
                Session["KullaniciID"] = x.KullaniciID;
                Session["KullaniciEmail"] = x.Email;
                return RedirectToAction("Profilim", "Misafir");

            }
            else
            {
                ViewBag.giris = "Hatalı Kullanıcı Adı Veya Şifre";
                return View();
            }
        }

        public ActionResult KayitOl()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KayitOl(TKullaniciSite t)
        {
            Baglanti.db.TKullaniciSite.Add(t);
            Baglanti.db.SaveChanges();
            ViewBag.kayit = "Başarıyla Kayıt Olundu Giriş Yapabilirsiniz.";
            return View();
        }
    }
}