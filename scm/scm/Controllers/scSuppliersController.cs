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
    public class scSuppliersController : Controller
    {
        private ScmDBContainer db = new ScmDBContainer();

        // GET: scSuppliers
        public ActionResult Index()
        {
            return View(db.scSuppliers.ToList());
        }

        #region Supplier Items
        public ActionResult SupplierItem(int? SupplierId)
        {
            if (SupplierId == null)
            {
                if (Session["SupplierId"] == null)
                {
                    return RedirectToAction("index");
                }
                else
                {
                    SupplierId = (int)Session["SupplierId"];
                    if (SupplierId == 0) return RedirectToAction("index");
                }

            }

            Session["SupplierId"] = SupplierId;

            var scItemSuppliers = db.scItemSuppliers
                .Include(s => s.scItem)
                .Include(s => s.scSupplier)
                .Include(s => s.scUom)
                .Where(d=>d.scSupplierId==SupplierId);

            ViewBag.SupplierId = SupplierId;
            return View(scItemSuppliers);

        }
        public ActionResult AddSupplierItem(int SupplierId)
        {
            var newitem = new Models.scItemSupplier();
            newitem.scSupplierId = SupplierId;

            ViewBag.scItemId = new SelectList(db.scItems, "Id", "Name");
            ViewBag.scSupplierId = new SelectList(db.scSuppliers, "Id", "Name", SupplierId);
            ViewBag.scUomId = new SelectList(db.scUoms, "Id", "Unit");

            return View(newitem);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddSupplierItem([Bind(Include = "Id,scItemId,scSupplierId,Leadtime,UnitPrice,scUomId")] scItemSupplier scItemSupplier)
        {
            if (ModelState.IsValid)
            {
                db.scItemSuppliers.Add(scItemSupplier);
                db.SaveChanges();
                return RedirectToAction("SupplierItem");
            }

            ViewBag.scItemId = new SelectList(db.scItems, "Id", "Name", scItemSupplier.scItemId);
            ViewBag.scSupplierId = new SelectList(db.scSuppliers, "Id", "Name", scItemSupplier.scSupplierId);
            ViewBag.scUomId = new SelectList(db.scUoms, "Id", "Unit", scItemSupplier.scUomId);
            return View(scItemSupplier);
        }

        // GET: scItemSuppliers/Edit/5
        public ActionResult EditSupplierItem(int? id)
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
        public ActionResult EditSupplierItem([Bind(Include = "Id,scItemId,scSupplierId,Leadtime,UnitPrice,scUomId")] scItemSupplier scItemSupplier)
        {
            if (ModelState.IsValid)
            {
                db.Entry(scItemSupplier).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("SupplierItem");
            }
            ViewBag.scItemId = new SelectList(db.scItems, "Id", "Name", scItemSupplier.scItemId);
            ViewBag.scSupplierId = new SelectList(db.scSuppliers, "Id", "Name", scItemSupplier.scSupplierId);
            ViewBag.scUomId = new SelectList(db.scUoms, "Id", "Unit", scItemSupplier.scUomId);
            return View(scItemSupplier);
        }

        // GET: scItemSuppliers/Delete/5
        public ActionResult DeleteSupplierItem(int? id)
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
        [HttpPost, ActionName("DeleteSupplierItem")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteSupplierItemConfirmed(int id)
        {
            scItemSupplier scItemSupplier = db.scItemSuppliers.Find(id);
            db.scItemSuppliers.Remove(scItemSupplier);
            db.SaveChanges();
            return RedirectToAction("SupplierItem");
        }


        #endregion

        // GET: scSuppliers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            scSupplier scSupplier = db.scSuppliers.Find(id);
            if (scSupplier == null)
            {
                return HttpNotFound();
            }
            return View(scSupplier);
        }

        // GET: scSuppliers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: scSuppliers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Remarks")] scSupplier scSupplier)
        {
            if (ModelState.IsValid)
            {
                db.scSuppliers.Add(scSupplier);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(scSupplier);
        }

        // GET: scSuppliers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            scSupplier scSupplier = db.scSuppliers.Find(id);
            if (scSupplier == null)
            {
                return HttpNotFound();
            }
            return View(scSupplier);
        }

        // POST: scSuppliers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Remarks")] scSupplier scSupplier)
        {
            if (ModelState.IsValid)
            {
                db.Entry(scSupplier).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(scSupplier);
        }

        // GET: scSuppliers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            scSupplier scSupplier = db.scSuppliers.Find(id);
            if (scSupplier == null)
            {
                return HttpNotFound();
            }
            return View(scSupplier);
        }

        // POST: scSuppliers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            scSupplier scSupplier = db.scSuppliers.Find(id);
            db.scSuppliers.Remove(scSupplier);
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
