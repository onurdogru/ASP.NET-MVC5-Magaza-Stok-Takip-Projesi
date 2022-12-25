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

        public ActionResult Index(string p)
        {
            //21.ADIMstart : tolisti revize ederiz
            //var urunler = db.tblurunler.ToList();
            // var urunler = db.tblurunler.Where(x=>x.durum==true).ToList();

            //36.ADIM start //yukarıdaki 21.adımın satırlarını sileriz/revize ederiz.
            var urunler = db.tblurunler.Where(x => x.durum == true);
            if (!string.IsNullOrEmpty(p))
            {
                urunler = urunler.Where(x => x.ad.Contains(p) && x.durum == true);
            }
            return View(urunler.ToList());
        }

        //14.ADIM : Yeni Ürün Ekleme
        [HttpGet]
        public ActionResult YeniUrun()
        {
            //15.ADIM başlangıç //ktg ismindeki değerime aşağıdaki değerleri atamış oldul.
            List <SelectListItem> ktg=(from x in db.tblkategori.ToList()
                                       select new SelectListItem
                                       {
                                           Text=x.ad,
                                           Value=x.id.ToString()
                                       }).ToList();
            ViewBag.drop = ktg; //drop isminde bir değer oluştururuz, ktg'deki değerleri tutmakla görevlidir.
                            
            return View();
        }

        [HttpPost]
        public ActionResult YeniUrun(tblurunler t)
        {
            //16.Adımstart
            var ktgr = db.tblkategori.Where(x => x.id == t.tblkategori.id).FirstOrDefault(); //Linq sorgusu
            t.tblkategori=ktgr;
            db.tblurunler.Add(t);
            db.SaveChanges();
            return RedirectToAction("Index");
           

            //return View();
        }

        //17.ADIM: Ürün Güncelleme Sayfasına Veri Taşıma İşlemi
        public ActionResult UrunGetir(int id)
        {
            //18.Adımstart/Güncelleme dropdown veri taşıma
            List<SelectListItem> kat=(from x in db.tblkategori.ToList() select new SelectListItem
                {
                Text= x.ad,
                Value = x.id.ToString()
            }).ToList ();




            var ktgr = db.tblurunler.Find(id);
            /*18Ek */ ViewBag.urunkategori = kat;

            return View("UrunGetir", ktgr);
        }

        //19.ADIMstart - Ürün Güncelleme İşlemi
        public ActionResult UrunGuncelle(tblurunler p)
        {
            var urun = db.tblurunler.Find(p.id);
            urun.marka = p.marka;
            urun.satisfiyat = p.satisfiyat;
            urun.stok = p.stok;
            urun.alisfiyat = p.alisfiyat;
            urun.ad = p.ad;
            var ktg = db.tblurunler.Where(x => x.id == p.tblkategori.id).FirstOrDefault();
            urun.kategori = ktg.id;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //20.ADIM
        public ActionResult UrunSil(tblurunler p1) //kendi içinde bir "p" parametresi olduğu için yukardaki ile karıştırma.Yada p1 yaparız karıştırmamak adına.
        {
            var urunbul = db.tblurunler.Find(p1.id);
            urunbul.durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}