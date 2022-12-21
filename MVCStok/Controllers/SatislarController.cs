using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCStok.Models.Entity;

namespace MVCStok.Controllers
{
    public class SatislarController : Controller
    {
        // GET: Satislar
        //31.ADIM - kütüphanesini de ekleriz

        DbMvcStokEntities db = new DbMvcStokEntities();
        public ActionResult Index()
        {
            var satislar = db.tblsatislar.ToList();
            return View();
        }


        //32.Adım - Satış Ekranı
        [HttpGet]
        public ActionResult YeniSatis()
        {
            //33.Adımstart /ÜRÜNLER
            List<SelectListItem> urun = (from x in db.tblurunler.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.ad,
                                            Value = x.id.ToString()
                                        }).ToList();
            ViewBag.drop1 = urun; //drop isminde bir değer oluştururuz, ktg'deki değerleri tutmakla görevlidir.




            //PERSONELLER
            List<SelectListItem> per = (from x in db.tblpersonel.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.ad +" "+ x.soyad,
                                             Value = x.id.ToString()
                                         }).ToList();
            ViewBag.drop = per; //drop isminde bir değer oluştururuz, ktg'deki değerleri tutmakla görevlidir.






            //MÜŞTERİLER
            List<SelectListItem> must = (from x in db.tblmusteri.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.ad +" "+ x.soyad,
                                             Value = x.id.ToString()
                                         }).ToList();
            ViewBag.drop3 = must; //drop isminde bir değer oluştururuz, ktg'deki değerleri tutmakla görevlidir.

            return View();
        }

        [HttpPost]
        public ActionResult YeniSatis(tblsatislar p)
        {
            //34.ADIM BAŞLANGIÇ
            var urun = db.tblurunler.Where(x => x.id == p.tblurunler.id).FirstOrDefault(); //Linq sorgusu
            var musteri = db.tblmusteri.Where(x => x.id == p.tblmusteri.id).FirstOrDefault();
            var personel = db.tblpersonel.Where(x => x.id == p.tblpersonel.id).FirstOrDefault();

            //ürünler tablopsundan içinden, üründen gelen değeri ekle anlamındadır.
            p.tblurunler = urun;
            p.tblmusteri = musteri;
            p.tblpersonel = personel;
            p.tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.tblsatislar.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");

            
        }
    }
}