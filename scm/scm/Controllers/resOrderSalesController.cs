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
    public class resOrderSalesController : Controller
    {
        #region header
        private ScmDBContainer db = new ScmDBContainer();

        // GET: resOrderHdrs
        public ActionResult Index()
        {
            var resOrderHdrs = db.resOrderHdrs.Include(r => r.resCustomer);
            return View(resOrderHdrs.ToList());
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
        #endregion

        #region Details
        public ActionResult Details(int? id)
        {
            if (id == null) id = (int)Session["SOHDRID"];
            Session["SOHDRID"] = id;

            return View(db.resOrderDtls.Where(d => d.resOrderHdrId == id).ToList());

        }

        // GET: resOrderDtls/Create
        public ActionResult CreateItem()
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
        public ActionResult CreateItem([Bind(Include = "Id,resOrderHdrId,resMenuId,resItemId,Qty,UnitPrice")] resOrderDtl resOrderDtl)
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
        public ActionResult EditItem(int? id)
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
        public ActionResult EditItem([Bind(Include = "Id,resOrderHdrId,resMenuId,resItemId,Qty,UnitPrice")] resOrderDtl resOrderDtl)
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
        public ActionResult DeleteItem(int? id)
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
        [HttpPost, ActionName("DeleteItem")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteItemConfirmed(int id)
        {
            resOrderDtl resOrderDtl = db.resOrderDtls.Find(id);
            db.resOrderDtls.Remove(resOrderDtl);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        #endregion
    }
}