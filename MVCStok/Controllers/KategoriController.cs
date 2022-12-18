using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//7.ADIM : Modeli tanımlarız, SQL db'nin olduğu kısım.
using MVCStok.Models.Entity;

namespace MVCStok.Controllers
{
    public class KategoriController : Controller
    {
        //4.ADIM : Kategori Controleri oluştururz.

        // GET: Kategori

        //7.ADIM devam : db'den nesne türetmemiz gereklidir. Db'deki tablolara ulaşmak için yaparız.
       DbMvcStokEntities db = new DbMvcStokEntities();

        public ActionResult Index()
        {
            //7.ADIM devam2: listeyle çağırmamız gereklidir

            var kategoriler = db.tblkategori.ToList();
            return View(kategoriler);
        }
    }
}