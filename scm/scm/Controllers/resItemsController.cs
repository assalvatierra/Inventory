using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using scm.Models;

namespace scm.Controllers
{
    public class resItemsController : Controller
    {
        private ScmDBContainer db = new ScmDBContainer();


        public ActionResult EditItem(int? id)
        {
            Models.scItem item = db.scItems.Find(id);
            Models.resItem data = db.resItems.Where(d => d.scItemId == id).FirstOrDefault();

            if(data==null)
            {
                data = new resItem();
                data.scItemId = (int) id;
                data.Description = item.Name;
                data.resQty = 1;

                db.resItems.Add(data);
                db.SaveChanges();
            }

            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditItem([Bind(Include = "Id,scItemId,Description,Price,barcode,resQty")] resItem resItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(resItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(resItem);
        }



    }
}
