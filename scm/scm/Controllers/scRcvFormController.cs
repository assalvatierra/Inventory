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
    public class scRcvFormController : Controller
    {
        private ScmDBContainer db = new ScmDBContainer();
        #region Hdr functions
        // GET: scRcvForm
        public ActionResult Index()
        {
            var scRcvHdrs = db.scRcvHdrs.Include(s => s.scSupplier);
            return View(scRcvHdrs.ToList());
        }
        // GET: scRcvHdrs/Create
        public ActionResult Create()
        {
            ViewBag.scSupplierId = new SelectList(db.scSuppliers, "Id", "Name");
            return View();
        }

        // POST: scRcvHdrs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,dtRcv,scSupplierId,Remarks")] scRcvHdr scRcvHdr)
        {
            if (ModelState.IsValid)
            {
                db.scRcvHdrs.Add(scRcvHdr);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.scSupplierId = new SelectList(db.scSuppliers, "Id", "Name", scRcvHdr.scSupplierId);
            return View(scRcvHdr);
        }

        // GET: scRcvHdrs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            scRcvHdr scRcvHdr = db.scRcvHdrs.Find(id);
            if (scRcvHdr == null)
            {
                return HttpNotFound();
            }
            ViewBag.scSupplierId = new SelectList(db.scSuppliers, "Id", "Name", scRcvHdr.scSupplierId);
            return View(scRcvHdr);
        }

        // POST: scRcvHdrs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,dtRcv,scSupplierId,Remarks")] scRcvHdr scRcvHdr)
        {
            if (ModelState.IsValid)
            {
                db.Entry(scRcvHdr).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.scSupplierId = new SelectList(db.scSuppliers, "Id", "Name", scRcvHdr.scSupplierId);
            return View(scRcvHdr);
        }

        // GET: scRcvHdrs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            scRcvHdr scRcvHdr = db.scRcvHdrs.Find(id);
            if (scRcvHdr == null)
            {
                return HttpNotFound();
            }
            return View(scRcvHdr);
        }

        // POST: scRcvHdrs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            scRcvHdr scRcvHdr = db.scRcvHdrs.Find(id);
            db.scRcvHdrs.Remove(scRcvHdr);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        #endregion
        #region Detail Function
        // GET: scRcvDtls
        public ActionResult Details(int? id)
        {
            if (id == null) id = (int)Session["RCVHDRID"];
            Session["RCVHDRID"] = id;

            var scRcvDtls = db.scRcvDtls.Include(s => s.scRcvHdr).Include(s => s.scItem).Include(s => s.scStoreBin).Include(s => s.scPoDtl).Where(d=>d.scRcvHdrId==id);
            return View(scRcvDtls.ToList());
        }

        // GET: scRcvDtls/Create
        public ActionResult CreateItem()
        {
            int hdrid = (int)Session["RCVHDRID"];

            ViewBag.scRcvHdrId = new SelectList(db.scRcvHdrs, "Id", "Remarks",hdrid);
            ViewBag.scItemId = new SelectList(db.scItems, "Id", "Name");
            ViewBag.scStoreBinId = new SelectList(db.scStoreBins, "Id", "Code");
            ViewBag.scPoDtlId = new SelectList(db.scPoDtls, "Id", "Id");
            return View();
        }

        // POST: scRcvDtls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateItem([Bind(Include = "Id,scRcvHdrId,scItemId,Qty,scStoreBinId,scPoDtlId")] scRcvDtl scRcvDtl)
        {
            if (ModelState.IsValid)
            {
                db.scRcvDtls.Add(scRcvDtl);
                db.SaveChanges();
                return RedirectToAction("Details");
            }

            ViewBag.scRcvHdrId = new SelectList(db.scRcvHdrs, "Id", "Remarks", scRcvDtl.scRcvHdrId);
            ViewBag.scItemId = new SelectList(db.scItems, "Id", "Name", scRcvDtl.scItemId);
            ViewBag.scStoreBinId = new SelectList(db.scStoreBins, "Id", "Code", scRcvDtl.scStoreBinId);
            ViewBag.scPoDtlId = new SelectList(db.scPoDtls, "Id", "Id", scRcvDtl.scPoDtlId);
            return View(scRcvDtl);
        }

        // GET: scRcvDtls/Edit/5
        public ActionResult EditItem(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            scRcvDtl scRcvDtl = db.scRcvDtls.Find(id);
            if (scRcvDtl == null)
            {
                return HttpNotFound();
            }
            ViewBag.scRcvHdrId = new SelectList(db.scRcvHdrs, "Id", "Remarks", scRcvDtl.scRcvHdrId);
            ViewBag.scItemId = new SelectList(db.scItems, "Id", "Name", scRcvDtl.scItemId);
            ViewBag.scStoreBinId = new SelectList(db.scStoreBins, "Id", "Code", scRcvDtl.scStoreBinId);
            ViewBag.scPoDtlId = new SelectList(db.scPoDtls, "Id", "Id", scRcvDtl.scPoDtlId);
            return View(scRcvDtl);
        }

        // POST: scRcvDtls/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditItem([Bind(Include = "Id,scRcvHdrId,scItemId,Qty,scStoreBinId,scPoDtlId")] scRcvDtl scRcvDtl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(scRcvDtl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details");
            }
            ViewBag.scRcvHdrId = new SelectList(db.scRcvHdrs, "Id", "Remarks", scRcvDtl.scRcvHdrId);
            ViewBag.scItemId = new SelectList(db.scItems, "Id", "Name", scRcvDtl.scItemId);
            ViewBag.scStoreBinId = new SelectList(db.scStoreBins, "Id", "Code", scRcvDtl.scStoreBinId);
            ViewBag.scPoDtlId = new SelectList(db.scPoDtls, "Id", "Id", scRcvDtl.scPoDtlId);
            return View(scRcvDtl);
        }

        // GET: scRcvDtls/Delete/5
        public ActionResult DeleteItem(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            scRcvDtl scRcvDtl = db.scRcvDtls.Find(id);
            if (scRcvDtl == null)
            {
                return HttpNotFound();
            }
            return View(scRcvDtl);
        }

        // POST: scRcvDtls/Delete/5
        [HttpPost, ActionName("DeleteItem")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteItemConfirmed(int id)
        {
            scRcvDtl scRcvDtl = db.scRcvDtls.Find(id);
            db.scRcvDtls.Remove(scRcvDtl);
            db.SaveChanges();
            return RedirectToAction("Details");
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