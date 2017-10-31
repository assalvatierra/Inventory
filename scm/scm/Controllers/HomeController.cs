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
        public ActionResult SupplierByItem()
        {
            return RedirectToAction("SupplierByItem", "scSuppliers");
        }
        public ActionResult PurchaseRequest()
        {
            return RedirectToAction("Index", "scPrForm");
        }
        public ActionResult PurchaseOrder()
        {
            return RedirectToAction("Index", "scPoForm");
        }
        public ActionResult InventoryReceive()
        {
            return RedirectToAction("Index", "scRcvForm");
        }
        public ActionResult InventoryOut()
        {
            return RedirectToAction("Index", "scInvOutForm");
        }
        public ActionResult InventoryRepack()
        {
            return RedirectToAction("index", "resPreparationForm");
        }
        public ActionResult StorageBin()
        {
            return RedirectToAction("StoreBin", "scStoreBins");
        }
        public ActionResult StockCount()
        {
            return RedirectToAction("ItemInventory", "scItems");
        }

        public ActionResult CustomerList()
        {
            return RedirectToAction("Index", "resCustomers");
        }
        public ActionResult SalesOrder()
        {
            return RedirectToAction("Index", "resCustomers");
        }

    }
}