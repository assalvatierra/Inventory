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
    public class resOrderDtlsController : Controller
    {
        private ScmDBContainer db = new ScmDBContainer();

        // GET: resOrderDtls
        public ActionResult Index()
        {
            var resOrderDtls = db.resOrderDtls.Include(r => r.resOrderHdr).Include(r => r.resMenu).Include(r => r.resItem);
            return View(resOrderDtls.ToList());
        }

        // GET: resOrderDtls/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            resOrderDtl resOrderDtl = db.resOrderDtls.Find(id);
            if (resOrderDtl == null)
            {
                return HttpNotFound();
            }
            return View(resOrderDtl);
        }

        // GET: resOrderDtls/Create
        public ActionResult Create()
        {
            ViewBag.resOrderHdrId = new SelectList(db.resOrderHdrs, "Id", "dtDelivery");
            ViewBag.resMenuId = new SelectList(db.resMenus, "Id", "Name");
            ViewBag.resItemId = new SelectList(db.resItems, "Id", "Description");
            return View();
        }

        // POST: resOrderDtls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,resOrderHdrId,resMenuId,resItemId,Qty,UnitPrice")] resOrderDtl resOrderDtl)
        {
            if (ModelState.IsValid)
            {
                db.resOrderDtls.Add(resOrderDtl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.resOrderHdrId = new SelectList(db.resOrderHdrs, "Id", "dtDelivery", resOrderDtl.resOrderHdrId);
            ViewBag.resMenuId = new SelectList(db.resMenus, "Id", "Name", resOrderDtl.resMenuId);
            ViewBag.resItemId = new SelectList(db.resItems, "Id", "Description", resOrderDtl.resItemId);
            return View(resOrderDtl);
        }

        // GET: resOrderDtls/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            resOrderDtl resOrderDtl = db.resOrderDtls.Find(id);
            if (resOrderDtl == null)
            {
                return HttpNotFound();
            }
            ViewBag.resOrderHdrId = new SelectList(db.resOrderHdrs, "Id", "dtDelivery", resOrderDtl.resOrderHdrId);
            ViewBag.resMenuId = new SelectList(db.resMenus, "Id", "Name", resOrderDtl.resMenuId);
            ViewBag.resItemId = new SelectList(db.resItems, "Id", "Description", resOrderDtl.resItemId);
            return View(resOrderDtl);
        }

        // POST: resOrderDtls/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,resOrderHdrId,resMenuId,resItemId,Qty,UnitPrice")] resOrderDtl resOrderDtl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(resOrderDtl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.resOrderHdrId = new SelectList(db.resOrderHdrs, "Id", "dtDelivery", resOrderDtl.resOrderHdrId);
            ViewBag.resMenuId = new SelectList(db.resMenus, "Id", "Name", resOrderDtl.resMenuId);
            ViewBag.resItemId = new SelectList(db.resItems, "Id", "Description", resOrderDtl.resItemId);
            return View(resOrderDtl);
        }

        // GET: resOrderDtls/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            resOrderDtl resOrderDtl = db.resOrderDtls.Find(id);
            if (resOrderDtl == null)
            {
                return HttpNotFound();
            }
            return View(resOrderDtl);
        }

        // POST: resOrderDtls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            resOrderDtl resOrderDtl = db.resOrderDtls.Find(id);
            db.resOrderDtls.Remove(resOrderDtl);
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
