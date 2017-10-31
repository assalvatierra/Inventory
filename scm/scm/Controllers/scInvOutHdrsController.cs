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
    public class scInvOutHdrsController : Controller
    {
        private ScmDBContainer db = new ScmDBContainer();

        // GET: scInvOutHdrs
        public ActionResult Index()
        {
            return View(db.scInvOutHdrs.ToList());
        }

        // GET: scInvOutHdrs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            scInvOutHdr scInvOutHdr = db.scInvOutHdrs.Find(id);
            if (scInvOutHdr == null)
            {
                return HttpNotFound();
            }
            return View(scInvOutHdr);
        }

        // GET: scInvOutHdrs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: scInvOutHdrs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,dtOut,Remarks")] scInvOutHdr scInvOutHdr)
        {
            if (ModelState.IsValid)
            {
                db.scInvOutHdrs.Add(scInvOutHdr);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(scInvOutHdr);
        }

        // GET: scInvOutHdrs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            scInvOutHdr scInvOutHdr = db.scInvOutHdrs.Find(id);
            if (scInvOutHdr == null)
            {
                return HttpNotFound();
            }
            return View(scInvOutHdr);
        }

        // POST: scInvOutHdrs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,dtOut,Remarks")] scInvOutHdr scInvOutHdr)
        {
            if (ModelState.IsValid)
            {
                db.Entry(scInvOutHdr).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(scInvOutHdr);
        }

        // GET: scInvOutHdrs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            scInvOutHdr scInvOutHdr = db.scInvOutHdrs.Find(id);
            if (scInvOutHdr == null)
            {
                return HttpNotFound();
            }
            return View(scInvOutHdr);
        }

        // POST: scInvOutHdrs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            scInvOutHdr scInvOutHdr = db.scInvOutHdrs.Find(id);
            db.scInvOutHdrs.Remove(scInvOutHdr);
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
