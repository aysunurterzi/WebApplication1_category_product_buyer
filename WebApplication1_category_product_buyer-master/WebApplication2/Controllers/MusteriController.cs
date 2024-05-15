using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models.Entity;

namespace WebApplication2.Controllers
{
    public class MusteriController : Controller
    {
        MvcDbStokEntities db = new MvcDbStokEntities();
        // GET: Musteri
        public ActionResult Index(string p)
        {
            var degerler = from d in db.tablomüsteriler select d;
            if (!string.IsNullOrEmpty(p))
            {
                degerler = degerler.Where(m => m.müsteriad.Contains(p));
            }
            return View(degerler.ToList());
        //     var degerler = db.tablomüsteriler.ToList();
        //    return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniMusteri()
        {

            return View();
        }

        [HttpPost]
        public ActionResult YeniMusteri(tablomüsteriler p1)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniMusteri");
            }
            db.tablomüsteriler.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult sil(int id)
        {
            var musteri = db.tablomüsteriler.Find(id);
            db.tablomüsteriler.Remove(musteri);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MusteriGetir(int id)
        {
            var mus = db.tablomüsteriler.Find(id);
            return View("MusteriGetir", mus);
        }

        public ActionResult Guncelle(tablomüsteriler p1)
        {
            var musteri = db.tablomüsteriler.Find(p1.müsteriid);
            musteri.müsteriad = p1.müsteriad;
            musteri.müsterisoyad = p1.müsterisoyad;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}