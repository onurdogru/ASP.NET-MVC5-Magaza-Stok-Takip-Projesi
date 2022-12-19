using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//13.ADIM : yeni bir ürün controlü aktif ederiz, entity'i de aktif ederiz.
using MVCStok.Models.Entity;

namespace MVCStok.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun

        DbMvcStokEntities db = new DbMvcStokEntities();
        //13.ADIMek index sayfasına add view deriz.

        public ActionResult Index()
        {
            var urunler = db.tblurunler.ToList();
            return View(urunler);
        }
    }
}