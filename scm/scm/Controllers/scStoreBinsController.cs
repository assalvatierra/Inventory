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
    public class scStoreBinsController : Controller
    {
        private ScmDBContainer db = new ScmDBContainer();

        // GET: scStoreBins
        public ActionResult Index()
        {
            var scStoreBins = db.scStoreBins.Include(s => s.scStorage).Include(s => s.scItem);
            return View(scStoreBins.ToList());
        }

        public ActionResult StoreBin(int? id)
        {
            if (id == null) id = 0;
            dbClasses db1 = new dbClasses();
            var data = db1.getStorageBinInventory( id );
            return View(data);
        }

        // GET: scStoreBins/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            scStoreBin scStoreBin = db.scStoreBins.Find(id);
            if (scStoreBin == null)
            {
                return HttpNotFound();
            }
            return View(scStoreBin);
        }

        // GET: scStoreBins/Create
        public ActionResult Create()
        {
            ViewBag.scStorageId = new SelectList(db.scStorages, "Id", "Name");
            ViewBag.scItemId = new SelectList(db.scItems, "Id", "Name");
            return View();
        }

        // POST: scStoreBins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,scStorageId,Code,PostedQty,PostedDate,ExpiryDate,scItemId,BinStatus")] scStoreBin scStoreBin)
        {
            if (ModelState.IsValid)
            {
                db.scStoreBins.Add(scStoreBin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.scStorageId = new SelectList(db.scStorages, "Id", "Name", scStoreBin.scStorageId);
            ViewBag.scItemId = new SelectList(db.scItems, "Id", "Name", scStoreBin.scItemId);
            return View(scStoreBin);
        }

        // GET: scStoreBins/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            scStoreBin scStoreBin = db.scStoreBins.Find(id);
            if (scStoreBin == null)
            {
                return HttpNotFound();
            }
            ViewBag.scStorageId = new SelectList(db.scStorages, "Id", "Name", scStoreBin.scStorageId);
            ViewBag.scItemId = new SelectList(db.scItems, "Id", "Name", scStoreBin.scItemId);
            return View(scStoreBin);
        }

        // POST: scStoreBins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,scStorageId,Code,PostedQty,PostedDate,ExpiryDate,scItemId,BinStatus")] scStoreBin scStoreBin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(scStoreBin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.scStorageId = new SelectList(db.scStorages, "Id", "Name", scStoreBin.scStorageId);
            ViewBag.scItemId = new SelectList(db.scItems, "Id", "Name", scStoreBin.scItemId);
            return View(scStoreBin);
        }

        // GET: scStoreBins/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            scStoreBin scStoreBin = db.scStoreBins.Find(id);
            if (scStoreBin == null)
            {
                return HttpNotFound();
            }
            return View(scStoreBin);
        }

        // POST: scStoreBins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            scStoreBin scStoreBin = db.scStoreBins.Find(id);
            db.scStoreBins.Remove(scStoreBin);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

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
