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

        //9.ADIM - Yeni kategori eklememiz için, yeni action resultlar yazmamız gereklidir.
        //Ek olarakda Add view deriz YeniKategoriye.
        [HttpGet] //sayfa yüklendiğinde çalışsın
        public ActionResult YeniKategori()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKategori(tblkategori p) //tbl kategori için p adında bir nesne türetmiş olduk.
        {
            db.tblkategori.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index"); //bunu yazmamızın nedenide kategori ekledikten sonra, hangi sayfaya
            //dönmesini istememizdir.

        }



        //10.ADIM Kategori Silme İşlemi
        public ActionResult KategoriSil(int id)
        {
           var ktg = db.tblkategori.Find(id);
            db.tblkategori.Remove(ktg);
            db.SaveChanges();
            return RedirectToAction("Index");
        }



        //11.ADIM Kategori Güncelleme/Getirme
        public ActionResult KategoriGetir(int id)
        {
            var ktgr = db.tblkategori.Find(id);
            return View("KategoriGetir", ktgr);
        }



        //12.ADIM Kategori Güncelleme
        public ActionResult KategoriGuncelle(tblkategori k)
        {
            var ktg = db.tblkategori.Find(k.id);
            ktg.ad = k.ad;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}