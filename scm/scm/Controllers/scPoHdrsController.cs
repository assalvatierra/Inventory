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
    public class scPoHdrsController : Controller
    {
        private ScmDBContainer db = new ScmDBContainer();

        // GET: scPoHdrs
        public ActionResult Index()
        {
            var scPoHdrs = db.scPoHdrs.Include(s => s.scSupplier);
            return View(scPoHdrs.ToList());
        }

        // GET: scPoHdrs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            scPoHdr scPoHdr = db.scPoHdrs.Find(id);
            if (scPoHdr == null)
            {
                return HttpNotFound();
            }
            return View(scPoHdr);
        }

        // GET: scPoHdrs/Create
        public ActionResult Create()
        {
            ViewBag.scSupplierId = new SelectList(db.scSuppliers, "Id", "Name");
            return View();
        }

        // POST: scPoHdrs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,dtPo,scSupplierId")] scPoHdr scPoHdr)
        {
            if (ModelState.IsValid)
            {
                db.scPoHdrs.Add(scPoHdr);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.scSupplierId = new SelectList(db.scSuppliers, "Id", "Name", scPoHdr.scSupplierId);
            return View(scPoHdr);
        }

        // GET: scPoHdrs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            scPoHdr scPoHdr = db.scPoHdrs.Find(id);
            if (scPoHdr == null)
            {
                return HttpNotFound();
            }
            ViewBag.scSupplierId = new SelectList(db.scSuppliers, "Id", "Name", scPoHdr.scSupplierId);
            return View(scPoHdr);
        }

        // POST: scPoHdrs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,dtPo,scSupplierId")] scPoHdr scPoHdr)
        {
            if (ModelState.IsValid)
            {
                db.Entry(scPoHdr).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.scSupplierId = new SelectList(db.scSuppliers, "Id", "Name", scPoHdr.scSupplierId);
            return View(scPoHdr);
        }

        // GET: scPoHdrs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            scPoHdr scPoHdr = db.scPoHdrs.Find(id);
            if (scPoHdr == null)
            {
                return HttpNotFound();
            }
            return View(scPoHdr);
        }

        // POST: scPoHdrs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            scPoHdr scPoHdr = db.scPoHdrs.Find(id);
            db.scPoHdrs.Remove(scPoHdr);
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
