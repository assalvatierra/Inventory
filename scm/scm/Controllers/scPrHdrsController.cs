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
    public class scPrHdrsController : Controller
    {
        private ScmDBContainer db = new ScmDBContainer();

        // GET: scPrHdrs
        public ActionResult Index()
        {
            return View(db.scPrHdrs.ToList());
        }

        // GET: scPrHdrs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            scPrHdr scPrHdr = db.scPrHdrs.Find(id);
            if (scPrHdr == null)
            {
                return HttpNotFound();
            }
            return View(scPrHdr);
        }

        // GET: scPrHdrs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: scPrHdrs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,dtPr,Remarks,Status")] scPrHdr scPrHdr)
        {
            if (ModelState.IsValid)
            {
                db.scPrHdrs.Add(scPrHdr);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(scPrHdr);
        }

        // GET: scPrHdrs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            scPrHdr scPrHdr = db.scPrHdrs.Find(id);
            if (scPrHdr == null)
            {
                return HttpNotFound();
            }
            return View(scPrHdr);
        }

        // POST: scPrHdrs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,dtPr,Remarks,Status")] scPrHdr scPrHdr)
        {
            if (ModelState.IsValid)
            {
                db.Entry(scPrHdr).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(scPrHdr);
        }

        // GET: scPrHdrs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            scPrHdr scPrHdr = db.scPrHdrs.Find(id);
            if (scPrHdr == null)
            {
                return HttpNotFound();
            }
            return View(scPrHdr);
        }

        // POST: scPrHdrs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            scPrHdr scPrHdr = db.scPrHdrs.Find(id);
            db.scPrHdrs.Remove(scPrHdr);
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
