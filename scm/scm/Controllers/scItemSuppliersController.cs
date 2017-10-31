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
    public class scItemSuppliersController : Controller
    {
        private ScmDBContainer db = new ScmDBContainer();

        // GET: scItemSuppliers
        public ActionResult Index()
        {
            var scItemSuppliers = db.scItemSuppliers.Include(s => s.scItem).Include(s => s.scSupplier).Include(s => s.scUom);
            return View(scItemSuppliers.ToList());
        }

        // GET: scItemSuppliers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            scItemSupplier scItemSupplier = db.scItemSuppliers.Find(id);
            if (scItemSupplier == null)
            {
                return HttpNotFound();
            }
            return View(scItemSupplier);
        }

        // GET: scItemSuppliers/Create
        public ActionResult Create()
        {
            ViewBag.scItemId = new SelectList(db.scItems, "Id", "Name");
            ViewBag.scSupplierId = new SelectList(db.scSuppliers, "Id", "Name");
            ViewBag.scUomId = new SelectList(db.scUoms, "Id", "Unit");
            return View();
        }

        // POST: scItemSuppliers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,scItemId,scSupplierId,Leadtime,UnitPrice,scUomId")] scItemSupplier scItemSupplier)
        {
            if (ModelState.IsValid)
            {
                db.scItemSuppliers.Add(scItemSupplier);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.scItemId = new SelectList(db.scItems, "Id", "Name", scItemSupplier.scItemId);
            ViewBag.scSupplierId = new SelectList(db.scSuppliers, "Id", "Name", scItemSupplier.scSupplierId);
            ViewBag.scUomId = new SelectList(db.scUoms, "Id", "Unit", scItemSupplier.scUomId);
            return View(scItemSupplier);
        }

        // GET: scItemSuppliers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            scItemSupplier scItemSupplier = db.scItemSuppliers.Find(id);
            if (scItemSupplier == null)
            {
                return HttpNotFound();
            }
            ViewBag.scItemId = new SelectList(db.scItems, "Id", "Name", scItemSupplier.scItemId);
            ViewBag.scSupplierId = new SelectList(db.scSuppliers, "Id", "Name", scItemSupplier.scSupplierId);
            ViewBag.scUomId = new SelectList(db.scUoms, "Id", "Unit", scItemSupplier.scUomId);
            return View(scItemSupplier);
        }

        // POST: scItemSuppliers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,scItemId,scSupplierId,Leadtime,UnitPrice,scUomId")] scItemSupplier scItemSupplier)
        {
            if (ModelState.IsValid)
            {
                db.Entry(scItemSupplier).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.scItemId = new SelectList(db.scItems, "Id", "Name", scItemSupplier.scItemId);
            ViewBag.scSupplierId = new SelectList(db.scSuppliers, "Id", "Name", scItemSupplier.scSupplierId);
            ViewBag.scUomId = new SelectList(db.scUoms, "Id", "Unit", scItemSupplier.scUomId);
            return View(scItemSupplier);
        }

        // GET: scItemSuppliers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            scItemSupplier scItemSupplier = db.scItemSuppliers.Find(id);
            if (scItemSupplier == null)
            {
                return HttpNotFound();
            }
            return View(scItemSupplier);
        }

        // POST: scItemSuppliers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            scItemSupplier scItemSupplier = db.scItemSuppliers.Find(id);
            db.scItemSuppliers.Remove(scItemSupplier);
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
