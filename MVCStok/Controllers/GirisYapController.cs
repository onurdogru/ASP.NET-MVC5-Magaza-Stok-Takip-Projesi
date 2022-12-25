using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCStok.Models.Entity; //40
using System.Web.Security; //40

namespace MVCStok.Controllers
{
    public class GirisYapController : Controller
    {
        //37.ADIMstart
        // GET: GirisYap
        DbMvcStokEntities db = new DbMvcStokEntities(); //40
        public ActionResult Giris()
        {
            return View();
        }

        //40.adımstart
        [HttpPost]
        public ActionResult Giris(tbladmin t)
        {
            var bilgiler = db.tbladmin.FirstOrDefault(x => x.kullanici == t.kullanici && x.sifre == t.sifre);
            if (bilgiler  != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.kullanici, false);
                return RedirectToAction("Index","Musteri");
            }
            else
            {
                return View();
            }

            return View();
        }



    }
}