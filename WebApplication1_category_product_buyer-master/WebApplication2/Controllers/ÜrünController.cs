using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models.Entity;


namespace WebApplication2.Controllers
{
    public class ÜrünController : Controller
    {
        // GET: Ürün
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index(string p)
        {
            var degerler = from d in db.tabloürünler select d;
            if (!string.IsNullOrEmpty(p))
            {
                degerler = degerler.Where(m => m.ürünadi.Contains(p));
            }
            return View(degerler.ToList());
        }
        [HttpGet]
        public ActionResult YeniÜrün()
        {
            List<SelectListItem> degerler = (from i in db.tablokategoriler.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.kategoriad,
                                                 Value = i.kategoriid.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;             
            return View();
        }

        [HttpPost]
        public ActionResult YeniÜrün(tabloürünler p1)
        {
            var ktg = db.tablokategoriler.Where(m => m.kategoriid == p1.tablokategoriler.kategoriid).FirstOrDefault();
            p1.tablokategoriler = ktg;
            db.tabloürünler.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult sil(int id)
        {
            var urun = db.tabloürünler.Find(id);
            db.tabloürünler.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunGetir(int id)
        {
            var urun = db.tabloürünler.Find(id);
            List<SelectListItem> degerler = (from i in db.tablokategoriler.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.kategoriad,
                                                 Value = i.kategoriid.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View("UrunGetir", urun);
        }

        public ActionResult Guncelle(tabloürünler p1)
        {
            var urun = db.tabloürünler.Find(p1.ürünid);
            urun.ürünadi = p1.ürünadi;
            urun.marka = p1.marka;
           // urun.ürünkategori = p1.ürünkategori;
            urun.fiyat = p1.fiyat;
            urun.stok = p1.stok; 

            var ktg = db.tablokategoriler.Where(m => m.kategoriid == p1.tablokategoriler.kategoriid).FirstOrDefault();
            urun.ürünkategori = ktg.kategoriid;

            db.SaveChanges();
            return RedirectToAction("Index");


        }



    }
}