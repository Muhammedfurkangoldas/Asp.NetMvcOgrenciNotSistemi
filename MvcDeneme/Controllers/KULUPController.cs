using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcDeneme.Models.EntitiyFramework;
namespace MvcDeneme.Controllers
{
    public class KULUPController : Controller
    {
        // GET: KULUP
        MvcDenemeEntities db = new MvcDenemeEntities();
        public ActionResult Index()
        {
            var kulupler = db.TBLKULUPLER.ToList();
            return View(kulupler);
        }
        [HttpGet]
        public ActionResult KulupEkleme()
        {
            return View();
        }
        public ActionResult KulupEkleme(TBLKULUPLER klp)
        {
            db.TBLKULUPLER.Add(klp);
            db.SaveChanges();
            return RedirectToAction("Index","KULUP");
        }
        public ActionResult Sil(int id) 
        {
            var kulup = db.TBLKULUPLER.Find(id);
            db.TBLKULUPLER.Remove(kulup);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KulupGetir(int id) 
        {
            var kulupGetir = db.TBLKULUPLER.Find(id);

            return View("KulupGetir",kulupGetir);
        }
        public ActionResult Guncelle(TBLKULUPLER gnc) 
        {
            var guncelle = db.TBLKULUPLER.Find(gnc.KULUPID);
            guncelle.KULUPAD = gnc.KULUPAD;
            db.SaveChanges();
            return RedirectToAction("Index", "KULUP");

        }



    }
}