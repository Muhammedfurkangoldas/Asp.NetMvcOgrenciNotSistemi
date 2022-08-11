using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcDeneme.Models.EntitiyFramework;

namespace MvcDeneme.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        MvcDenemeEntities db = new MvcDenemeEntities();
        public ActionResult Index()
        {
            var dersler = db.TBLDERSLER.ToList();
            return View(dersler);
        }
        [HttpGet]
        public ActionResult YeniDersKaydı()
        {
            return View();

        }
        [HttpPost]
        public ActionResult YeniDersKaydı(TBLDERSLER drs)
        {
            db.TBLDERSLER.Add(drs);
            db.SaveChanges();
            return RedirectToAction("Index","Default");
        }

        public ActionResult Sil(int id)
        {
            var dersler = db.TBLDERSLER.Find(id);
            db.TBLDERSLER.Remove(dersler);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DersGetir(int id) 
        {
            var dersGetir = db.TBLDERSLER.Find(id);

            return View("DersGetir",dersGetir);
        }
        public ActionResult DersGuncelle(TBLDERSLER dgnc)
        {
            var dguncelle = db.TBLDERSLER.Find(dgnc.DERSID);
            dguncelle.DERSAD = dgnc.DERSAD;
            db.SaveChanges();
            return RedirectToAction("Index", "Default");
        }
    }
}