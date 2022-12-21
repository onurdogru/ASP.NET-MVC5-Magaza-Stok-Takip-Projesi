using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//23.ADIM : yeni eklenen pagetlistmvc dahil etme
using PagedList;
using PagedList.Mvc;
//22.ADIMstart
using MVCStok.Models.Entity;

namespace MVCStok.Controllers
{
    public class MusteriController : Controller
    {

        // GET: Musteri 22.ADIMdevam
        DbMvcStokEntities db = new DbMvcStokEntities();
        public ActionResult Index(int sayfa=1) //sayfalama işleminin kaçtan başlıcağını belirtir
        {
            //var musteriliste = db.tblmusteri.ToList(); //23.Adım pagedlist ile ilgili
            //alt satırdaki true kısmı, sadece durumu true olanları çekmek için yazılmıştır.
            var musteriliste = db.tblmusteri.Where(x=>x.durum==true).ToList().ToPagedList(sayfa, 3); //kaçadet sütun alacağını belirtir.
            return View(musteriliste);
        }

        //25.ADIM - Yeni Müşteri Ekleme
        [HttpGet]
        public ActionResult YeniMusteri()
        {
           return View();
        }
        [HttpPost]
        public ActionResult YeniMusteri(tblmusteri p)
        {
            if(!ModelState.IsValid) //30.ADIMstart
            {
                return View("YeniMusteri");
            }



            p.durum = true; //29.Adımek
            db.tblmusteri.Add(p);
            
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //26.ADIM - Müşteri Silme
        public ActionResult MusteriSil(tblmusteri p)
        {
            var musteribul = db.tblmusteri.Find(p.id);
            musteribul.durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //27.ADIM - Müşteri Bilgileri Taşıma
        public ActionResult MusteriGetir(int id)
        {
            var mus = db.tblmusteri.Find(id);
            return View("MusteriGetir", mus);
        }

        //28.Adım - Müşteri Güncelleme
        public ActionResult MusteriGuncelle(tblmusteri t)
        {
            var mus = db.tblmusteri.Find(t.id);
            mus.ad = t.ad;
            mus.soyad = t.soyad;
            mus.sehir = t.sehir;
            mus.bakiye = t.bakiye;

            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}