using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcDeneme.Models.EntitiyFramework;
using MvcDeneme.Models;
namespace MvcDeneme.Controllers
{
    public class SınavNotController : Controller
    {
        // GET: SınavNot
        MvcDenemeEntities db = new MvcDenemeEntities();
        public ActionResult Index()
        {
            var notlar = db.TBLNOTLAR.ToList();
            return View(notlar);
        }
        [HttpGet]
        public ActionResult YeniSinav() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniSinav(TBLNOTLAR tbn)
        {
            db.TBLNOTLAR.Add(tbn);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SınavNotGetir(int id) 
        {
            var snvnot = db.TBLNOTLAR.Find(id);
            return View("SınavNotGetir", snvnot);
        }
        [HttpPost]
        public ActionResult SınavNotGetir(Class1 model, TBLNOTLAR ntlr, int SINAV1 = 0, int SINAV2 = 0, int SINAV3 = 0, int PROJE = 0)
        {
            if (model.islem == "HESAPLA")
            {
                //islem1
                int ortalama = (SINAV1 + SINAV2 + SINAV3 + PROJE) / 4;
                ViewBag.ort = ortalama;
            }
            if (model.islem== "NOTGUNCELLE")
            {
                var snvnt = db.TBLNOTLAR.Find(ntlr.NOTID);
                snvnt.SINAV1 = ntlr.SINAV1;
                snvnt.SINAV2 = ntlr.SINAV2;
                snvnt.SINAV3 = ntlr.SINAV3;
                snvnt.PROJE = ntlr.PROJE;
                snvnt.ORTALAMA = ntlr.ORTALAMA;
                db.SaveChanges();
                return RedirectToAction("Index", "SınavNot");
            }
            return View();
        }
    }
}