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
    public class scPrDtlsController : Controller
    {
        private ScmDBContainer db = new ScmDBContainer();

        // GET: scPrDtls
        public ActionResult Index()
        {
            var scPrDtls = db.scPrDtls.Include(s => s.scPrHdr).Include(s => s.scItem).Include(s => s.scUom);
            return View(scPrDtls.ToList());
        }

        public ActionResult Index(int? hdrId)
        {
            var scPrDtls = db.scPrDtls.Include(s => s.scPrHdr).Include(s => s.scItem).Include(s => s.scUom).Where(d=>d.scPrHdrId==hdrId);
            return View(scPrDtls.ToList());
        }

        // GET: scPrDtls/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            scPrDtl scPrDtl = db.scPrDtls.Find(id);
            if (scPrDtl == null)
            {
                return HttpNotFound();
            }
            return View(scPrDtl);
        }

        // GET: scPrDtls/Create
        public ActionResult Create()
        {
            ViewBag.scPrHdrId = new SelectList(db.scPrHdrs, "Id", "Remarks");
            ViewBag.scItemId = new SelectList(db.scItems, "Id", "Name");
            ViewBag.scUomId = new SelectList(db.scUoms, "Id", "Unit");
            return View();
        }

        // POST: scPrDtls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,scPrHdrId,scItemId,Qty,scUomId")] scPrDtl scPrDtl)
        {
            if (ModelState.IsValid)
            {
                db.scPrDtls.Add(scPrDtl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.scPrHdrId = new SelectList(db.scPrHdrs, "Id", "Remarks", scPrDtl.scPrHdrId);
            ViewBag.scItemId = new SelectList(db.scItems, "Id", "Name", scPrDtl.scItemId);
            ViewBag.scUomId = new SelectList(db.scUoms, "Id", "Unit", scPrDtl.scUomId);
            return View(scPrDtl);
        }

        // GET: scPrDtls/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            scPrDtl scPrDtl = db.scPrDtls.Find(id);
            if (scPrDtl == null)
            {
                return HttpNotFound();
            }
            ViewBag.scPrHdrId = new SelectList(db.scPrHdrs, "Id", "Remarks", scPrDtl.scPrHdrId);
            ViewBag.scItemId = new SelectList(db.scItems, "Id", "Name", scPrDtl.scItemId);
            ViewBag.scUomId = new SelectList(db.scUoms, "Id", "Unit", scPrDtl.scUomId);
            return View(scPrDtl);
        }

        // POST: scPrDtls/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,scPrHdrId,scItemId,Qty,scUomId")] scPrDtl scPrDtl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(scPrDtl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.scPrHdrId = new SelectList(db.scPrHdrs, "Id", "Remarks", scPrDtl.scPrHdrId);
            ViewBag.scItemId = new SelectList(db.scItems, "Id", "Name", scPrDtl.scItemId);
            ViewBag.scUomId = new SelectList(db.scUoms, "Id", "Unit", scPrDtl.scUomId);
            return View(scPrDtl);
        }

        // GET: scPrDtls/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            scPrDtl scPrDtl = db.scPrDtls.Find(id);
            if (scPrDtl == null)
            {
                return HttpNotFound();
            }
            return View(scPrDtl);
        }

        // POST: scPrDtls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            scPrDtl scPrDtl = db.scPrDtls.Find(id);
            db.scPrDtls.Remove(scPrDtl);
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
