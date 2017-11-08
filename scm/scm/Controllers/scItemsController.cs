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
    public class scItemsController : Controller
    {
        private ScmDBContainer db = new ScmDBContainer();

        // GET: scItems
        public ActionResult Index()
        {
            //return View(db.scItems.ToList());
            return RedirectToAction("ItemInventory");
        }

        public ActionResult ItemInventory()
        {
            dbClasses db1 = new dbClasses();
            var scItems = db1.getItemInventory();
            return View(scItems);
        }

        public ActionResult ItemOrderStatus()
        {
            dbClasses db1 = new dbClasses();
            var scItems = db1.getOrderStatus();
            return View(scItems);
        }

        // GET: scItems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            scItem scItem = db.scItems.Find(id);
            if (scItem == null)
            {
                return HttpNotFound();
            }
            return View(scItem);
        }

        // GET: scItems/Create
        public ActionResult Create()
        {
            ViewBag.scUomId = new SelectList(db.scUoms, "Id", "Unit");
            return View();
        }

        // POST: scItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,scUomId,Expirydays, LowLevel")] scItem scItem)
        {
            if (ModelState.IsValid)
            {
                db.scItems.Add(scItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.scUomId = new SelectList(db.scUoms, "Id", "Unit", scItem.scUomId);
            return View(scItem);
        }

        // GET: scItems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            scItem scItem = db.scItems.Find(id);
            if (scItem == null)
            {
                return HttpNotFound();
            }
            ViewBag.scUomId = new SelectList(db.scUoms, "Id", "Unit", scItem.scUomId);
            return View(scItem);
        }

        // POST: scItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,scUomId,Expirydays,LowLevel")] scItem scItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(scItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.scUomId = new SelectList(db.scUoms, "Id", "Unit", scItem.scUomId);
            return View(scItem);
        }

        // GET: scItems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            scItem scItem = db.scItems.Find(id);
            if (scItem == null)
            {
                return HttpNotFound();
            }
            return View(scItem);
        }

        // POST: scItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            scItem scItem = db.scItems.Find(id);
            db.scItems.Remove(scItem);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        #region retail item
        public ActionResult RetailItem(int? id)
        {
            Models.scItem item = db.scItems.Find(id);
            Models.resItem data = db.resItems.Where(d => d.scItemId == id).FirstOrDefault();
            if (data == null)
                return RedirectToAction("CreateRetailItem", new { id = (int)id } );
            else
                return RedirectToAction("EditRetailItem", new { id = data.Id });
        }

        public ActionResult CreateRetailItem(int? id)
        {
            Models.scItem item = db.scItems.Find(id);

            var data = new resItem();
            data.scItemId = (int)id;
            data.Description = item.Name;
            data.resQty = 1;
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateRetailItem([Bind(Include = "Id,scItemId,Description,Price,barcode,resQty")] resItem resItem)
        {
            if (ModelState.IsValid)
            {
                db.resItems.Add(resItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(resItem);
        }

        // GET: resItems/Edit/5
        public ActionResult EditRetailItem(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            resItem resItem = db.resItems.Find(id);
            if (resItem == null)
            {
                return HttpNotFound();
            }
//            ViewBag.scItemId = new SelectList(db.scItems, "Id", "Name", resItem.scItemId);
            return View(resItem);
        }

        // POST: resItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditRetailItem([Bind(Include = "Id,scItemId,Description,Price,barcode,resQty")] resItem resItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(resItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.scItemId = new SelectList(db.scItems, "Id", "Name", resItem.scItemId);
            return View(resItem);
        }


        #endregion

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
