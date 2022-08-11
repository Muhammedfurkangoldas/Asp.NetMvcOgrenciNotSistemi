using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcDeneme.Models.EntitiyFramework;
namespace MvcDeneme.Controllers
{
    public class OgrencıController : Controller
    {
        // GET: Ogrencı
        MvcDenemeEntities db = new MvcDenemeEntities();
        private TBLOGRENCILER ogr;

        public ActionResult Index()
        {
            var ogr = db.TBLOGRENCILER.ToList();
            return View(ogr);
        }
        [HttpGet]
        public ActionResult YeniOgrenci()
        {
            List<SelectListItem> degerler = (from i in db.TBLKULUPLER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KULUPAD,
                                                 Value = i.KULUPID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }
        [HttpPost]
        public ActionResult YeniOgrenci(TBLOGRENCILER ogrlr) 
        {
            var klp = db.TBLKULUPLER.Where(m => m.KULUPID == ogrlr.TBLKULUPLER.KULUPID).FirstOrDefault();
            ogrlr.TBLKULUPLER = klp;
            db.TBLOGRENCILER.Add(ogrlr);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult Sil(int id) 
        {
            var o = db.TBLOGRENCILER.Find(id);
            db.TBLOGRENCILER.Remove(o);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult OgrenciGetir(int id)
        {
            var ogrenci = db.TBLOGRENCILER.Find(id);

            List<SelectListItem> degerler = (from i in db.TBLKULUPLER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KULUPAD,
                                                 Value = i.KULUPID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;

            return View("OgrenciGetir", ogrenci);
        }
        public ActionResult Guncelle(TBLOGRENCILER ogrler)
        {
            var ogrenciler = db.TBLOGRENCILER.Find(ogrler.OGRENCIID);
            ogrenciler.OGRAD = ogrler.OGRAD;
            ogrenciler.OGRSOYAD = ogrler.OGRSOYAD;
            ogrenciler.OGRFOTO = ogrler.OGRFOTO;
            ogrenciler.OGRCINSIYET = ogrler.OGRCINSIYET;
            ogrenciler.OGRKULUP = ogrler.OGRKULUP;
            db.SaveChanges();
            return RedirectToAction("Index", "Ogrencı");
        }
    }
}