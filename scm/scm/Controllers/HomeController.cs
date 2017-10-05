using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace scm.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult MasterFiles()
        {
            return View();
        }

        public ActionResult Supplier()
        {
            return RedirectToAction("Index", "scSuppliers");
        }
        public ActionResult PurchaseOrder()
        {
            return RedirectToAction("Index", "scPoHdrs");
        }
        public ActionResult StorageBin()
        {
            return RedirectToAction("Index", "scStoreBins");
        }
        public ActionResult StockCount()
        {
            return RedirectToAction("Index", "scItems");
        }
    }
}