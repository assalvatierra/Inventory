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
    public class scInvOutDtlsController : Controller
    {
        private ScmDBContainer db = new ScmDBContainer();

        // GET: scInvOutDtls
        public ActionResult Index()
        {
            var scInvOutDtls = db.scInvOutDtls.Include(s => s.scInvOutHdr).Include(s => s.scItem).Include(s => s.scStoreBin).Include(s => s.resOrderDtl);
            return View(scInvOutDtls.ToList());
        }

        // GET: scInvOutDtls/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            scInvOutDtl scInvOutDtl = db.scInvOutDtls.Find(id);
            if (scInvOutDtl == null)
            {
                return HttpNotFound();
            }
            return View(scInvOutDtl);
        }

        // GET: scInvOutDtls/Create
        public ActionResult Create()
        {
            ViewBag.scInvOutHdrId = new SelectList(db.scInvOutHdrs, "Id", "Remarks");
            ViewBag.scItemId = new SelectList(db.scItems, "Id", "Name");
            ViewBag.scStoreBinId = new SelectList(db.scStoreBins, "Id", "Code");
            ViewBag.resOrderDtlId = new SelectList(db.resOrderDtls, "Id", "Id");
            return View();
        }

        // POST: scInvOutDtls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,scInvOutHdrId,scItemId,scStoreBinId,Qty,resOrderDtlId")] scInvOutDtl scInvOutDtl)
        {
            if (ModelState.IsValid)
            {
                db.scInvOutDtls.Add(scInvOutDtl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.scInvOutHdrId = new SelectList(db.scInvOutHdrs, "Id", "Remarks", scInvOutDtl.scInvOutHdrId);
            ViewBag.scItemId = new SelectList(db.scItems, "Id", "Name", scInvOutDtl.scItemId);
            ViewBag.scStoreBinId = new SelectList(db.scStoreBins, "Id", "Code", scInvOutDtl.scStoreBinId);
            ViewBag.resOrderDtlId = new SelectList(db.resOrderDtls, "Id", "Id", scInvOutDtl.resOrderDtlId);
            return View(scInvOutDtl);
        }

        // GET: scInvOutDtls/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            scInvOutDtl scInvOutDtl = db.scInvOutDtls.Find(id);
            if (scInvOutDtl == null)
            {
                return HttpNotFound();
            }
            ViewBag.scInvOutHdrId = new SelectList(db.scInvOutHdrs, "Id", "Remarks", scInvOutDtl.scInvOutHdrId);
            ViewBag.scItemId = new SelectList(db.scItems, "Id", "Name", scInvOutDtl.scItemId);
            ViewBag.scStoreBinId = new SelectList(db.scStoreBins, "Id", "Code", scInvOutDtl.scStoreBinId);
            ViewBag.resOrderDtlId = new SelectList(db.resOrderDtls, "Id", "Id", scInvOutDtl.resOrderDtlId);
            return View(scInvOutDtl);
        }

        // POST: scInvOutDtls/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,scInvOutHdrId,scItemId,scStoreBinId,Qty,resOrderDtlId")] scInvOutDtl scInvOutDtl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(scInvOutDtl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.scInvOutHdrId = new SelectList(db.scInvOutHdrs, "Id", "Remarks", scInvOutDtl.scInvOutHdrId);
            ViewBag.scItemId = new SelectList(db.scItems, "Id", "Name", scInvOutDtl.scItemId);
            ViewBag.scStoreBinId = new SelectList(db.scStoreBins, "Id", "Code", scInvOutDtl.scStoreBinId);
            ViewBag.resOrderDtlId = new SelectList(db.resOrderDtls, "Id", "Id", scInvOutDtl.resOrderDtlId);
            return View(scInvOutDtl);
        }

        // GET: scInvOutDtls/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            scInvOutDtl scInvOutDtl = db.scInvOutDtls.Find(id);
            if (scInvOutDtl == null)
            {
                return HttpNotFound();
            }
            return View(scInvOutDtl);
        }

        // POST: scInvOutDtls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            scInvOutDtl scInvOutDtl = db.scInvOutDtls.Find(id);
            db.scInvOutDtls.Remove(scInvOutDtl);
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
