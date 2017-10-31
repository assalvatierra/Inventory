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
    public class scRcvDtlsController : Controller
    {
        private ScmDBContainer db = new ScmDBContainer();

        // GET: scRcvDtls
        public ActionResult Index()
        {
            var scRcvDtls = db.scRcvDtls.Include(s => s.scRcvHdr).Include(s => s.scItem).Include(s => s.scStoreBin).Include(s => s.scPoDtl);
            return View(scRcvDtls.ToList());
        }

        // GET: scRcvDtls/Details/5
        public ActionResult Details(int? id)
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

        // GET: scRcvDtls/Create
        public ActionResult Create()
        {
            ViewBag.scRcvHdrId = new SelectList(db.scRcvHdrs, "Id", "Remarks");
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
        public ActionResult Create([Bind(Include = "Id,scRcvHdrId,scItemId,Qty,scStoreBinId,scPoDtlId")] scRcvDtl scRcvDtl)
        {
            if (ModelState.IsValid)
            {
                db.scRcvDtls.Add(scRcvDtl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.scRcvHdrId = new SelectList(db.scRcvHdrs, "Id", "Remarks", scRcvDtl.scRcvHdrId);
            ViewBag.scItemId = new SelectList(db.scItems, "Id", "Name", scRcvDtl.scItemId);
            ViewBag.scStoreBinId = new SelectList(db.scStoreBins, "Id", "Code", scRcvDtl.scStoreBinId);
            ViewBag.scPoDtlId = new SelectList(db.scPoDtls, "Id", "Id", scRcvDtl.scPoDtlId);
            return View(scRcvDtl);
        }

        // GET: scRcvDtls/Edit/5
        public ActionResult Edit(int? id)
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
        public ActionResult Edit([Bind(Include = "Id,scRcvHdrId,scItemId,Qty,scStoreBinId,scPoDtlId")] scRcvDtl scRcvDtl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(scRcvDtl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.scRcvHdrId = new SelectList(db.scRcvHdrs, "Id", "Remarks", scRcvDtl.scRcvHdrId);
            ViewBag.scItemId = new SelectList(db.scItems, "Id", "Name", scRcvDtl.scItemId);
            ViewBag.scStoreBinId = new SelectList(db.scStoreBins, "Id", "Code", scRcvDtl.scStoreBinId);
            ViewBag.scPoDtlId = new SelectList(db.scPoDtls, "Id", "Id", scRcvDtl.scPoDtlId);
            return View(scRcvDtl);
        }

        // GET: scRcvDtls/Delete/5
        public ActionResult Delete(int? id)
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
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            scRcvDtl scRcvDtl = db.scRcvDtls.Find(id);
            db.scRcvDtls.Remove(scRcvDtl);
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
