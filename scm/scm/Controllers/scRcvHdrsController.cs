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
    public class scRcvHdrsController : Controller
    {
        private ScmDBContainer db = new ScmDBContainer();

        // GET: scRcvHdrs
        public ActionResult Index()
        {
            var scRcvHdrs = db.scRcvHdrs.Include(s => s.scSupplier);
            return View(scRcvHdrs.ToList());
        }

        // GET: scRcvHdrs/Details/5
        public ActionResult Details(int? id)
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
