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
    public class resOrderHdrsController : Controller
    {
        private ScmDBContainer db = new ScmDBContainer();

        // GET: resOrderHdrs
        public ActionResult Index()
        {
            var resOrderHdrs = db.resOrderHdrs.Include(r => r.resCustomer);
            return View(resOrderHdrs.ToList());
        }

        // GET: resOrderHdrs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            resOrderHdr resOrderHdr = db.resOrderHdrs.Find(id);
            if (resOrderHdr == null)
            {
                return HttpNotFound();
            }
            return View(resOrderHdr);
        }

        // GET: resOrderHdrs/Create
        public ActionResult Create()
        {
            ViewBag.resCustomerId = new SelectList(db.resCustomers, "Id", "Name");
            return View();
        }

        // POST: resOrderHdrs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,resCustomerId,dtOrder,dtDelivery,Remarks")] resOrderHdr resOrderHdr)
        {
            if (ModelState.IsValid)
            {
                db.resOrderHdrs.Add(resOrderHdr);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.resCustomerId = new SelectList(db.resCustomers, "Id", "Name", resOrderHdr.resCustomerId);
            return View(resOrderHdr);
        }

        // GET: resOrderHdrs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            resOrderHdr resOrderHdr = db.resOrderHdrs.Find(id);
            if (resOrderHdr == null)
            {
                return HttpNotFound();
            }
            ViewBag.resCustomerId = new SelectList(db.resCustomers, "Id", "Name", resOrderHdr.resCustomerId);
            return View(resOrderHdr);
        }

        // POST: resOrderHdrs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,resCustomerId,dtOrder,dtDelivery,Remarks")] resOrderHdr resOrderHdr)
        {
            if (ModelState.IsValid)
            {
                db.Entry(resOrderHdr).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.resCustomerId = new SelectList(db.resCustomers, "Id", "Name", resOrderHdr.resCustomerId);
            return View(resOrderHdr);
        }

        // GET: resOrderHdrs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            resOrderHdr resOrderHdr = db.resOrderHdrs.Find(id);
            if (resOrderHdr == null)
            {
                return HttpNotFound();
            }
            return View(resOrderHdr);
        }

        // POST: resOrderHdrs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            resOrderHdr resOrderHdr = db.resOrderHdrs.Find(id);
            db.resOrderHdrs.Remove(resOrderHdr);
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
