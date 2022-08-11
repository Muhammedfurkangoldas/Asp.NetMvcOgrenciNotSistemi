using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcDeneme.Controllers
{
    public class HesapTestController : Controller
    {
        // GET: HesapTest
        public ActionResult Index(int sayi1 = 0, int sayi2 = 0, int sayi3 = 0)
        {
            double sonuc = (sayi1 + sayi2) / 2;
            ViewBag.snc = sonuc;
            return View();
        }
    }
}