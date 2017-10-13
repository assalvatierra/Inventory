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
    public class scPoDtlsController : Controller
    {
        private ScmDBContainer db = new ScmDBContainer();

        // GET: scPoDtls
        public ActionResult Index()
        {
            var scPoDtls = db.scPoDtls.Include(s => s.scPoHdr).Include(s => s.scItem).Include(s => s.scUom).Include(s => s.scPrDtl);
            return View(scPoDtls.ToList());
        }

        // GET: scPoDtls/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            scPoDtl scPoDtl = db.scPoDtls.Find(id);
            if (scPoDtl == null)
            {
                return HttpNotFound();
            }
            return View(scPoDtl);
        }

        // GET: scPoDtls/Create
        public ActionResult Create()
        {
            ViewBag.scPoHdrId = new SelectList(db.scPoHdrs, "Id", "Remarks");
            ViewBag.scItemId = new SelectList(db.scItems, "Id", "Name");
            ViewBag.scUomId = new SelectList(db.scUoms, "Id", "Unit");
            ViewBag.scPrDtlId = new SelectList(db.scPrDtls, "Id", "Id");
            return View();
        }

        // POST: scPoDtls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,scPoHdrId,scItemId,Qty,UnitPrice,scUomId,scPrDtlId")] scPoDtl scPoDtl)
        {
            if (ModelState.IsValid)
            {
                db.scPoDtls.Add(scPoDtl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.scPoHdrId = new SelectList(db.scPoHdrs, "Id", "Remarks", scPoDtl.scPoHdrId);
            ViewBag.scItemId = new SelectList(db.scItems, "Id", "Name", scPoDtl.scItemId);
            ViewBag.scUomId = new SelectList(db.scUoms, "Id", "Unit", scPoDtl.scUomId);
            ViewBag.scPrDtlId = new SelectList(db.scPrDtls, "Id", "Id", scPoDtl.scPrDtlId);
            return View(scPoDtl);
        }

        // GET: scPoDtls/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            scPoDtl scPoDtl = db.scPoDtls.Find(id);
            if (scPoDtl == null)
            {
                return HttpNotFound();
            }
            ViewBag.scPoHdrId = new SelectList(db.scPoHdrs, "Id", "Remarks", scPoDtl.scPoHdrId);
            ViewBag.scItemId = new SelectList(db.scItems, "Id", "Name", scPoDtl.scItemId);
            ViewBag.scUomId = new SelectList(db.scUoms, "Id", "Unit", scPoDtl.scUomId);
            ViewBag.scPrDtlId = new SelectList(db.scPrDtls, "Id", "Id", scPoDtl.scPrDtlId);
            return View(scPoDtl);
        }

        // POST: scPoDtls/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,scPoHdrId,scItemId,Qty,UnitPrice,scUomId,scPrDtlId")] scPoDtl scPoDtl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(scPoDtl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.scPoHdrId = new SelectList(db.scPoHdrs, "Id", "Remarks", scPoDtl.scPoHdrId);
            ViewBag.scItemId = new SelectList(db.scItems, "Id", "Name", scPoDtl.scItemId);
            ViewBag.scUomId = new SelectList(db.scUoms, "Id", "Unit", scPoDtl.scUomId);
            ViewBag.scPrDtlId = new SelectList(db.scPrDtls, "Id", "Id", scPoDtl.scPrDtlId);
            return View(scPoDtl);
        }

        // GET: scPoDtls/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            scPoDtl scPoDtl = db.scPoDtls.Find(id);
            if (scPoDtl == null)
            {
                return HttpNotFound();
            }
            return View(scPoDtl);
        }

        // POST: scPoDtls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            scPoDtl scPoDtl = db.scPoDtls.Find(id);
            db.scPoDtls.Remove(scPoDtl);
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
