using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models.Entity;
using WebApplication2.Controllers;



namespace WebApplication2.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index(string p)
        {
            var degerler = from d in db.tablokategoriler select d;
            if (!string.IsNullOrEmpty(p))
            {
                degerler = degerler.Where(m => m.kategoriad.Contains(p));
            }
            return View(degerler.ToList());
        }
        [HttpGet]
        public ActionResult Yenikategori()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Yenikategori(tablokategoriler p1)
        {
            if (!ModelState.IsValid)
            {
                return View("Yenikategori");
            }
            db.tablokategoriler.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult sil(int id)
        {
            var kategori = db.tablokategoriler.Find(id);
            db.tablokategoriler.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriGetir(int id)
        {
            var ktg = db.tablokategoriler.Find(id);
            return View("KategoriGetir", ktg);
        }

        public ActionResult Guncelle(tablokategoriler p1)
        {
            var ktg = db.tablokategoriler.Find(p1.kategoriid);
            ktg.kategoriad = p1.kategoriad;
            db.SaveChanges();
            return RedirectToAction("Index");
        }





    }
}