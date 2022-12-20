﻿using System;
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
            return View();
        }
    }
}